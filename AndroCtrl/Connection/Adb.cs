using AndroCtrl.Android;
using AndroCtrl.Protocols.AndroidDebugBridge;

namespace AndroCtrl.Connection;

public static class Adb
{
    public static AdbClient Client { get; }
    public static AdbServer Server { get; }

    public static Dictionary<string, AndroidDevice> Devices { get; }
    public static AndroidDevice DefaultDevice { get; set; }

    public static DeviceData DDID => DefaultDevice.DeviceID;

    public static string ServerPath = @"bin\adb.exe";
    internal static string LocalServer = @"C:\Windows\adb\adb.exe";

    static Adb()
    {
        Client = new AdbClient();

        Server = new AdbServer(Client, Factories.AdbCommandLineClientFactory);

        Devices = new();
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
}