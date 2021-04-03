using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JASONParser;

namespace Monitor_Windows_Agent
{
    public partial class Form1 : Form
    {
        private void iconNotify_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Environment.Exit(0);
            }
        }
        public Form1()
        {
            InitializeComponent();
            iconNotify.MouseClick += iconNotify_MouseClick;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                iconNotify.Visible = true;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            Hide();
            iconNotify.Visible = true;
        }
        private void iconNotify_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            iconNotify.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iconNotify.BalloonTipText = "Aplikacija minimizirana";
            iconNotify.BalloonTipTitle = "Monitor Windows Agent";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                String url = textBox1.Text + textBox5.Text;
                JToken result;
                ComputerInfo comp = new ComputerInfo();
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
                    comp.webSocketUrl = textBox3.Text;
                    comp.pingUri = textBox2.Text;
                    comp.installationCode = null;
                    comp.mainUri = textBox1.Text;
                    comp.fileUri = textBox4.Text;
                    comp.keepAlive = 30;
                comp.fileLocations.File1 = File1path.Text;
                comp.fileLocations.File2 = null;
                comp.fileLocations.File3 = null;
                comp.fileLocations.File4 = null;
                comp.fileLocations.File5 = null;
                string json = JsonConvert.SerializeObject(comp);
                    File.WriteAllText(File1path.Text, json);
                    Form2 form2 = new Form2();
                    this.Hide(); 
                    form2.ShowDialog();
                    this.Close();

                }
                catch (System.Net.WebException)
                {
                    textBox5.Focus();
                    textBox5.Clear();
                    textBox5.BackColor = Color.LightPink;

                }


            
            
        }
    }
}
