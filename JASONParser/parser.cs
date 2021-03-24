using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JASONParser
{
    public class Parser
    {
        
        public  ComputerInfo ConfigParser()
        {
            var json = File.ReadAllText("../../../../config.json");

            var item = JsonConvert.DeserializeObject<ComputerInfo>(json);

            Console.WriteLine(item);

            return item;
        }

    }
}
