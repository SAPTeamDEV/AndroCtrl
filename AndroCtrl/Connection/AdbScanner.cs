using System.Net;

namespace AndroCtrl.Connection;

internal partial class Adb
{
    private DnsServiceBrowser mdns;

    internal void ScanDevices()
    {
        mdns = new(DnsServiceTypes.AdbConnect);
        mdns.NetworkFound += Listen;
        mdns.Scan();
    }
    internal void Listen(DnsEndPoint ep)
    {
        Client.Connect(ep);
        mdns.Stop();
    }
}
