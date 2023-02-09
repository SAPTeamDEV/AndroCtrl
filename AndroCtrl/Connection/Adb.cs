using AndroCtrl.Protocols.AndroidDebugBridge;

namespace AndroCtrl.Connection;

internal partial class Adb
{
    internal static AdbClient Client { get; }
    internal static AdbServer Server { get; }

    private static string serverPath = @"bin\adb.exe";
    private static string localServer = @"C:\Windows\adb\adb.exe";

    static Adb()
    {
        Client = new AdbClient();
        Server = new AdbServer(Client, Factories.AdbCommandLineClientFactory);
        Server.StartServer(localServer, true);
    }
}