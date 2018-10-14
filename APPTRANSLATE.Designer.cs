namespace GB
{
    partial class APPTRANSLATE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panContent = new System.Windows.Forms.Panel();
            this.GIF = new System.Windows.Forms.PictureBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsClone = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new GB.lbButton();
            this.btnRefresh = new GB.lbButton();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panFooter = new System.Windows.Forms.Panel();
            this.panHeader = new System.Windows.Forms.Panel();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSERCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colENABLE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDOUBLECLICK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Holdclick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SkipClipboard = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSHORTKEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panContent
            // 
            this.panContent.BackColor = System.Drawing.Color.White;
            this.panContent.Controls.Add(this.GIF);
            this.panContent.Controls.Add(this.dgv);
            this.panContent.Controls.Add(this.btnAdd);
            this.panContent.Controls.Add(this.btnRefresh);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(775, 312);
            this.panContent.TabIndex = 6;
            // 
            // GIF
            // 
            this.GIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GIF.BackColor = System.Drawing.Color.White;
            this.GIF.Image = global::GB.Properties.Resources.Loading;
            this.GIF.Location = new System.Drawing.Point(33, 88);
            this.GIF.Name = "GIF";
            this.GIF.Size = new System.Drawing.Size(428, 131);
            this.GIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.GIF.TabIndex = 37;
            this.GIF.TabStop = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.colID,
            this.colUSERCODE,
            this.colAPPNAME,
            this.colENABLE,
            this.colCDATETIME,
            this.colDOUBLECLICK,
            this.Holdclick,
            this.SkipClipboard,
            this.colSHORTKEY});
            this.dgv.ContextMenuStrip = this.cms;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(-3, 31);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(775, 278);
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
            // btnAdd
            // 
            this.btnAdd.AutoEllipsis = true;
            this.btnAdd.AutoSize = true;
            this.btnAdd.HAllowDisable = false;
            this.btnAdd.HisBorder = true;
            this.btnAdd.HisClickChange = true;
            this.btnAdd.HisDisable = false;
            this.btnAdd.HResourceImage = "";
            this.btnAdd.Image = global::GB.Properties.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(84, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 17);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "       New";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.Click += new System.EventHandler(this.Insert_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoEllipsis = true;
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.HAllowDisable = false;
            this.btnRefresh.HisBorder = true;
            this.btnRefresh.HisClickChange = true;
            this.btnRefresh.HisDisable = false;
            this.btnRefresh.HResourceImage = "";
            this.btnRefresh.Image = global::GB.Properties.Resources.Refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(12, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 17);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "       Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseCompatibleTextRendering = true;
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
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
            this.panFooter.Location = new System.Drawing.Point(0, 312);
            this.panFooter.Name = "panFooter";
            this.panFooter.Size = new System.Drawing.Size(775, 0);
            this.panFooter.TabIndex = 5;
            // 
            // panHeader
            // 
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(775, 0);
            this.panHeader.TabIndex = 4;
            // 
            // Icon
            // 
            this.Icon.DataPropertyName = "ICON";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = " ";
            this.Icon.DefaultCellStyle = dataGridViewCellStyle1;
            this.Icon.HeaderText = " ";
            this.Icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Icon.Width = 50;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "Id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colUSERCODE
            // 
            this.colUSERCODE.DataPropertyName = "USERCODE";
            this.colUSERCODE.HeaderText = "Usercode";
            this.colUSERCODE.Name = "colUSERCODE";
            this.colUSERCODE.ReadOnly = true;
            this.colUSERCODE.Visible = false;
            // 
            // colAPPNAME
            // 
            this.colAPPNAME.DataPropertyName = "APPNAME";
            this.colAPPNAME.HeaderText = "Appname";
            this.colAPPNAME.Name = "colAPPNAME";
            this.colAPPNAME.ReadOnly = true;
            // 
            // colENABLE
            // 
            this.colENABLE.DataPropertyName = "ENABLE";
            this.colENABLE.HeaderText = "Enabled";
            this.colENABLE.Name = "colENABLE";
            this.colENABLE.ReadOnly = true;
            this.colENABLE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colENABLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCDATETIME
            // 
            this.colCDATETIME.DataPropertyName = "CDATETIME";
            this.colCDATETIME.HeaderText = "Cdatetime";
            this.colCDATETIME.Name = "colCDATETIME";
            this.colCDATETIME.ReadOnly = true;
            this.colCDATETIME.Visible = false;
            // 
            // colDOUBLECLICK
            // 
            this.colDOUBLECLICK.DataPropertyName = "DOUBLECLICK";
            this.colDOUBLECLICK.HeaderText = "Double Click";
            this.colDOUBLECLICK.Name = "colDOUBLECLICK";
            this.colDOUBLECLICK.ReadOnly = true;
            // 
            // Holdclick
            // 
            this.Holdclick.DataPropertyName = "HOLDCLICK";
            this.Holdclick.HeaderText = "HoldTranslate";
            this.Holdclick.Name = "Holdclick";
            this.Holdclick.ReadOnly = true;
            this.Holdclick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Holdclick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SkipClipboard
            // 
            this.SkipClipboard.DataPropertyName = "SKIP_OLD_CLIPBOARD";
            this.SkipClipboard.HeaderText = "SkipClipboard";
            this.SkipClipboard.Name = "SkipClipboard";
            this.SkipClipboard.ReadOnly = true;
            this.SkipClipboard.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SkipClipboard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colSHORTKEY
            // 
            this.colSHORTKEY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSHORTKEY.DataPropertyName = "SHORTKEY";
            this.colSHORTKEY.HeaderText = "Shortkey";
            this.colSHORTKEY.Name = "colSHORTKEY";
            this.colSHORTKEY.ReadOnly = true;
            // 
            // APPTRANSLATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panFooter);
            this.Controls.Add(this.panHeader);
            this.Name = "APPTRANSLATE";
            this.Size = new System.Drawing.Size(775, 312);
            this.Load += new System.EventHandler(this.Sample_Load);
            this.panContent.ResumeLayout(false);
            this.panContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cms.ResumeLayout(false);
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
        private lbButton btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem cmsClone;

        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUSERCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPPNAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colENABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCDATETIME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDOUBLECLICK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Holdclick;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SkipClipboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSHORTKEY;
    }
}
