using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class PCS : UserControl
    {
        public ZPCT M = null;
        public int ID = 0;
        public int PCS_ID = 0;
        public string PCS_NAME = "";
        public string PASS = "";
        public string USERCODE = "";
        public int isOnline = 0;
        public int Last_Signal = 0;
        public int Last_Signal_Second = 0;
        public int isBundle = 0;
        public string BundleString = "";

        public PCS()
        {
            InitializeComponent();
        
        }

        private void PCS_Load(object sender, EventArgs e)
        {
            lbText.Text = "          " + PCS_NAME + " ( " + PCS_ID + " ) ";
            if ( isOnline == 1)
            {
                lbText.ResetStatus(false);
            }
            else lbText.ResetStatus(true);

            if (BundleString != "")
            {
                lbText.ForeColor = Color.Blue;
            }


        }

        private void cmsDeletePCS_Click(object sender, EventArgs e)
        {
            Confirm C = new Confirm();
            C.StartPosition = FormStartPosition.CenterScreen;
            C.edtText.Text = "Delete ?";
            C.ShowDialog();
            if (C.Res == 1)
            {
                DHuy.DELETE("USER_PCS", ID);
                M.RefreshPCS();
                M.panRight.Visible = true;
            }
        }
        private void cmsRemotePCS_Click(object sender, EventArgs e)
        {
            M.edtRemoteID.Text = PCS_ID.ToString();
            M.NameInList = PCS_NAME;
           
            M.CONTROL_BEGIN_SESSION(null, null);
        }
        private void lbText_DoubleClick(object sender, EventArgs e)
        {
            M.edtRemoteID.Text = PCS_ID.ToString();
            M.NameInList = PCS_NAME;
            if( PASS != "")  M.RemotePassword = DHuy.OpenFood(PASS, "ForTheWin", new byte[256]);
            M.REMOTE(PCS_ID, M.RemotePassword, PCS_NAME, 0);
            M.RemotePassword = "";
        }
        private void lbText_Click_1(object sender, EventArgs e)
        {
            M.edtRemoteID.Text = PCS_ID.ToString();
        }
        private void edtEdit_Click(object sender, EventArgs e)
        {
            PCS_Detail A = new PCS_Detail();
            A.lbWelcome.Text = "Edit";
            A.ID = ID;
            A.USERCODE = USERCODE;
            A.isUpdate = 1;
            A.edtPass.Text = DHuy.OpenFood(PASS, "ForTheWin", new byte[256]);
            A.edtPCS_NAME.Text = PCS_NAME;
            A.edtPCS_ID.Text = PCS_ID.ToString();
            A.ShowDialog();
            if (A.Res == 1)
            {
                M.RefreshPCS();
                M.panRight.Visible = true;
            }
        }

        private void cmsFileTransferPCS_Click(object sender, EventArgs e)
        {
             M.TRANSFER_BEGIN_SESSION(PCS_ID);
        }
        private void lbText_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.SkyBlue;
        }
        private void lbText_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        public void Update(int Online)
        {
            if (Online == 1)
            {
                isOnline = 1;
                lbText.ResetStatus(false);
            }
            else
            {
                isOnline = 0;
                lbText.ResetStatus(true);
            }
        }
        private void cmsRefresh_Click(object sender, EventArgs e)
        {
            M.RefreshPCS();
            M.panRight.Visible = true;
        }

        private void cmsBundle_Click(object sender, EventArgs e)
        {
            BundleConfig B = new BundleConfig();
            B.Icon = M.Icon;
            B.M = M;
            B.ID = ID;
            B.Show();
        }

        private void cmsBundleRemote_Click(object sender, EventArgs e)
        {
            if (BundleString != "")
            {
                string[] S = BundleString.Split('\n');
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] == "") continue;
                    String PCSID = S[i].Split(':')[0];
                    //M.edtRemoteID.Text = PCSID;
                    string pcsname = "";
                    try
                    {
                        pcsname = DBase.StringReturn(DBase.dtpcslist.Select("PCS_ID = " + PCSID)[0]["PCS_NAME"]);
                    }
                    catch(Exception  ex)
                    {
                        
                       // MessageBox.Show(ex.ToString());
                    }
                    string RemotePassword = "1";
                    try
                    {
                        RemotePassword = S[i].Split(':')[1];
                    }
                    catch (Exception ex) { }
                    M.REMOTE(DBase.IntReturn(PCSID),RemotePassword,pcsname, 1);

                }
            }
        }
    }
}
