using System;
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

public class Device
{
    public DeviceData DeviceID { get; }

    public string DeviceName { get; private set; }
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public string API { get; private set; }
    public string Fingerprint { get; private set; }
    public DnsEndPoint EndPoint { get; private set; }
    public ConnectionTypes ConnectionType { get; private set; }

    public bool IsUsbDevice => ConnectionType == ConnectionTypes.Usb;
    public bool IsWifiDevice => ConnectionType == ConnectionTypes.Wifi;

    public Device(DeviceData deviceData)
    {
        DeviceID = deviceData;
    }

    public static Device CreateNewDevice(DeviceData device)
    {
        Device dev = new(device);

        string[] rawEndpoint = device.Serial.Split(":");
        IPAddress? ip;
        int port;
        if (rawEndpoint.Length == 2 && IPAddress.TryParse(rawEndpoint[0], out ip) && int.TryParse(rawEndpoint[1], out port))
        {
            dev.EndPoint = new(ip.ToString(), port);
            dev.ConnectionType = ConnectionTypes.Wifi;
        }

        if (device.State == DeviceState.Offline)
        {
            return dev;
        }

        var props = Adb.Client.GetProperties(device);

        dev.Model = props["ro.product.model"];
        dev.DeviceName = props["ro.product.device"];
        dev.Manufacturer = props["ro.product.manufacturer"];
        dev.API = props["ro.build.version.sdk"];
        dev.Fingerprint = props["ro.build.fingerprint"];

        return dev;
    }

    public override string ToString()
    {
        return string.Format("{0} | {1}", DeviceName, Model);
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
}
