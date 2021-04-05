using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.Management;

namespace MonitorWindowsAgentService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
        }
        protected override void OnCommitted(System.Collections.IDictionary savedState)
        {
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController("MonitorWindowsAgentService");
            sc.Start();
        }
       
    }

}
