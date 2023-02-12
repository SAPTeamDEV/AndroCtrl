using AndroCtrl.Android;
using AndroCtrl.Protocols.AndroidDebugBridge;

namespace AndroCtrl.Connection;

public static class Adb
{
    public static AdbClient Client { get; }
    public static AdbServer Server { get; }

    public static Dictionary<DeviceData, Device> Devices { get; }
    public static Device DefaultDevice { get; set; }

    public static DeviceData DDID => DefaultDevice.DeviceID;

    private static string serverPath = @"bin\adb.exe";
    private static string localServer = @"C:\Windows\adb\adb.exe";

    static Adb()
    {
        Client = new AdbClient();

        Server = new AdbServer(Client, Factories.AdbCommandLineClientFactory);
        Server.StartServer(localServer, true);

        Devices = new();
    }

    public static void UpdateDevices()
    {
        var devices = Client.GetDevices();

        foreach (var device in devices)
        {
            if (!Devices.ContainsKey(device))
            {
                var devObj = Device.CreateNewDevice(device);
                if (devObj.DeviceID.State == DeviceState.Offline && devObj.IsWifiDevice)
                {
                    try
                    {
                        devObj.Disconnect();
                    }
                    catch (Exception) { }
                }
                else
                {
                    Devices[device] = devObj;
                }
            }
        }

        var devCopy = new Dictionary<DeviceData, Device>(Devices);
        foreach (var device in devCopy)
        {
            if (!devices.Contains(device.Key))
            {
                Devices.Remove(device.Key);
            }
        }

        if (Devices.Count > 0 && (DefaultDevice == null || !Devices.ContainsValue(DefaultDevice)))
        {
            DefaultDevice = Devices.First().Value;
        }
    }
}