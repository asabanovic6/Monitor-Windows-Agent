using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Monitor_Windows_Agent
{
    public partial class Form2 : Form
    {
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
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
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

        private void Form2_Load(object sender, EventArgs e)
        {
            iconNotify.BalloonTipText = "Aplikacija minimizirana";
            iconNotify.BalloonTipTitle = "Monitor Windows Agent";
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

    }
}
