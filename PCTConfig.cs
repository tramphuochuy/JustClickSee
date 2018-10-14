using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GB
{
    public partial class PCTConfig : Form
    {
        public string PCNAME = "";
        public string CurrentUserLogin = "";
        public int Res = 0;
        public string TextContents = "";
        public string Text = "";
        public ZPCT M = null;
        public PCTConfig()
        {
            InitializeComponent();
        }

        public void SetColor(Color C )
        {
            panHead.BackColor = BackColor = edtText.ForeColor = C;
        }
        private void Config_Load(object sender, EventArgs e)
        {
            try
            {
                edtPassword.Text = DHuy.OpenFood(DBase.PasswordAuthen, "justicenzy", new byte[64]);
                edtNickName.Text = DBase.NickName;
               
                if (DBase.AutoLogOn == "1") edtAutoLogon.Checked = true;
                if (DBase.WallChange == 1) edtWallPapper.Checked = true;
                if (DBase.ActiveTranslation == 1) edtActiveTranslator.Checked = true;
                edtIntervalWall.Text = DBase.StringReturn(DBase.WallChangeSecond);

                if (DBase.LockDesktopWhenSessionFinish == "1") edtLockAfterSession.Checked = true;
                if (DBase.AutoupdateWhenStart == "1") edtAutoUpdateWhenStart.Checked = true;
                if (DBase.DisableAreoThemWhenConnect == "1") edtDisableAreo.Checked = true;
                if (DBase.SoundDeviceText == "") edtSoundDevice.Text = "Headphone,Speakers";
                else edtSoundDevice.Text = DBase.SoundDeviceText;
                edtDisableWindowsLock.Checked = DBase.RegistryGetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff") == "1" ? true : false; // DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff", "1", true);
                
            }
            catch (Exception ex) { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (edtPassword.Text == "") DBase.PasswordAuthen = "";
                else DBase.PasswordAuthen = DHuy.HideFood(edtPassword.Text, "justicenzy", new byte[64]);
                DBase.NickName = edtNickName.Text;
                DBase.LockDesktopWhenSessionFinish = edtLockAfterSession.Checked ? "1" : "0";
                DBase.AutoupdateWhenStart = edtAutoUpdateWhenStart.Checked ? "1" : "0";
                DBase.DisableAreoThemWhenConnect = edtDisableAreo.Checked ? "1" : "0";
                DBase.WallChange = edtWallPapper.Checked ? 1 : 0;
                DBase.WallChangeSecond = DBase.IntReturn(edtIntervalWall.Text);
                DBase.ActiveTranslation = edtActiveTranslator.Checked ? 1 : 0;
                DBase.SoundDeviceText = edtSoundDevice.Text;
                if ( edtDisableWindowsLock.Checked) 
                DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff","1",true) ;
                else DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff", "0", true);

            }
            catch (Exception ex) { }


            DBase.SaveSetting();
            M.RefreshButton();
            this.Close();
        }
        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CHAT_Click(object sender, EventArgs e)
        {
            M.PublicChat.Show();
        }

        // Advanced Config
        private void edtAutoLogon_Click(object sender, EventArgs e)
        {
            int canEditReg = 1;
            try
            {
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultDomainName", Environment.MachineName);
            }
            catch (Exception ex)
            {
                canEditReg = 0;

            }
            if (canEditReg == 0)
            {
                MessageBox.Show("Administrator Only!");
                edtAutoLogon.Checked = edtAutoLogon.Checked ? false : true;
                return;
            }

            if (edtAutoLogon.Checked)
            {
                try
                {
                    ConfigAutoLogOn C = new ConfigAutoLogOn();
                    C.Location = new Point(this.Location.X, this.Location.Y + 30 );
                 
                    C.ShowDialog(this);
                    if (C.Res == 1)
                    {
                        try
                        {

                           
                            DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoRestartShell", "0", true);
                            DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "ForceAutoLogon", "1", true);

                            DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultDomainName", Environment.MachineName);
                            DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultUserName", Environment.UserName);
                            DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoAdminLogon", "1");
                            DBase.RegistrySetLM("SYSTEM\\CurrentControlSet\\Control", "WaitToKillServiceTimeout", "1000");

                            RegEncryption R = new RegEncryption("DefaultPassword"); R.SetSecret(C.TextInput);
                            DBase.AutoLogOn = "1";
                            DBase.LogOnPassword = DHuy.HideFood(C.TextInput, "Asdasd123!", new byte[512]);
                            DBase.SaveSetting();

                           

                        }
                        catch (Exception ex) { DBase.AutoLogOn = "0"; }
                        try
                        {
                            DBase.RegistryDeleteCU("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run","PCT");
                            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                            if (rk.GetValue("PCT") != null) rk.DeleteValue("PCT");
                            if (DBase.AutoLogOn == "1")
                            {
                                rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP_LOGON");
                            }
                            else rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP");

                            M.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
                        }
                        catch (Exception ex) { }
                    }
                    else
                    {
                        DBase.AutoLogOn = "0";
                        edtAutoLogon.Checked = false;
                        try
                        {
                            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true);
                            if (rk.GetValue("DefaultDomainName") != null) rk.DeleteValue("DefaultDomainName");
                            if (rk.GetValue("ForceAutoLogon") != null) rk.DeleteValue("ForceAutoLogon");
                            if (rk.GetValue("DefaultUserName") != null) rk.DeleteValue("DefaultUserName");
                            DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoAdminLogon", "0");
                            if (rk.GetValue("DefaultPassword") != null) rk.DeleteValue("DefaultPassword");
                            DBase.LogOnPassword = "";
                        }
                        catch(Exception ex){}
                    }
                }
                catch (Exception ex) { }
                
            }
            else
            {
                try
                {
                    DBase.AutoLogOn = "0";
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true);
                    if (rk.GetValue("DefaultDomainName") != null) rk.DeleteValue("DefaultDomainName");
                    if (rk.GetValue("ForceAutoLogon") != null) rk.DeleteValue("ForceAutoLogon");
                    if (rk.GetValue("DefaultUserName") != null) rk.DeleteValue("DefaultUserName");
                    if (rk.GetValue("AutoAdminLogon") != null) rk.DeleteValue("AutoAdminLogon");
                    if (rk.GetValue("DefaultPassword") != null) rk.DeleteValue("DefaultPassword");
                    DBase.LogOnPassword = "";

                }
                catch (Exception ex) { }

                try
                {
                    
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (rk.GetValue("PCT") != null) rk.DeleteValue("PCT");
                    rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP");
                    M.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
                }
                catch (Exception ex) { }
                

               
            }
            DBase.SaveSetting();
        }
        private void edtWindowsLock_Click(object sender, EventArgs e)
        {

        }

        private void cmsLoadDevice_Click(object sender, EventArgs e)
        {
            Form F = new Form();
            TextBox T = new TextBox();
            T.Multiline = true;
            F.Controls.Add(T);
            F.Height = T.Height = 500;
            F.Width = T.Width = 500;
            

            F.Show();
        }

        private void Help_SetNameSoundDevice_Click(object sender, EventArgs e)
        {
            DBase.DownloadAndRun("ChangeNameSoundDevice.png");
        }
       

    }
}
