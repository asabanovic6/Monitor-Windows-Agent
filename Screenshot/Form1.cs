using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("Screenshot", Application.ExecutablePath.ToString());
            makeFolder();
            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, closeApp);
        }

        private void makeFolder()
        {
            string root = @"C:\MyScreenshot";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }
        private void closeApp(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void screenshot(object sender, EventArgs e)
        {
            makeFolder();
            Bitmap memoryImage;

            memoryImage = new Bitmap(1920, 1080);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = @"C:\MyScreenshot" + "\\screenshot.jpg";
                  //   DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png";
            memoryImage.Save(fileName);

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
            button3.Enabled = true;
            button2.Enabled = false;
            timer1.Stop();

        }

       

        private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            timer1.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void notifyIcon1_DoubleClick_1(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

       
    }
}
