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

namespace PingServer
{
    public class Ping
    {



        private string uri { get; set; }
        private  string uriFile { get; set; }
        private int miliSec { get; set; }
        private static CreateJSON create;
        private string uriError { get; set; }
        private string errorData { get; set; }
        private int tim { get; set; }
        //Ova metoda je jedina public i nju trebamo pozvati u Program.cs iz main-a 

        public Ping(String path)
        {
            Parser pars = new Parser(path);
            this.uri = pars.ConfigParser().pingUri;
            this.uriError = pars.ConfigParser().errorUri;
            this.miliSec = (int)(pars.ConfigParser().keepAlive * 1000);
            this.uriFile = pars.ConfigParser().fileUri;
            this.errorData = "{ \"code\":\"" + 0 + "\", \"message\":\"" + "Doslo je do greske!" + "\", \"deviceUid\":\"" + pars.ConfigParser().deviceUid + "\", \"errorTime\":\"" + DateTime.Now + "\"}";
            this.tim = 0;
            create = new CreateJSON(path);
        }

        public void PostJsonAndKeepAlive()
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

        private  string getJSON(String folderPath)
        {

            string s = "[";
            if (IsDirectory(folderPath))
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                    var subdirectories = directoryInfo.EnumerateDirectories();
                    //OVDJE PREUREDITI KOD DA RADI SA OVIM PODFOLDERIMA
                    /*
                     foreach (var subdirectory in subdirectories)
                     {

                         getFiles(subdirectory.FullName);
                     } */

                    var files = directoryInfo.EnumerateFiles();

                    foreach (var file in files)
                    {

                        byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                        string base64String = Convert.ToBase64String(bytes);
                        s += "{ \"FileData\":\"" + base64String + "\", \"DeviceUID\":\"" + "fc548ecb-12ec-4ad5-8672-9d5a9565ff60" + "\", \"TimeStamp\":\"" + DateTime.Now + "\", \"Name\":\"" + file.Name + "\"},";
                    }
                 
                }
                catch (Exception e)
                {
                    PostError();
                }
                s = s.Remove(s.Length - 1, 1);
               
            }
            else
            {
                byte[] bytes = System.IO.File.ReadAllBytes(folderPath);
                string base64String = Convert.ToBase64String(bytes);
                s += "{ \"FileData\":\"" + base64String + "\", \"DeviceUID\":\"" + "fc548ecb-12ec-4ad5-8672-9d5a9565ff60" + "\", \"TimeStamp\":\"" + DateTime.Now + "\", \"Name\":\"" + Path.GetFileName(folderPath) + "\"},";
            }
            s += "]";
            return s;

        }
        private  void PostFiles(String path)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(getJSON(path));
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uriFile);
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
    }
}
