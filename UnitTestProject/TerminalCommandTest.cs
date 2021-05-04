using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;


namespace UnitTestProject
{
    [TestClass]
   public class TerminalCommandTest
    {
        [TestMethod]
        public void HDDUsageTest()
        {
            double usage = TerminalCommand.getHDDUsage();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }

       
        [TestMethod]
        public void RAMUsageTest()
        {
            double usage = TerminalCommand.getRAMUsege();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }
        
        [TestMethod]
        public void CPUUsageTest()
        {
            double usage = TerminalCommand.getCPUUsage();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }

        [TestMethod]
        public void GPUUsageTest()
        {
            double usage = TerminalCommand.getGPUUsage();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }

        [TestMethod]
        public void SystemInfoTest1()
        {
            
            Assert.AreNotEqual("Nesto", TerminalCommand.SystemInfo("SystemInfo", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));
        }

       [TestMethod]
        public void SystemInfoTest2()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string command = "SystemInfo";
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Verb = "runas";
            process.StartInfo.WorkingDirectory = path;

            RegistryKey myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            myKey.SetValue("Monitor-Windows-Agent", @"C:\Program Files (x86)\si_group1\MWA\Monitor-Windows-Agent.exe");

            List<string> args = command.Split(' ').ToList();
            process.StartInfo.Arguments = command;
            process.Start();
            string message = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Assert.AreNotEqual(message, TerminalCommand.SystemInfo("SystemInfo1", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));
        }
    }
}
