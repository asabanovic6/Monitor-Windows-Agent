
using JASONParser;
using System;
using System.IO;
using ImageSender;
using PingServer;
using System.Drawing;

namespace Monitor_Windows_Agent
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void Fill()
        {
            var json = System.IO.File.ReadAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            this.textBoxName.Text = jsonObj.name;
            this.textBoxKeepAlive.Text = jsonObj.keepAlive;
            this.textBoxLocation.Text = jsonObj.location;
            this.textBox1.Text = jsonObj.path;
            this.File1path.Text = jsonObj.fileLocations.File1.path;
            this.File2path.Text = jsonObj.fileLocations.File2.path;
            this.File3path.Text = jsonObj.fileLocations.File3.path;
            this.File4path.Text = jsonObj.fileLocations.File4.path;
            this.File5path.Text = jsonObj.fileLocations.File5.path;
            this.textBox5.Text = jsonObj.fileLocations.File1.minutes;
            this.textBox6.Text = jsonObj.fileLocations.File2.minutes;
            this.textBox7.Text = jsonObj.fileLocations.File3.minutes;
            this.textBox8.Text = jsonObj.fileLocations.File4.minutes;
            this.textBox9.Text = jsonObj.fileLocations.File5.minutes;

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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.File1path = new System.Windows.Forms.TextBox();
            this.File2path = new System.Windows.Forms.TextBox();
            this.File3path = new System.Windows.Forms.TextBox();
            this.File4path = new System.Windows.Forms.TextBox();
            this.File5path = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxKeepAlive = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconNotify
            // 
            this.iconNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("iconNotify.Icon")));
            this.iconNotify.Text = "notifyIcon1";
            this.iconNotify.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxName.Location = new System.Drawing.Point(125, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(225, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Keep alive:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 161);
            this.label3.Name = "label2";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Path:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "File 4:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "File 1:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "File 2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "File 5:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "File 3:";
            // 
            // File1path
            // 
            this.File1path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File1path.Location = new System.Drawing.Point(63, 17);
            this.File1path.Name = "File1path";
            this.File1path.ReadOnly = false;
            this.File1path.Size = new System.Drawing.Size(241, 27);
            this.File1path.TabIndex = 11;
            this.File1path.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
        
            // 
            // File2path
            // 
            this.File2path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File2path.Location = new System.Drawing.Point(63, 63);
            this.File2path.Name = "File2path";
            this.File2path.ReadOnly = false;
            this.File2path.Size = new System.Drawing.Size(241, 27);
            this.File2path.TabIndex = 13;
            // 
            // File3path
            // 
            this.File3path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File3path.Location = new System.Drawing.Point(63, 110);
            this.File3path.Name = "File3path";
            this.File3path.ReadOnly = false;
            this.File3path.Size = new System.Drawing.Size(241, 27);
            this.File3path.TabIndex = 14;
            // 
            // File4path
            // 
            this.File4path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File4path.Location = new System.Drawing.Point(63, 154);
            this.File4path.Name = "File4path";
            this.File4path.ReadOnly = false;
            this.File4path.Size = new System.Drawing.Size(241, 27);
            this.File4path.TabIndex = 15;
            // 
            // File5path
            // 
            this.File5path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File5path.Location = new System.Drawing.Point(63, 199);
            this.File5path.Name = "File5path";
            this.File5path.ReadOnly = false;
            this.File5path.Size = new System.Drawing.Size(241, 27);
            this.File5path.TabIndex = 16;
        
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(-2150, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(281, 27);
            this.textBox2.TabIndex = 21;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(-2150, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(281, 27);
            this.textBox3.TabIndex = 22;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(-2150, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(244, 27);
            this.textBox4.TabIndex = 23;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxLocation.Location = new System.Drawing.Point(125, 67);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.ReadOnly = true;
            this.textBoxLocation.Size = new System.Drawing.Size(225, 27);
            this.textBoxLocation.TabIndex = 24;
            this.textBoxLocation.TextChanged += new System.EventHandler(this.textBoxLocation_TextChanged);
            // 
            // textBoxKeepAlive
            // 
            this.textBoxKeepAlive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxKeepAlive.Location = new System.Drawing.Point(125, 114);
            this.textBoxKeepAlive.Name = "textBoxKeepAlive";
            this.textBoxKeepAlive.ReadOnly = true;
            this.textBoxKeepAlive.Size = new System.Drawing.Size(225, 27);
            this.textBoxKeepAlive.TabIndex = 25;
            // 
            // textBoxName
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(125, 161);
            this.textBox1.Name = "textBoxName";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(225, 27);
            this.textBox1.TabIndex = 1;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.submitBtn.Location = new System.Drawing.Point(1051, 343);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(106, 36);
            this.submitBtn.TabIndex = 32;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(808, 343);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(106, 36);
            this.CancelBtn.TabIndex = 33;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(930, 343);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(106, 36);
            this.Refresh.TabIndex = 34;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.submitBtn);
            this.groupBox1.Controls.Add(this.CancelBtn);
            this.groupBox1.Controls.Add(this.Refresh);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(67, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1193, 443);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration form";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox9);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.textBox7);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.File1path);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.File2path);
            this.panel2.Controls.Add(this.File3path);
            this.panel2.Controls.Add(this.File4path);
            this.panel2.Controls.Add(this.File5path);
            this.panel2.Location = new System.Drawing.Point(433, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 285);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxKeepAlive);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxLocation);
            this.panel1.Location = new System.Drawing.Point(26, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 285);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Path to config:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 27);
            this.textBox1.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Keep alive:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(461, 20);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(241, 27);
            this.textBox5.TabIndex = 22;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Keep alive:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(461, 62);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(241, 27);
            this.textBox6.TabIndex = 24;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(374, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Keep alive:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(461, 107);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(241, 27);
            this.textBox7.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(374, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Keep alive:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(461, 150);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(241, 27);
            this.textBox8.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(374, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Keep alive:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(461, 196);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(241, 27);
            this.textBox9.TabIndex = 30;
            // 
            // Form2
            // 
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 601);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void Button_Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }
        private void Button_Refresh_Click(object sender, System.EventArgs e)
        {
            var json = System.IO.File.ReadAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            this.textBoxName.Text = jsonObj.name;
            this.textBoxKeepAlive.Text = jsonObj.keepAlive;
            this.textBoxLocation.Text = jsonObj.location;
            this.textBox1.Text = jsonObj.path;
            this.File1path.Text = jsonObj.fileLocations.File1.path;
            this.File2path.Text = jsonObj.fileLocations.File2.path;
            this.File3path.Text = jsonObj.fileLocations.File3.path;
            this.File4path.Text = jsonObj.fileLocations.File4.path;
            this.File5path.Text = jsonObj.fileLocations.File5.path;
            this.textBox5.Text = jsonObj.fileLocations.File1.minutes;
            this.textBox6.Text = jsonObj.fileLocations.File2.minutes;
            this.textBox7.Text = jsonObj.fileLocations.File3.minutes;
            this.textBox8.Text = jsonObj.fileLocations.File4.minutes;
            this.textBox9.Text = jsonObj.fileLocations.File5.minutes;

        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            //zamijeniti prve dvije linije koda sa pozivom parsera
            var json = System.IO.File.ReadAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
         
            //jsonObj["name"] = this.textBoxName.Text;
            //jsonObj["keepAlive"] = Int32.Parse(this.textBoxKeepAlive.Text);
            //jsonObj["location"] = this.textBoxLocation.Text;
           // jsonObj["ip"] = this.textBoxIpAddress.Text;
           // jsonObj["webSocketUrl"] = this.textBoxWebSocket.Text;
           // jsonObj["pingUri"] = this.textBoxPingUri.Text;
            ComputerInfo comp = new ComputerInfo();
            comp.name= jsonObj.name;
            comp.keepAlive= jsonObj.keepAlive;
            comp.location= jsonObj.location;
            comp.deviceUid = jsonObj.deviceUid;
            comp.fileUri= jsonObj.fileUri;
            comp.errorUri = jsonObj.errorUri;
            comp.pingUri = jsonObj.pingUri;
            comp.webSocketUrl = jsonObj.webSocketUrl;
            comp.installationCode = null;
            comp.mainUri = jsonObj.mainUri;
            comp.path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            FileLocations f = new FileLocations();
            JASONParser.File newFile = new JASONParser.File();
            newFile.path = this.File1path.Text;
            newFile.minutes = double.Parse(this.textBox5.Text);
            f.File1 = newFile;
            JASONParser.File newFile2 = new JASONParser.File();
            newFile2.path = this.File2path.Text;
            newFile2.minutes = double.Parse(this.textBox6.Text);
            f.File2 = newFile2;
            JASONParser.File newFile3 = new JASONParser.File();
            newFile3.path = this.File3path.Text;
            newFile3.minutes = double.Parse(this.textBox7.Text);
            f.File3 = newFile3;
            JASONParser.File newFile4 = new JASONParser.File();
            newFile4.path = this.File4path.Text;
            newFile4.minutes = double.Parse(this.textBox8.Text);
            f.File4 = newFile4;
            JASONParser.File newFile5 = new JASONParser.File();
            newFile5.path = this.File5path.Text;
            newFile5.minutes = double.Parse(this.textBox9.Text);
            f.File5 = newFile5;

            comp.fileLocations = f;
            
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(comp, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json", output);
            Ping p = new Ping((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");

            if (Directory.Exists(File1path.Text) || System.IO.File.Exists(File1path.Text)) {
                File1path.BackColor = Color.White;
                if (File1path.Text != "" && textBox5.Text != "0") p.PostFilesAndKeepAlive(f.File1.path, double.Parse(this.textBox5.Text));
            }
            else if (!(Directory.Exists(File1path.Text) || System.IO.File.Exists(File1path.Text)) && File1path.Text != "")
            {
                File1path.Focus();
                File1path.Clear();
                File1path.BackColor = Color.LightPink;
            }
            if (Directory.Exists(File2path.Text) || System.IO.File.Exists(File2path.Text))
            {
                File2path.BackColor = Color.White;
                if (File2path.Text != "" && textBox6.Text != "0") p.PostFilesAndKeepAlive(f.File2.path, double.Parse(this.textBox6.Text));
            }
            else if (!(Directory.Exists(File2path.Text) || System.IO.File.Exists(File2path.Text)) && File2path.Text != "")
            {
                File2path.Focus();
                File2path.Clear();
                File2path.BackColor = Color.LightPink;
            }
            if (Directory.Exists(File3path.Text) || System.IO.File.Exists(File3path.Text))
            {
                File3path.BackColor = Color.White;
                if (File3path.Text != "" && textBox7.Text != "0") p.PostFilesAndKeepAlive(f.File3.path, double.Parse(this.textBox7.Text));
            }
            else if (!(Directory.Exists(File3path.Text) || System.IO.File.Exists(File3path.Text)) && File3path.Text != "")
            {
                File3path.Focus();
                File3path.Clear();
                File3path.BackColor = Color.LightPink;
            }
            if (Directory.Exists(File4path.Text) || System.IO.File.Exists(File4path.Text))
            {
                File4path.BackColor = Color.White;
                if (File4path.Text != "" && textBox8.Text != "0") p.PostFilesAndKeepAlive(f.File4.path, double.Parse(this.textBox8.Text));
            }
            else if (!(Directory.Exists(File4path.Text) || System.IO.File.Exists(File4path.Text)) && File4path.Text != "")
            {
                File4path.Focus();
                File4path.Clear();
                File4path.BackColor = Color.LightPink;
            }
            if (Directory.Exists(File5path.Text) || System.IO.File.Exists(File5path.Text))
            {
                File5path.BackColor = Color.White;
                if (File5path.Text != "" && textBox9.Text != "0") p.PostFilesAndKeepAlive(f.File5.path, double.Parse(this.textBox9.Text));
            }
            else if (!(Directory.Exists(File5path.Text) || System.IO.File.Exists(File5path.Text)) && File5path.Text != "")
            {
                File5path.Focus();
                File5path.Clear();
                File5path.BackColor = Color.LightPink;
            }
            p1.sendFile((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)), "config.json");
            //p1.conn();
        }
        #endregion

        private System.Windows.Forms.NotifyIcon iconNotify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox File1path;
        private System.Windows.Forms.TextBox File2path;
        private System.Windows.Forms.TextBox File3path;
        private System.Windows.Forms.TextBox File4path;
        private System.Windows.Forms.TextBox File5path;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxKeepAlive;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
    }

}