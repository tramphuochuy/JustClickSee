namespace GB
{
    partial class FileDownload
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
            this.lbHead = new System.Windows.Forms.Label();
            this.edtFileName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panHead.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Controls.Add(this.lbClose);
            this.panHead.Controls.Add(this.lbHead);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(291, 25);
            this.panHead.TabIndex = 3;
            this.panHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseDown);
            this.panHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseUp);
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
            this.lbClose.Location = new System.Drawing.Point(267, 2);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(22, 20);
            this.lbClose.TabIndex = 4;
            this.lbClose.Text = "      ";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClose.UseCompatibleTextRendering = true;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // lbHead
            // 
            this.lbHead.AutoSize = true;
            this.lbHead.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHead.ForeColor = System.Drawing.Color.White;
            this.lbHead.Image = global::GB.Properties.Resources.WApp;
            this.lbHead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHead.Location = new System.Drawing.Point(4, 2);
            this.lbHead.Name = "lbHead";
            this.lbHead.Size = new System.Drawing.Size(125, 20);
            this.lbHead.TabIndex = 3;
            this.lbHead.Text = "     Downloading...";
            // 
            // edtFileName
            // 
            this.edtFileName.AutoSize = true;
            this.edtFileName.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtFileName.ForeColor = System.Drawing.Color.SeaGreen;
            this.edtFileName.Location = new System.Drawing.Point(22, 39);
            this.edtFileName.Name = "edtFileName";
            this.edtFileName.Size = new System.Drawing.Size(83, 15);
            this.edtFileName.TabIndex = 5;
            this.edtFileName.Text = "Huy.txt   ?kb/s";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.panHead);
            this.panel1.Controls.Add(this.edtFileName);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 116);
            this.panel1.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 58);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(244, 12);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(190, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel  ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.TIMER_STATUS_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            // 
            // FileDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(295, 119);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileDownload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloader";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FileTransfer_Process_Load);
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHead;
        private lbButton lbClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label edtFileName;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lbHead;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer2;
    }
}