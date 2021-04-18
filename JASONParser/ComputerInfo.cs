using System;
using System.Collections.Generic;

namespace JASONParser
{
    public class ComputerInfo
    {
        public String name { get; set; }
        public String location { get; set; }
        public String deviceUid { get; set; }
        public decimal keepAlive { get; set; }
        public String webSocketUrl { get; set; }
        public String pingUri { get; set; }

        public String errorUri { get; set; }
        public String mainUri { get; set; }
        public String fileUri { get; set; }
        public String installationCode { get; set; }
        public FileLocations fileLocations { get; set; }


    }
}
