using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using System.DirectoryServices;



namespace GB
{
    public partial class LOGON_HOME : Form
    {
        public int allowClose = 0;
        public String USERNAME = "";
        public String PASSWORD = "";


        public LOGON_HOME()
        {
            InitializeComponent();

        }

        private void LOGON_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (allowClose == 0)
            {
                e.Cancel = true;
            }
        }

        private void LOGON_Load(object sender, EventArgs e)
        {
            panFlow.Controls.Clear();
            try
            {
                List<String> List = DWindow.GetUsers();
                foreach (string S in List)
                {
                    if (S.Contains("$") | S.ToLower() == "guest") continue;
                    LOGON_ITEM L = new LOGON_ITEM();
                    L.BackColor = this.BackColor;
                    L.edtUserName.BackColor = this.BackColor;
                    L.edtUserName.Text = S;
                    L.H = this;
                    L.USERNAME = S;
                    panFlow.Controls.Add(L);
                }



            }
            catch (Exception ex) { }
 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
