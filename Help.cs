using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class Help : Form
    {

        public int Res = 0;
        public string TextContents = "";
        public Help()
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

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://dl.dropboxusercontent.com/u/46151949/PCT.exe");
            }
            catch (Exception ex) { }
        }

        private void copyLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://dl.dropboxusercontent.com/u/46151949/PCT.exe");
        }

     
    }
}
