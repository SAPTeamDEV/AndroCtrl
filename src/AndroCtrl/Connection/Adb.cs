using System.ComponentModel;
using System.Diagnostics;

using SAPTeam.AndroCtrl.Android;

using SAPTeam.AndroCtrl.Adb;

namespace SAPTeam.AndroCtrl.Connection;

public static class AdbInterface
{
    private static string adbPath;

    public static AdbClient Client { get; }
    public static AdbServer Server { get; }
    public static AdbServerStatus LastServerStatus { get; private set; }

    public static Dictionary<string, AndroidDevice> Devices { get; }
    public static AndroidDevice DefaultDevice { get; set; }

    public static DeviceData DDID => DefaultDevice.DeviceID;

    public static string AdbPath
    {
        get
        {
            return adbPath;
        }
        set
        {
            adbPath = value;

            if (!string.IsNullOrEmpty(adbPath))
            {
                string adbDir = Directory.GetParent(adbPath).FullName;
                if (!Program.Settings.SearchPaths.Contains(adbDir))
                {
                    Program.Settings.SearchPaths.Add(adbDir);
                }
            }
        }
    }

    static AdbInterface()
    {
        Client = new AdbClient();
        Server = new AdbServer(Client, Factories.AdbCommandLineClientFactory);
        Devices = new();
        AdbPath = GetAdbPathFromProccess();

        if (AdbPath == null)
        {
            if (!Directory.Exists("bin"))
            {
                Directory.CreateDirectory("bin");
            }

            if (!File.Exists(Path.Join("bin", "adb.exe")))
            {
                File.WriteAllBytes(Path.Join("bin", "adb.exe"), Resources.adb);
                File.WriteAllBytes(Path.Join("bin", "AdbWinApi.dll"), Resources.AdbWinApi);
                File.WriteAllBytes(Path.Join("bin", "AdbWinUsbApi.dll"), Resources.AdbWinUsbApi);
            }

            foreach (var path in Program.Settings.SearchPaths)
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