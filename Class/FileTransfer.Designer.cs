namespace GB
{
    partial class FileTransfer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTransfer));
            this.edtFilePath = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.edtFilePath2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panContent1 = new GB.ColorPanelFlow();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSEND = new GB.lbButton();
            this.btnUp = new GB.lbButton();
            this.btnHome = new GB.lbButton();
            this.panContent2 = new GB.ColorPanelFlow();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome2 = new GB.lbButton();
            this.btnReceive = new GB.lbButton();
            this.btnUp2 = new GB.lbButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtFilePath
            // 
            this.edtFilePath.BackColor = System.Drawing.Color.Linen;
            this.edtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtFilePath.Location = new System.Drawing.Point(0, 425);
            this.edtFilePath.Multiline = true;
            this.edtFilePath.Name = "edtFilePath";
            this.edtFilePath.Size = new System.Drawing.Size(344, 20);
            this.edtFilePath.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.FILE_TRANSFER_LIST_Tick);
            // 
            // edtFilePath2
            // 
            this.edtFilePath2.BackColor = System.Drawing.Color.Linen;
            this.edtFilePath2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtFilePath2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtFilePath2.Location = new System.Drawing.Point(0, 425);
            this.edtFilePath2.Multiline = true;
            this.edtFilePath2.Name = "edtFilePath2";
            this.edtFilePath2.Size = new System.Drawing.Size(366, 20);
            this.edtFilePath2.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Linen;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panContent1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.edtFilePath);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panContent2);
            this.splitContainer1.Panel2.Controls.Add(this.edtFilePath2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(714, 445);
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.TabIndex = 15;
            // 
            // panContent1
            // 
            this.panContent1.AutoScroll = true;
            this.panContent1.AutoScrollMinSize = new System.Drawing.Size(250, 0);
            this.panContent1.BackColor = System.Drawing.Color.White;
            this.panContent1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent1.HisColor = 0;
            this.panContent1.Location = new System.Drawing.Point(0, 36);
            this.panContent1.Name = "panContent1";
            this.panContent1.Size = new System.Drawing.Size(344, 389);
            this.panContent1.TabIndex = 1;
            this.panContent1.MouseEnter += new System.EventHandler(this.panContents_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.Controls.Add(this.btnSEND);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 36);
            this.panel1.TabIndex = 0;
            // 
            // btnSEND
            // 
            this.btnSEND.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSEND.AutoEllipsis = true;
            this.btnSEND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEND.HAllowDisable = false;
            this.btnSEND.HisBorder = true;
            this.btnSEND.HisClickChange = true;
            this.btnSEND.HisDisable = false;
            this.btnSEND.HResourceImage = "";
            this.btnSEND.Image = global::GB.Properties.Resources.arrow_right_32;
            this.btnSEND.Location = new System.Drawing.Point(305, 9);
            this.btnSEND.Name = "btnSEND";
            this.btnSEND.Size = new System.Drawing.Size(36, 22);
            this.btnSEND.TabIndex = 13;
            this.btnSEND.Text = "      ";
            this.btnSEND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSEND.UseCompatibleTextRendering = true;
            this.btnSEND.Click += new System.EventHandler(this.SEND);
            // 
            // btnUp
            // 
            this.btnUp.AutoEllipsis = true;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.HAllowDisable = false;
            this.btnUp.HisBorder = true;
            this.btnUp.HisClickChange = true;
            this.btnUp.HisDisable = false;
            this.btnUp.HResourceImage = "";
            this.btnUp.Image = global::GB.Properties.Resources.folder_up_24;
            this.btnUp.Location = new System.Drawing.Point(48, 5);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(32, 28);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "        ";
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUp.UseCompatibleTextRendering = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnHome
            // 
            this.btnHome.AutoEllipsis = true;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.HAllowDisable = false;
            this.btnHome.HisBorder = true;
            this.btnHome.HisClickChange = true;
            this.btnHome.HisDisable = false;
            this.btnHome.HResourceImage = "";
            this.btnHome.Image = global::GB.Properties.Resources.go_home_24;
            this.btnHome.Location = new System.Drawing.Point(10, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(32, 28);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "        ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseCompatibleTextRendering = true;
            this.btnHome.Click += new System.EventHandler(this.HOME1_Click);
            // 
            // panContent2
            // 
            this.panContent2.AutoScroll = true;
            this.panContent2.AutoScrollMinSize = new System.Drawing.Size(250, 0);
            this.panContent2.BackColor = System.Drawing.Color.White;
            this.panContent2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panContent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent2.HisColor = 0;
            this.panContent2.Location = new System.Drawing.Point(0, 36);
            this.panContent2.Name = "panContent2";
            this.panContent2.Size = new System.Drawing.Size(366, 389);
            this.panContent2.TabIndex = 1;
            this.panContent2.MouseEnter += new System.EventHandler(this.panContent2_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.Controls.Add(this.btnHome2);
            this.panel2.Controls.Add(this.btnReceive);
            this.panel2.Controls.Add(this.btnUp2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 36);
            this.panel2.TabIndex = 0;
            // 
            // btnHome2
            // 
            this.btnHome2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome2.AutoEllipsis = true;
            this.btnHome2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome2.HAllowDisable = false;
            this.btnHome2.HisBorder = true;
            this.btnHome2.HisClickChange = true;
            this.btnHome2.HisDisable = false;
            this.btnHome2.HResourceImage = "";
            this.btnHome2.Image = global::GB.Properties.Resources.go_home_24;
            this.btnHome2.Location = new System.Drawing.Point(288, 5);
            this.btnHome2.Name = "btnHome2";
            this.btnHome2.Size = new System.Drawing.Size(32, 28);
            this.btnHome2.TabIndex = 8;
            this.btnHome2.Text = "        ";
            this.btnHome2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome2.UseCompatibleTextRendering = true;
            this.btnHome2.Click += new System.EventHandler(this.HOME2_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.AutoEllipsis = true;
            this.btnReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceive.HAllowDisable = false;
            this.btnReceive.HisBorder = true;
            this.btnReceive.HisClickChange = true;
            this.btnReceive.HisDisable = false;
            this.btnReceive.HResourceImage = "";
            this.btnReceive.Image = global::GB.Properties.Resources.arrow_left_32;
            this.btnReceive.Location = new System.Drawing.Point(0, 9);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(41, 22);
            this.btnReceive.TabIndex = 14;
            this.btnReceive.Text = "         ";
            this.btnReceive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceive.UseCompatibleTextRendering = true;
            this.btnReceive.Click += new System.EventHandler(this.RECEIVE);
            // 
            // btnUp2
            // 
            this.btnUp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp2.AutoEllipsis = true;
            this.btnUp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp2.HAllowDisable = false;
            this.btnUp2.HisBorder = true;
            this.btnUp2.HisClickChange = true;
            this.btnUp2.HisDisable = false;
            this.btnUp2.HResourceImage = "";
            this.btnUp2.Image = global::GB.Properties.Resources.folder_up_24;
            this.btnUp2.Location = new System.Drawing.Point(326, 5);
            this.btnUp2.Name = "btnUp2";
            this.btnUp2.Size = new System.Drawing.Size(32, 28);
            this.btnUp2.TabIndex = 9;
            this.btnUp2.Text = "        ";
            this.btnUp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUp2.UseCompatibleTextRendering = true;
            this.btnUp2.Click += new System.EventHandler(this.UP2_Click);
            // 
            // FileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 445);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileTransfer_FormClosing);
            this.Load += new System.EventHandler(this.FileExplorer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private lbButton btnHome;
        private lbButton btnUp;
        private ColorPanelFlow panContent1;
        public System.Windows.Forms.TextBox edtFilePath;
        private System.Windows.Forms.Timer timer1;
        private ColorPanelFlow panContent2;
        private lbButton btnUp2;
        private lbButton btnHome2;
        public System.Windows.Forms.TextBox edtFilePath2;
        private lbButton btnReceive;
        private lbButton btnSEND;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}
