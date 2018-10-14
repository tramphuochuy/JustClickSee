namespace GB
{
    partial class LOGON_ITEM
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
            this.edtUserName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtDescription = new System.Windows.Forms.Label();
            this.edtPic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).BeginInit();
            this.SuspendLayout();
            // 
            // edtUserName
            // 
            this.edtUserName.BackColor = System.Drawing.Color.MidnightBlue;
            this.edtUserName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserName.ForeColor = System.Drawing.Color.White;
            this.edtUserName.Location = new System.Drawing.Point(0, 207);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(200, 24);
            this.edtUserName.TabIndex = 54;
            this.edtUserName.Text = "Admin";
            this.edtUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edtUserName.UseCompatibleTextRendering = true;
            this.edtUserName.Click += new System.EventHandler(this.edtUserName_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtPic);
            this.panel1.Controls.Add(this.edtUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 231);
            this.panel1.TabIndex = 55;
            this.panel1.Click += new System.EventHandler(this.edtUserName_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.edtDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 231);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 24);
            this.panel2.TabIndex = 55;
            // 
            // edtDescription
            // 
            this.edtDescription.BackColor = System.Drawing.Color.MidnightBlue;
            this.edtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDescription.ForeColor = System.Drawing.Color.White;
            this.edtDescription.Location = new System.Drawing.Point(0, 0);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(200, 24);
            this.edtDescription.TabIndex = 55;
            this.edtDescription.Text = "( Not available )";
            this.edtDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edtDescription.UseCompatibleTextRendering = true;
            this.edtDescription.Visible = false;
            // 
            // edtPic
            // 
            this.edtPic.BackColor = System.Drawing.Color.MidnightBlue;
            this.edtPic.BackgroundImage = global::GB.Properties.Resources.UserWindow8;
            this.edtPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.edtPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPic.Location = new System.Drawing.Point(0, 0);
            this.edtPic.Name = "edtPic";
            this.edtPic.Size = new System.Drawing.Size(200, 207);
            this.edtPic.TabIndex = 53;
            this.edtPic.TabStop = false;
            this.edtPic.Click += new System.EventHandler(this.edtUserName_Click);
            // 
            // LOGON_ITEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "LOGON_ITEM";
            this.Size = new System.Drawing.Size(200, 255);
            this.Load += new System.EventHandler(this.LOGON_ITEM_Load);
            this.Click += new System.EventHandler(this.edtUserName_Click);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox edtPic;
        public System.Windows.Forms.Label edtUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label edtDescription;

    }
}
