namespace GB
{
    partial class PCS
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
            this.cmsRemotePCS = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFileTransferPCS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.edtEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeletePCS = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBundle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBundleRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.lbText = new GB.lbButton3();
            this.cmsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsList
            // 
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRemotePCS,
            this.cmsFileTransferPCS,
            this.toolStripSeparator1,
            this.edtEdit,
            this.cmsDeletePCS,
            this.cmsRefresh,
            this.toolStripSeparator2,
            this.cmsBundle,
            this.cmsBundleRemote});
            this.cmsList.Name = "cmsList";
            this.cmsList.Size = new System.Drawing.Size(156, 170);
            // 
            // cmsRemotePCS
            // 
          
            this.cmsRemotePCS.Name = "cmsRemotePCS";
            this.cmsRemotePCS.Size = new System.Drawing.Size(155, 22);
            this.cmsRemotePCS.Text = "Remote";
            this.cmsRemotePCS.Click += new System.EventHandler(this.cmsRemotePCS_Click);
            // 
            // cmsFileTransferPCS
            // 
            this.cmsFileTransferPCS.Image = global::GB.Properties.Resources.Tranfer2;
            this.cmsFileTransferPCS.Name = "cmsFileTransferPCS";
            this.cmsFileTransferPCS.Size = new System.Drawing.Size(155, 22);
            this.cmsFileTransferPCS.Text = "File Transfer";
            this.cmsFileTransferPCS.Click += new System.EventHandler(this.cmsFileTransferPCS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // edtEdit
            // 
            this.edtEdit.Image = global::GB.Properties.Resources.pencil_16;
            this.edtEdit.Name = "edtEdit";
            this.edtEdit.Size = new System.Drawing.Size(155, 22);
            this.edtEdit.Text = "Edit";
            this.edtEdit.Click += new System.EventHandler(this.edtEdit_Click);
            // 
            // cmsDeletePCS
            // 
            this.cmsDeletePCS.Image = global::GB.Properties.Resources.DeleteRed;
            this.cmsDeletePCS.Name = "cmsDeletePCS";
            this.cmsDeletePCS.Size = new System.Drawing.Size(155, 22);
            this.cmsDeletePCS.Text = "Delete";
            this.cmsDeletePCS.Click += new System.EventHandler(this.cmsDeletePCS_Click);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(155, 22);
            this.cmsRefresh.Text = "Refresh";
            this.cmsRefresh.Click += new System.EventHandler(this.cmsRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // cmsBundle
            // 
            this.cmsBundle.Image = global::GB.Properties.Resources.Bundle24;
            this.cmsBundle.Name = "cmsBundle";
            this.cmsBundle.Size = new System.Drawing.Size(155, 22);
            this.cmsBundle.Text = "Bundle Setup";
            this.cmsBundle.Click += new System.EventHandler(this.cmsBundle_Click);
            // 
            // cmsBundleRemote
            // 
            this.cmsBundleRemote.Name = "cmsBundleRemote";
            this.cmsBundleRemote.Size = new System.Drawing.Size(155, 22);
            this.cmsBundleRemote.Text = "Bundle Remote";
            this.cmsBundleRemote.Click += new System.EventHandler(this.cmsBundleRemote_Click);
            // 
            // lbText
            // 
            this.lbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbText.AutoEllipsis = true;
            this.lbText.BackColor = System.Drawing.Color.White;
            this.lbText.ContextMenuStrip = this.cmsList;
            this.lbText.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.HAllowDisable = true;
            this.lbText.HisBorder = true;
            this.lbText.HisClickChange = false;
            this.lbText.HisDisable = false;
            this.lbText.HResourceImage = "online";
            this.lbText.Image = global::GB.Properties.Resources.online;
            this.lbText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbText.Location = new System.Drawing.Point(6, 2);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(198, 28);
            this.lbText.TabIndex = 8;
            this.lbText.Text = "          Settings";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbText.UseCompatibleTextRendering = true;
            this.lbText.Click += new System.EventHandler(this.lbText_Click_1);
            this.lbText.DoubleClick += new System.EventHandler(this.lbText_DoubleClick);
            this.lbText.MouseEnter += new System.EventHandler(this.lbText_MouseEnter);
            this.lbText.MouseLeave += new System.EventHandler(this.lbText_MouseLeave);
            // 
            // PCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.cmsList;
            this.Controls.Add(this.lbText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PCS";
            this.Size = new System.Drawing.Size(201, 31);
            this.Load += new System.EventHandler(this.PCS_Load);
            this.cmsList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsList;
        private System.Windows.Forms.ToolStripMenuItem cmsRemotePCS;
        private System.Windows.Forms.ToolStripMenuItem cmsFileTransferPCS;
        private System.Windows.Forms.ToolStripMenuItem cmsDeletePCS;
        public lbButton3 lbText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem edtEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsBundle;
        private System.Windows.Forms.ToolStripMenuItem cmsBundleRemote;
    }
}
