using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Tmds.MDns;

namespace MulticastDNSDiscovery;

class MDnsServiceBrowser
{
    public static void Main(string[] args)
    {
        string serviceType = "_workstation._tcp";
        if (args.Length >= 1)
        {
            serviceType = args[0];
        }

        ServiceBrowser serviceBrowser = new ServiceBrowser();
        serviceBrowser.ServiceAdded += OnServiceAdded;
        serviceBrowser.ServiceRemoved += OnServiceRemoved;
        serviceBrowser.ServiceChanged += OnServiceChanged;

        Console.WriteLine("Browsing for type: {0}", serviceType);
        serviceBrowser.StartBrowse(serviceType);
        Console.ReadLine();
    }

    static void OnServiceChanged(object? sender, ServiceAnnouncementEventArgs e)
    {
        PrintService('~', e.Announcement);
    }

    static void OnServiceRemoved(object? sender, ServiceAnnouncementEventArgs e)
    {
        PrintService('-', e.Announcement);
    }

    static void OnServiceAdded(object? sender, ServiceAnnouncementEventArgs e)
    {
        PrintService('+', e.Announcement);
    }

    static void PrintService(char startChar, ServiceAnnouncement service)
    {
        Console.WriteLine("{0} '{1}' on {2}", startChar, service.Instance, service.NetworkInterface.Name);
        Console.WriteLine("\tHost: {0} ({1})", service.Hostname, string.Join(", ", service.Addresses));
        Console.WriteLine("\tPort: {0}", service.Port);
        Console.WriteLine("\tTxt : [{0}]", string.Join(", ", service.Txt));
    }
}