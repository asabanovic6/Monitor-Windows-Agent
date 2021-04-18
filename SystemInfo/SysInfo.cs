using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace SystemInfo
{
    public class SysInfo

    {

        public static string getInfoGPU ()
        {
            /*
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            string s = "";
            
            foreach (ManagementObject obj in myVideoObject.Get())
            {
                 s += "Name  -  " + obj["Name"]  +Environment.NewLine +
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
            */
            return "caoDino";
            string s = "";
            SelectQuery querySound = new SelectQuery("Win32_SoundDevice");
            ManagementObjectSearcher searcherSound = new ManagementObjectSearcher(querySound);
            foreach (ManagementObject sound in searcherSound.Get())
            {
                s += "Sound device: " + sound["Name"];
            }

            SelectQuery queryVideo = new SelectQuery("Win32_VideoController");
            ManagementObjectSearcher searchVideo = new ManagementObjectSearcher(queryVideo);
            foreach (ManagementObject video in searchVideo.Get())
            {
                s += "Video device: " + video["Name"];
            }

            return s;
        }

    }
}
