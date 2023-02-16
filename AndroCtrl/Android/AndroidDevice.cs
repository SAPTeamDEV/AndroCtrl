﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using AndroCtrl.Connection;
using AndroCtrl.Protocols.AndroidDebugBridge;
using AndroCtrl.Protocols.AndroidDebugBridge.DeviceCommands;
using AndroCtrl.Protocols.AndroidDebugBridge.Exceptions;

namespace AndroCtrl.Android;

public class AndroidDevice
{
    public DeviceData DeviceID { get; private set; }

    public string DeviceName { get; private set; }
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public string API { get; private set; }
    public string Fingerprint { get; private set; }
    public DnsEndPoint EndPoint { get; private set; }
    public ConnectionTypes ConnectionType { get; private set; }

    public bool IsUsbDevice => ConnectionType == ConnectionTypes.Usb;
    public bool IsWifiDevice => ConnectionType == ConnectionTypes.Wifi;

    public AndroidDevice(DeviceData deviceData)
    {
        DeviceID = deviceData;

        DeviceName = string.Empty;
        Model = string.Empty;
        Manufacturer = string.Empty;
        API = string.Empty;
        Fingerprint = string.Empty;
    }

    public static AndroidDevice CreateNewDevice(DeviceData device)
    {
        AndroidDevice dev = new(device);
        if (SerializeDeviceAddress(device.Serial) is DnsEndPoint ep)
        {
            dev.EndPoint = ep;
            dev.ConnectionType = ConnectionTypes.Wifi;
        }

        if (device.State == DeviceState.Offline)
        {
            return dev;
        }

        var props = Adb.Client.GetProperties(device);

        props.TryGetValue("ro.product.device", out string dName);
        props.TryGetValue("ro.product.model", out string model);
        props.TryGetValue("ro.product.manufacturer", out string manufacturer);
        props.TryGetValue("ro.build.version.sdk", out string api);
        props.TryGetValue("ro.build.fingerprint", out string fingerprint);

        dev.DeviceName = dName;
        dev.Model = model;
        dev.Manufacturer = manufacturer;
        dev.API = api;
        dev.Fingerprint = fingerprint;

        return dev;
    }

    public static DnsEndPoint SerializeDeviceAddress(string serial)
    {
        string[] rawEndpoint = serial.Split(":");
        if (rawEndpoint.Length == 2 && IPAddress.TryParse(rawEndpoint[0], out IPAddress? ip) && int.TryParse(rawEndpoint[1], out int port))
        {
            return new(ip.ToString(), port);
        }
        return null;
    }

    public static string TrimSerial(string serial)
    {
        string[] rawEndpoint = serial.Split(":");
        if (rawEndpoint.Length == 2 && IPAddress.TryParse(rawEndpoint[0], out IPAddress? ip) && int.TryParse(rawEndpoint[1], out int port))
        {
            return ip.ToString();
        }
        return serial;
    }

    public override string ToString()
    {
        return DeviceID.State == DeviceState.Online ? string.Format("{0} | {1}", DeviceName, Model) : string.Format("{0} | {1} [{2}]", DeviceID.Name, DeviceID.Serial, DeviceID.State);
    }

    public void Disconnect()
    {
        if (IsWifiDevice)
        {
            Adb.Client.Disconnect(EndPoint);
        }
        else
        {
            throw new EntryPointNotFoundException();
        }
    }

    public void SetDevice(DeviceData device)
    {
        DeviceID = device;
        if (SerializeDeviceAddress(device.Serial) is DnsEndPoint ep)
        {
            EndPoint = ep;
        }
    }
}