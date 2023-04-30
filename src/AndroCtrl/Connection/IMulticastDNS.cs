using System.Net;

namespace SAPTeam.AndroCtrl.Connection;

public interface IMulticastDNS
{
    Dictionary<string, DnsEndPoint> Endpoints { get; }

    event Action<DnsEndPoint>? NetworkFound;

    void Scan();
    void Stop();
}