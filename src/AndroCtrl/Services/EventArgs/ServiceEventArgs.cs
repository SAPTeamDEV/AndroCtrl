using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroCtrl.Services.EventArgs
{
    public class ServiceEventArgs : IServiceEventArgs
    {
        public static ServiceEventArgs Empty { get; } = new();
    }
}
