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
using TerminalLibrary;

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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            try
            {
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream stream = httpWebResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = reader.ReadToEnd();
                    
                    result = JsonConvert.DeserializeObject<JToken>(responseString);
                }
                comp.deviceUid = result["deviceUid"].Value<String>();
                comp.name = result["name"].Value<String>();
                comp.location = result["location"].Value<String>();
                comp.installationCode = result["installationCode"].Value<String>();
                string json = JsonConvert.SerializeObject(comp);
                File.WriteAllText(@"C:\Program Files (x86)\Grupa2\Monitor Service\config.json", json);
                Post();
            }
            catch (Exception e)
            {
                PostError(0);
            }

        }
        private void SocketPong(object sender, ElapsedEventArgs e)
        {
            if (ws!=null)    
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
            comp = pars.ConfigParser();
            if (comp.installationCode != null)
                GetStartValue();
            else Post();
    
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
                PostError(0); // bit ce update-ovano
            }

        }
        public void conn()
        {
     
            ws = new WebSocket(url: pars.ConfigParser().webSocketUrl, onMessage: OnMessage, onError: OnError);
            ws.SetCookie(new WebSocketSharp.Net.Cookie("cookie", comp.deviceUid));
            ws.Connect().Wait();

            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromSeconds(30);

            sendMessage("sendCredentials", "");
        }

        private Task OnError(WebSocketSharp.ErrorEventArgs arg)
        {
            PostError(0); // bit ce update-ovano
            return Task.FromResult(0);
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

            if (result["type"].Value<String>() == "command") 
                {
                    String ret = TerminalCommand.RunCommand(result["command"].Value<String>(), result["path"].Value<String>());
                    ret += comp.deviceUid + "\"}";
                    ws.Send(ret);
                }

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
                using (Image image = Image.FromFile(@"C:\MyScreenshot\screenshot.jpg"))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        string base64String = Convert.ToBase64String(imageBytes);
                        WriteToFile(base64String);
                        sendMessage("sendScreenshot", base64String);
                    }
                }

            }
            catch (Exception e) {
                ws.Send("{ \"type\":\"" + "error" + "\", \"message\":\"" + "Can't take screenshot" + "\", \"deviceUid\":\"" + comp.deviceUid + "\"}");
                PostError(0);
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

        public void PostError(int code)
        {
            string errorData = "{ \"code\":\"" + code + "\", \"message\":\"" + "Doslo je do greske!" + "\", \"deviceUid\":\"" + pars.ConfigParser().deviceUid + "\", \"errorTime\":\"" + DateTime.Now + "\"}";
            byte[] bytes = Encoding.UTF8.GetBytes(errorData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(comp.errorUri);
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
