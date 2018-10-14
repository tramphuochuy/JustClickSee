using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class ConfirmAuthencation : Form
    {

        public int Res = 0;
     
        public string UserName = "";
        public string Password = "";

        public ConfirmAuthencation()
        {
            InitializeComponent();
        }

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            UserName = edtUserName.Text;
            Password = DHuy.HideFood(edtPassword.Text, "RELOGON", new byte[256]);
            Res = 1;
            this.Close();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }

     
    }
}
