using System.Net;

using AndroCtrl.Connection;
using AndroCtrl.Services.EventArgs;

namespace AndroCtrl.Services;

public class RemoteConnectionService : Service, IService
{
    private DnsServiceBrowser mdns;

    public RemoteConnectionService() : base()
    {
        mdns = new(DnsServiceTypes.AdbConnect);
        mdns.NetworkFound += (ep) => Adb.Client.Connect(ep);
    }

    protected override void Run(object? sender, IServiceEventArgs e)
    {
        mdns.Scan();
        Status = ServiceStatus.Running;
    }

    protected override void Finish(object? sender, IServiceEventArgs e) => mdns.Stop();
}
