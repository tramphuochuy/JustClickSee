namespace GB
{
    partial class CODER_DETAIL
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.edtPCSID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 51);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // edtPCSID
            // 
            this.edtPCSID.Location = new System.Drawing.Point(3, 3);
            this.edtPCSID.Multiline = true;
            this.edtPCSID.Name = "edtPCSID";
            this.edtPCSID.Size = new System.Drawing.Size(648, 171);
            this.edtPCSID.TabIndex = 2;
            // 
            // CODER_DETAIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 240);
            this.Controls.Add(this.edtPCSID);
            this.Controls.Add(this.btnSave);
            this.Name = "CODER_DETAIL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CODER_DETAIL";
            this.Load += new System.EventHandler(this.CODER_DETAIL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox edtPCSID;
        
    }
}