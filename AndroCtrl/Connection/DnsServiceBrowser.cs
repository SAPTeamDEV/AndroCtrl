using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Tmds.MDns;

namespace AndroCtrl.Connection;

public class DnsServiceBrowser
{
    ServiceBrowser mdns;
    string type;

    public readonly Dictionary<string, DnsEndPoint> Endpoints = new();

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

    void OnServiceAdded(object? sender, ServiceAnnouncementEventArgs e)
    {
        var ep = AddEndpoint(e.Announcement.Addresses[0].ToString(), e.Announcement.Port);
        if (ep != null)
        {
            NetworkFound?.Invoke(ep);
        }
    }

    void OnServiceRemoved(object? sender, ServiceAnnouncementEventArgs e)
    {
        Endpoints.Remove(e.Announcement.Addresses[0].ToString());
    }

    DnsEndPoint AddEndpoint(string host, int port)
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
