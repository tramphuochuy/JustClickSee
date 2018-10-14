namespace GB
{
    partial class LOGON
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
            this.panHead = new System.Windows.Forms.Panel();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.edtUserName = new System.Windows.Forms.Label();
            this.edtInvalid = new System.Windows.Forms.Label();
            this.edtHOME = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.edtHOME)).BeginInit();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(888, 0);
            this.panHead.TabIndex = 53;
            // 
            // edtPassword
            // 
            this.edtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPassword.Location = new System.Drawing.Point(321, 182);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(196, 26);
            this.edtPassword.TabIndex = 0;
            this.edtPassword.TextChanged += new System.EventHandler(this.edtPassword_TextChanged);
            this.edtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPassword_KeyDown);
            // 
            // edtUserName
            // 
            this.edtUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edtUserName.AutoSize = true;
            this.edtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserName.ForeColor = System.Drawing.Color.White;
            this.edtUserName.Location = new System.Drawing.Point(319, 154);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(65, 24);
            this.edtUserName.TabIndex = 54;
            this.edtUserName.Text = "Admin";
            // 
            // edtInvalid
            // 
            this.edtInvalid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edtInvalid.AutoSize = true;
            this.edtInvalid.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtInvalid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.edtInvalid.Location = new System.Drawing.Point(321, 211);
            this.edtInvalid.Name = "edtInvalid";
            this.edtInvalid.Size = new System.Drawing.Size(44, 15);
            this.edtInvalid.TabIndex = 55;
            this.edtInvalid.Text = "Invalid";
            this.edtInvalid.Visible = false;
            // 
            // edtHOME
            // 
            this.edtHOME.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edtHOME.BackgroundImage = global::GB.Properties.Resources.UserWindow8;
            this.edtHOME.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.edtHOME.Location = new System.Drawing.Point(107, 150);
            this.edtHOME.Name = "edtHOME";
            this.edtHOME.Size = new System.Drawing.Size(206, 208);
            this.edtHOME.TabIndex = 52;
            this.edtHOME.TabStop = false;
            this.edtHOME.Click += new System.EventHandler(this.HOME_Click);
            // 
            // LOGON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(888, 555);
            this.Controls.Add(this.edtInvalid);
            this.Controls.Add(this.edtUserName);
            this.Controls.Add(this.panHead);
            this.Controls.Add(this.edtPassword);
            this.Controls.Add(this.edtHOME);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LOGON";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LOGON";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LOGON_FormClosing);
            this.Load += new System.EventHandler(this.LOGON_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtHOME)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox edtHOME;
        private System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.TextBox edtPassword;
        public System.Windows.Forms.Label edtUserName;
        public System.Windows.Forms.Label edtInvalid;
    }
}