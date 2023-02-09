using System.Net;

using Tmds.MDns;

namespace AndroCtrl.Connection;

public class DnsServiceBrowser : IMulticastDNS
{
    private ServiceBrowser mdns;
    private string type;

    public Dictionary<string, DnsEndPoint> Endpoints { get; } = new();

    public event Action<DnsEndPoint>? NetworkFound;

    public DnsServiceBrowser(string type)
    {
        mdns = new();

        mdns.ServiceAdded += OnServiceAdded;
        mdns.ServiceChanged += OnServiceAdded;
        mdns.ServiceRemoved += OnServiceRemoved;

        this.type = type;
    }

    public DnsServiceBrowser() : this(string.Empty) { }

    private void OnServiceAdded(object? sender, ServiceAnnouncementEventArgs e)
    {
        var ep = AddEndpoint(e.Announcement.Addresses[0].ToString(), e.Announcement.Port);
        if (ep != null)
        {
            NetworkFound?.Invoke(ep);
        }
    }

    private void OnServiceRemoved(object? sender, ServiceAnnouncementEventArgs e)
    {
        Endpoints.Remove(e.Announcement.Addresses[0].ToString());
    }

    private DnsEndPoint AddEndpoint(string host, int port)
    {
        DnsEndPoint ep = new(host, port);
        if (!Endpoints.ContainsKey(host) || !Endpoints.ContainsValue(ep))
        {
            Endpoints[host] = ep;
            return ep;
        }
        return null;
    }

    public void Scan()
    {
        mdns.StartBrowse(type);
    }

    public void Stop()
    {
        mdns.StopBrowse();
    }
}
