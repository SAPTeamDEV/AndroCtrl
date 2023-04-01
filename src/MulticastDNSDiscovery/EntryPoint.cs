using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDNSDiscovery
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "browser")
            {
                MDnsServiceBrowser.Main(new string[1] { args[1] });
            }
            else
            {
                MDnsDiscovery.Main(Array.Empty<string>());
            }
        }
    }
}
