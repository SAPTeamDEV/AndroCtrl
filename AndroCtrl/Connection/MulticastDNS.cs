using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Makaretu.Dns;

namespace AndroCtrl.Connection
{
    public class MulticastDNS
    {
        MulticastService mdns;
        ServiceDiscovery sd;
        string type;

        public readonly List<DnsEndPoint> Endpoints = new();

        public event Action<DnsEndPoint>? NetworkFound;

        public MulticastDNS(string type)
        {
            mdns = new();
            sd = new(mdns);

            sd.ServiceDiscovered += OnServiceDiscovery;
            mdns.AnswerReceived += OnAnswerReceive;

            this.type = type;
         }

        public MulticastDNS() : this(string.Empty) { }

        void OnServiceDiscovery(object? s, DomainName serviceName)
        {
            if (type == string.Empty || serviceName == type)
            {
                // Ask for the name of instances of the service.
                mdns.SendQuery(serviceName, type: DnsType.ANY);
            }
        }

        void OnAnswerReceive(object? s, MessageEventArgs e)
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

        DnsEndPoint AddEndpoint(string host, int port)
        {
            DnsEndPoint ep = new(host, port);
            if (!Endpoints.Contains(ep))
            {
                Endpoints.Add(ep);
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
}
