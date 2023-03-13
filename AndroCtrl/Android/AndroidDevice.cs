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

public partial class AndroidDevice
{
    public DeviceData DeviceID { get; private set; }
    public DeviceState Status => DeviceID.State;

    public string DeviceName { get; private set; }
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public string API { get; private set; }
    public string Fingerprint { get; private set; }

    public ShellSocket Shell { get; private set; }
    public bool IsRoot => Shell.Access == ShellAccess.Root;

    public DnsEndPoint EndPoint { get; private set; }
    public ConnectionTypes ConnectionType { get; private set; }

    public bool IsUsbDevice => ConnectionType == ConnectionTypes.Usb;
    public bool IsWifiDevice => ConnectionType == ConnectionTypes.Wifi;

    public bool IsUsable => IsDeviceUsable(Status);

    public bool HasInfo { get; private set; }
    public bool HasShell => Shell != null;

    public AndroidDevice(DeviceData deviceData)
    {
        DeviceID = deviceData;

        DeviceName = string.Empty;
        Model = string.Empty;
        Manufacturer = string.Empty;
        API = string.Empty;
        Fingerprint = string.Empty;
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

        if (IsDeviceUsable(device.State))
        {
            if (!HasInfo)
            {
                GatherDeviceInfo(device, this);
            }

            if (!HasShell)
            {
                Shell = Adb.Client.StartShell(device);
            }
        }
    }
}
