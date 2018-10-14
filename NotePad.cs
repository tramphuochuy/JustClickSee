using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class NotePad : Form
    {
        public string FilePath = "";
        public string UserCode = "";
        public long ID = 0;

        public NotePad()
        {
            InitializeComponent();
        }

        private void cmsNew_Click(object sender, EventArgs e)
        {

        }

        private void cmsSave_Click(object sender, EventArgs e)
        {

        }

        private void cmsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotePad_Load(object sender, EventArgs e)
        {
            if (DBase.UserCodeLogin == "")
            {
                edtBody.Text = "";
            }
        }
    }
}
