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
        
       
        
        private  string uri { get; set; }
        private  int miliSec { get; set; }
        private static CreateJSON create;
        
        //Ova metoda je jedina public i nju trebamo pozvati u Program.cs iz main-a 

       public Ping (String path)
        {
            Parser pars = new Parser(path);
            this.uri = pars.ConfigParser().pingUri;
            this.miliSec = (int)(pars.ConfigParser().keepAlive * 1000);
          create = new CreateJSON(path);
        }
      
        public void PostJsonAndKeepAplive()
        {
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(this.miliSec);

            Timer timer = new System.Threading.Timer((e) =>
            {
                PostJson(this.uri, create.getJSON());
            }, null, startTimeSpan, periodTimeSpan);
        }

        public void PostJsonAndKeepAliveForService()
        {
            PostJson(uri, create.getJSON());
        }

        private static void PostJson(string uri, String postData)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "application/json";
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
