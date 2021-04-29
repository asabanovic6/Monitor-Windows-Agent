using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Terminal
{
    public class TerminalCommand
    {

        public static string RunCommand(string command, string path)
        {
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

            if (args[0] == "shutdown" && args[1] == "-r")
            {

                var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

                var key = root.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", true);

                var username = args[2];
                var password = args[3];

                try
                {
                    key.SetValue("DefaultUserName", username, RegistryValueKind.String);
                    key.SetValue("DefaultPassword", password, RegistryValueKind.String);
                    key.SetValue("AutoAdminLogon", "1", RegistryValueKind.String);

                    process.StartInfo.Arguments = args[0] + " " + args[1];
                    process.Start();
                    process.WaitForExit();

                    System.Diagnostics.Debug.WriteLine("Successfully saved!");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error during save");
                }

            }
            else
            {
                process.StartInfo.Arguments = command;
                process.Start();
                string message = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return ("{ \"type\":\"" + "command_result" + "\", \"message\":\"" + message + "\", \"path\":\"" + GetNewPath(command, message, path) + "\", \"deviceUid\":\"");
                // string str = "{'message': '" + message + "', 'path': '" + GetNewPath(command, message, path) + "', 'type': '" + "command_result"+ "'}";
                // return JsonConvert.SerializeObject(str); 
            }

            return "Nesto";
        }

        private static string GetNewPath(string command, string message, string path)
        {
            if (command.Trim().Split(' ')[0].ToLower().Equals("cd") && message.Equals(string.Empty))
            {
                if (command.Trim().Split(' ')[1].Contains(":")) return command.Trim().Split(' ')[1];
                if (command.Trim().Split(' ')[1].Equals("..")) return path.Remove(path.LastIndexOf('\\'));
                return path + "\\" + command.Trim().Split(' ')[1];
            }
            return path;
        }
        public static  double getRAMUsege()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            double availableMemory = ramCounter.NextValue();

            Process[] proc = Process.GetProcesses();
            long used = 0;
            for (int i = 0; i < proc.Length; i++)
            {
                used += proc[i].PrivateMemorySize64;
            }

            double usedMemory = Convert.ToDouble(used) / 1024d / 1024d;
            double percentage = usedMemory / (availableMemory + usedMemory);

            return Math.Round(percentage, 2);
        }
        public static double getCPUUsage()
        {
            PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total"); ;
            cpuUsage.NextValue();
            Thread.Sleep(1000);
            return cpuUsage.NextValue() / 100;
        }

        public static double getHDDUsage()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            double usage = 0.0;
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name.Equals("C:\\"))
                {
                    if (d.IsReady == true)
                    {
                        usage = (d.TotalSize - d.TotalFreeSpace) / (float)d.TotalSize;
                    }
                }
            }

            return Math.Round(usage, 2);
        }

       

        public static double getGPUUsage()
        {
            try
            {
                var category = new PerformanceCounterCategory("GPU Engine");
                var counterNames = category.GetInstanceNames();
                var gpuCounters = new List<PerformanceCounter>();
                var result = 0f;

                foreach (string counterName in counterNames)
                {
                    if (counterName.EndsWith("engtype_3D"))
                    {
                        foreach (PerformanceCounter counter in category.GetCounters(counterName))
                        {
                            if (counter.CounterName == "Utilization Percentage")
                            {
                                gpuCounters.Add(counter);
                            }
                        }
                    }
                }

                gpuCounters.ForEach(x =>
                {
                    _ = x.NextValue();
                });

                gpuCounters.ForEach(x =>
                {
                    result += x.NextValue();
                });

                return result / 10;
            }
            catch
            {
                return 0f;
            }
        }
        public static string SystemInfo(string command, string path)
        {
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

            if (args[0] == "shutdown" && args[1] == "-r")
            {

                var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

                var key = root.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", true);

                var username = args[2];
                var password = args[3];

                try
                {
                    key.SetValue("DefaultUserName", username, RegistryValueKind.String);
                    key.SetValue("DefaultPassword", password, RegistryValueKind.String);
                    key.SetValue("AutoAdminLogon", "1", RegistryValueKind.String);

                    process.StartInfo.Arguments = args[0] + " " + args[1];
                    process.Start();
                    process.WaitForExit();

                    System.Diagnostics.Debug.WriteLine("Successfully saved!");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error during save");
                }

            }
            else
            {
                process.StartInfo.Arguments = command;
                process.Start();
                string message = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return message;           
                // string str = "{'message': '" + message + "', 'path': '" + GetNewPath(command, message, path) + "', 'type': '" + "command_result"+ "'}";
                // return JsonConvert.SerializeObject(str); 
            }

            return "Nesto";
        }
    }
}
