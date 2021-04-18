using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SystemInformation
{
    public class SystemInfo {
        public static string getGPUInfo()
        {
            return "Cao dino";
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            string s = "";

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                s += "Name  -  " + obj["Name"] + Environment.NewLine +
              "Status  -  " + obj["Status"] + Environment.NewLine +
              "Caption  -  " + obj["Caption"] + Environment.NewLine +
              "DeviceID  -  " + obj["DeviceID"] + Environment.NewLine +
               "AdapterRAM  -  " + obj["AdapterRAM"] + Environment.NewLine +
               "AdapterDACType  -  " + obj["AdapterDACType"] + Environment.NewLine +
               "Monochrome  -  " + obj["Monochrome"] + Environment.NewLine +
             "InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"] + Environment.NewLine +
              "DriverVersion  -  " + obj["DriverVersion"] + Environment.NewLine +
               "VideoProcessor  -  " + obj["VideoProcessor"] + Environment.NewLine +
               "VideoArchitecture  -  " + obj["VideoArchitecture"] + Environment.NewLine +
              "VideoMemoryType  -  " + obj["VideoMemoryType"];
            }
            return s;

        }
    }
}
