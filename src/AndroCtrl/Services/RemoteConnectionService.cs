using System.Net;

using SAPTeam.AndroCtrl.Connection;
using SAPTeam.AndroCtrl.Services.EventArgs;

namespace SAPTeam.AndroCtrl.Services;

public class RemoteConnectionService : Service, IService
{
    private DnsServiceBrowser mdns;

    public RemoteConnectionService() : base()
    {
        mdns = new(DnsServiceTypes.AdbConnect);
        mdns.NetworkFound += (ep) =>
        {
            AdbInterface.Client.Connect(ep);
            OnExecute(ServiceEventArgs.Empty);
        };
    }

    protected override void Run(object? sender, IServiceEventArgs e)
    {
        mdns.Scan();
        Status = ServiceStatus.Running;
    }

    protected override void Finish(object? sender, IServiceEventArgs e) => mdns.Stop();
}
