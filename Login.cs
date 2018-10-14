using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class Login : Form
    {

        public int Res = 0;
        public string UserName = "";
      
        public Login()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            if (DBase.LastUserLogin2 != "") edtName.Text = DBase.LastUserLogin2;
            if (edtName.Text != "")
            {
                edtPass.Focus();
                this.ActiveControl = edtPass;

            }
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            UserName = edtName.Text;
            lbWelcome.Text = " Love you! ";
            DataTable dt = DHuy.SELECT_SQL("SELECT * FROM USERS WHERE USERCODE = '" + edtName.Text + "' AND PASSWORD = '" + edtPass.Text + "'" );
            if (dt.Rows.Count > 0)
            {
                Res = 1;
                DBase.LastUserLogin = edtName.Text;
                DBase.LastUserLogin2 = DBase.LastUserLogin;
                DBase.LastPasswordLogin = edtPass.Text;
                DBase.SaveSetting();
                this.Close();
            }
            else
            {
                lbWelcome.Text = " Name/Password is incorrect!";
            }


        }


        private void REGISTER_Click(object sender, EventArgs e)
        {
            panHead.BackColor = Color.MediumSeaGreen;
            Register R = new Register();
            R.Location = new Point(Location.X, Location.Y + Height + 1);
            R.ShowDialog();
            panHead.BackColor = Color.SeaGreen;
            if (R.Res == 1)
            {
               
                lbWelcome.Text = "Welcome ! " + R.AccountName;
                edtName.Text = R.AccountName;
                edtPass.Focus();
            }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void edtPass_KeyUp(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }
    }
}
