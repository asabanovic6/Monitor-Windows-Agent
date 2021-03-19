using System;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApp1
{
    class pr
    {
        static WebSocket ws;
        static void Main(string[] args)
        {
            ws = new WebSocket(url: "ws://109.237.36.76:25565", onMessage: OnMessage, onError: OnError);
            //  Console.WriteLine("Hello World!");
            ws.Connect().Wait();
            //image, bilo sta

            sendMessage("connected", "");
        }

        private static Task OnError(ErrorEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private static Task OnMessage(MessageEventArgs messageEventArgs)
        {
            string text = messageEventArgs.Text.ReadToEnd();
           
            return Task.FromResult(0);
            
        }
        private static void sendScreen() {
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
        private static void sendMessage(string key, string value)
        {

            ws.Send("{ \"key\":\"" + key + "\", \"value\":\"" + value + "\"}");

        }
    }
}
