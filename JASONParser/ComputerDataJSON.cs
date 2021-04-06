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
        public String  message { get; set; }
   
        public Nullable<Decimal> cpuUsage { get; set; }
        public Nullable<Decimal> ramUsage { get; set; }
        public Nullable<Decimal> hddUsage { get; set; }
        public Nullable<Decimal> gpuUsage { get; set; }


    }
}
