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
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;



namespace PingServer
{
    public class Ping
    {


        #region[Attributes]

        private string uri { get; set; }
        private static  string uriFile { get; set; }
        private int miliSec { get; set; }
        private static CreateJSON create;
        private string uriError { get; set; }
        private string errorData { get; set; }
        private int tim { get; set; }
        private static Parser pars { get; set; }
        //Ova metoda je jedina public i nju trebamo pozvati u Program.cs iz main-a 

        public Ping(String path)
        {
            pars = new Parser(path);
            this.uri = pars.ConfigParser().pingUri;
            this.uriError = pars.ConfigParser().errorUri;
            this.miliSec = (int)(pars.ConfigParser().keepAlive * 1000);
            uriFile = pars.ConfigParser().fileUri;
          this.errorData = "{ \"code\":\"" + 0 + "\", \"message\":\"" + "Doslo je do greske!" + "\", \"deviceUid\":\"" + pars.ConfigParser().deviceUid + "\", \"errorTime\":\"" + DateTime.Now + "\"}";
            this.tim = 0;
            create = new CreateJSON(path);
        }
        #endregion

        #region[PostConfigInfo]

        public void PostJsonAndKeepAlive()
        {
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(this.miliSec);

            Timer timer = new System.Threading.Timer((e) =>
            {
                PostJson(this.uri, create.getJSON());
            }, null, startTimeSpan, periodTimeSpan);
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
        #endregion

        #region[PostError]

        public void PostError()
        {

            byte[] bytes = Encoding.UTF8.GetBytes(errorData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uriError);
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
        #endregion

        #region[PostFiles]

        private static bool IsDirectory(string path)
        {
            // Get the file attributes for file or directory
            try
            {
                FileAttributes attr = System.IO.File.GetAttributes(path);

                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) return true;//It's a directory
                else return false;//It's a file
            }
            catch (FileNotFoundException)
            {
                return false;
            }

        }

        private   JArray getJSON(String folderPath)
        {

            JArray a = new JArray();
            if (IsDirectory(folderPath))
            {
                
                    DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                   

                    var files = directoryInfo.EnumerateFiles();
                  
                    foreach (var file in files)
                    {
                   
                        byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                        String fileString = Convert.ToBase64String(bytes);
                        JObject jo = new JObject();
                        jo.Add("FileData", fileString);
                        jo.Add("DeviceUID", pars.ConfigParser().deviceUid);
                        jo.Add("TimeStamp", DateTime.Now);
                        jo.Add("Name", file.Name);
                        a.Add(jo);
                    }
                 
                
      
               
            }
            else
            {

                byte[] bytes = System.IO.File.ReadAllBytes(folderPath);
                String fileString = Convert.ToBase64String(bytes);
                JObject jo = new JObject();
                jo.Add("FileData", fileString);
                jo.Add("DeviceUID", pars.ConfigParser().deviceUid);
                jo.Add("TimeStamp", DateTime.Now);
                jo.Add("Name", Path.GetFileName(folderPath));
                a.Add(jo);
            }
            return a;

        }
        private   void PostFiles(String path)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uriFile);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(getJSON(path));
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public  void PostFilesAndKeepAlive(String path, double keepAlive)
        {    
            //OVDJE NEKAKO SKONTATI KAKO ZAUSTAVIT TIMER AKO VEC RADI I POKRENUTI PONOVO SA
            //NOVIM KEEP ALIVE 
            //POKUSATI SA CHANGE ILI PITATI JASMINA
            //NE ZABORAVITI POMOCNU VARIABLE TIM 
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromMinutes(keepAlive);

            Timer timer = new System.Threading.Timer((e) =>
                {
                    PostFiles(path);
                }, null, startTimeSpan, periodTimeSpan);
              
            
           
             //  timer.Change(0, Convert.ToInt32(keepAlive) * 60000);
            
        }
        #endregion
    }
}
