﻿
using JASONParser;
using System;
using System.IO;

namespace Monitor_Windows_Agent
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public Parser p = new Parser();
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void Fill() {
            this.textBoxName.Text = p.ConfigParser().name;
            
            this.textBoxKeepAlive.Text = p.ConfigParser().keepAlive.ToString();
            this.textBoxPingUri.Text = p.ConfigParser().pingUri;
            this.textBoxLocation.Text = p.ConfigParser().location;
            this.textBoxWebSocket.Text = p.ConfigParser().webSocketUrl;
            this.File1path.Text = p.ConfigParser().fileLocations.File1;
            this.File2path.Text = p.ConfigParser().fileLocations.File2;
            this.File3path.Text = p.ConfigParser().fileLocations.File3;
            this.File4path.Text = p.ConfigParser().fileLocations.File4;
            this.File5path.Text = p.ConfigParser().fileLocations.File5;

        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.iconNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.File1path = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.File2path = new System.Windows.Forms.TextBox();
            this.File3path = new System.Windows.Forms.TextBox();
            this.File4path = new System.Windows.Forms.TextBox();
            this.File5path = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxKeepAlive = new System.Windows.Forms.TextBox();
            this.textBoxWebSocket = new System.Windows.Forms.TextBox();
            this.textBoxPingUri = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iconNotify
            // 
            this.iconNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("iconNotify.Icon")));
            this.iconNotify.Text = "notifyIcon1";
            this.iconNotify.Visible = true;
            this.iconNotify.DoubleClick += new System.EventHandler(this.iconNotify_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(206, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(144, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Keep alive:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Web socket:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ping URI:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "File4:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "File1:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(396, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "File2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "File5:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(396, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "File3:";
            // 
            // File1path
            // 
            this.File1path.Location = new System.Drawing.Point(445, 31);
            this.File1path.Name = "File1path";
            this.File1path.ReadOnly = true;
            this.File1path.Size = new System.Drawing.Size(241, 27);
            this.File1path.TabIndex = 12;
            this.File1path.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(692, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // File2path
            // 
            this.File2path.Location = new System.Drawing.Point(445, 77);
            this.File2path.Name = "File2path";
            this.File2path.ReadOnly = true;
            this.File2path.Size = new System.Drawing.Size(241, 27);
            this.File2path.TabIndex = 14;
            // 
            // File3path
            // 
            this.File3path.Location = new System.Drawing.Point(445, 124);
            this.File3path.Name = "File3path";
            this.File3path.ReadOnly = true;
            this.File3path.Size = new System.Drawing.Size(241, 27);
            this.File3path.TabIndex = 15;
            // 
            // File4path
            // 
            this.File4path.Location = new System.Drawing.Point(445, 168);
            this.File4path.Name = "File4path";
            this.File4path.ReadOnly = true;
            this.File4path.Size = new System.Drawing.Size(241, 27);
            this.File4path.TabIndex = 16;
            // 
            // File5path
            // 
            this.File5path.Location = new System.Drawing.Point(445, 213);
            this.File5path.Name = "File5path";
            this.File5path.ReadOnly = true;
            this.File5path.Size = new System.Drawing.Size(241, 27);
            this.File5path.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(692, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(692, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 24);
            this.button3.TabIndex = 19;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(692, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 24);
            this.button4.TabIndex = 20;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(692, 216);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 24);
            this.button5.TabIndex = 21;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(-2176, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(281, 27);
            this.textBox2.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(-2186, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(281, 27);
            this.textBox3.TabIndex = 23;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(-2040, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(244, 27);
            this.textBox4.TabIndex = 24;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(206, 78);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(144, 27);
            this.textBoxLocation.TabIndex = 25;
            this.textBoxLocation.TextChanged += new System.EventHandler(this.textBoxLocation_TextChanged);
            // 
            // textBoxKeepAlive
            // 
            this.textBoxKeepAlive.Location = new System.Drawing.Point(206, 131);
            this.textBoxKeepAlive.Name = "textBoxKeepAlive";
            this.textBoxKeepAlive.Size = new System.Drawing.Size(144, 27);
            this.textBoxKeepAlive.TabIndex = 27;
            // 
            // textBoxWebSocket
            // 
            this.textBoxWebSocket.Location = new System.Drawing.Point(206, 175);
            this.textBoxWebSocket.Name = "textBoxWebSocket";
            this.textBoxWebSocket.Size = new System.Drawing.Size(144, 27);
            this.textBoxWebSocket.TabIndex = 28;
            // 
            // textBoxPingUri
            // 
            this.textBoxPingUri.Location = new System.Drawing.Point(206, 220);
            this.textBoxPingUri.Name = "textBoxPingUri";
            this.textBoxPingUri.Size = new System.Drawing.Size(144, 27);
            this.textBoxPingUri.TabIndex = 29;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(256, 385);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(94, 29);
            this.submitBtn.TabIndex = 32;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(579, 385);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(94, 29);
            this.CancelBtn.TabIndex = 33;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(416, 385);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(94, 29);
            this.Refresh.TabIndex = 34;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 426);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.textBoxPingUri);
            this.Controls.Add(this.textBoxWebSocket);
            this.Controls.Add(this.textBoxKeepAlive);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.File5path);
            this.Controls.Add(this.File4path);
            this.Controls.Add(this.File3path);
            this.Controls.Add(this.File2path);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.File1path);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void Button_Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }
        private void Button_Refresh_Click(object sender, System.EventArgs e)
        {
            var json = File.ReadAllText("../../../../config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            this.textBoxName.Text = jsonObj.name;
            this.textBoxKeepAlive.Text = jsonObj.keepAlive;
            this.textBoxLocation.Text = jsonObj.location;
            this.textBoxWebSocket.Text= jsonObj.webSocketUrl;
            this.textBoxPingUri.Text = jsonObj.pingUri;
            this.File1path.Text = jsonObj.fileLocations.File1;
            this.File2path.Text = jsonObj.fileLocations.File2;
            this.File3path.Text = jsonObj.fileLocations.File3;
            this.File4path.Text = jsonObj.fileLocations.File4;
            this.File5path.Text = jsonObj.fileLocations.File5;

        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            //zamijeniti prve dvije linije koda sa pozivom parsera
            var json = File.ReadAllText("../../../../config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //jsonObj["name"] = this.textBoxName.Text;
            //jsonObj["keepAlive"] = Int32.Parse(this.textBoxKeepAlive.Text);
            //jsonObj["location"] = this.textBoxLocation.Text;
           // jsonObj["ip"] = this.textBoxIpAddress.Text;
           // jsonObj["webSocketUrl"] = this.textBoxWebSocket.Text;
           // jsonObj["pingUri"] = this.textBoxPingUri.Text;
            ComputerInfo comp = new ComputerInfo();
            comp.name= this.textBoxName.Text;
            comp.keepAlive= Decimal.Parse(this.textBoxKeepAlive.Text);
            comp.location= this.textBoxLocation.Text;
            comp.webSocketUrl=this.textBoxWebSocket.Text;
            comp.pingUri = this.textBoxPingUri.Text;
            FileLocations f = new FileLocations();
            f.File1 = this.File1path.Text;
            f.File2 = this.File2path.Text;
            f.File3 = this.File3path.Text;
            f.File4 = this.File4path.Text;
            f.File5 = this.File5path.Text;
            comp.fileLocations = f;
            
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(comp, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("../../../../config.json", output);
            this.Close();
        }
        #endregion

        private System.Windows.Forms.NotifyIcon iconNotify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox File1path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox File2path;
        private System.Windows.Forms.TextBox File3path;
        private System.Windows.Forms.TextBox File4path;
        private System.Windows.Forms.TextBox File5path;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxKeepAlive;
        private System.Windows.Forms.TextBox textBoxWebSocket;
        private System.Windows.Forms.TextBox textBoxPingUri;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Refresh;
    }

}