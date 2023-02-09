using System.Net;

using Makaretu.Dns;

namespace AndroCtrl.Connection;

public class DnsServiceDiscovery : IMulticastDNS
{
    private MulticastService mdns;
    private ServiceDiscovery sd;
    private string type;

    public Dictionary<string, DnsEndPoint> Endpoints { get; } = new();

    public event Action<DnsEndPoint>? NetworkFound;

    public DnsServiceDiscovery(string type)
    {
        mdns = new();
        sd = new(mdns);

        sd.ServiceDiscovered += OnServiceDiscovery;
        mdns.AnswerReceived += OnAnswerReceive;

        this.type = type;
    }

    public DnsServiceDiscovery() : this(string.Empty) { }

    private void OnServiceDiscovery(object? s, DomainName serviceName)
    {
        if (type == string.Empty || serviceName == type)
        {
            // Ask for the name of instances of the service.
            mdns.SendQuery(serviceName, type: DnsType.ANY);
        }
    }

    private void OnAnswerReceive(object? s, MessageEventArgs e)
    {
        var servers = e.Message.Answers.OfType<SRVRecord>();
        foreach (var server in servers)
        {
            if (type == string.Empty || server.Name.Parent() == type)
            {
                // Console.WriteLine($"host '{server.Target}' for '{server.Name}:{server.Port}'");
                var ep = AddEndpoint(server.Target.ToString(), server.Port);
                if (ep != null)
                {
                    NetworkFound?.Invoke(ep);
                }
            }
        }
    }

    private DnsEndPoint AddEndpoint(string host, int port)
    {
        DnsEndPoint ep = new(host, port);
        if (!Endpoints.ContainsKey(host))
        {
            Endpoints[host] = ep;
            return ep;
        }
        return null;
    }

    public void Scan()
    {
        mdns.Start();
    }

    public void Stop()
    {
        sd.Dispose();
        mdns.Stop();
    }
}
