namespace GB
{
    partial class TextImage
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
            this.PanBorder = new GB.ColorPanel();
            this.edtText = new System.Windows.Forms.TextBox();
            this.PanBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanBorder
            // 
            this.PanBorder.BackColor = System.Drawing.Color.White;
            this.PanBorder.Controls.Add(this.edtText);
            this.PanBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanBorder.HisColor = 0;
            this.PanBorder.Location = new System.Drawing.Point(0, 0);
            this.PanBorder.Name = "PanBorder";
            this.PanBorder.Size = new System.Drawing.Size(224, 60);
            this.PanBorder.TabIndex = 2;
            // 
            // edtText
            // 
            this.edtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtText.Font = new System.Drawing.Font("Comic Sans MS", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtText.Location = new System.Drawing.Point(8, 7);
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(206, 49);
            this.edtText.TabIndex = 0;
            this.edtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanBorder);
            this.Name = "TextImage";
            this.Size = new System.Drawing.Size(224, 60);
            this.PanBorder.ResumeLayout(false);
            this.PanBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorPanel PanBorder;
        public System.Windows.Forms.TextBox edtText;

    }
}
