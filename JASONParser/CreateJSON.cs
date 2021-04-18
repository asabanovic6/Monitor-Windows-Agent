using System;
using System.Collections.Generic;
using System.Text;
using JASONParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TerminalLibrary;

namespace Monitor_Windows_Agent
{
    public class CreateJSON
    {
        
        private static Parser parser = new Parser();
        private static ComputerInfo computer = parser.ConfigParser();
        private static ComputerDataJSON dataJSON = new ComputerDataJSON();
  

    public static String getJSON ()
        {
            dataJSON.deviceUid = computer.deviceUid;
            dataJSON.timeStamp = DateTime.Now;
            dataJSON.message = "Ping";
            dataJSON.cpuUsage = (decimal)TerminalCommand.getCPUUsage();
            dataJSON.ramUsage = (decimal)TerminalCommand.getRAMUsege();
            dataJSON.hddUsage = (decimal)TerminalCommand.getHDDUsage();
            dataJSON.gpuUsage = (decimal)TerminalCommand.getGPUUsage();
            String result = JsonConvert.SerializeObject(dataJSON);
            return result;
        }
    }
    }

