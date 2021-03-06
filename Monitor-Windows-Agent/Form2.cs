using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PingServer;
using ImageSender;
using JASONParser;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;

namespace Monitor_Windows_Agent
{
    public partial class Form2 : Form
    {
        public static imageSender p1;
        private Parser pars = new Parser((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
        private void iconNotify_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Environment.Exit(0);
            }
        }
        public Form2()
        {
            InitializeComponent();
            iconNotify.MouseClick += iconNotify_MouseClick;
            SetAutoLogOff();
            // Ping p = new Ping(Form1.path);
            // p.PostJsonAndKeepAplive();
            Ping p = new Ping((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
            try
            {
                p.PostJsonAndKeepAlive();
               
               
            }
            catch (Exception E)
            {
                p.PostError();
            }

            p1 = new imageSender((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))+"\\config.json");
            p1.conn();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                Hide();
                iconNotify.Visible = true;
            }
            iconNotify.Visible = true;
        }
        protected override void OnFormClosing (FormClosingEventArgs e)
        {
            e.Cancel = false;
            
        }
        private void iconNotify_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            iconNotify.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            iconNotify.BalloonTipText = "Aplikacija minimizirana";
            iconNotify.BalloonTipTitle = "Monitor Windows Agent";
            Fill();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private static void SetAutoLogOff()
        {
            var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            var key = root.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", true);

            key.SetValue("AutoAdminLogon", "0", RegistryValueKind.String);
        }
    }
}
