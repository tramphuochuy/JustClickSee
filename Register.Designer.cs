namespace GB
{
    partial class Register
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbRegister = new System.Windows.Forms.Label();
            this.edtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panHead = new System.Windows.Forms.Panel();
            this.lbClose = new GB.lbButton();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbRegister);
            this.panel1.Controls.Add(this.edtPass);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panHead);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 136);
            this.panel1.TabIndex = 9;
            // 
            // lbRegister
            // 
            this.lbRegister.AutoSize = true;
            this.lbRegister.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegister.ForeColor = System.Drawing.Color.DarkRed;
            this.lbRegister.Location = new System.Drawing.Point(66, 90);
            this.lbRegister.Name = "lbRegister";
            this.lbRegister.Size = new System.Drawing.Size(71, 15);
            this.lbRegister.TabIndex = 6;
            this.lbRegister.Text = "Name exist !";
            this.lbRegister.Visible = false;
            // 
            // edtPass
            // 
            this.edtPass.Location = new System.Drawing.Point(69, 66);
            this.edtPass.Name = "edtPass";
            this.edtPass.PasswordChar = '*';
            this.edtPass.Size = new System.Drawing.Size(186, 20);
            this.edtPass.TabIndex = 1;
            this.edtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPass_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Pass";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(69, 44);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(186, 20);
            this.edtName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.SeaGreen;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Controls.Add(this.lbClose);
            this.panHead.Controls.Add(this.lbWelcome);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(299, 25);
            this.panHead.TabIndex = 3;
            // 
            // lbClose
            // 
            this.lbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClose.AutoEllipsis = true;
            this.lbClose.HAllowDisable = false;
            this.lbClose.HisBorder = true;
            this.lbClose.HisClickChange = true;
            this.lbClose.HisDisable = false;
            this.lbClose.HResourceImage = "";
            this.lbClose.Image = global::GB.Properties.Resources.close23_16;
            this.lbClose.Location = new System.Drawing.Point(274, 2);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(22, 20);
            this.lbClose.TabIndex = 4;
            this.lbClose.Text = "      ";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClose.UseCompatibleTextRendering = true;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.White;
            this.lbWelcome.Location = new System.Drawing.Point(4, 2);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(113, 20);
            this.lbWelcome.TabIndex = 3;
            this.lbWelcome.Text = "Quick Register";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(177, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(303, 139);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox edtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panHead;
        private lbButton lbClose;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbRegister;


    }
}