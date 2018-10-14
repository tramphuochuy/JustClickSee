namespace GB
{
    partial class PCSList
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIGNAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.StartAt,
            this.colDescription,
            this.colDate,
            this.colPCName,
            this.OS,
            this.SIGNAL});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(979, 456);
            this.dgv.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            // 
            // StartAt
            // 
            this.StartAt.DataPropertyName = "STARTAT";
            this.StartAt.HeaderText = "STARTAT";
            this.StartAt.Name = "StartAt";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "PCID";
            this.colDescription.HeaderText = "PCID";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 400;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "CDATETIME";
            this.colDate.HeaderText = "CDatetime";
            this.colDate.Name = "colDate";
            // 
            // colPCName
            // 
            this.colPCName.DataPropertyName = "PCNAME";
            this.colPCName.HeaderText = "PCName";
            this.colPCName.Name = "colPCName";
            // 
            // OS
            // 
            this.OS.DataPropertyName = "OS";
            this.OS.HeaderText = "OS";
            this.OS.Name = "OS";
            // 
            // SIGNAL
            // 
            this.SIGNAL.DataPropertyName = "SIGNAL";
            this.SIGNAL.HeaderText = "SIgnal";
            this.SIGNAL.Name = "SIGNAL";
            // 
            // PCSList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 456);
            this.Controls.Add(this.dgv);
            this.Name = "PCSList";
            this.Text = "PCSList";
            this.Load += new System.EventHandler(this.PCSList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIGNAL;
    }
}