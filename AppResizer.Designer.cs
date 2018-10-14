namespace GB
{
    partial class AppResizer
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
            this.button1 = new System.Windows.Forms.Button();
            this.edtAppname = new System.Windows.Forms.TextBox();
            this.edtW = new System.Windows.Forms.TextBox();
            this.edtH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OK_Click );
            // 
            // edtAppname
            // 
            this.edtAppname.Location = new System.Drawing.Point(64, 19);
            this.edtAppname.Name = "edtAppname";
            this.edtAppname.Size = new System.Drawing.Size(304, 20);
            this.edtAppname.TabIndex = 0;
            this.edtAppname.Text = "Ori";
            // 
            // edtW
            // 
            this.edtW.Location = new System.Drawing.Point(64, 45);
            this.edtW.Name = "edtW";
            this.edtW.Size = new System.Drawing.Size(90, 20);
            this.edtW.TabIndex = 1;
            this.edtW.Text = "5760";
            // 
            // edtH
            // 
            this.edtH.Location = new System.Drawing.Point(64, 71);
            this.edtH.Name = "edtH";
            this.edtH.Size = new System.Drawing.Size(90, 20);
            this.edtH.TabIndex = 2;
            this.edtH.Text = "1080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "App";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height";
            // 
            // AppResizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 167);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtH);
            this.Controls.Add(this.edtW);
            this.Controls.Add(this.edtAppname);
            this.Controls.Add(this.button1);
            this.Name = "AppResizer";
            this.Text = "AppResizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox edtAppname;
        private System.Windows.Forms.TextBox edtW;
        private System.Windows.Forms.TextBox edtH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}