using JASONParser;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Net;
using Monitor_Windows_Agent;

using EventLogger;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MonitorWindowsAgentService
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer1,timer2;
        Parser pars = new Parser();
        WebSocket ws;
        private ComputerInfo comp=new ComputerInfo();
        private JToken result;
      
        public Service1()
        {
            InitializeComponent();
            StartConfig();
        }
        protected override void OnStart(string[] args)
        {
           //
           //WriteToFile("Service is started at " +comp.ToString());
           // pars = new Parser();
            timer1 = new System.Timers.Timer();
            timer1.Elapsed += new ElapsedEventHandler(this.OnElapsedTime);
            timer1.Interval =(int) pars.ConfigParser().keepAlive*1000; //number in milisecinds
            timer1.AutoReset=true;
            timer1.Enabled = true;
            timer1.Start();
            timer2 = new System.Timers.Timer();
            timer2.Elapsed += new ElapsedEventHandler(this.SocketPong);
            timer2.Interval = 25000; //number in milisecinds
            timer2.AutoReset = true;
            timer2.Enabled = true;
            timer2.Start();
        }
        private void GetStartValue() {
            comp = pars.ConfigParser();
            String url = comp.mainUri + comp.installationCode;
            JToken result;
            //ComputerInfo comp = new ComputerInfo();
            //WriteToFile(url+"aaa");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            try
            {
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //WriteToFile(httpWebResponse.Headers.ToString());
                using (Stream stream = httpWebResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = reader.ReadToEnd();
                    
                    result = JsonConvert.DeserializeObject<JToken>(responseString);
                    WriteToFile(result.ToString());
                }
                comp.deviceUid = result["deviceUid"].Value<String>();
                comp.name = result["name"].Value<String>();
                comp.location = result["location"].Value<String>();
               
                string json = JsonConvert.SerializeObject(comp);
                File.WriteAllText(@"C:\Program Files (x86)\Grupa2\Monitor Service", json);
                Post();
            }
            catch (System.Net.WebException)
            {
                Post();

            }


        }
        private void SocketPong(object sender, ElapsedEventArgs e)
        {
            
            if(ws!=null)    
                ws.Send("{ \"type\":\"" + "pong" + "\"}");
        
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            PostJson();
        }
        public void StartConfig() {
            //string uri = pars.ConfigParser().pingUri;
            //p1.Post();
            // Post();
            GetStartValue();
            
            //  WriteToFile("Inicijalizovo sam se: " + pars.ConfigParser()+" u: "+ DateTime.Now);

        }
        public void PostJson() {
            

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(pars.ConfigParser().pingUri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                
                streamWriter.Write(CreateJSON.getJSON());
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
       
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
        public void Post()
        {
            try
            {
                comp = pars.ConfigParser();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://si-grupa5.herokuapp.com/login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                CookieContainer cok = new CookieContainer();
                httpWebRequest.CookieContainer = cok;
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Headers.Add("Authorization", comp.deviceUid);

                using (var streamWriter = new

                StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{ \"id\":\"" + comp.deviceUid + "\"}";

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode.ToString() == "OK") conn();
                //return 1;

            }
            catch (Exception e)
            {
                WriteToFile(pars.ConfigParser().deviceUid + " mater usta");
            }

        }
        public void conn()
        {
           /* if (Post() == 0) { 
                
            }*/

            // vs = ws://109.237.36.76:25565
            // ws = new WebSocket(url: "ws://si-grupa5.herokuapp.com", onMessage: OnMessage, onError: OnError);
            ws = new WebSocket(url: pars.ConfigParser().webSocketUrl, onMessage: OnMessage, onError: OnError);
            ws.SetCookie(new WebSocketSharp.Net.Cookie("cookie", comp.deviceUid));
            ws.Connect().Wait();

            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromSeconds(30);

           

            sendMessage("sendCredentials", "");
        }

        private Task OnError(WebSocketSharp.ErrorEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private  Task OnMessage(MessageEventArgs messageEventArgs)
        {
            string text = messageEventArgs.Text.ReadToEnd();
            result = JsonConvert.DeserializeObject<JToken>(text);
            if (result["type"].Value<String>() == "Connected") return Task.FromResult(0);
            else if (result["type"].Value<String>() == "ping")
            {
                return Task.FromResult(0);
            }
            else if (result["type"].Value<String>() == "Disconnected") { return Task.FromResult(0); }

            if (result["type"].Value<String>() == "command") sendMessage("command_result", "radi");

            else if (result["type"].Value<String>() == "getScreenshot") sendScreenshot();
            else if (result["type"].Value<String>() == "getFile") sendFile(result["path"].Value<String>(), result["fileName"].Value<String>());
            else if (result["type"].Value<String>() == "getFileDirect") sendFile(result["path"].Value<String>(), result["fileName"].Value<String>(), "sendFileDirect");
            else if (result["type"].Value<String>() == "putFile") getFile(result["data"].Value<String>(), result["path"].Value<String>(), result["fileName"].Value<String>());
            else if (result["type"].Value<String>() != "Connected") sendMessage("empty", "Komanda ne postoji");

            Logger logger = new Logger(result["type"].Value<String>(), result["user"].Value<String>());
            logger.writeLog();

            return Task.FromResult(0);
        }
        
        private void sendScreenshot()
        {
            try {

                var captureBmp = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
                using (var captureGraphic = Graphics.FromImage(captureBmp))
                {
                    captureGraphic.CopyFromScreen(0, 0, 0, 0, captureBmp.Size);
                    captureBmp.Save("capture.jpg", ImageFormat.Jpeg);
                }
                //potrebno podesit putanju slike
                using (Image image = Image.FromFile(@"capture.jpg"))
                {

                    using (MemoryStream m = new MemoryStream())
                    {

                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        string base64String = Convert.ToBase64String(imageBytes);

                        sendMessage("sendScreenshot", base64String);

                    }
                }

            }
            catch (Exception e) {
                sendMessage("sendScreenshot", "error");
                WriteToFile(e.ToString());
            }
        }
        private  void sendMessage(string type, string message)
        {
            comp = pars.ConfigParser();

            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + message + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"deviceUid\":\"" + comp.deviceUid + "\", \"path\":\"" + comp.fileLocations.File1 + "\"}");
        }

        private void sendFile(String path, String fileName, String type = "sendFile")
        {
            comp = pars.ConfigParser();

            String abspath = comp.fileLocations.File1 + "\\" + path + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(abspath);
            string base64String = Convert.ToBase64String(bytes);

            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + base64String + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + "ip" + "\", \"fileName\":\"" + fileName + "\"}");
        }

        private void getFile(String base64String, String path, String fileName)
        {
            String abspath = comp.fileLocations.File1 + "\\" + path + fileName;
            byte[] bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(abspath, bytes);

            //ovdje trebam vratiti ws ono sto njima treba 
            ws.Send("{ \"type\":\"" + "savedFile" + "\", \"message\":\"" + "fileSaved" + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + "ip" + "\"}");

        }

    }
}
