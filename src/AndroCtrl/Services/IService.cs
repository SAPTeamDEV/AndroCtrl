using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPTeam.AndroCtrl.Services.EventArgs;

namespace SAPTeam.AndroCtrl.Services;

internal interface IService
{
    bool IsPersistent { get; }
    bool IsRunning { get; }
    ServiceStatus Status { get; }

    event EventHandler<IServiceEventArgs> TaskExecuted;
    event EventHandler<IServiceEventArgs> ServiceChanged;
    event EventHandler<IServiceEventArgs> ServiceStarted;
    event EventHandler<IServiceEventArgs> ServiceStopped;

    void Start(bool persistent = false);
    void Stop();
}
