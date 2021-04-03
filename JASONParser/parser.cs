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

        public ComputerInfo ConfigParser()
        {
             var json = File.ReadAllText(@"C:\Users\Dalee\Desktop\si2\Monitor-Windows-Agent\config.json");

            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //var json = File.ReadAllText(path + "\\config.json"); //osigurava da se moze izvrsiti gdje god da se servis instalira preko setup-a

            var item = JsonConvert.DeserializeObject<ComputerInfo>(json);

            return item;
        }

    }
}

