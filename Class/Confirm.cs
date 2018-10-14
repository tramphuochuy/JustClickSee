using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class Confirm : Form
    {

        public int Res = 0;
        public string TextContents = "";
        public Confirm()
        {
            InitializeComponent();
        }

        public void SetColor(Color C )
        {
            panHead.BackColor = BackColor = edtText.ForeColor = C;
        }
        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Res = 1;
            this.Close();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
