using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class Register : Form
    {
        public int Res = 0;
        public string AccountName = "";
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            lbRegister.Visible = false;
            DataTable dt = DHuy.SELECT_NEWROW("USERS");
            dt.Rows[0]["USERCODE"] = edtName.Text;
            dt.Rows[0]["PASSWORD"] = edtPass.Text;

            DHuy dhuy = new DHuy();
          
           int kq =  DHuy.INSERT_IDENTITY("USERS", dt);
           if (kq > 0)
           {
               AccountName = edtName.Text;
               Res = 1;
               this.Close();
           }
           else
           {
               lbRegister.Visible = true;
           }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }
    }
}
