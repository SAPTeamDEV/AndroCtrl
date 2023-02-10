using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroCtrl.Services.EventArgs
{
    internal class ServiceStatusEventArgs : IServiceEventArgs
    {
        public ServiceStatus Status { get; private set; }

        public ServiceStatusEventArgs(ServiceStatus status)
        {
            Status = status;
        }
    }
}
