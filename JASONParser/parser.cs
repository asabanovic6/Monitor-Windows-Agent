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
      public  String path { get; set; }
      
        public Parser (String pathConfig)
        {
            this.path = pathConfig;
        }
        
        public  ComputerInfo ConfigParser()
        {
            var json = System.IO.File.ReadAllText(path); 

            var item = JsonConvert.DeserializeObject<ComputerInfo>(json);

            return item;
        }

    }
}

