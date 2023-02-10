using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AndroCtrl.Services.EventArgs;

namespace AndroCtrl.Services;

public abstract class Service : IService
{
    protected IServiceEventArgs runEventArgs;
    private ServiceStatus status;

    public bool IsPersistent { get; private set; }
    public bool IsRunning => Status == ServiceStatus.Running;
    public ServiceStatus Status
    {
        get => status;
        protected set
        {
            status = value;
            ServiceChanged?.Invoke(null, new ServiceStatusEventArgs(status));
        }
    }

    public event EventHandler<IServiceEventArgs> TaskExecuted;
    public event EventHandler<IServiceEventArgs> ServiceChanged;
    public event EventHandler<IServiceEventArgs> ServiceStarted;
    public event EventHandler<IServiceEventArgs> ServiceStopped;

    public Service()
    {
        ServiceStarted += Run;
        ServiceStopped += Finish;
    }

    public virtual void Start(bool persistent = false)
    {
        if (Status != ServiceStatus.Running)
        {
            if (!persistent)
            {
                TaskExecuted += (sender, e) =>
                {
                    Stop();
                };
            }

            ServiceStarted?.Invoke(null, runEventArgs ?? ServiceEventArgs.Empty);
        }
    }

    protected abstract void Run(object? sender, IServiceEventArgs e);

    public virtual void Stop()
    {
        ServiceStopped?.Invoke(null, ServiceEventArgs.Empty);
        Status = ServiceStatus.Stopped;
    }

    protected abstract void Finish(object? sender, IServiceEventArgs e);

    protected void OnExecute(IServiceEventArgs e) => TaskExecuted?.Invoke(null, e);
}
