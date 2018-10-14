namespace GB
{
    partial class ChatItem
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
            this.edtUpdateInform = new GB.lbButton();
            this.edtText = new GB.TextboxWarp();
            this.cmsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsList
            // 
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCut,
            this.cmsCopy,
            this.toolStripSeparator1,
            this.cmsRefresh,
            this.cmsDelete});
            this.cmsList.Name = "cmsList";
            this.cmsList.Size = new System.Drawing.Size(114, 98);
            // 
            // cmsCut
            // 
            this.cmsCut.Name = "cmsCut";
            this.cmsCut.Size = new System.Drawing.Size(113, 22);
            this.cmsCut.Text = "Cut";
            this.cmsCut.Click += new System.EventHandler(this.cmsCut_Click);
            // 
            // cmsCopy
            // 
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.Size = new System.Drawing.Size(113, 22);
            this.cmsCopy.Text = "Copy ";
            this.cmsCopy.Click += new System.EventHandler(this.cmsCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(113, 22);
            this.cmsRefresh.Text = "Refresh";
            this.cmsRefresh.Click += new System.EventHandler(this.cmsRefresh_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(113, 22);
            this.cmsDelete.Text = "Delete";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDeletePCS_Click);
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
            this.edtUpdateInform.Location = new System.Drawing.Point(2, 2);
            this.edtUpdateInform.Name = "edtUpdateInform";
            this.edtUpdateInform.Size = new System.Drawing.Size(21, 19);
            this.edtUpdateInform.TabIndex = 2;
            this.edtUpdateInform.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtUpdateInform.UseCompatibleTextRendering = true;
            // 
            // edtText
            // 
            this.edtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtText.BackColor = System.Drawing.Color.Thistle;
            this.edtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtText.ContextMenuStrip = this.cmsList;
            this.edtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtText.Location = new System.Drawing.Point(24, 2);
            this.edtText.Margin = new System.Windows.Forms.Padding(5);
            this.edtText.Multiline = true;
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(140, 19);
            this.edtText.TabIndex = 1;
            this.edtText.Text = "Huy(1155) : Welcome!";
            this.edtText.TextChanged += new System.EventHandler(this.edtText_TextChanged);
            // 
            // ChatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsList;
            this.Controls.Add(this.edtUpdateInform);
            this.Controls.Add(this.edtText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChatItem";
            this.Size = new System.Drawing.Size(166, 23);
            this.SizeChanged += new System.EventHandler(this.ChatItem_SizeChanged);
            this.cmsList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsList;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        public TextboxWarp edtText;
        private System.Windows.Forms.ToolStripMenuItem cmsCut;
        private System.Windows.Forms.ToolStripMenuItem cmsCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private lbButton edtUpdateInform;

    }
}
