using JASONParser;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EventLogger;
using System.Net;
using System.Threading;
using Terminal;
using PingServer;
using SystemInformation;

namespace ImageSender
{

    
    public class imageSender
    {

        private int connected = 0;
         WebSocket ws;
        private  ComputerInfo comp { get; set; }
        private  JToken result;
        private String pathConfig;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer connTimer = new System.Windows.Forms.Timer();
        private bool timer = false;
        private PingServer.Ping p = new PingServer.Ping((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
       
        public imageSender (String path)
        {
            Parser pars = new Parser(path);
            comp = new ComputerInfo();
            comp = pars.ConfigParser();
            pathConfig = path;
        }

        public bool conn()
        {
           
               if (logIn()==0)
            {
                
                return false;
            }

                ws = new WebSocket(url: "wss://"+ comp.webSocketUrl, onMessage: OnMessage, onError: OnError, onClose: OnClose); //dodati wss 
                ws.SetCookie(new WebSocketSharp.Net.Cookie("cookie", comp.deviceUid));
                ws.Connect().Wait();


            connected = 0;
            if (timer==false)
            {
                timer = true;
                myTimer.Tick += new EventHandler(TimerEventProcessor);

                // Sets the timer interval to 30 seconds.
                myTimer.Interval = 30000;
                myTimer.Start();

                connTimer.Tick += new EventHandler(CheckConnection);

                // Sets the timer interval to 5 seconds.
                connTimer.Interval = 5000;
                connTimer.Start();

            }


            ws.Send("{ \"type\":\"" + "sendCredentials" + "\", \"message\":\"" + "" + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location +
                "\", \"deviceUid\":\"" + comp.deviceUid + "\", \"path\":\"" + comp.path + "\"}");
            
            return true;
           

        }

        private Task OnClose(CloseEventArgs arg)
        {
            connected = 10;
            return Task.FromResult(0);
        }

        private void CheckConnection(object sender, EventArgs e)
        {
            if (connected++ >= 10) conn();
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
           
            ws.Send("{ \"type\":\"" + "pong" + "\"}");
        }

       

        private Task OnError(WebSocketSharp.ErrorEventArgs arg)
        {

            return Task.FromResult(0);
        }
        
        private  Task OnMessage(MessageEventArgs messageEventArgs)
        {
            string text = messageEventArgs.Text.ReadToEnd();
             result = JsonConvert.DeserializeObject<JToken>(text);
           if (result["type"].Value<String>()=="Error") return Task.FromResult(0);
            if (result["type"].Value<String>() == "Connected") return Task.FromResult(0);
         
            else if (result["type"].Value<String>() == "ping")
            {
                connected = 0;
                return Task.FromResult(0);
            }
            else if (result["type"].Value<String>() == "Disconnected") { return Task.FromResult(0); }

            if (result["type"].Value<String>() == "command")
            {
                String ret = TerminalCommand.RunCommand(result["command"].Value<String>(), result["path"].Value<String>());
                ret += comp.deviceUid + "\"}";
                ws.Send(ret);
            }
            else if (result["type"].Value<String>() == "systemInfo")
            {
             //   MessageBox.Show(getGPUInfo());
               //   ws.Send("{ \"type\":\"" + "sendInfo" + "\", \"message\":\"" + getGPUInfo() +  "\", \"deviceUid\":\"" + comp.deviceUid +  "\"}");
              //  ws.Send("{ \"type\":\"" + "sendInfo" + "\", \"message\":\"" + "Cao jasmine" + "\", \"deviceUid\":\"" + comp.deviceUid + "\"}");

            }
            else if (result["type"].Value<String>() == "getScreenshot") sendScreenshot();
            else if (result["type"].Value<String>() == "getFile") sendFile(result["path"].Value<String>(), result["fileName"].Value<String>());
            else if (result["type"].Value<String>() == "getFileDirect") sendFile(result["path"].Value<String>(), result["fileName"].Value<String>(), "sendFileDirect");
            else if (result["type"].Value<String>() == "putFile") getFile(result["data"].Value<String>(), result["path"].Value<String>(), result["fileName"].Value<String>());
            else if (result["type"].Value<String>() != "Connected") sendMessage("empty", "Komanda ne postoji");

            Logger logger = new Logger( result["type"].Value<String>(), result["user"].Value<String>());
            logger.writeLog();

            return Task.FromResult(0);
        }

       

        private void sendScreenshot()
        {
            try
            {
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
            catch (Exception E)
            {
                ws.Send("{ \"type\":\"" + "error" + "\", \"message\":\"" + "Can't take screenshot" + "\", \"deviceUid\":\"" + comp.deviceUid + "\"}");
                p.PostError();
            }

        }
        private void sendMessage(string type, string message)
        {


            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + message + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"deviceUid\":\"" + comp.deviceUid + "\", \"path\":\"" + "" + "\"}");
        }

        public void sendFile(String path, String fileName, String type = "sendFile")
        {
            try
            {
                String abspath = path + fileName;
                if (fileName == "config.json")
                {
                    abspath = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json";
                }

                byte[] bytes = System.IO.File.ReadAllBytes(abspath);
                string base64String = Convert.ToBase64String(bytes);

                ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + base64String + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"deviceUid\":\"" + comp.deviceUid + "\", \"fileName\":\"" + fileName + "\"}");
            }
            catch (Exception E)
            {
                ws.Send("{ \"type\":\"" + "error" + "\", \"message\":\"" + "File could not be sent" + "\", \"deviceUid\":\"" + comp.deviceUid + "\"}");
                p.PostError();
            }
        }

        private void getFile(String base64String, String path, String fileName)
        {
            try
            {
                String abspath = path + fileName;
                if (fileName == "config.json")
                {
                    abspath = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json";
                }

                byte[] bytes = Convert.FromBase64String(base64String);
                System.IO.File.WriteAllBytes(abspath, bytes);

                //ovdje trebam vratiti ws ono sto njima treba 
                ws.Send("{ \"type\":\"" + "savedFile" + "\", \"message\":\"" + "fileSaved" + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"deviceUid\":\"" + comp.deviceUid + "\"}");
            }
            catch (Exception E)
            {
                ws.Send("{ \"type\":\"" + "error" + "\", \"message\":\"" + "File could not be saved" + "\", \"deviceUid\":\"" + comp.deviceUid + "\"}");
                p.PostError();
            }
        }
        private void saveFiles(string files)
        {
           
            JArray json = JArray.Parse(files);

            int length = json.Count;
            string toReturn = "{ \"type\":\"" + "savedFiles" + "\", \"deviceUid\":\"" + comp.deviceUid + "\", \"message\":" + " [ ";


            foreach (JObject o in json)
            {
                try
                {
                    System.IO.File.WriteAllBytes(o.GetValue("fileName").ToString(), Convert.FromBase64String(o.GetValue("data").ToString()));
                    toReturn += "{ \"message\":\"" + o.GetValue("fileName").ToString() + " Written" + "\"},";
                }
                catch (Exception e)
                {
                    toReturn += "{ \"message\":\"" + o.GetValue("fileName").ToString() + " Not Written" + "\"},";

                }
            }


            toReturn += "{ " + "\"Message\":\"" + "DONE" + "\"} ] }";
            //recieveBox.Invoke(new Action(() => recieveBox.Text = toReturn)); 
            ws.Send(toReturn);


        }
        private int logIn()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://" + comp.webSocketUrl + "/login");

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

                return 1;
            }
            catch (Exception E)
            {
                p.PostError();
                return 0;
            }
        }
       
    }
}