using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using AndroCtrl.Protocols.AndroidDebugBridge;

namespace AndroCtrl.Connection;

internal class Adb
{
    internal static AdbClient Client { get; private set; }
    internal static AdbServer Server { get; private set; }

    static string serverPath = @"bin\adb.exe";
    static string localServer = @"C:\Windows\adb\adb.exe";

    internal static List<DeviceData> Devices { get; private set; } = new List<DeviceData>();
    internal static List<DeviceData> LiveDevices => Client.GetDevices();

    static Adb()
    {
        Client = new AdbClient();
        Server = new AdbServer(Client, Factories.AdbCommandLineClientFactory);
        Server.StartServer(localServer, true);
    }
}