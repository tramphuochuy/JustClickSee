using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class DiaryBook : Form
    {

        public int Res = 0;
        public string TextContents = "";
        public DiaryBook()
        {
            InitializeComponent();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chatbox.vn");
        }

     
    }
}
