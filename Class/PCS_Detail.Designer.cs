namespace GB
{
    partial class PCS_Detail
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
            this.label1 = new System.Windows.Forms.Label();
            this.edtPCS_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtPass = new System.Windows.Forms.TextBox();
            this.edtPCS_NAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panHead = new System.Windows.Forms.Panel();
            this.lbClose = new GB.lbButton();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // edtPCS_ID
            // 
            this.edtPCS_ID.Location = new System.Drawing.Point(82, 48);
            this.edtPCS_ID.Name = "edtPCS_ID";
            this.edtPCS_ID.Size = new System.Drawing.Size(174, 20);
            this.edtPCS_ID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pass";
            // 
            // edtPass
            // 
            this.edtPass.Location = new System.Drawing.Point(82, 70);
            this.edtPass.Name = "edtPass";
            this.edtPass.PasswordChar = '*';
            this.edtPass.Size = new System.Drawing.Size(174, 20);
            this.edtPass.TabIndex = 1;
            // 
            // edtPCS_NAME
            // 
            this.edtPCS_NAME.Location = new System.Drawing.Point(82, 91);
            this.edtPCS_NAME.Name = "edtPCS_NAME";
            this.edtPCS_NAME.Size = new System.Drawing.Size(174, 20);
            this.edtPCS_NAME.TabIndex = 2;
            this.edtPCS_NAME.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPCS_NAME_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.edtPCS_NAME);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.edtPass);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panHead);
            this.panel1.Controls.Add(this.edtPCS_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 167);
            this.panel1.TabIndex = 8;
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
            this.lbWelcome.Size = new System.Drawing.Size(87, 20);
            this.lbWelcome.TabIndex = 3;
            this.lbWelcome.Text = "Add to List";
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(178, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.Save_Click);
            // 
            // PCS_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(303, 170);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PCS_Detail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add PC+ ";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panHead;
        private lbButton lbClose;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox edtPCS_ID;
        public System.Windows.Forms.TextBox edtPass;
        public System.Windows.Forms.TextBox edtPCS_NAME;
        public System.Windows.Forms.Label lbWelcome;
    }
}