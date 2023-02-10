using AndroCtrl.Android;
using AndroCtrl.Protocols.AndroidDebugBridge;

namespace AndroCtrl.Connection;

public static class Adb
{
    public static AdbClient Client { get; }
    public static AdbServer Server { get; }

    public static Dictionary<DeviceData, Device> Devices { get; }
    public static Device DefaultDevice { get; set; }

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
                Devices[device] = Device.CreateNewDevice(device);
            }
        }
    }
}