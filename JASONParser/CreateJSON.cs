using System;
using System.Collections.Generic;
using System.Text;
using JASONParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Monitor_Windows_Agent
{
    public class CreateJSON
    {
        
        private static Parser parser = new Parser();
        private static ComputerInfo computer = parser.ConfigParser();
        private static ComputerDataJSON dataJSON = new ComputerDataJSON();
  

    public static String getJSON ()
        {
            dataJSON.name = computer.name;
            dataJSON.location = computer.location;
            dataJSON.timeStamp = DateTime.Now;
            dataJSON.message = "Djes Huso";
            dataJSON.cpuUsage = null;
            dataJSON.ramUsage = null;
            dataJSON.hddUsage = null;
            dataJSON.gpuUsage = null;
            String result = JsonConvert.SerializeObject(dataJSON);
            return result;
        }
    }
    }

