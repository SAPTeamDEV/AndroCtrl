using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAPTeam.AndroCtrl.Services.EventArgs
{
    public class ReconnectServiceEventArgs : IServiceEventArgs
    {
        public DnsEndPoint EndPoint { get; }
        public int Delay { get; }

        public ReconnectServiceEventArgs(DnsEndPoint ep, int delay)
        {
            EndPoint = ep;
            Delay = delay;
        }
    }
}
