namespace GB
{
    partial class Config
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.apptranslate1 = new GB.APPTRANSLATE();
            this.panel4 = new System.Windows.Forms.Panel();
            this.edtTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbButton1 = new GB.lbButton();
            this.edtTarget2 = new GB.lbButton();
            this.edtTarget1 = new GB.lbButton();
            this.btnLangTarget = new GB.lbButton();
            this.edtShowException = new System.Windows.Forms.CheckBox();
            this.edtActiveTranslator = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLoadDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.panHead.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.cms.SuspendLayout();
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
            this.panHead.Size = new System.Drawing.Size(660, 1);
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
            this.lbClose.Location = new System.Drawing.Point(638, -1);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(22, 20);
            this.lbClose.TabIndex = 4;
            this.lbClose.Text = "      ";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClose.UseCompatibleTextRendering = true;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
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
            this.panel1.Size = new System.Drawing.Size(660, 379);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.apptranslate1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 291);
            this.panel3.TabIndex = 7;
            // 
            // apptranslate1
            // 
            this.apptranslate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apptranslate1.Location = new System.Drawing.Point(0, 25);
            this.apptranslate1.Name = "apptranslate1";
            this.apptranslate1.Size = new System.Drawing.Size(660, 266);
            this.apptranslate1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.Controls.Add(this.edtTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(660, 25);
            this.panel4.TabIndex = 7;
            // 
            // edtTitle
            // 
            this.edtTitle.AutoSize = true;
            this.edtTitle.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtTitle.ForeColor = System.Drawing.Color.Black;
            this.edtTitle.Location = new System.Drawing.Point(4, 2);
            this.edtTitle.Name = "edtTitle";
            this.edtTitle.Size = new System.Drawing.Size(132, 20);
            this.edtTitle.TabIndex = 3;
            this.edtTitle.Text = "Application Setup";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbButton1);
            this.panel2.Controls.Add(this.edtTarget2);
            this.panel2.Controls.Add(this.edtTarget1);
            this.panel2.Controls.Add(this.btnLangTarget);
            this.panel2.Controls.Add(this.edtShowException);
            this.panel2.Controls.Add(this.edtActiveTranslator);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 87);
            this.panel2.TabIndex = 6;
            // 
            // lbButton1
            // 
            this.lbButton1.AutoEllipsis = true;
            this.lbButton1.AutoSize = true;
            this.lbButton1.HAllowDisable = false;
            this.lbButton1.HisBorder = true;
            this.lbButton1.HisClickChange = true;
            this.lbButton1.HisDisable = false;
            this.lbButton1.HResourceImage = "";
            this.lbButton1.Image = global::GB.Properties.Resources.Trans16;
            this.lbButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbButton1.Location = new System.Drawing.Point(154, 59);
            this.lbButton1.Name = "lbButton1";
            this.lbButton1.Size = new System.Drawing.Size(118, 17);
            this.lbButton1.TabIndex = 41;
            this.lbButton1.Text = "      Target Language 2";
            this.lbButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbButton1.UseCompatibleTextRendering = true;
            // 
            // edtTarget2
            // 
            this.edtTarget2.AutoEllipsis = true;
            this.edtTarget2.AutoSize = true;
            this.edtTarget2.ForeColor = System.Drawing.Color.Green;
            this.edtTarget2.HAllowDisable = false;
            this.edtTarget2.HisBorder = true;
            this.edtTarget2.HisClickChange = true;
            this.edtTarget2.HisDisable = false;
            this.edtTarget2.HResourceImage = "";
            this.edtTarget2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtTarget2.Location = new System.Drawing.Point(281, 59);
            this.edtTarget2.Name = "edtTarget2";
            this.edtTarget2.Size = new System.Drawing.Size(58, 17);
            this.edtTarget2.TabIndex = 41;
            this.edtTarget2.Text = "en-English";
            this.edtTarget2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.edtTarget2.UseCompatibleTextRendering = true;
            this.edtTarget2.Click += new System.EventHandler(this.edtTarget2_Click);
            // 
            // edtTarget1
            // 
            this.edtTarget1.AutoEllipsis = true;
            this.edtTarget1.AutoSize = true;
            this.edtTarget1.ForeColor = System.Drawing.Color.Navy;
            this.edtTarget1.HAllowDisable = false;
            this.edtTarget1.HisBorder = true;
            this.edtTarget1.HisClickChange = true;
            this.edtTarget1.HisDisable = false;
            this.edtTarget1.HResourceImage = "";
            this.edtTarget1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtTarget1.Location = new System.Drawing.Point(281, 36);
            this.edtTarget1.Name = "edtTarget1";
            this.edtTarget1.Size = new System.Drawing.Size(82, 17);
            this.edtTarget1.TabIndex = 41;
            this.edtTarget1.Text = "vi-Vietnamnese";
            this.edtTarget1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.edtTarget1.UseCompatibleTextRendering = true;
            this.edtTarget1.Click += new System.EventHandler(this.edtTarget1_Click);
            // 
            // btnLangTarget
            // 
            this.btnLangTarget.AutoEllipsis = true;
            this.btnLangTarget.AutoSize = true;
            this.btnLangTarget.HAllowDisable = false;
            this.btnLangTarget.HisBorder = true;
            this.btnLangTarget.HisClickChange = true;
            this.btnLangTarget.HisDisable = false;
            this.btnLangTarget.HResourceImage = "";
            this.btnLangTarget.Image = global::GB.Properties.Resources.Trans16;
            this.btnLangTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLangTarget.Location = new System.Drawing.Point(154, 36);
            this.btnLangTarget.Name = "btnLangTarget";
            this.btnLangTarget.Size = new System.Drawing.Size(118, 17);
            this.btnLangTarget.TabIndex = 41;
            this.btnLangTarget.Text = "      Target Language 1";
            this.btnLangTarget.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLangTarget.UseCompatibleTextRendering = true;
            // 
            // edtShowException
            // 
            this.edtShowException.AutoSize = true;
            this.edtShowException.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtShowException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.edtShowException.Location = new System.Drawing.Point(18, 57);
            this.edtShowException.Name = "edtShowException";
            this.edtShowException.Size = new System.Drawing.Size(109, 19);
            this.edtShowException.TabIndex = 17;
            this.edtShowException.Text = "Show Exception";
            this.edtShowException.UseVisualStyleBackColor = true;
            // 
            // edtActiveTranslator
            // 
            this.edtActiveTranslator.AutoSize = true;
            this.edtActiveTranslator.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtActiveTranslator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.edtActiveTranslator.Location = new System.Drawing.Point(18, 35);
            this.edtActiveTranslator.Name = "edtActiveTranslator";
            this.edtActiveTranslator.Size = new System.Drawing.Size(66, 19);
            this.edtActiveTranslator.TabIndex = 17;
            this.edtActiveTranslator.Text = "Enabled";
            this.edtActiveTranslator.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(575, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(660, 26);
            this.panel5.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Options";
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
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(660, 379);
            this.Controls.Add(this.panel1);
            this.Name = "Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Config_Load);
            this.panHead.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private lbButton lbClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label edtTitle;
        public System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsLoadDevice;
        private System.Windows.Forms.CheckBox edtActiveTranslator;
        private APPTRANSLATE apptranslate1;
        private System.Windows.Forms.CheckBox edtShowException;
        private lbButton btnLangTarget;
        private lbButton lbButton1;
        private lbButton edtTarget2;
        private lbButton edtTarget1;
    }
}