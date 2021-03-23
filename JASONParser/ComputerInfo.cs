using System;

namespace JASONParser
{
    public class ComputerInfo
    {
        public String name { get; set; }
        public decimal keepAlive { get; set; }
        public String location { get; set; }
        public String webSocketUrl { get; set; }
        public String pingUri { get; set; }
    }
}