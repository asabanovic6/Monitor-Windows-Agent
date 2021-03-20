using System;
using Topshelf;

namespace MonitorWindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<ActionTrigger>(service =>
                {
                    service.ConstructUsing(actionTrigger => new ActionTrigger());
                    service.WhenStarted(actionTrigger => actionTrigger.Start());
                    service.WhenStopped(actionTrigger => actionTrigger.Stop());

                });

                x.RunAsLocalSystem();

                x.SetServiceName("MonitorWindowsService");
                x.SetDisplayName("Monitor Windows Service");
                x.SetDescription("Ovdje ide deskripcija!");
            });

            int exitCodeValue = (int) Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
