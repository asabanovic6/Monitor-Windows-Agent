using JASONParser;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace ImageSender
{
    public class imageSender
    {
        static WebSocket ws;
        private static ComputerInfo comp = new ComputerInfo();
        private static Parser parser = new Parser();

        public void conn()
        {
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
            if (text.Contains("cd"))
            {
                sendMessage("command_result", "radi");
            }
            else if (text == "getScreenshot") sendScreenshot();
           else if (text != "Connected")
            {
                sendMessage("command_result", "Komanda ne postoji");
            }
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
            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + message + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\"}");
        }

    }
}