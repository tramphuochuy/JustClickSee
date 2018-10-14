using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GB
{
    public partial class Config : Form
    {
        public string PCNAME = "";
        public string CurrentUserLogin = "";
        public int Res = 0;
        public string TextContents = "";
        public string Text = "";
        public ZMain M = null;
        public Config()
        {
            InitializeComponent();
        }

        public void SetColor(Color C )
        {
            //panHead.BackColor = BackColor = edtText.ForeColor = C;
        }
        private void Config_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (DBase.ActiveTranslation == 1) edtActiveTranslator.Checked = true;
                if (DBase.ShowException == 1) edtShowException.Checked = true;
                edtTarget1.Text = DBase.TargetLanguage1Setting;
                edtTarget2.Text = DBase.TargetLanguage2Setting;
                    
            }
            catch (Exception ex) { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (edtTarget1.Text == "" )
                {
                    edtTarget1.BackColor = Color.Pink;
                    return;
                }
                else edtTarget1.BackColor = Color.White;

                if (edtTarget2.Text == "")
                {
                    edtTarget2.BackColor = Color.Pink;
                    return;
                }
                else edtTarget1.BackColor = Color.White;

                DBase.TargetLanguage1Setting = edtTarget1.Text;
                DBase.TargetLanguage2Setting = edtTarget2.Text;

                try
                {

                    DBase.TargetLanguage1 = DBase.TargetLanguage1Setting.Split('-')[0];
                    DBase.TargetLanguage2 = DBase.TargetLanguage2Setting.Split('-')[0];
                    DBase.TargetLanguage1Name = DBase.TargetLanguage1Setting.Split('-')[1];
                    DBase.TargetLanguage2Name = DBase.TargetLanguage2Setting.Split('-')[1];
                }
                catch (Exception) { }

                DBase.ActiveTranslation = edtActiveTranslator.Checked ? 1 : 0;
                DBase.ShowException = edtShowException.Checked ? 1 : 0;
                //DBase.SoundDeviceText = edtSoundDevice.Text;
              

            }
            catch (Exception ex) { }


            DBase.SaveSetting();
            M.RefreshButton();
            this.Close();
        }
        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CHAT_Click(object sender, EventArgs e)
        {
          
        }

        // Advanced Config
      
    

        private void cmsLoadDevice_Click(object sender, EventArgs e)
        {
            Form F = new Form();
            TextBox T = new TextBox();
            T.Multiline = true;
            F.Controls.Add(T);
            F.Height = T.Height = 500;
            F.Width = T.Width = 500;
            

            F.Show();
        }

        private void Help_SetNameSoundDevice_Click(object sender, EventArgs e)
        {
            DBase.DownloadAndRun("ChangeNameSoundDevice.png");
        }

        private void edtTarget1_Click(object sender, EventArgs e)
        {
            LanguageList F = new LanguageList();
            F.StartPosition = FormStartPosition.Manual;
            F.Icon = this.Icon;
            F.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
            F.ShowDialog();
            if (F.Res > 0)
            {
                edtTarget1.Text = F.APPNAME;
            }

        }

        private void edtTarget2_Click(object sender, EventArgs e)
        {
            LanguageList F = new LanguageList();
            F.StartPosition = FormStartPosition.Manual;
            F.Icon = this.Icon;
            F.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
            F.ShowDialog();
            if (F.Res > 0)
            {
                edtTarget2.Text = F.APPNAME;
            }
        }
       

    }
}
