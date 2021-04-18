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


namespace Monitor_Windows_Agent
{
    public partial class Form2 : Form
    {
        public static imageSender p1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) File1path.Text = fbd.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) File2path.Text = fbd.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) File3path.Text = fbd.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) File4path.Text = fbd.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) File5path.Text = fbd.SelectedPath;
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
    }
}
