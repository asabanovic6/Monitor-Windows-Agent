using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using PingServer;
using ImageSender;
namespace MWA_Service
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
               new Service1()
            };
            ServiceBase.Run(ServicesToRun);

            //pozivamo metodu koja ce svako 0.5 sec da salje kreirani json objekat prema serveru 
            Ping p = new Ping();
            p.PostJsonAndKeepAplive();

            imageSender img = new imageSender();
            img.conn();
          
        }
    }
}
