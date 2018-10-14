namespace GB
{
    partial class LanguageList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colICON = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GIF = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GIF)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colICON,
            this.colCODE,
            this.colNAME});
            this.dgv.ContextMenuStrip = this.cms;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(282, 547);
            this.dgv.TabIndex = 15;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // colICON
            // 
            this.colICON.DataPropertyName = "ICON";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = " ";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colICON.DefaultCellStyle = dataGridViewCellStyle1;
            this.colICON.HeaderText = " ";
            this.colICON.Name = "colICON";
            this.colICON.ReadOnly = true;
            this.colICON.Width = 40;
            // 
            // colCODE
            // 
            this.colCODE.DataPropertyName = "CODE";
            this.colCODE.HeaderText = "Code";
            this.colCODE.Name = "colCODE";
            this.colCODE.ReadOnly = true;
            this.colCODE.Width = 80;
            // 
            // colNAME
            // 
            this.colNAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNAME.DataPropertyName = "NAME";
            this.colNAME.HeaderText = "Name";
            this.colNAME.Name = "colNAME";
            this.colNAME.ReadOnly = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // GIF
            // 
            this.GIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GIF.BackColor = System.Drawing.Color.White;
            this.GIF.Image = global::GB.Properties.Resources.Loading;
            this.GIF.Location = new System.Drawing.Point(229, 111);
            this.GIF.Name = "GIF";
            this.GIF.Size = new System.Drawing.Size(0, 324);
            this.GIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.GIF.TabIndex = 38;
            this.GIF.TabStop = false;
            // 
            // LanguageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 547);
            this.Controls.Add(this.GIF);
            this.Controls.Add(this.dgv);
            this.Name = "LanguageList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Languages";
            this.Load += new System.EventHandler(this.ProcessList_Load);
            this.SizeChanged += new System.EventHandler(this.ProcessList_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GIF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.PictureBox GIF;
        private System.Windows.Forms.DataGridViewImageColumn colICON;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNAME;
    }
}