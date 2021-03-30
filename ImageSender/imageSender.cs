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
            // vs = ws://109.237.36.76:25565
            // ws = new WebSocket(url: "ws://si-grupa5.herokuapp.com", onMessage: OnMessage, onError: OnError);
            ws = new WebSocket(url: parser.ConfigParser().webSocketUrl, onMessage: OnMessage, onError: OnError);
            ws.Connect().Wait();

            sendMessage("sendCredentials", "" );
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
                sendMessage("pong", "");
                return Task.FromResult(0);
            }
            else if (result["type"].Value<String>() == "Disconnected") { return Task.FromResult(0); }

            if (result["type"].Value<String>() == "command") sendMessage("command_result", "radi");
     
            else if (result["type"].Value<String>() == "getScreenshot") sendScreenshot();
            else if (result["type"].Value<String>() == "getFile") sendFile(result["path"].Value<String>(), result["fileName"].Value<String>());
            else if (result["type"].Value<String>() == "putFile") getFile(result["data"].Value<String>(), result["path"].Value<String>(), result["fileName"].Value<String>());
            else if (result["type"].Value<String>() != "Connected") sendMessage("command_result", "Komanda ne postoji");

            Logger logger = new Logger( result["type"].Value<String>(), result["user"].Value<String>());
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
  
            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + message + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + comp.ip + "\", \"path\":\"" + comp.fileLocations.File1 + "\"}");
        }

        private static void sendFile (String path,String fileName)
        {
            String abspath = comp.fileLocations.File1 + "\\" + path + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(abspath);
            string base64String = Convert.ToBase64String(bytes);
            
            ws.Send ("{ \"type\":\"" + "sendFile" + "\", \"message\":\"" + base64String + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + comp.ip + "\", \"fileName\":\"" + fileName + "\"}");
            }

     private static void getFile(String base64String, String path, String fileName)
        {
            String abspath = comp.fileLocations.File1 + "\\" + path +  fileName;
            byte[] bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(abspath, bytes);

            //ovdje trebam vratiti ws ono sto njima treba 
            ws.Send("{ \"type\":\"" + "savedFile" + "\", \"message\":\"" + "fileSaved" + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\", \"ip\":\"" + comp.ip +  "\"}");

        }

    }
}