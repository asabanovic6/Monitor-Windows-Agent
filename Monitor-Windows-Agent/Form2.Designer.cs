
using JASONParser;
using System;
using System.IO;
using ImageSender;

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
            var json = File.ReadAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            this.textBoxName.Text = jsonObj.name;
            this.textBoxKeepAlive.Text = jsonObj.keepAlive;
            this.textBoxLocation.Text = jsonObj.location;
            this.File1path.Text = jsonObj.fileLocations.File1;
            this.File2path.Text = jsonObj.fileLocations.File2;
            this.File3path.Text = jsonObj.fileLocations.File3;
            this.File4path.Text = jsonObj.fileLocations.File4;
            this.File5path.Text = jsonObj.fileLocations.File5;

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
            this.submitBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.textBoxName.Location = new System.Drawing.Point(100, 20);
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
            this.File1path.ReadOnly = true;
            this.File1path.Size = new System.Drawing.Size(241, 27);
            this.File1path.TabIndex = 11;
            this.File1path.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(310, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // File2path
            // 
            this.File2path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File2path.Location = new System.Drawing.Point(63, 63);
            this.File2path.Name = "File2path";
            this.File2path.ReadOnly = true;
            this.File2path.Size = new System.Drawing.Size(241, 27);
            this.File2path.TabIndex = 13;
            // 
            // File3path
            // 
            this.File3path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File3path.Location = new System.Drawing.Point(63, 110);
            this.File3path.Name = "File3path";
            this.File3path.ReadOnly = true;
            this.File3path.Size = new System.Drawing.Size(241, 27);
            this.File3path.TabIndex = 14;
            // 
            // File4path
            // 
            this.File4path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File4path.Location = new System.Drawing.Point(63, 154);
            this.File4path.Name = "File4path";
            this.File4path.ReadOnly = true;
            this.File4path.Size = new System.Drawing.Size(241, 27);
            this.File4path.TabIndex = 15;
            // 
            // File5path
            // 
            this.File5path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.File5path.Location = new System.Drawing.Point(63, 199);
            this.File5path.Name = "File5path";
            this.File5path.ReadOnly = true;
            this.File5path.Size = new System.Drawing.Size(241, 27);
            this.File5path.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(310, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 27);
            this.button2.TabIndex = 17;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(310, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 27);
            this.button3.TabIndex = 18;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(310, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 27);
            this.button4.TabIndex = 19;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Location = new System.Drawing.Point(310, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 27);
            this.button5.TabIndex = 20;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.textBoxLocation.Location = new System.Drawing.Point(100, 67);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.ReadOnly = true;
            this.textBoxLocation.Size = new System.Drawing.Size(225, 27);
            this.textBoxLocation.TabIndex = 24;
            this.textBoxLocation.TextChanged += new System.EventHandler(this.textBoxLocation_TextChanged);
            // 
            // textBoxKeepAlive
            // 
            this.textBoxKeepAlive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxKeepAlive.Location = new System.Drawing.Point(100, 114);
            this.textBoxKeepAlive.Name = "textBoxKeepAlive";
            this.textBoxKeepAlive.ReadOnly = true;
            this.textBoxKeepAlive.Size = new System.Drawing.Size(225, 27);
            this.textBoxKeepAlive.TabIndex = 25;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.submitBtn.Location = new System.Drawing.Point(655, 343);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(106, 36);
            this.submitBtn.TabIndex = 32;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(422, 343);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(106, 36);
            this.CancelBtn.TabIndex = 33;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(538, 343);
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
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 401);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration form";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.File1path);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.File2path);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.File3path);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.File4path);
            this.panel2.Controls.Add(this.File5path);
            this.panel2.Location = new System.Drawing.Point(394, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 285);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxKeepAlive);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxLocation);
            this.panel1.Location = new System.Drawing.Point(26, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 285);
            this.panel1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AcceptButton = this.button4;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 481);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
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
            var json = File.ReadAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            this.textBoxName.Text = jsonObj.name;
            this.textBoxKeepAlive.Text = jsonObj.keepAlive;
            this.textBoxLocation.Text = jsonObj.location;
            this.File1path.Text = jsonObj.fileLocations.File1;
            this.File2path.Text = jsonObj.fileLocations.File2;
            this.File3path.Text = jsonObj.fileLocations.File3;
            this.File4path.Text = jsonObj.fileLocations.File4;
            this.File5path.Text = jsonObj.fileLocations.File5;

        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            //zamijeniti prve dvije linije koda sa pozivom parsera
            var json = File.ReadAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json");
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
            comp.pingUri = jsonObj.pingUri;
            comp.webSocketUrl = jsonObj.webSocketUrl;
            comp.installationCode = null;
            comp.mainUri = jsonObj.mainUri;
            FileLocations f = new FileLocations();
            f.File1 = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            f.File2 = this.File2path.Text;
            f.File3 = this.File3path.Text;
            f.File4 = this.File4path.Text;
            f.File5 = this.File5path.Text;
            comp.fileLocations = f;
            
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(comp, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\config.json", output);

           
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
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }

}