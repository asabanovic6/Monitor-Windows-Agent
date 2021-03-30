using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PingServer;
using ImageSender;
using EventLogger;
using Microsoft.Win32;

namespace Monitor_Windows_Agent
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        
        [STAThread]
        static void Main()
        {
            Logger.Registry_Write(Registry.LocalMachine);
            //pozivamo metodu koja ce svako 0.5 sec da salje kreirani json objekat prema serveru 
           
           // Ping p = new Ping();
           //p.PostJsonAndKeepAplive();
            // imageSender p1 = new imageSender();
            // p1.conn();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
