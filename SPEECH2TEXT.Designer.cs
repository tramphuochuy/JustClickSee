namespace GB
{
    partial class SPEECH2TEXT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPEECH2TEXT));
            this.timerAction = new System.Windows.Forms.Timer(this.components);
            this.panHead = new System.Windows.Forms.Panel();
            this.edtPic = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panRight = new GB.ColorPanelFlow();
            this.panLeft = new GB.ColorPanel();
            this.panContents = new GB.ColorPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.edtResult = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtText = new System.Windows.Forms.TextBox();
            this.edtTimeInfo = new System.Windows.Forms.Label();
            this.panHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).BeginInit();
            this.panContents.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerAction
            // 
            this.timerAction.Enabled = true;
            this.timerAction.Interval = 50;
            this.timerAction.Tick += new System.EventHandler(this.timerAction_Tick);
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.White;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panHead.Controls.Add(this.edtTimeInfo);
            this.panHead.Controls.Add(this.panel1);
            this.panHead.Controls.Add(this.edtPic);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(773, 73);
            this.panHead.TabIndex = 31;
            // 
            // edtPic
            // 
            this.edtPic.Image = global::GB.Properties.Resources.Speech64;
            this.edtPic.Location = new System.Drawing.Point(5, 4);
            this.edtPic.Name = "edtPic";
            this.edtPic.Size = new System.Drawing.Size(64, 64);
            this.edtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.edtPic.TabIndex = 9;
            this.edtPic.TabStop = false;
            this.edtPic.Click += new System.EventHandler(this.SPEECH2TEXT_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(773, 0);
            this.panel3.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 2);
            this.panel1.TabIndex = 10;
            // 
            // panRight
            // 
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.HisColor = 0;
            this.panRight.Location = new System.Drawing.Point(773, 73);
            this.panRight.Margin = new System.Windows.Forms.Padding(0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(0, 433);
            this.panRight.TabIndex = 32;
            this.panRight.Visible = false;
            // 
            // panLeft
            // 
            this.panLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.HisColor = 4;
            this.panLeft.Location = new System.Drawing.Point(0, 73);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(0, 433);
            this.panLeft.TabIndex = 34;
            // 
            // panContents
            // 
            this.panContents.BackColor = System.Drawing.Color.White;
            this.panContents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panContents.Controls.Add(this.panel4);
            this.panContents.Controls.Add(this.panel2);
            this.panContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContents.HisColor = 6;
            this.panContents.Location = new System.Drawing.Point(0, 73);
            this.panContents.Margin = new System.Windows.Forms.Padding(0);
            this.panContents.Name = "panContents";
            this.panContents.Size = new System.Drawing.Size(773, 433);
            this.panContents.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.edtResult);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(773, 383);
            this.panel4.TabIndex = 2;
            // 
            // edtResult
            // 
            this.edtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtResult.Location = new System.Drawing.Point(0, 0);
            this.edtResult.Multiline = true;
            this.edtResult.Name = "edtResult";
            this.edtResult.Size = new System.Drawing.Size(773, 383);
            this.edtResult.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.edtText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 50);
            this.panel2.TabIndex = 1;
            // 
            // edtText
            // 
            this.edtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtText.Location = new System.Drawing.Point(0, 0);
            this.edtText.Multiline = true;
            this.edtText.Name = "edtText";
            this.edtText.Size = new System.Drawing.Size(773, 50);
            this.edtText.TabIndex = 0;
            // 
            // edtTimeInfo
            // 
            this.edtTimeInfo.AutoSize = true;
            this.edtTimeInfo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtTimeInfo.Location = new System.Drawing.Point(76, 13);
            this.edtTimeInfo.Name = "edtTimeInfo";
            this.edtTimeInfo.Size = new System.Drawing.Size(10, 14);
            this.edtTimeInfo.TabIndex = 11;
            this.edtTimeInfo.Text = " ";
            // 
            // SPEECH2TEXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 506);
            this.Controls.Add(this.panRight);
            this.Controls.Add(this.panLeft);
            this.Controls.Add(this.panContents);
            this.Controls.Add(this.panHead);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SPEECH2TEXT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPEECH2TEXT";
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPic)).EndInit();
            this.panContents.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public ColorPanelFlow panRight;
        private ColorPanel panLeft;
        private ColorPanel panContents;
        private System.Windows.Forms.Timer timerAction;
        private System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox edtPic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox edtText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox edtResult;
        private System.Windows.Forms.Label edtTimeInfo;
    }
}