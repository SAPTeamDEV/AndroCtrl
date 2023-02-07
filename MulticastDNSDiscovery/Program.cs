using System;

using Makaretu.Dns;

var mdns = new MulticastService();
var sd = new ServiceDiscovery(mdns);

/*mdns.NetworkInterfaceDiscovered += (s, e) =>
{
    foreach (var nic in e.NetworkInterfaces)
    {
        Console.WriteLine($"NIC '{nic.Name}'");
    }

    // Ask for the name of all services.
    sd.QueryAllServices();
};
*/

sd.ServiceDiscovered += (s, serviceName) =>
{
    if (serviceName == "_adb-tls-connect._tcp.local")
    {
        Console.WriteLine($"service '{serviceName}'");

        // Ask for the name of instances of the service.
        mdns.SendQuery(serviceName, type: DnsType.ANY);
    }
};

/*
sd.ServiceInstanceDiscovered += (s, e) =>
{
    if(e.ServiceInstanceName.Parent() == "_adb-tls-connect._tcp.local")
    {
        Console.WriteLine($"service instance '{e.ServiceInstanceName}' at {e.RemoteEndPoint.Address}:{e.RemoteEndPoint.Port}");

        // Ask for the service instance details.
        mdns.SendQuery(e.ServiceInstanceName, type: DnsType.SRV);
    }
};
*/

mdns.AnswerReceived += (s, e) =>
{
    var servers = e.Message.Answers.OfType<SRVRecord>();
    foreach (var server in servers)
    {
        if (server.Name.Parent() == "_adb-tls-connect._tcp.local")
        {
            Console.WriteLine($"host '{server.Target}' for '{server.Name}:{server.Port}'");
        }
    }
};

try
{
    mdns.Start();
    Console.ReadKey();
}
finally
{
    sd.Dispose();
    mdns.Stop();
}