using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using AndroCtrl.Connection;
using AndroCtrl.Protocols.AndroidDebugBridge;
using AndroCtrl.Protocols.AndroidDebugBridge.DeviceCommands;
using AndroCtrl.Protocols.AndroidDebugBridge.Exceptions;
using AndroCtrl.Services;

namespace AndroCtrl.Android;

public class AndroidDevice
{
    public DeviceData DeviceID { get; private set; }
    public DeviceState Status => DeviceID.State;

    public string DeviceName { get; private set; }
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public string API { get; private set; }
    public string Fingerprint { get; private set; }
    public DnsEndPoint EndPoint { get; private set; }
    public ConnectionTypes ConnectionType { get; private set; }

    public bool IsUsbDevice => ConnectionType == ConnectionTypes.Usb;
    public bool IsWifiDevice => ConnectionType == ConnectionTypes.Wifi;

    public bool IsUsable => IsDeviceUsable(Status);

    public bool HasInfo { get; private set; }

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

        if (!IsDeviceUsable(device.State))
        {
            return dev;
        }

        GatherDeviceInfo(device, dev);

        return dev;
    }

    public static bool IsDeviceUsable(DeviceState state)
    {
        if (state
            is DeviceState.Offline
            or DeviceState.NoPermissions
            or DeviceState.Unauthorized
            or DeviceState.Authorizing
            or DeviceState.Unknown)
        {
            return false;
        }
        return true;
    }

    public static void GatherDeviceInfo(DeviceData device, AndroidDevice dev)
    {
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

        dev.HasInfo = dName != string.Empty && model != string.Empty;
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
        if (DeviceID.State == DeviceState.Online)
        {
            return string.Format("{0} | {1}", DeviceName, Model);
        }
        else
        {
            return string.Format("{0} | {1} [{2}]", HasInfo ? DeviceName : DeviceID.Name, HasInfo ? Model : DeviceID.Serial, DeviceID.State);
        }
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
        if (device.State == DeviceState.Offline && SerializeDeviceAddress(device.Serial) is DnsEndPoint ep && ep.Port != EndPoint.Port)
        {
            Adb.Client.Disconnect(ep);
            return;
        }

        DeviceID = device;
        if (SerializeDeviceAddress(device.Serial) is DnsEndPoint endPoint)
        {
            EndPoint = endPoint;
        }

        if (!HasInfo && IsDeviceUsable(device.State))
        {
            GatherDeviceInfo(device, this);
        }
    }
}
