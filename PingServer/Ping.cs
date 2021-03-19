using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Monitor_Windows_Agent;
using JASONParser;
using System.Security.Policy;
using System.Threading;


namespace PingServer
{
    public class Ping
    {
        private static string uri = "http://167.99.244.168:3000/liveStatus";
        private string datas = CreateJSON.getJSON();
      private static Parser pars = new Parser();
        private static int miliSec = (int) ( pars.ConfigParser().keepAlive*1000);

        //Ova metoda je jedina public i nju trebamo pozvati u Program.cs iz main-a 
        public void PostJsonAndKeepAplive()
        {
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(miliSec);

            Timer timer = new System.Threading.Timer((e) =>
            {
                PostJson(uri, datas);
            }, null, startTimeSpan, periodTimeSpan);
        }

        private static void PostJson(string uri, String postData)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "text/xml";
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                string message = String.Format("POST failed. Received HTTP {0}", httpWebResponse.StatusCode);
                throw new ApplicationException(message);
            }
        }
    }
}

      /*  public void connection() {
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

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(new
            StreamReader(response.GetResponseStream()).ReadToEnd());
            Console.WriteLine("Headers:");
            Console.WriteLine(response.Headers.ToString());
        }    */    
   

