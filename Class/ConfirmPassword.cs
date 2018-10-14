using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class ConfirmPassword : Form
    {

        public int Res = 0;
        public string TextContents = "";
        public string Text = "";
        public ConfirmPassword()
        {
            InitializeComponent();
        }

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            Text = edtPassword.Text;
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
