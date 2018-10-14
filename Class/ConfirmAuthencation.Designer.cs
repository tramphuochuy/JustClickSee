namespace GB
{
    partial class ConfirmAuthencation
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
            this.edtText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtUserName = new System.Windows.Forms.TextBox();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtText
            // 
            this.edtText.AutoSize = true;
            this.edtText.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtText.ForeColor = System.Drawing.Color.SeaGreen;
            this.edtText.Location = new System.Drawing.Point(27, 61);
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(54, 15);
            this.edtText.TabIndex = 5;
            this.edtText.Text = "Password";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.edtUserName);
            this.panel1.Controls.Add(this.edtPassword);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edtText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 151);
            this.panel1.TabIndex = 7;
            // 
            // edtUserName
            // 
            this.edtUserName.Location = new System.Drawing.Point(30, 38);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(195, 20);
            this.edtUserName.TabIndex = 0;
            this.edtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPassword_KeyDown);
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(30, 79);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(195, 20);
            this.edtPassword.TabIndex = 1;
            this.edtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPassword_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(148, 105);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Account";
            // 
            // ConfirmAuthencation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(262, 151);
            this.Controls.Add(this.panel1);
            this.Name = "ConfirmAuthencation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label edtText;
        public System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.TextBox edtUserName;
        public System.Windows.Forms.Label label1;
    }
}