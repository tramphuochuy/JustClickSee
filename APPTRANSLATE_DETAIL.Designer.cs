namespace GB
{
    partial class APPTRANSLATE_DETAIL
    {
     
        private System.ComponentModel.IContainer components = null;

      
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APPTRANSLATE_DETAIL));
            this.btnSave = new System.Windows.Forms.Button();
            this.lbAPPNAME = new System.Windows.Forms.Label();
            this.edtAPPNAME = new System.Windows.Forms.TextBox();
            this.edtENABLE = new System.Windows.Forms.CheckBox();
            this.lbSHORTKEY = new System.Windows.Forms.Label();
            this.edtSHORTKEY = new System.Windows.Forms.TextBox();
            this.edtDOUBLECLICK = new System.Windows.Forms.CheckBox();
            this.edtHOLDCLICK = new System.Windows.Forms.CheckBox();
            this.edtICON = new System.Windows.Forms.PictureBox();
            this.btnAdd = new GB.lbButton();
            this.edtSKIP_OLD_CLIPBOARD = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.edtICON)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 45);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // lbAPPNAME
            // 
            this.lbAPPNAME.AutoSize = true;
            this.lbAPPNAME.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAPPNAME.Location = new System.Drawing.Point(19, 17);
            this.lbAPPNAME.Name = "lbAPPNAME";
            this.lbAPPNAME.Size = new System.Drawing.Size(59, 15);
            this.lbAPPNAME.TabIndex = 5;
            this.lbAPPNAME.Text = "Appname";
            // 
            // edtAPPNAME
            // 
            this.edtAPPNAME.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtAPPNAME.Location = new System.Drawing.Point(99, 14);
            this.edtAPPNAME.Name = "edtAPPNAME";
            this.edtAPPNAME.Size = new System.Drawing.Size(231, 22);
            this.edtAPPNAME.TabIndex = 4;
            // 
            // edtENABLE
            // 
            this.edtENABLE.AutoSize = true;
            this.edtENABLE.Location = new System.Drawing.Point(99, 64);
            this.edtENABLE.Name = "edtENABLE";
            this.edtENABLE.Size = new System.Drawing.Size(59, 17);
            this.edtENABLE.TabIndex = 6;
            this.edtENABLE.Text = "Enable";
            // 
            // lbSHORTKEY
            // 
            this.lbSHORTKEY.AutoSize = true;
            this.lbSHORTKEY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSHORTKEY.Location = new System.Drawing.Point(19, 40);
            this.lbSHORTKEY.Name = "lbSHORTKEY";
            this.lbSHORTKEY.Size = new System.Drawing.Size(53, 15);
            this.lbSHORTKEY.TabIndex = 8;
            this.lbSHORTKEY.Text = "Shortkey";
            // 
            // edtSHORTKEY
            // 
            this.edtSHORTKEY.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtSHORTKEY.Location = new System.Drawing.Point(99, 37);
            this.edtSHORTKEY.Name = "edtSHORTKEY";
            this.edtSHORTKEY.Size = new System.Drawing.Size(231, 22);
            this.edtSHORTKEY.TabIndex = 7;
            this.edtSHORTKEY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtSHORTKEY_KeyDown);
            this.edtSHORTKEY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtSHORTKEY_KeyPress);
            // 
            // edtDOUBLECLICK
            // 
            this.edtDOUBLECLICK.AutoSize = true;
            this.edtDOUBLECLICK.Location = new System.Drawing.Point(99, 87);
            this.edtDOUBLECLICK.Name = "edtDOUBLECLICK";
            this.edtDOUBLECLICK.Size = new System.Drawing.Size(119, 17);
            this.edtDOUBLECLICK.TabIndex = 6;
            this.edtDOUBLECLICK.Text = "Enable double click";
            // 
            // edtHOLDCLICK
            // 
            this.edtHOLDCLICK.AutoSize = true;
            this.edtHOLDCLICK.Location = new System.Drawing.Point(99, 110);
            this.edtHOLDCLICK.Name = "edtHOLDCLICK";
            this.edtHOLDCLICK.Size = new System.Drawing.Size(103, 17);
            this.edtHOLDCLICK.TabIndex = 6;
            this.edtHOLDCLICK.Text = "Hold to translate";
            // 
            // edtICON
            // 
            this.edtICON.Location = new System.Drawing.Point(37, 64);
            this.edtICON.Name = "edtICON";
            this.edtICON.Size = new System.Drawing.Size(25, 22);
            this.edtICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.edtICON.TabIndex = 41;
            this.edtICON.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoEllipsis = true;
            this.btnAdd.AutoSize = true;
            this.btnAdd.HAllowDisable = false;
            this.btnAdd.HisBorder = true;
            this.btnAdd.HisClickChange = true;
            this.btnAdd.HisDisable = false;
            this.btnAdd.HResourceImage = "";
            this.btnAdd.Image = global::GB.Properties.Resources.BAT;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(333, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 17);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "       Process List";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // edtSKIP_OLD_CLIPBOARD
            // 
            this.edtSKIP_OLD_CLIPBOARD.AutoSize = true;
            this.edtSKIP_OLD_CLIPBOARD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtSKIP_OLD_CLIPBOARD.Location = new System.Drawing.Point(99, 133);
            this.edtSKIP_OLD_CLIPBOARD.Name = "edtSKIP_OLD_CLIPBOARD";
            this.edtSKIP_OLD_CLIPBOARD.Size = new System.Drawing.Size(249, 17);
            this.edtSKIP_OLD_CLIPBOARD.TabIndex = 6;
            this.edtSKIP_OLD_CLIPBOARD.Text = "By past old clip board ( for word/excel/offlice.. )";
            this.edtSKIP_OLD_CLIPBOARD.UseVisualStyleBackColor = false;
            // 
            // APPTRANSLATE_DETAIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 251);
            this.Controls.Add(this.edtICON);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.edtAPPNAME);
            this.Controls.Add(this.lbAPPNAME);
            this.Controls.Add(this.edtSKIP_OLD_CLIPBOARD);
            this.Controls.Add(this.edtHOLDCLICK);
            this.Controls.Add(this.edtDOUBLECLICK);
            this.Controls.Add(this.edtENABLE);
            this.Controls.Add(this.edtSHORTKEY);
            this.Controls.Add(this.lbSHORTKEY);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "APPTRANSLATE_DETAIL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application for Translate";
            this.Load += new System.EventHandler(this.APPTRANSLATE_DETAIL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtICON)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
private System.Windows.Forms.Label lbAPPNAME;
                    private System.Windows.Forms.TextBox edtAPPNAME;
private System.Windows.Forms.CheckBox edtENABLE;
private System.Windows.Forms.Label lbSHORTKEY;
                    private System.Windows.Forms.TextBox edtSHORTKEY;
                    private System.Windows.Forms.CheckBox edtDOUBLECLICK;
                    private lbButton btnAdd;
                    private System.Windows.Forms.CheckBox edtHOLDCLICK;
                    private System.Windows.Forms.PictureBox edtICON;
                    private System.Windows.Forms.CheckBox edtSKIP_OLD_CLIPBOARD;
        
    }
}