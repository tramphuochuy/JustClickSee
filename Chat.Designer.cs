namespace GB
{
    partial class Chat
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.edtUpdateInform = new GB.lbButton();
            this.panMain = new System.Windows.Forms.Panel();
            this.panChat = new GB.ColorPanelFlow();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtChat = new System.Windows.Forms.TextBox();
            this.cmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panHead.SuspendLayout();
            this.panMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.Tan;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Controls.Add(this.panel2);
            this.panHead.Controls.Add(this.Title);
            this.panHead.Controls.Add(this.edtUpdateInform);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(327, 42);
            this.panHead.TabIndex = 3;
            this.panHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseDown);
            this.panHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 10);
            this.panel2.TabIndex = 7;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(26, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(78, 19);
            this.Title.TabIndex = 5;
            this.Title.Text = "Public chat";
            // 
            // edtUpdateInform
            // 
            this.edtUpdateInform.AutoEllipsis = true;
            this.edtUpdateInform.BackColor = System.Drawing.Color.Transparent;
            this.edtUpdateInform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUpdateInform.HAllowDisable = false;
            this.edtUpdateInform.HisBorder = false;
            this.edtUpdateInform.HisClickChange = false;
            this.edtUpdateInform.HisDisable = false;
            this.edtUpdateInform.HResourceImage = "";
            this.edtUpdateInform.Image = global::GB.Properties.Resources.chat_16;
            this.edtUpdateInform.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtUpdateInform.Location = new System.Drawing.Point(2, 4);
            this.edtUpdateInform.Name = "edtUpdateInform";
            this.edtUpdateInform.Size = new System.Drawing.Size(21, 19);
            this.edtUpdateInform.TabIndex = 6;
            this.edtUpdateInform.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtUpdateInform.UseCompatibleTextRendering = true;
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.Snow;
            this.panMain.Controls.Add(this.panChat);
            this.panMain.Controls.Add(this.panel1);
            this.panMain.Controls.Add(this.panHead);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(327, 445);
            this.panMain.TabIndex = 7;
            // 
            // panChat
            // 
            this.panChat.AllowDrop = true;
            this.panChat.AutoScroll = true;
            this.panChat.BackColor = System.Drawing.Color.White;
            this.panChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panChat.HisColor = 0;
            this.panChat.Location = new System.Drawing.Point(0, 42);
            this.panChat.Margin = new System.Windows.Forms.Padding(0);
            this.panChat.Name = "panChat";
            this.panChat.Size = new System.Drawing.Size(327, 361);
            this.panChat.TabIndex = 0;
            this.panChat.WrapContents = false;
            this.panChat.DragDrop += new System.Windows.Forms.DragEventHandler(this.panChat_DragDrop);
            this.panChat.DragEnter += new System.Windows.Forms.DragEventHandler(this.panChat_DragEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.edtChat);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 42);
            this.panel1.TabIndex = 8;
            // 
            // edtChat
            // 
            this.edtChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtChat.BackColor = System.Drawing.Color.White;
            this.edtChat.ContextMenuStrip = this.cmsList;
            this.edtChat.Location = new System.Drawing.Point(3, 3);
            this.edtChat.Multiline = true;
            this.edtChat.Name = "edtChat";
            this.edtChat.Size = new System.Drawing.Size(208, 36);
            this.edtChat.TabIndex = 0;
            this.edtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPassword_KeyDown);
            // 
            // cmsList
            // 
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCut,
            this.cmsCopy,
            this.toolStripSeparator1,
            this.undoToolStripMenuItem,
            this.cmsDelete});
            this.cmsList.Name = "cmsList";
            this.cmsList.Size = new System.Drawing.Size(158, 98);
            // 
            // cmsCut
            // 
            this.cmsCut.Name = "cmsCut";
            this.cmsCut.Size = new System.Drawing.Size(157, 22);
            this.cmsCut.Text = "Cut";
            this.cmsCut.Click += new System.EventHandler(this.cmsCut_Click);
            // 
            // cmsCopy
            // 
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.Size = new System.Drawing.Size(157, 22);
            this.cmsCopy.Text = "Copy ";
            this.cmsCopy.Click += new System.EventHandler(this.cmsCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.undoToolStripMenuItem.Text = "Undo ( Crt + Z )";
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(157, 22);
            this.cmsDelete.Text = "Delete";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.Location = new System.Drawing.Point(215, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 37);
            this.btnOK.TabIndex = 1;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(327, 445);
            this.Controls.Add(this.panMain);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.LocationChanged += new System.EventHandler(this.Chat_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Chat_SizeChanged);
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            this.panMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        public System.Windows.Forms.Label Title;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.TextBox edtChat;
        private ColorPanelFlow panChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip cmsList;
        private System.Windows.Forms.ToolStripMenuItem cmsCut;
        private System.Windows.Forms.ToolStripMenuItem cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private lbButton edtUpdateInform;
        private System.Windows.Forms.Panel panel2;
    }
}