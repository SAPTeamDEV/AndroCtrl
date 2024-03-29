﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using SAPTeam.AndroCtrl.Connection;
using SAPTeam.AndroCtrl.Services.EventArgs;

namespace SAPTeam.AndroCtrl.Services
{
    public class ReconnectionService : Service, IService
    {
        public ReconnectionService(DnsEndPoint ep, int delay)
        {
            runEventArgs = new ReconnectServiceEventArgs(ep, delay);
        }

        protected override void Finish(object? sender, IServiceEventArgs e) { }

        protected override async void Run(object? sender, IServiceEventArgs e)
        {
            Status = ServiceStatus.Running;
            ReconnectServiceEventArgs args = (ReconnectServiceEventArgs)e;
            DnsEndPoint ep = args.EndPoint;
            int delay = args.Delay;

            while (Status == ServiceStatus.Running)
            {
                await Task.Delay(delay);
                try
                {
                    AdbInterface.Client.Connect(ep);
                    OnExecute(ServiceEventArgs.Empty);
                }
                catch (Exception) { }
            }
        }
    }
}
