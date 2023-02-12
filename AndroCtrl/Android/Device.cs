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

        DeviceName = string.Empty;
        Model = string.Empty;
        Manufacturer = string.Empty;
        API = string.Empty;
        Fingerprint = string.Empty;
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

        string dName = string.Empty;
        string model = string.Empty;
        string manufacturer = string.Empty;
        string api = string.Empty;
        string fingerprint = string.Empty;

        props.TryGetValue("ro.product.device", out dName);
        props.TryGetValue("ro.product.model", out model);
        props.TryGetValue("ro.product.manufacturer", out manufacturer);
        props.TryGetValue("ro.build.version.sdk", out api);
        props.TryGetValue("ro.build.fingerprint", out fingerprint);

        dev.DeviceName = dName;

        return dev;
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
}
