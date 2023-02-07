using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Makaretu.Dns;

namespace AndroCtrl.Connection
{
    internal class MulticastDNS
    {
        public MulticastDNS()
        {
            MulticastService mdns = new();
            ServiceDiscovery sd = new(mdns);


        }
    }
}
