using System;
using System.Collections.Generic;

namespace JASONParser
{
    public class ComputerInfo
    {
        public String name { get; set; }
        public decimal keepAlive { get; set; }
        public String location { get; set; }
        public String ip { get; set; }
     
       
        public String webSocketUrl { get; set; }
        public String pingUri { get; set; }
        public Nullable<Decimal> cpuUsage { get; set; }
        public Nullable<Decimal> ramUsage { get; set; }
        public Nullable<Decimal> hddUsage { get; set; }
        public Nullable<Decimal> gpuUsage { get; set; }
        public FileLocations fileLocations { get; set; }


    }
}
