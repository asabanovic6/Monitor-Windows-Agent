using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JASONParser
{
    public class parser
    {
        
           
      
        public class ComputerInfo
        {
            public String Computer_name { get; set; }
            public decimal Keep_alive { get; set; }
        }

        public  ComputerInfo ConfigParser()
        {
            var json = File.ReadAllText("../../../../config.json");

            var item = JsonConvert.DeserializeObject<ComputerInfo>(json);

            return item;
        }

    }
}
