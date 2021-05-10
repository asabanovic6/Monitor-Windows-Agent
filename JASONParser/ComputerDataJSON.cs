using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JASONParser
{
   public class ComputerDataJSON
    {
        #region[Attributes]
        public DateTime timeStamp { get; set; }
       public String deviceUid { get; set; }
        public String  message { get; set; }
   
        public double cpuUsage { get; set; }
        public double ramUsage { get; set; }
        public double hddUsage { get; set; }
        public double gpuUsage { get; set; }
        #endregion

    }
}
