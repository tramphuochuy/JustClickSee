namespace GB
{
    partial class Confirm
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
            this.edtTitle = new System.Windows.Forms.Label();
            this.edtText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbClose = new GB.lbButton();
            this.panHead.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.SeaGreen;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Controls.Add(this.lbClose);
            this.panHead.Controls.Add(this.edtTitle);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(263, 25);
            this.panHead.TabIndex = 3;
            // 
            // edtTitle
            // 
            this.edtTitle.AutoSize = true;
            this.edtTitle.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtTitle.ForeColor = System.Drawing.Color.White;
            this.edtTitle.Location = new System.Drawing.Point(4, 2);
            this.edtTitle.Name = "edtTitle";
            this.edtTitle.Size = new System.Drawing.Size(64, 20);
            this.edtTitle.TabIndex = 3;
            this.edtTitle.Text = "Confirm";
            // 
            // edtText
            // 
            this.edtText.AutoSize = true;
            this.edtText.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtText.ForeColor = System.Drawing.Color.SeaGreen;
            this.edtText.Location = new System.Drawing.Point(22, 43);
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(79, 15);
            this.edtText.TabIndex = 5;
            this.edtText.Text = "Contents Here";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.panHead);
            this.panel1.Controls.Add(this.edtText);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 136);
            this.panel1.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GB.Properties.Resources._011_yes_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(42, 74);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 26);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(139, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel  ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.LOGIN_Click);
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
            this.lbClose.Location = new System.Drawing.Point(239, 2);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(22, 20);
            this.lbClose.TabIndex = 4;
            this.lbClose.Text = "      ";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClose.UseCompatibleTextRendering = true;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(267, 139);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Confirm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label edtTitle;
        private lbButton lbClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label edtText;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel panHead;
    }
}