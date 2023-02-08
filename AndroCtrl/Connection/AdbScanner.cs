using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AndroCtrl.Connection
{
    internal partial class Adb
    {
        const string TYPE = "_adb-tls-connect._tcp";

        DnsServiceBrowser mdns;

        internal void ScanDevices()
        {
            mdns = new(TYPE);
            mdns.NetworkFound += Listen;
            mdns.Scan();
        }
        internal void Listen(DnsEndPoint ep)
        {
            Client.Connect(ep);
            mdns.Stop();
        }
    }
}
