namespace GB
{
    partial class RunCMD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunCMD));
            this.timerAction = new System.Windows.Forms.Timer(this.components);
            this.edtCMD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timerAction
            // 
            this.timerAction.Enabled = true;
            this.timerAction.Tick += new System.EventHandler(this.timerAction_Tick);
            // 
            // edtCMD
            // 
            this.edtCMD.BackColor = System.Drawing.Color.Black;
            this.edtCMD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtCMD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtCMD.ForeColor = System.Drawing.Color.White;
            this.edtCMD.Location = new System.Drawing.Point(0, 0);
            this.edtCMD.Multiline = true;
            this.edtCMD.Name = "edtCMD";
            this.edtCMD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtCMD.Size = new System.Drawing.Size(559, 294);
            this.edtCMD.TabIndex = 0;
            this.edtCMD.WordWrap = false;
            this.edtCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtCMD_KeyDown);
            // 
            // RunCMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(559, 294);
            this.Controls.Add(this.edtCMD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "RunCMD";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.RunCMD_Activated);
            this.Deactivate += new System.EventHandler(this.RunCMD_Deactivate);
            this.Load += new System.EventHandler(this.RunCMD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerAction;
        public System.Windows.Forms.TextBox edtCMD;
    }
}