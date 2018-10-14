using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GB
{
    public partial class RunCMD : Form
    {
        public int CONTROL_ID = 0;
        public int REMOTE_ID = 0;
        public int SESSION_ID = 0;

        public RunCMD()
        {
            InitializeComponent();
        }

        private void RunCMD_Load(object sender, EventArgs e)
        {
            String command = "CLIPBOARD;" + "";
            DHuy.AddCommand(SESSION_ID, command);
            Clipboard.Clear();
        }


        string oldclip = "";
        private void edtCMD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
           {
               edtCMD.SelectAll();
           }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{BKSP}");
                string cmd = edtCMD.Text;
                try
                {
                    string action = "RUN_CMD;" + cmd;
                    DHuy.AddCommand(SESSION_ID, action);
                    oldclip = Clipboard.GetText();
                }
                catch (Exception ex) { }

                finally
                {
                   
                }
            }
        }

        private void timerAction_Tick(object sender, EventArgs e)
        {
            string newclip = Clipboard.GetText();
            if (newclip != oldclip)
            {
                oldclip = newclip;
                edtCMD.Text = newclip;
            }
        }

        private void RunCMD_Activated(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
        }

        private void RunCMD_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.2;
        }
    }
}
