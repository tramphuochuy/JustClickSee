namespace GB
{
    partial class PCTConfig
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panHead = new System.Windows.Forms.Panel();
            this.lbClose = new GB.lbButton();
            this.edtText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.edtIntervalWall = new System.Windows.Forms.TextBox();
            this.edtWallPapper = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edtMirrorDriver = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtSoundDevice = new System.Windows.Forms.TextBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLoadDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.edtDisableAreo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtDisableWindowsLock = new System.Windows.Forms.CheckBox();
            this.edtAutoUpdateWhenStart = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtLockAfterSession = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.edtTitle = new System.Windows.Forms.Label();
            this.edtAutoLogon = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.edtNickName = new System.Windows.Forms.TextBox();
            this.edtActiveTranslator = new System.Windows.Forms.CheckBox();
            this.panHead.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cms.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.SeaGreen;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Controls.Add(this.lbClose);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(820, 1);
            this.panHead.TabIndex = 3;
            // 
            // lbClose
            // 
            this.lbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClose.AutoEllipsis = true;
            this.lbClose.HAllowDisable = false;
            this.lbClose.HisBorder = true;
            this.lbClose.HisClickChange = true;
            this.lbClose.HisDisable = false;
            this.lbClose.HResourceImage = "";
            this.lbClose.Image = global::GB.Properties.Resources.close23_16;
            this.lbClose.Location = new System.Drawing.Point(798, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(22, 20);
            this.lbClose.TabIndex = 4;
            this.lbClose.Text = "      ";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClose.UseCompatibleTextRendering = true;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // edtText
            // 
            this.edtText.AutoSize = true;
            this.edtText.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtText.Location = new System.Drawing.Point(16, 38);
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(181, 15);
            this.edtText.TabIndex = 5;
            this.edtText.Text = "Your personal password ( Remote )";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panHead);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 529);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.edtActiveTranslator);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.edtIntervalWall);
            this.panel3.Controls.Add(this.edtWallPapper);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.edtMirrorDriver);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.edtSoundDevice);
            this.panel3.Controls.Add(this.edtDisableAreo);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.edtDisableWindowsLock);
            this.panel3.Controls.Add(this.edtAutoUpdateWhenStart);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.edtLockAfterSession);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.edtAutoLogon);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(820, 396);
            this.panel3.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(268, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "( second )";
            // 
            // edtIntervalWall
            // 
            this.edtIntervalWall.Location = new System.Drawing.Point(176, 257);
            this.edtIntervalWall.Name = "edtIntervalWall";
            this.edtIntervalWall.Size = new System.Drawing.Size(86, 20);
            this.edtIntervalWall.TabIndex = 9;
            // 
            // edtWallPapper
            // 
            this.edtWallPapper.AutoSize = true;
            this.edtWallPapper.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtWallPapper.ForeColor = System.Drawing.Color.DarkGreen;
            this.edtWallPapper.Location = new System.Drawing.Point(19, 258);
            this.edtWallPapper.Name = "edtWallPapper";
            this.edtWallPapper.Size = new System.Drawing.Size(151, 19);
            this.edtWallPapper.TabIndex = 16;
            this.edtWallPapper.Text = "Wallpaper Change every";
            this.edtWallPapper.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(425, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Sound Toogle Device ( recomment edit name of SoundDevice , click to see image )";
            this.label8.Click += new System.EventHandler(this.Help_SetNameSoundDevice_Click);
            // 
            // edtMirrorDriver
            // 
            this.edtMirrorDriver.AutoSize = true;
            this.edtMirrorDriver.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtMirrorDriver.ForeColor = System.Drawing.Color.DarkGreen;
            this.edtMirrorDriver.Location = new System.Drawing.Point(18, 40);
            this.edtMirrorDriver.Name = "edtMirrorDriver";
            this.edtMirrorDriver.Size = new System.Drawing.Size(120, 19);
            this.edtMirrorDriver.TabIndex = 15;
            this.edtMirrorDriver.Text = "Use Mirror Driver";
            this.edtMirrorDriver.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(326, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(277, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "( Remove wallpaper , areo theme to increase latency )";
            // 
            // edtSoundDevice
            // 
            this.edtSoundDevice.ContextMenuStrip = this.cms;
            this.edtSoundDevice.Enabled = false;
            this.edtSoundDevice.ForeColor = System.Drawing.Color.Gray;
            this.edtSoundDevice.Location = new System.Drawing.Point(19, 223);
            this.edtSoundDevice.Name = "edtSoundDevice";
            this.edtSoundDevice.Size = new System.Drawing.Size(634, 20);
            this.edtSoundDevice.TabIndex = 10;
            this.edtSoundDevice.Text = "Headphone,Speakers";
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLoadDevice});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(147, 26);
            // 
            // cmsLoadDevice
            // 
            this.cmsLoadDevice.Name = "cmsLoadDevice";
            this.cmsLoadDevice.Size = new System.Drawing.Size(146, 22);
            this.cmsLoadDevice.Text = "Show Devices";
            this.cmsLoadDevice.Click += new System.EventHandler(this.cmsLoadDevice_Click);
            // 
            // edtDisableAreo
            // 
            this.edtDisableAreo.AutoSize = true;
            this.edtDisableAreo.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDisableAreo.ForeColor = System.Drawing.Color.Navy;
            this.edtDisableAreo.Location = new System.Drawing.Point(18, 175);
            this.edtDisableAreo.Name = "edtDisableAreo";
            this.edtDisableAreo.Size = new System.Drawing.Size(277, 19);
            this.edtDisableAreo.TabIndex = 9;
            this.edtDisableAreo.Text = "Disable Wallpaper and Areo Theme when connect";
            this.edtDisableAreo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(326, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "( Stop user from screen lock while Remote )";
            // 
            // edtDisableWindowsLock
            // 
            this.edtDisableWindowsLock.AutoSize = true;
            this.edtDisableWindowsLock.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDisableWindowsLock.ForeColor = System.Drawing.Color.Navy;
            this.edtDisableWindowsLock.Location = new System.Drawing.Point(18, 148);
            this.edtDisableWindowsLock.Name = "edtDisableWindowsLock";
            this.edtDisableWindowsLock.Size = new System.Drawing.Size(217, 19);
            this.edtDisableWindowsLock.TabIndex = 13;
            this.edtDisableWindowsLock.Text = "Disable Window Lock ( Windows + L )";
            this.edtDisableWindowsLock.UseVisualStyleBackColor = true;
            this.edtDisableWindowsLock.Click += new System.EventHandler(this.edtWindowsLock_Click);
            // 
            // edtAutoUpdateWhenStart
            // 
            this.edtAutoUpdateWhenStart.AutoSize = true;
            this.edtAutoUpdateWhenStart.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtAutoUpdateWhenStart.ForeColor = System.Drawing.Color.Navy;
            this.edtAutoUpdateWhenStart.Location = new System.Drawing.Point(18, 121);
            this.edtAutoUpdateWhenStart.Name = "edtAutoUpdateWhenStart";
            this.edtAutoUpdateWhenStart.Size = new System.Drawing.Size(239, 19);
            this.edtAutoUpdateWhenStart.TabIndex = 11;
            this.edtAutoUpdateWhenStart.Text = "Auto update when start ( Not Recomment )";
            this.edtAutoUpdateWhenStart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(326, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "(  Auto lock desktop when session is finished )";
            // 
            // edtLockAfterSession
            // 
            this.edtLockAfterSession.AutoSize = true;
            this.edtLockAfterSession.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtLockAfterSession.ForeColor = System.Drawing.Color.Navy;
            this.edtLockAfterSession.Location = new System.Drawing.Point(18, 94);
            this.edtLockAfterSession.Name = "edtLockAfterSession";
            this.edtLockAfterSession.Size = new System.Drawing.Size(207, 19);
            this.edtLockAfterSession.TabIndex = 9;
            this.edtLockAfterSession.Text = "Lock desktop when session finished";
            this.edtLockAfterSession.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(326, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Allow use Mirro driver to increase speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(326, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "( Force Window Logon Sign-In and Replace by custome Logon )";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.Controls.Add(this.edtTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(820, 25);
            this.panel4.TabIndex = 7;
            // 
            // edtTitle
            // 
            this.edtTitle.AutoSize = true;
            this.edtTitle.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtTitle.ForeColor = System.Drawing.Color.White;
            this.edtTitle.Location = new System.Drawing.Point(4, 2);
            this.edtTitle.Name = "edtTitle";
            this.edtTitle.Size = new System.Drawing.Size(77, 20);
            this.edtTitle.TabIndex = 3;
            this.edtTitle.Text = "Advanced";
            // 
            // edtAutoLogon
            // 
            this.edtAutoLogon.AutoSize = true;
            this.edtAutoLogon.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtAutoLogon.ForeColor = System.Drawing.Color.Green;
            this.edtAutoLogon.Location = new System.Drawing.Point(18, 67);
            this.edtAutoLogon.Name = "edtAutoLogon";
            this.edtAutoLogon.Size = new System.Drawing.Size(87, 19);
            this.edtAutoLogon.TabIndex = 0;
            this.edtAutoLogon.Text = "Auto Log-on";
            this.edtAutoLogon.UseVisualStyleBackColor = true;
            this.edtAutoLogon.Click += new System.EventHandler(this.edtAutoLogon_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(19, 329);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 35);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.edtText);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.edtPassword);
            this.panel2.Controls.Add(this.edtNickName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 132);
            this.panel2.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SeaGreen;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(820, 26);
            this.panel5.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Nickname ( Chat )";
            this.label1.Click += new System.EventHandler(this.CHAT_Click);
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(19, 56);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(212, 20);
            this.edtPassword.TabIndex = 1;
            // 
            // edtNickName
            // 
            this.edtNickName.Location = new System.Drawing.Point(19, 97);
            this.edtNickName.Name = "edtNickName";
            this.edtNickName.Size = new System.Drawing.Size(212, 20);
            this.edtNickName.TabIndex = 0;
            // 
            // edtActiveTranslator
            // 
            this.edtActiveTranslator.AutoSize = true;
            this.edtActiveTranslator.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtActiveTranslator.ForeColor = System.Drawing.Color.Blue;
            this.edtActiveTranslator.Location = new System.Drawing.Point(19, 293);
            this.edtActiveTranslator.Name = "edtActiveTranslator";
            this.edtActiveTranslator.Size = new System.Drawing.Size(115, 19);
            this.edtActiveTranslator.TabIndex = 17;
            this.edtActiveTranslator.Text = "Translataor ( F2 )";
            this.edtActiveTranslator.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(820, 529);
            this.Controls.Add(this.panel1);
            this.Name = "Config";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Config_Load);
            this.panHead.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cms.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private lbButton lbClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label edtText;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.TextBox edtNickName;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox edtAutoLogon;
        public System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label edtTitle;
        public System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox edtLockAfterSession;
        private System.Windows.Forms.CheckBox edtAutoUpdateWhenStart;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox edtDisableWindowsLock;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox edtDisableAreo;
        private System.Windows.Forms.CheckBox edtMirrorDriver;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edtSoundDevice;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsLoadDevice;
        private System.Windows.Forms.TextBox edtIntervalWall;
        private System.Windows.Forms.CheckBox edtWallPapper;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox edtActiveTranslator;
    }
}