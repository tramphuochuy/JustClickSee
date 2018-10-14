using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;




namespace GB
{
    public partial class Translation : Form
    {
        public string key = "";
        public string[] keyCompare;
        public string res = "";
        DataTable temp = new DataTable();
        public int isShow = 0;
        public int RowIndex = 0;
        DataTable DT = new DataTable();
        public TextBox T = null;
        Random Ran = new Random();
        BackgroundWorker W1 = new BackgroundWorker();
        public Image OriIcon = null;

        public Translation()
        {
            InitializeComponent();
            OriIcon = edtIcon.Image;
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted1);
        }

        private void FilterPopup_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        public string KEYWORD;
        public void Translate()
        {
            int Pic = Ran.Next(1,6);
            if (Pic == 1) edtPic.Image = Properties.Resources.Loading;
            else if (Pic == 2) edtPic.Image = Properties.Resources.Loading;
            else if (Pic == 3) edtPic.Image = Properties.Resources.Loading2;
            else if (Pic == 4) edtPic.Image = Properties.Resources.Loading2;
            else if (Pic == 5) edtPic.Image = Properties.Resources.Loading4;

            edtAutoText.Text = "";
            edtResultText.Text = "";
            KEYWORD = edtKey.Text.Replace("(", "").Replace(")", "").Replace(",", "");
            if (DBase.TargetLanguage1 == "vi") DT = DHuy.SELECT_SQL("SELECT * FROM ENVN WHERE EN = '" + KEYWORD + "'");
            else DT.Clear();
            if (DT.Rows.Count == 1)
            {
                edtWordFound.Text = KEYWORD;
                string R =  DBase.StringReturn(DT, 0, "VN").Replace("<br />", Environment.NewLine);
                DisplayResult(R,true);
            }
            else
            {
                edtWordFound.Text = "Google Translate ... ";
                //edtRESULTLABEL.Text = "";
                //edtResultText.Text = "Not found";
                //google API
                if( isbusy == 0 )
                {
                    isbusy = 1;
                    edtPic.Visible = true;
                    edtPic.BringToFront();
                    W1.RunWorkerAsync();
                }
            }
        }

        public void DisplayResult(string R, bool Resize)
        {
            edtAutoText.Text = R;
            edtResultText.Text = R;
            //if (Resize)
            //{
            this.Width = edtAutoText.Width + 30;
            this.Height = edtAutoText.Height + 30;
            if (this.Height < 200) this.Height = 200;
            if (this.Height > 800) this.Height = 800;
            if (this.Width > 1000) this.Width = 1000;
            //}
            edtAutoText.Visible = false;
        }

        public string TranslateText = "";
        public int isbusy = 0;
        public string Title = "";
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Detection D = DBase.GTC.DetectLanguage(KEYWORD);
                if (D.Language != DBase.TargetLanguage1)
                {
                    var Respond = DBase.GTC.TranslateText(KEYWORD, DBase.TargetLanguage1);
                    TranslateText = Respond.TranslatedText;
                    Title = D.Language + "-" + DBase.TargetLanguage1Name;
                }
                else
                {
                    var Respond = DBase.GTC.TranslateText(KEYWORD, DBase.TargetLanguage2);
                    TranslateText = Respond.TranslatedText;
                    Title = DBase.TargetLanguage1Name + "-" + DBase.TargetLanguage2Name;
                }
               

                
            }
            catch (Exception ex) {
              //  MessageBox.Show(ex.ToString());
                
            }

        } 
        private void bgw_RunWorkerCompleted1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            isbusy = 0;
            edtWordFound.Text = "Google Translate ( " +Title + " )";
            edtPic.Visible = false;
            DisplayResult(TranslateText, true);
           
        }




        public string OLDCLIPBOARD = "";
        private void Translation_Deactivate(object sender, EventArgs e)
        {
            //MessageBox.Show("3");
            this.Close();
            //Clipboard.SetText(OLDCLIPBOARD);
           
        }







        public void UpdateIcon(DataTable dt)
        {
            DBase.AddColumn(dt, "ICON", typeof(Image));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              //  DBase.SetValue(dt, i, "ICON", Properties.Resources.RemoveBlack);
            }
        }
        private void edtKey_TextChanged(object sender, EventArgs e)
        {

        }
       
        

        private void FilterPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
               this.Close();
            }

        }

     

        private void Translation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public bool isMouseIn = false;
        private void Translation_MouseLeave(object sender, EventArgs e)
        {
            isMouseIn = true;
        }

        private void Translation_MouseEnter(object sender, EventArgs e)
        {
            isMouseIn = false;
        }

        private void exiitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Translation_Leave(object sender, EventArgs e)
        {
            this.Close();
        }







        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Caption_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.Clicks == 1) && (this.WindowState != FormWindowState.Maximized))
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void CLOSE_Enter(object sender, EventArgs e)
        {
                //this.edtIcon.Image = global::GB.Properties.Resources.RemoveBlack;
        }
        private void CLOSE_Leave(object sender, EventArgs e)
        {
            //this.edtIcon.Image = OriIcon;
        }

        private void edtIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }









    }
}
