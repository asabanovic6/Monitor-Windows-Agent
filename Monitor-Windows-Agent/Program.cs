using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using JASONParser;
using PingServer;

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
            //pozivamo metodu koja ce svako 0.5 sec da salje kreirani json objekat prema serveru 
           
            Ping p = new Ping();
            p.PostJsonAndKeepAplive();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
