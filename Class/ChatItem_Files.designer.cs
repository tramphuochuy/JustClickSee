namespace GB
{
    partial class ChatItem_Files
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
            this.cmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.markClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edtUserCode = new System.Windows.Forms.Label();
            this.edtPic = new System.Windows.Forms.PictureBox();
            this.cmsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsList
            // 
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCut,
            this.cmsCopy,
            this.toolStripSeparator1,
            this.cmsRefresh,
            this.cmsDelete,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.markClearToolStripMenuItem});
            this.cmsList.Name = "cmsList";
            this.cmsList.Size = new System.Drawing.Size(141, 170);
            // 
            // cmsCut
            // 
            this.cmsCut.Name = "cmsCut";
            this.cmsCut.Size = new System.Drawing.Size(140, 22);
            this.cmsCut.Text = "Cut";
            this.cmsCut.Click += new System.EventHandler(this.cmsCut_Click);
            // 
            // cmsCopy
            // 
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.Size = new System.Drawing.Size(140, 22);
            this.cmsCopy.Text = "Copy ";
            this.cmsCopy.Click += new System.EventHandler(this.cmsCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(140, 22);
            this.cmsRefresh.Text = "Refresh";
            this.cmsRefresh.Click += new System.EventHandler(this.cmsRefresh_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(140, 22);
            this.cmsDelete.Text = "Delete";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDeletePCS_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.toolStripMenuItem1.Text = "Mark RED";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.RED_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
            this.toolStripMenuItem2.Text = "Mark GREEN";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.GREEN_Click);
            // 
            // markClearToolStripMenuItem
            // 
            this.markClearToolStripMenuItem.Name = "markClearToolStripMenuItem";
            this.markClearToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.markClearToolStripMenuItem.Text = "Mark Clear";
            this.markClearToolStripMenuItem.Click += new System.EventHandler(this.CLEARMARK_Click);
            // 
            // edtUserCode
            // 
            this.edtUserCode.AutoSize = true;
            this.edtUserCode.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserCode.ForeColor = System.Drawing.Color.Gray;
            this.edtUserCode.Location = new System.Drawing.Point(103, 13);
            this.edtUserCode.Margin = new System.Windows.Forms.Padding(5);
            this.edtUserCode.Name = "edtUserCode";
            this.edtUserCode.Size = new System.Drawing.Size(40, 17);
            this.edtUserCode.TabIndex = 5;
            this.edtUserCode.Text = "Admin";
            this.edtUserCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtPic
            // 
            this.edtPic.Location = new System.Drawing.Point(63, 6);
            this.edtPic.Name = "edtPic";
            this.edtPic.Size = new System.Drawing.Size(32, 32);
            this.edtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.edtPic.TabIndex = 6;
            this.edtPic.TabStop = false;
            this.edtPic.Click += new System.EventHandler(this.edtPic_Click);
            this.edtPic.MouseLeave += new System.EventHandler(this.edtPic_MouseLeave);
            this.edtPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChatItem_Image_MouseMove);
            // 
            // ChatItem_Files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContextMenuStrip = this.cmsList;
            this.Controls.Add(this.edtPic);
            this.Controls.Add(this.edtUserCode);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChatItem_Files";
            this.Size = new System.Drawing.Size(977, 43);
            this.SizeChanged += new System.EventHandler(this.ChatItem_SizeChanged);
            this.cmsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsList;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsCut;
        private System.Windows.Forms.ToolStripMenuItem cmsCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem markClearToolStripMenuItem;
        public System.Windows.Forms.Label edtUserCode;
        private System.Windows.Forms.PictureBox edtPic;

    }
}
