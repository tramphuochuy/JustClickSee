namespace GB
{
    partial class CODER
    {
      
        private System.ComponentModel.IContainer components = null;

      
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

   
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panContent = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsClone = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panFooter = new System.Windows.Forms.Panel();
            this.panHeader = new System.Windows.Forms.Panel();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIF = new System.Windows.Forms.PictureBox();
            this.btnAdd = new GB.lbButton();
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GIF)).BeginInit();
            this.SuspendLayout();
            // 
            // panContent
            // 
            this.panContent.BackColor = System.Drawing.Color.White;
            this.panContent.Controls.Add(this.GIF);
            this.panContent.Controls.Add(this.dgv);
            this.panContent.Controls.Add(this.btnAdd);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(423, 255);
            this.panContent.TabIndex = 6;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colPCSID,
            this.colPCNAME,
            this.colCDATETIME});
            this.dgv.ContextMenuStrip = this.cms;
            this.dgv.Location = new System.Drawing.Point(0, 41);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(423, 211);
            this.dgv.TabIndex = 14;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCopy,
            this.cmsClone,
            this.cmsRefresh,
            this.toolStripSeparator1,
            this.cmsDelete,
            this.cmsExport});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(114, 120);
            // 
            // cmsCopy
            // 
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.Size = new System.Drawing.Size(113, 22);
            this.cmsCopy.Text = "Copy";
            this.cmsCopy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // cmsClone
            // 
            this.cmsClone.Name = "cmsClone";
            this.cmsClone.Size = new System.Drawing.Size(113, 22);
            this.cmsClone.Text = "Clone";
            this.cmsClone.Click += new System.EventHandler(this.cmsClone_Click);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(113, 22);
            this.cmsRefresh.Text = "Refresh";
            this.cmsRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(113, 22);
            this.cmsDelete.Text = "Delete";
            this.cmsDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.Name = "cmsExport";
            this.cmsExport.Size = new System.Drawing.Size(113, 22);
            this.cmsExport.Text = "Export";
            this.cmsExport.Click += new System.EventHandler(this.Export_Click);
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.thêmToolStripMenuItem.Text = "Add";
            this.thêmToolStripMenuItem.Click += new System.EventHandler(this.Insert_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.Edit_Click);
            // 
            // panFooter
            // 
            this.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFooter.Location = new System.Drawing.Point(0, 255);
            this.panFooter.Name = "panFooter";
            this.panFooter.Size = new System.Drawing.Size(423, 0);
            this.panFooter.TabIndex = 5;
            // 
            // panHeader
            // 
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(423, 0);
            this.panHeader.TabIndex = 4;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "Id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colPCSID
            // 
            this.colPCSID.DataPropertyName = "PCSID";
            this.colPCSID.HeaderText = "Pcsid";
            this.colPCSID.Name = "colPCSID";
            this.colPCSID.ReadOnly = true;
            // 
            // colPCNAME
            // 
            this.colPCNAME.DataPropertyName = "PCNAME";
            this.colPCNAME.HeaderText = "Pcname";
            this.colPCNAME.Name = "colPCNAME";
            this.colPCNAME.ReadOnly = true;
            this.colPCNAME.Visible = false;
            // 
            // colCDATETIME
            // 
            this.colCDATETIME.DataPropertyName = "CDATETIME";
            this.colCDATETIME.HeaderText = "Cdatetime";
            this.colCDATETIME.Name = "colCDATETIME";
            this.colCDATETIME.ReadOnly = true;
            this.colCDATETIME.Visible = false;
            // 
            // GIF
            // 
            this.GIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GIF.BackColor = System.Drawing.Color.White;
            this.GIF.Location = new System.Drawing.Point(12, 176);
            this.GIF.Name = "GIF";
            this.GIF.Size = new System.Drawing.Size(0, 0);
            this.GIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.GIF.TabIndex = 37;
            this.GIF.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoEllipsis = true;
            this.btnAdd.AutoSize = true;
            this.btnAdd.HAllowDisable = false;
            this.btnAdd.HisBorder = true;
            this.btnAdd.HisClickChange = true;
            this.btnAdd.HisDisable = false;
            this.btnAdd.HResourceImage = "";
            this.btnAdd.Image = global::GB.Properties.Resources.Finger;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 17);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "        New";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.Click += new System.EventHandler(this.Insert_Click);
            // 
            // CODER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 255);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panFooter);
            this.Controls.Add(this.panHeader);
            this.Name = "CODER";
            this.Load += new System.EventHandler(this.Sample_Load);
            this.panContent.ResumeLayout(false);
            this.panContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GIF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.Panel panFooter;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.Panel panHeader;
        public System.Windows.Forms.DataGridView dgv;

    
        private System.Windows.Forms.ToolStripMenuItem cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem cmsExport ;
        private System.Windows.Forms.PictureBox GIF;
        private lbButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsClone;

        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCDATETIME;
    }
}
