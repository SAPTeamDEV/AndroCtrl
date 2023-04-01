using System.ComponentModel;
using System.Diagnostics;

using AndroCtrl.Android;
using SAPTeam.AndroCtrl.Adb;

namespace AndroCtrl.Connection;

public static class Adb
{
    public static AdbClient Client { get; }
    public static AdbServer Server { get; }
    public static AdbServerStatus LastServerStatus { get; private set; }

    public static Dictionary<string, AndroidDevice> Devices { get; }
    public static AndroidDevice DefaultDevice { get; set; }

    public static DeviceData DDID => DefaultDevice.DeviceID;

    public static string AdbPath { get; }

    static Adb()
    {
        Client = new AdbClient();
        Server = new AdbServer(Client, Factories.AdbCommandLineClientFactory);
        Devices = new();

        foreach (var path in Program.SearchPaths)
        {
            string adbpath = Path.Join(path, "adb.exe");

            if (File.Exists(adbpath))
            {
                AdbCommandLineClient cmd = new(adbpath);
                if (cmd.GetVersion() >= AdbServer.RequiredAdbVersion)
                {
                    AdbPath = adbpath;
                    break;
                }
            }
        }

        if (AdbPath == null)
        {
            AdbPath = GetAdbPathFromProccess();
        }
    }

    public static void UpdateDevices()
    {
        var newDevices = Client.GetDevices();

        foreach (var device in newDevices)
        {
            string serial = AndroidDevice.TrimSerial(device.Serial);

            if (Devices.ContainsKey(serial))
            {
                if (Devices[serial].DeviceID.State != device.State)
                {
                    Devices[serial].SetDevice(device);
                }
            }
            else
            {
                var devObj = AndroidDevice.CreateNewDevice(device);
                Devices[serial] = devObj;
            }
        }

        foreach (var device in Devices)
        {
            if (!newDevices.Contains(device.Value.DeviceID))
            {
                Devices.Remove(device.Key);
            }
        }

        if (Devices.Count > 0 && (DefaultDevice == null || !Devices.ContainsValue(DefaultDevice)))
        {
            DefaultDevice = Devices.First().Value;
        }
        else if (Devices.Count == 0)
        {
            DefaultDevice = null;
        }
    }

    public static AdbServerStatus UpdateServerStatus()
    {
        LastServerStatus = Server.GetStatus(false);
        return LastServerStatus;
    }

    public static string GetAdbPathFromProccess()
    {
        foreach (Process adbProcess in Process.GetProcessesByName("adb"))
        {
            try
            {
                return adbProcess.MainModule.FileName;
            }
            catch (Exception)
            {
                
            }
        }

        return null;
    }
}