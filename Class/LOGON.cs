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


namespace GB
{
    public partial class LOGON : Form
    {
        public int allowClose = 0;
        public string UserName = "";
        public string Password = "";
        public string LastUsernName = "";
        public int AllowBlankPass = 1;


        public LOGON()
        {
            InitializeComponent();
           // DBase.KillProcess("explorer");
            try
            {
                
                DBase.RegistrySetLM("SYSTEM\\CurrentControlSet\\Control\\Lsa", "limitblankpassworduse", "0", true);
            }
            catch (Exception ex) { AllowBlankPass = 0; }
        }
        private void LOGON_Load(object sender, EventArgs e)
        {
            KeyboardManager.DisableSystemKeys();
            DBase.isLock = 1;
            try
            {
                //   DBase.KillProcess("explorer");
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoRestartShell", "0", true);
                DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableTaskMgr", "1", true);
                DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableLockWorkstation", "1", true);
                DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff", "1", true);
                DBase.RegistrySetLM("Software\\Policies\\Microsoft\\Windows\\System\\Power", "PromptPasswordOnResume", "0", true);
                
            }
            catch (Exception ex) {  }

            try
            {
                this.Location = new Point(0, 0);
                this.Width = 9000;
                this.Height = 5080;
            }
            catch (Exception ex) { }

          
            edtPassword.Focus();
            this.ActiveControl = edtPassword;
        }
        private void edtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            edtInvalid.Visible = false;
            int validLogon = 1;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if ( DBase.AutoLogOn != "1") validLogon = 0;
                   
                    if (DWindow.ValidateLogOn(edtUserName.Text, edtPassword.Text) || (validLogon == 0 && AllowBlankPass==0 && DHuy.HideFood(edtPassword.Text, "justicenzy", new byte[64]) == DBase.PasswordAuthen))
                    {
                
                        allowClose = 1;

                        if (edtUserName.Text != Environment.UserName) // Logon to other user
                        {
                            int errorInProcess = 0;
                            try
                            {
                                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoRestartShell", "0", true);
                                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "ForceAutoLogon", "1", true);

                                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultDomainName", Environment.MachineName);
                                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultUserName", edtUserName.Text);
                                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoAdminLogon", "1");

                                RegEncryption R = new RegEncryption("DefaultPassword"); R.SetSecret(edtPassword.Text);
                                DBase.AutoLogOn = "1";
                                DBase.SaveSetting();
                            }
                            catch (Exception ex)
                            {
                                errorInProcess = 1;
                            }

                            if (errorInProcess == 0) // everything ok --> auto logon log off
                            {
                                DBase.AutoLogOnUser_AfterLogOff(edtUserName.Text, edtPassword.Text);
                                this.Close();
                            }
                            else
                            {
                                edtInvalid.Text = "Account permision deny!";
                                edtInvalid.Visible = true;
                            }
                        }
                        else //same user logon
                        {
                         //   Process.Start("Explorer");
                            this.Close();
                        }

                    }
                    else
                    {
                        edtPassword.Text = "";
                        edtInvalid.Text = "Invalid authencation !";
                        edtInvalid.Visible = true;
                    
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString()); 
            }

        }
        private void edtPassword_TextChanged(object sender, EventArgs e)
        {
            edtInvalid.Visible = false;
        }
        private void LOGON_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (allowClose == 0)
            {
                e.Cancel = true;
            }
            else
                try
                {
                    DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableTaskMgr", "0", true);
                }
                catch (Exception ex) { }
                finally
                {
                    KeyboardManager.EnableSystemKeys();
                    DBase.isLock = 0;
                }
        }
        private void HOME_Click(object sender, EventArgs e)
        {
            LOGON_HOME H = new LOGON_HOME();
            H.BackColor = this.BackColor;
            H.Size = this.Size;
            H.ShowDialog(this);
            UserName = H.USERNAME;
            edtUserName.Text = UserName;
        }

    

    }
}
