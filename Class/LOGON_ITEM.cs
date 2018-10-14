using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class LOGON_ITEM : UserControl
    {
        public string USERNAME = "";
        public string PASSWORD = "";
        public LOGON_HOME H = null;

        public LOGON_ITEM()
        {
            InitializeComponent();
           
        }

        private void edtUserName_Click(object sender, EventArgs e)
        {
            H.USERNAME = USERNAME;
            H.PASSWORD = PASSWORD;
            H.allowClose = 1;
            H.Close();
         
        }

        private void LOGON_ITEM_Load(object sender, EventArgs e)
        {
            if ( Environment.UserName == USERNAME)
            {
                DBase.BoldLabel(edtUserName);
            }
        }
    }
}
