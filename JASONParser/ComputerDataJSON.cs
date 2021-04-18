using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JASONParser
{
   public class ComputerDataJSON
    {
        public DateTime timeStamp { get; set; }
        public String deviceUid { get; set; }
        public String message { get; set; }

        public decimal cpuUsage { get; set; }
        public decimal ramUsage { get; set; }
        public decimal hddUsage { get; set; }
        public decimal gpuUsage { get; set; }


    }
}
