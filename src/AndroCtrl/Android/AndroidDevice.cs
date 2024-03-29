﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SAPTeam.AndroCtrl.Adb;
using SAPTeam.AndroCtrl.Adb.DeviceCommands;
using SAPTeam.AndroCtrl.Adb.Exceptions;
using SAPTeam.AndroCtrl.Adb.Receivers;
using SAPTeam.AndroCtrl.Services;
using SAPTeam.AndroCtrl.Connection;

namespace SAPTeam.AndroCtrl.Android;

public partial class AndroidDevice
{
    ShellSocket _shell;

    public DeviceData DeviceID { get; private set; }
    public DeviceState Status => DeviceID.State;

    public string DeviceName { get; private set; }
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public string API { get; private set; }
    public string Fingerprint { get; private set; }

    private ShellSocket Shell
    {
        get
        {
            if (!HasShell && IsUsable)
            {
                _shell = AdbInterface.Client.StartShell(DeviceID);
                return _shell;
            }
            else
            {
                return _shell;
            }
        }
    }
    public bool IsRoot => HasShell && Shell.Access == ShellAccess.Root;

    public DnsEndPoint EndPoint { get; private set; }
    public ConnectionTypes ConnectionType { get; private set; }

    public bool IsUsbDevice => ConnectionType == ConnectionTypes.Usb;
    public bool IsWifiDevice => ConnectionType == ConnectionTypes.Wifi;

    public bool IsUsable => IsDeviceUsable(Status);

    public bool HasInfo { get; private set; }
    public bool HasShell => _shell != null && _shell.Connected;

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
        string text = string.Format("{0} | {1}", HasInfo ? DeviceName : DeviceID.Name, HasInfo ? Model : DeviceID.Serial);

        if (DeviceID.State != DeviceState.Online)
        {
            text += $" [{DeviceID.State}]";
        }
        else if (IsRoot)
        {
            text += $" [ROOT]";
        }

        return text;
    }

    public string Run(string command, IShellOutputReceiver receiver = null)
    {
        if (IsUsable)
        {
            IShellOutputReceiver checker = new ConsoleOutputReceiver();
            return Shell.Interact(command, receiver != null ? new IShellOutputReceiver[] { checker, receiver} : new IShellOutputReceiver[] { checker});
        }
        else
        {
            throw new AdbException("Device is not responsible.");
        }
    }

    public bool SuperUser()
    {
        if (!IsRoot)
        {
            Run("su");
            return IsRoot;
        }
        else
        {
            throw new InvalidOperationException("Device's shell already has root access.");
        }
    }

    public void Disconnect()
    {
        if (IsWifiDevice)
        {
            if (HasShell)
            {
                Shell.Dispose();
            }
            AdbInterface.Client.Disconnect(EndPoint);
        }
        else
        {
            throw new EntryPointNotFoundException();
        }
    }

    public void SetDevice(DeviceData device)
    {
        // Dispose outdated shell.
        if (HasShell)
        {
            Shell.Dispose();
        }

        if (device.State == DeviceState.Offline && SerializeDeviceAddress(device.Serial) is DnsEndPoint ep && ep.Port != EndPoint.Port)
        {
            Disconnect();
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
        }
    }
}
