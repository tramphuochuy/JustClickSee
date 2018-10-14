namespace GB
{
    partial class Translation
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
            this.edtKey = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panMain = new System.Windows.Forms.Panel();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exiitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edtIcon = new GB.lbButton();
            this.edtPic = new System.Windows.Forms.PictureBox();
            this.edtWordFound = new System.Windows.Forms.Label();
            this.edtResultText = new System.Windows.Forms.TextBox();
            this.edtAutoText = new System.Windows.Forms.Label();
            this.btnRefresh = new GB.lbButton();
            this.panMain.SuspendLayout();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).BeginInit();
            this.SuspendLayout();
            // 
            // edtKey
            // 
            this.edtKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtKey.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtKey.ForeColor = System.Drawing.Color.Navy;
            this.edtKey.Location = new System.Drawing.Point(0, 0);
            this.edtKey.Margin = new System.Windows.Forms.Padding(4);
            this.edtKey.Name = "edtKey";
            this.edtKey.Size = new System.Drawing.Size(458, 20);
            this.edtKey.TabIndex = 0;
            this.edtKey.Visible = false;
            this.edtKey.TextChanged += new System.EventHandler(this.edtKey_TextChanged);
            this.edtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterPopup_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DURATION";
            this.dataGridViewTextBoxColumn1.HeaderText = "DURATION";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "STARTTIME";
            this.dataGridViewTextBoxColumn2.HeaderText = "STARTTIME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ENDTIME";
            this.dataGridViewTextBoxColumn3.HeaderText = "ENDTIME";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "WU";
            this.dataGridViewTextBoxColumn4.HeaderText = "WU";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DESCRIPTION";
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SHIFTID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 0);
            this.panel1.TabIndex = 2;
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.SkyBlue;
            this.panMain.ContextMenuStrip = this.cms;
            this.panMain.Controls.Add(this.edtIcon);
            this.panMain.Controls.Add(this.edtPic);
            this.panMain.Controls.Add(this.edtWordFound);
            this.panMain.Controls.Add(this.edtResultText);
            this.panMain.Controls.Add(this.edtAutoText);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 20);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(458, 222);
            this.panMain.TabIndex = 3;
            this.panMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseDown);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exiitToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(93, 26);
            // 
            // exiitToolStripMenuItem
            // 
            this.exiitToolStripMenuItem.Name = "exiitToolStripMenuItem";
            this.exiitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exiitToolStripMenuItem.Text = "Exit";
            this.exiitToolStripMenuItem.Click += new System.EventHandler(this.exiitToolStripMenuItem_Click);
            // 
            // edtIcon
            // 
            this.edtIcon.AutoEllipsis = true;
            this.edtIcon.AutoSize = true;
            this.edtIcon.HAllowDisable = false;
            this.edtIcon.HisBorder = true;
            this.edtIcon.HisClickChange = true;
            this.edtIcon.HisDisable = false;
            this.edtIcon.HResourceImage = "";
            this.edtIcon.Image = global::GB.Properties.Resources.Trans16;
            this.edtIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtIcon.Location = new System.Drawing.Point(5, 4);
            this.edtIcon.Name = "edtIcon";
            this.edtIcon.Size = new System.Drawing.Size(20, 20);
            this.edtIcon.TabIndex = 39;
            this.edtIcon.Text = "    ";
            this.edtIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edtIcon.UseCompatibleTextRendering = true;
            this.edtIcon.Click += new System.EventHandler(this.edtIcon_Click);
            this.edtIcon.MouseEnter += new System.EventHandler(this.CLOSE_Enter);
            this.edtIcon.MouseLeave += new System.EventHandler(this.CLOSE_Leave);
            // 
            // edtPic
            // 
            this.edtPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPic.BackColor = System.Drawing.Color.White;
            this.edtPic.Image = global::GB.Properties.Resources.Loading;
            this.edtPic.Location = new System.Drawing.Point(4, 28);
            this.edtPic.Name = "edtPic";
            this.edtPic.Size = new System.Drawing.Size(448, 190);
            this.edtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.edtPic.TabIndex = 3;
            this.edtPic.TabStop = false;
            this.edtPic.Visible = false;
            // 
            // edtWordFound
            // 
            this.edtWordFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWordFound.AutoEllipsis = true;
            this.edtWordFound.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtWordFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.edtWordFound.Location = new System.Drawing.Point(29, 5);
            this.edtWordFound.Name = "edtWordFound";
            this.edtWordFound.Size = new System.Drawing.Size(422, 17);
            this.edtWordFound.TabIndex = 2;
            this.edtWordFound.Text = "Word Label";
            this.edtWordFound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseDown);
            // 
            // edtResultText
            // 
            this.edtResultText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtResultText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtResultText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtResultText.ForeColor = System.Drawing.Color.Black;
            this.edtResultText.Location = new System.Drawing.Point(3, 27);
            this.edtResultText.Multiline = true;
            this.edtResultText.Name = "edtResultText";
            this.edtResultText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtResultText.Size = new System.Drawing.Size(451, 192);
            this.edtResultText.TabIndex = 1;
            // 
            // edtAutoText
            // 
            this.edtAutoText.AutoSize = true;
            this.edtAutoText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtAutoText.Location = new System.Drawing.Point(12, 7);
            this.edtAutoText.Name = "edtAutoText";
            this.edtAutoText.Size = new System.Drawing.Size(14, 21);
            this.edtAutoText.TabIndex = 0;
            this.edtAutoText.Text = " ";
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
            this.btnRefresh.Image = global::GB.Properties.Resources.Trans16;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(5, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(20, 20);
            this.btnRefresh.TabIndex = 39;
            this.btnRefresh.Text = "    ";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseCompatibleTextRendering = true;
            // 
            // Translation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(458, 242);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.edtKey);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Translation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Translation_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Translation_FormClosing);
            this.Load += new System.EventHandler(this.FilterPopup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterPopup_KeyDown);
            this.Leave += new System.EventHandler(this.Translation_Leave);
            this.MouseEnter += new System.EventHandler(this.Translation_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Translation_MouseLeave);
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox edtKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem exiitToolStripMenuItem;
        private System.Windows.Forms.Label edtAutoText;
        public System.Windows.Forms.TextBox edtResultText;
        private System.Windows.Forms.Label edtWordFound;
        private System.Windows.Forms.PictureBox edtPic;
        private lbButton edtIcon;
        private lbButton btnRefresh;
    }
}