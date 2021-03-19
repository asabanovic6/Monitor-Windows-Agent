using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Monitor_Windows_Agent;
using JASONParser;

namespace PingServer
{
    public class Ping
    {

        public void connection() {
            string str = CreateJSON.getJSON();
            Parser pars = new Parser();
            ComputerInfo comp=  pars.ConfigParser();
            //string uri = "http://167.99.244.168:3000/liveStatus";
            string uri = "https://httpbin.org/post";
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(uri); 
            request.KeepAlive = true;
            request.Timeout = (int)(comp.keepAlive * 1000);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            byte[] postBytes = Encoding.ASCII.GetBytes(str);
            request.ContentType = "application/json";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

          /*  HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(new
            StreamReader(response.GetResponseStream()).ReadToEnd());
            Console.WriteLine("Headers:");
            Console.WriteLine(response.Headers.ToString());*/
        }    
    }
   
}
