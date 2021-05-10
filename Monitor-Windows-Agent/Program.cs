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


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
        
            if (!File.Exists((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json"))
            {
                
                Application.Run(new Form1());
            }
            else { 
                
                Application.Run(new Form2());
            }
           
        }
    }
}
