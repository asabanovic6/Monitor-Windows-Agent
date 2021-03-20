using JASONParser;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using WebSocketSharp;
using JASONParser;

namespace ImageSender
{
    public class imageSender
    {
        static WebSocket ws;
        private static ComputerInfo comp = new ComputerInfo();
        private static Parser parser = new Parser();

        // private String type; 


        public void conn()
        {
            ws = new WebSocket(url: "ws://si-grupa5.herokuapp.com", onMessage: OnMessage, onError: OnError);
            ws.Connect().Wait();
            sendMessage("", "sendCredentials");


        }

        private Task OnError(WebSocketSharp.ErrorEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private static Task OnMessage(MessageEventArgs messageEventArgs)
        {
            string text = messageEventArgs.Text.ReadToEnd();
            if (text.Contains("mkdir"))
            {
                sendMessage("Evo radi", "command_result");
            }

            return Task.FromResult(0);

        }
        private static void sendScreen()
        {


            /* Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
 
             Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
             //Creating a New Graphics Object
             Graphics captureGraphics = Graphics.FromImage(captureBitmap);
             //Copying Image from The Screen
             captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
             //Saving the Image File (I am here Saving it in My E drive).
             captureBitmap.Save(@"Capture.jpg", ImageFormat.Jpeg);
 
             using (Image image = Image.FromFile(@"Capture.jpg"))
             {
                 using (MemoryStream m = new MemoryStream())
                 {
                     image.Save(m, image.RawFormat);
                     byte[] imageBytes = m.ToArray();
                     string base64String = Convert.ToBase64String(imageBytes);
                     sendMessage("testImage", base64String);
                 }
 
             }*/
        }
        private static void sendMessage(string message,string type)
        {
            comp = parser.ConfigParser();
            ws.Send("{ \"type\":\"" + type + "\", \"message\":\"" + message + "\", \"name\":\"" + comp.name + "\", \"location\":\"" + comp.location + "\"}");
        }
    }
}
