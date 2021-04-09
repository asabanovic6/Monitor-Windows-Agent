using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void screenshot(object sender, EventArgs e)
        {
            Bitmap memoryImage;
           
            memoryImage = new Bitmap(1920, 1080);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            string fileName = @"C:\Users\Vedad\Desktop\Screenshots" +
                     @"\Screenshot" +
                     //DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png");
                     ".png";
            memoryImage.Save(fileName);
        }

        private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }
    }
}
