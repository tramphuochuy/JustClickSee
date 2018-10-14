namespace GB
{
    partial class SpeechToText
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
            this.btnSTart = new System.Windows.Forms.Button();
            this.edtText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSTart
            // 
            this.btnSTart.Location = new System.Drawing.Point(44, 317);
            this.btnSTart.Name = "btnSTart";
            this.btnSTart.Size = new System.Drawing.Size(75, 23);
            this.btnSTart.TabIndex = 0;
            this.btnSTart.Text = "button1";
            this.btnSTart.UseVisualStyleBackColor = true;
            this.btnSTart.Click += new System.EventHandler(this.btnSTart_Click);
            // 
            // edtText
            // 
            this.edtText.Location = new System.Drawing.Point(44, 33);
            this.edtText.Multiline = true;
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(658, 248);
            this.edtText.TabIndex = 1;
            // 
            // SpeechToText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 418);
            this.Controls.Add(this.edtText);
            this.Controls.Add(this.btnSTart);
            this.Name = "SpeechToText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpeechToText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSTart;
        private System.Windows.Forms.TextBox edtText;
    }
}