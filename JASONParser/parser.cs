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
        #region[Attributes]

        public String path { get; set; }
      
        public Parser (String pathConfig)
        {
            this.path = pathConfig;
        }
        #endregion
        #region[Methods]


        public ComputerInfo ConfigParser()
        {
            var json = System.IO.File.ReadAllText(path); 

            var item = JsonConvert.DeserializeObject<ComputerInfo>(json);

            return item;
        }
        #endregion

    }
}

