using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;


namespace GB
{
    public partial class ConfigAutoLogOn : Form
    {

        public int Res = 0;
        public string TextInput = "";
     
        public ConfigAutoLogOn()
        {
            InitializeComponent();
        }

        public void SetColor(Color C )
        {
            panHead.BackColor = BackColor = edtText.ForeColor = C;
        }
        private void Register_Load(object sender, EventArgs e)
        {
            edtTitle.Text = edtTitle.Text + " ( Current Logon : " + Environment.UserName + " ) ";
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            this.Close();



        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TextInput = edtPassword.Text;
            if (TextInput == "")
            {
                try
                {
                    DBase.RegistrySetLM("SYSTEM\\CurrentControlSet\\Control\\Lsa", "limitblankpassworduse", "0", true);
                }
                catch (Exception ex) { }
            }
            if (DWindow.ValidateLogOn(Environment.UserName, TextInput))
            {
                Res = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Your password is incorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                edtPassword.Text = "";
            }
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
