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
            dataJSON.deviceUid = computer.deviceUid;
            dataJSON.timeStamp = DateTime.Now;
            dataJSON.message = "Djes";
            dataJSON.cpuUsage = (Decimal)0.5;
            dataJSON.ramUsage = (Decimal)0.5;
            dataJSON.hddUsage = (Decimal)0.5;
            dataJSON.gpuUsage = (Decimal)0.5;
            String result = JsonConvert.SerializeObject(dataJSON);
            return result;
        }
    }
    }

