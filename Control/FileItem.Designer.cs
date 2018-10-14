namespace GB
{
    partial class FileItem
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbIcon = new System.Windows.Forms.Label();
            this.colorPanel2 = new GB.ColorPanel();
            this.lbText = new System.Windows.Forms.Label();
            this.panSize = new GB.ColorPanel();
            this.lbSize = new System.Windows.Forms.Label();
            this.colorPanel1 = new GB.ColorPanel();
            this.panRight = new GB.ColorPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.colorPanel2.SuspendLayout();
            this.panSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTransfer,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.cmsOpen,
            this.refreshToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 120);
            // 
            // cmsTransfer
            // 
            this.cmsTransfer.Name = "cmsTransfer";
            this.cmsTransfer.Size = new System.Drawing.Size(117, 22);
            this.cmsTransfer.Text = "Transfer";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // cmsOpen
            // 
            this.cmsOpen.Name = "cmsOpen";
            this.cmsOpen.Size = new System.Drawing.Size(117, 22);
            this.cmsOpen.Text = "Open";
            this.cmsOpen.Click += new System.EventHandler(this.cmsOpen_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // lbIcon
            // 
            this.lbIcon.BackColor = System.Drawing.Color.Transparent;
            this.lbIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.lbIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIcon.Image = global::GB.Properties.Resources.Hardisk;
            this.lbIcon.Location = new System.Drawing.Point(0, -4);
            this.lbIcon.Name = "lbIcon";
            this.lbIcon.Size = new System.Drawing.Size(24, 24);
            this.lbIcon.TabIndex = 0;
            this.lbIcon.Text = "     ";
            this.lbIcon.Click += new System.EventHandler(this.lbText_Click);
            this.lbIcon.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // colorPanel2
            // 
            this.colorPanel2.ContextMenuStrip = this.contextMenuStrip1;
            this.colorPanel2.Controls.Add(this.lbText);
            this.colorPanel2.Controls.Add(this.panSize);
            this.colorPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanel2.HisColor = 0;
            this.colorPanel2.Location = new System.Drawing.Point(25, 0);
            this.colorPanel2.Name = "colorPanel2";
            this.colorPanel2.Size = new System.Drawing.Size(186, 18);
            this.colorPanel2.TabIndex = 2;
            this.colorPanel2.Click += new System.EventHandler(this.lbText_Click);
            this.colorPanel2.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.ContextMenuStrip = this.contextMenuStrip1;
            this.lbText.Location = new System.Drawing.Point(5, 3);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(69, 13);
            this.lbText.TabIndex = 4;
            this.lbText.Text = "My Computer";
            this.lbText.Click += new System.EventHandler(this.lbText_Click);
            this.lbText.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // panSize
            // 
            this.panSize.ContextMenuStrip = this.contextMenuStrip1;
            this.panSize.Controls.Add(this.lbSize);
            this.panSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.panSize.HisColor = 0;
            this.panSize.Location = new System.Drawing.Point(138, 0);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(48, 18);
            this.panSize.TabIndex = 3;
            this.panSize.Click += new System.EventHandler(this.lbText_Click);
            this.panSize.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(3, 3);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(37, 13);
            this.lbSize.TabIndex = 5;
            this.lbSize.Text = "2,2Mb";
            this.lbSize.Click += new System.EventHandler(this.lbText_Click);
            this.lbSize.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // colorPanel1
            // 
            this.colorPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorPanel1.HisColor = 0;
            this.colorPanel1.Location = new System.Drawing.Point(0, 0);
            this.colorPanel1.Name = "colorPanel1";
            this.colorPanel1.Size = new System.Drawing.Size(25, 18);
            this.colorPanel1.TabIndex = 1;
            this.colorPanel1.Click += new System.EventHandler(this.lbText_Click);
            this.colorPanel1.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // panRight
            // 
            this.panRight.ContextMenuStrip = this.contextMenuStrip1;
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.HisColor = 0;
            this.panRight.Location = new System.Drawing.Point(211, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(0, 18);
            this.panRight.TabIndex = 2;
            this.panRight.Click += new System.EventHandler(this.lbText_Click);
            this.panRight.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            // 
            // FileItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.colorPanel2);
            this.Controls.Add(this.lbIcon);
            this.Controls.Add(this.colorPanel1);
            this.Controls.Add(this.panRight);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.Name = "FileItem";
            this.Size = new System.Drawing.Size(211, 18);
            this.contextMenuStrip1.ResumeLayout(false);
            this.colorPanel2.ResumeLayout(false);
            this.colorPanel2.PerformLayout();
            this.panSize.ResumeLayout(false);
            this.panSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorPanel colorPanel1;
        private ColorPanel colorPanel2;
        private ColorPanel panSize;
        public System.Windows.Forms.Label lbIcon;
        public ColorPanel panRight;
        public System.Windows.Forms.Label lbText;
        public System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsTransfer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsOpen;
    }
}
