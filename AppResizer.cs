using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class AppResizer : Form
    {
        public AppResizer()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
           IntPtr x =   DBase.GetEXEHandler(edtAppname.Text);
           const short SWP_NOMOVE = 0X2;
           const short SWP_NOSIZE = 1;
           const short SWP_NOZORDER = 0X4;
           const int SWP_SHOWWINDOW = 0x0040;

           DBase.SetWindowPos(x, 0, 0, 0, DBase.IntReturn(edtW.Text), DBase.IntReturn(edtH.Text), SWP_NOZORDER | SWP_SHOWWINDOW);
        
        

        }

    }
}
