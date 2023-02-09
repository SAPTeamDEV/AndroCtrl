using System.Net;

namespace AndroCtrl.Connection;

public interface IMulticastDNS
{
    Dictionary<string, DnsEndPoint> Endpoints { get; }

    event Action<DnsEndPoint>? NetworkFound;

    void Scan();
    void Stop();
}