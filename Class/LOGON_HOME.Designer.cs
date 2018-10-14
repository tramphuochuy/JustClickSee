namespace GB
{
    partial class LOGON_HOME
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
            this.panFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.logoN_ITEM1 = new GB.LOGON_ITEM();
            this.logoN_ITEM2 = new GB.LOGON_ITEM();
            this.panFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panFlow
            // 
            this.panFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panFlow.Controls.Add(this.logoN_ITEM1);
            this.panFlow.Controls.Add(this.logoN_ITEM2);
            this.panFlow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panFlow.Location = new System.Drawing.Point(226, 172);
            this.panFlow.Name = "panFlow";
            this.panFlow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panFlow.Size = new System.Drawing.Size(664, 373);
            this.panFlow.TabIndex = 56;
            // 
            // logoN_ITEM1
            // 
            this.logoN_ITEM1.BackColor = System.Drawing.Color.Transparent;
            this.logoN_ITEM1.Location = new System.Drawing.Point(3, 3);
            this.logoN_ITEM1.Name = "logoN_ITEM1";
            this.logoN_ITEM1.Size = new System.Drawing.Size(168, 178);
            this.logoN_ITEM1.TabIndex = 54;
            // 
            // logoN_ITEM2
            // 
            this.logoN_ITEM2.BackColor = System.Drawing.Color.Transparent;
            this.logoN_ITEM2.Location = new System.Drawing.Point(177, 3);
            this.logoN_ITEM2.Name = "logoN_ITEM2";
            this.logoN_ITEM2.Size = new System.Drawing.Size(168, 178);
            this.logoN_ITEM2.TabIndex = 55;
            // 
            // LOGON_HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(892, 546);
            this.Controls.Add(this.panFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LOGON_HOME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LOGON";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LOGON_FormClosing);
            this.Load += new System.EventHandler(this.LOGON_Load);
            this.panFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LOGON_ITEM logoN_ITEM1;
        private LOGON_ITEM logoN_ITEM2;
        private System.Windows.Forms.FlowLayoutPanel panFlow;

    }
}