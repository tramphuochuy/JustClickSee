namespace GB
{
    partial class FormTitleBarControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTitleBarControl));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.frmControlBox = new GB.FormControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(464, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Form Title";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            this.lblTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDoubleClick);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Caption_MouseDown);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.BackgroundImage = global::GB.Properties.Resources.Background;
            this.pbTitle.Location = new System.Drawing.Point(0, 0);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(394, 25);
            this.pbTitle.TabIndex = 2;
            this.pbTitle.TabStop = false;
            this.pbTitle.Click += new System.EventHandler(this.pbTitle_Click);
            this.pbTitle.DoubleClick += new System.EventHandler(this.pbTitle_DoubleClick);
            this.pbTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbTitle_MouseDoubleClick);
            this.pbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTitle_MouseDown);
            // 
            // frmControlBox
            // 
            this.frmControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.frmControlBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("frmControlBox.BackgroundImage")));
            this.frmControlBox.Close = true;
            this.frmControlBox.Location = new System.Drawing.Point(394, 0);
            this.frmControlBox.Maximize = true;
            this.frmControlBox.Minimize = true;
            this.frmControlBox.Name = "frmControlBox";
            this.frmControlBox.Size = new System.Drawing.Size(70, 25);
            this.frmControlBox.TabIndex = 0;
            // 
            // FormTitleBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GB.Properties.Resources.Background;
            this.Controls.Add(this.frmControlBox);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbTitle);
            this.Name = "FormTitleBarControl";
            this.Size = new System.Drawing.Size(464, 25);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GB.FormControlBox frmControlBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTitle;
    }
}
