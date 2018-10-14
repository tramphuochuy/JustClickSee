using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace GB
{
    public partial class ZMain : Form
    {
        BackgroundWorker W1 = new BackgroundWorker();
       
        public ZMain()
        {
            HookSetup();
            

           

            InitializeComponent();
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rk.GetValue("JCS") == null) this.cmsStartWithWindow.Image = null;
                else this.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
            }
            catch (Exception ex) { }

          //  MessageBox.Show("JustClickSee will restart explorer to enable API\nOK to continue");
         
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGLoading);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGLoading_Complete);
          
          
            DBase.UserCodeLogin = "ADMIN";
           
            if (DBase.StartMinimize == 1)
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
           
            try
            {
                DBase.GTC = TranslationClient.Create();
                DBase.API_Working = true;
                DBase.DTAPP = DHuy.SELECT_SQL("SELECT APPNAME,ENABLE,SHORTKEY,DOUBLECLICK,HOLDCLICK,SKIP_OLD_CLIPBOARD FROM APPTRANSLATE WHERE USERCODE ='ADMIN'");
            }
            catch (Exception ex3)
            {
               
                if (ex3.ToString().ToUpper().Contains("GOOGLE_APPLICATION_CREDENTIALS"))
                {
                    MessageBox.Show("JustClickSee will restart explorer to enable API\nOK to continue","Enable API",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    DBase.SetEnvirmoment();
                    try
                    {
                        DBase.GTC = TranslationClient.Create();
                        DBase.API_Working = true;
                        MessageBox.Show("Google Translate installed successful ! ");
                    }
                    catch (Exception ex4)
                    {
                        this.Text = "Restart to enable API !";
                        isClose = 1;
                        this.Close();
                        //MessageBox.Show("API not registed ! ");
                        //MessageBox.Show(ex4.ToString());
                    }
                }

             
            }
            //W1.RunWorkerAsync();
           
        }

        private void BGLoading(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            HookSetup();
        } //Action
        private void BGLoading_Complete(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            
        }

      
        public void HookSetup()
        {
            HookManager.KeyDown += new KeyEventHandler(HookManager_KeyDown);
         
            HookManager.MouseDoubleClick += HookManager_MouseDoubleClick;
            HookManager.MouseDown += new MouseEventHandler(HookManager_MouseDown);
            HookManager.MouseUp += new MouseEventHandler(HookManager_MouseUp);
            //HookManager.KeyPress += new KeyPressEventHandler(HookManager_KeyPress);
            //HookManager.KeyUp += new KeyEventHandler(HookManager_KeyUp);
         
          
        }


        bool ENABLE = false;
        bool DOUBLECLICK = false;
        bool HOLDCLICK = false;
        bool SKIP_OLD_CLIPBOARD = false;
        string APPNAME = "";
        string SHORTKEY = "";
        DataTable dtf = new DataTable();
        Keys key = Keys.F2;
        public string LastClip = "";
        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (DBase.ActiveTranslation == 0) return;
            try
            {
                APPNAME = DBase.ActiveApplicationName();
                dtf = DBase.FilterTable(DBase.DTAPP, "APPNAME = '" + APPNAME + "'");
                if (dtf.Rows.Count > 0)
                {
                    ENABLE = DBase.BoolReturn(dtf, 0, "ENABLE");
                    SKIP_OLD_CLIPBOARD = DBase.BoolReturn(dtf, 0, "SKIP_OLD_CLIPBOARD");
                    if (ENABLE)
                    {
                        SHORTKEY = DBase.StringReturn(dtf, 0, "SHORTKEY");
                        Enum.TryParse(SHORTKEY, out key);
                        if (e.KeyCode == key)
                        {
                            TRANSLATE(false);
                        }
                        else
                        {
                            this.Text = "KD - " + APPNAME + " - " + SHORTKEY;
                        }

                       
                    }
                }

                
            }
            catch (Exception ex)
            {
                if (DBase.ShowException == 1) MessageBox.Show(ex.ToString());
            }

            //Enable/Disable
            if (DWindow.IsControlKeyDown() && DWindow.IsAltKeyDown() && DWindow.IsShiftKeyDown())
            {
                if ((DateTime.Now - LastKeyPress).TotalMilliseconds > 1000)
                {
                    LastKeyPress = DateTime.Now;
                    DBase.ActiveTranslation = DBase.ActiveTranslation == 1 ? 0 : 1;
                    RefreshButton();
                }
            }

        }
        void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
            MDown = DateTime.Now;
            X = Cursor.Position.X;
            Y = Cursor.Position.Y;
        }
        void HookManager_MouseUp(object sender, MouseEventArgs e)
        {
            if (DBase.ActiveTranslation == 0) return;
          
            try
            {
                if ((DateTime.Now - MDown).TotalMilliseconds >= 2000)
                {
                    APPNAME = DBase.ActiveApplicationName();
                    SHORTKEY = DBase.StringReturn(dtf, 0, "SHORTKEY");
                    P2 = new Point(Cursor.Position.X, Cursor.Position.Y);
                  
                    this.Text = APPNAME + " - " + DBase.HandleLocation_Top + " - " + (Cursor.Position.Y - DBase.HandleLocation_Top);
                    dtf = DBase.FilterTable(DBase.DTAPP, "APPNAME = '" + APPNAME + "'");
                    if (dtf.Rows.Count > 0)
                    {
                        ENABLE = DBase.BoolReturn(dtf, 0, "ENABLE");
                        if (ENABLE)
                        {
                            DOUBLECLICK = DBase.BoolReturn(dtf, 0, "DOUBLECLICK");
                            HOLDCLICK = DBase.BoolReturn(dtf, 0, "HOLDCLICK");
                            SHORTKEY = DBase.StringReturn(dtf, 0, "SHORTKEY");
                            SKIP_OLD_CLIPBOARD = DBase.BoolReturn(dtf, 0, "SKIP_OLD_CLIPBOARD");
                            if (HOLDCLICK)
                            {
                                if (Cursor.Position.X < X) X = Cursor.Position.X;
                                if (Cursor.Position.Y < Y) Y = Cursor.Position.Y;

                                if (APPNAME.ToLower() == "firefox" || APPNAME.ToLower() == "chrome" || APPNAME.ToLower() == "steam" || APPNAME.ToLower() == "opera")
                                {
                                    if (Cursor.Position.Y > 150)
                                    {
                                      
                                        TRANSLATE(true);
                                    }
                                    else
                                    {
                                        //this.Text = DateTime.Now.ToString("hh:ss");
                                    }
                                }
                                else TRANSLATE(true);
                            }
                            else
                            {
                                this.Text = "HC - " + APPNAME + " - DISABLED - " + SHORTKEY + "  ";
                            }
                        }
                    }
                }
                else
                {
                    //this.Text = "JustClickSee";
                }
            }
            catch (Exception ex) {

                if (DBase.ShowException == 1) MessageBox.Show(ex.ToString());
            }
        }

      
        private void HookManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                APPNAME = DBase.ActiveApplicationName();
                this.Text = "DBC - " + APPNAME;
                DataTable dtf = DBase.FilterTable(DBase.DTAPP, "APPNAME = '" + APPNAME + "'");
                if (dtf.Rows.Count > 0)
                {
                    ENABLE = DBase.BoolReturn(dtf, 0, "ENABLE");
                    if (ENABLE)
                    {
                        DOUBLECLICK = DBase.BoolReturn(dtf, 0, "DOUBLECLICK");
                        HOLDCLICK = DBase.BoolReturn(dtf, 0, "HOLDCLICK");
                        SHORTKEY = DBase.StringReturn(dtf, 0, "SHORTKEY");
                        SKIP_OLD_CLIPBOARD = DBase.BoolReturn(dtf, 0, "SKIP_OLD_CLIPBOARD");
                        if (DOUBLECLICK)
                        {
                            if (APPNAME.ToLower() == "firefox" || APPNAME.ToLower() == "chrome" || APPNAME.ToLower() == "steam" || APPNAME.ToLower() == "opera")
                            {
                                if ((Cursor.Position.Y - DBase.HandleLocation_Top) > 150)
                                {
                                    TRANSLATE(true);
                                }
                            }
                            else TRANSLATE(true);
                        }
                        else
                        {
                            this.Text = "DBC - " + APPNAME + " - DISABLED - "+ SHORTKEY  ;
                        }
                    }
                    else
                    {
                       
                    }
                }
            }
            catch (Exception ex)
            {
                if (DBase.ShowException == 1) MessageBox.Show(ex.ToString());
            }
           
        }

        //RUN TRANSLATE
        public void TRANSLATE(bool CorrectLocation)
        {
            this.Text = this.Text + "@" + DateTime.Now.ToString("hh:mm:ss");

            try
            {
                if (!SKIP_OLD_CLIPBOARD) // keep old clibpard  ( not word/Excel/offlice )....
                {
                    if(Clipboard.ContainsText(TextDataFormat.Text)) OLDCLIPBOARD = Clipboard.GetText();
                    DBase.RunCMD("echo off| Clip");
                    //Thread.Sleep(200);
                    //                Clipboard.SetDataObject(
                    //" ", //text to store in clipboard
                    //false,       //do not keep after our app exits
                    //5,           //retry 5 times
                    //200);
                    //Clipboard.Clear();
                    //Clipboard.SetText(" ");
                    //Thread.Sleep(1200);

                    //Clipboard.SetData(DataFormats.Text, "");

                }
                else
                {
                    this.Text = this.Text + " SKIPED CLIPBOARD";
                }

                SendKeys.SendWait("^c");
                Thread.Sleep(50); 

               
                string CLIP = "";
                
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    CLIP = DBase.StringReturn(Clipboard.GetText()).Trim();
                    if (CLIP != " " && CLIP != "" && LastClip != CLIP)
                    {
                        LastClip = CLIP;
                        if (OLDCLIPBOARD != "" && !SKIP_OLD_CLIPBOARD) Clipboard.SetText(OLDCLIPBOARD);
                        TF.edtKey.Text = CLIP;
                        this.Text = "Run " + CLIP;
                        //TF.OLDCLIPBOARD = OLDCLIPBOARD;
                        if (CorrectLocation)
                        {
                            TF.Location = new Point(X, Y + 10);
                        }
                        else TF.Location = Cursor.Position;

                        TF.Size = new System.Drawing.Size(300, 200);
                        TF.Show();
                        TF.Activate();
                        TF.Focus();
                        TF.Translate();
                        DBase.RunCMD("echo off| Clip");
                    }
                    else
                    {
                        this.Text = "CLIP BLANK : " + CLIP;
                    }
                }
                else
                {
                    this.Text = "CLIP NOT TEXT ";
                }

               
            }
            catch (Exception ex2)
            {
                if (DBase.ShowException == 1) MessageBox.Show(ex2.ToString());
            }
        }




        DateTime LastKeyPress = DateTime.Now;
        DateTime MDown = DateTime.Now;
        Point P1 = new Point(0, 0);
        Point P2 = new Point(0, 0);
        int X = 0;
        int Y = 0;

        string OLDCLIPBOARD = "";
        Translation TF = new Translation();

      

        private void ZMain_Load(object sender, EventArgs e)
        {
            RefreshButton();


        }

        private void lbIcon1_Click(object sender, EventArgs e)
        {

            //Gma.UserActivityMonitorDemo.TestFormStatic F = new Gma.UserActivityMonitorDemo.TestFormStatic();
            //F.Show();
        }

        private void cmsExitForce_Click(object sender, EventArgs e)
        {
            isClose = 1;
            this.Close();
        }
        public int isClose = 0;
        private void ZMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.Visible)
            //{
            //    if (this.Height > 50) DBase.LastHeight = this.Height.ToString();
            //    if (this.Width > 120) DBase.LastWidth = this.Width.ToString();
            //    DBase.SaveSetting();
            //}

            if (DBase.CloseToTray != "0")
            {
                if (isClose == 0)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                    notifyIcon1.Visible = true;
                    e.Cancel = true;
                }
                else
                {
                    string PName = Process.GetCurrentProcess().ProcessName;
                    notifyIcon1.Visible = false;
                    DBase.KillProcess(PName);


                }

            }
            else
            {
                string PName = Process.GetCurrentProcess().ProcessName;
                notifyIcon1.Visible = false;
                DBase.KillProcess(PName);
            }
            
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.Show();
                this.Activate();
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                //if (ModifierKeys == Keys.Control) cmsSoundToogle_Click(cmsSpeaker, null);
                //else cmsSoundToogle_Click(cmsHeadphone, null);
            }
        }

        private void cmsActiveTranslation_Click(object sender, EventArgs e)
        {
            DBase.ActiveTranslation = DBase.ActiveTranslation == 0 ? 1 : 0;
            DBase.SaveSetting();
            RefreshButton();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            System.Diagnostics.Process.Start("explorer.exe", DBase.DataFolderPath);
        }

    
        private void cmsCloseToTray_Click(object sender, EventArgs e)
        {
            DBase.CloseToTray = DBase.CloseToTray == "1" ? "0" : "1";
            DBase.SaveSetting();
            RefreshButton();
        }

        private void cmsAppSetup_Click(object sender, EventArgs e)
        {
            if (DBase.UserCodeLogin == "") return;
            DBase.ShowControlFormNearBy(new APPTRANSLATE(), "Application Setting", this.Icon,this,this.Width,0);
        }

        private void cmsSetupAPI_Click(object sender, EventArgs e)
        {
            DBase.SetEnvirmoment();
        }

        private void openEnvironmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DBase.RunCMD("rundll32 sysdm.cpl,EditEnvironmentVariables");
            }
            catch (Exception) { }
        }


        private void APP_DOWNLOAD_Click(object sender, EventArgs e)
        {
            try
            {
                string appname = ((ToolStripMenuItem)sender).Tag.ToString();

                FileDownload F = new FileDownload(appname);
                F.Show();
            }
            catch (Exception ex) { }

        }

        private void LbButtonDownload_Click(object sender, EventArgs e)
        {
            string App = ((lbButton)sender).Tag.ToString();
            try
            {
                FileDownload F = new FileDownload(App);
                F.Show();
                //F.FileName = App;
                //DHuy.CheckAndUpdateFile(App);
                //System.Diagnostics.Process.Start(App);
            }
            catch (Exception ex) { }


        }

        public void RefreshButton()
        {
            if (DBase.ActiveTranslation == 0)
            {
                this.cmsActiveTranslation.Image = null;
                notifyIcon1.Icon = Properties.Resources.GoogleTrans_Disabled;
            }
            else
            {
                this.cmsActiveTranslation.Image = global::GB.Properties.Resources.YesBlue;
                notifyIcon1.Icon = Properties.Resources.GoogleTrans;
            }

            if (DBase.CloseToTray == "0") this.cmsCloseToTray.Image = null;
            else this.cmsCloseToTray.Image = global::GB.Properties.Resources._011_yes_16;

            if (DBase.StartMinimize == 0) this.cmsStartMinimize.Image = null;
            else this.cmsStartMinimize.Image = global::GB.Properties.Resources._011_yes_16;
        }

        private void cmsUpdate_Click(object sender, EventArgs e)
        {
            string app = "UpdateFireP.exe";
            string ExeName = System.IO.Path.GetFileName(Application.ExecutablePath);

            String tempPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + app;
            DHuy.DownloadFile(app, tempPath);
            try
            {
                System.Diagnostics.Process.Start(tempPath, ExeName.ToLower().Replace(".exe", "") + " JustClickSee.exe" + " \"" + Application.ExecutablePath + "\"");
            }
            catch (Exception ex) { }
        }

        private void cmsAbout_Click(object sender, EventArgs e)
        {
            DiaryBook P = new DiaryBook();
            P.Text = "Diary Book";
            P.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            P.StartPosition = FormStartPosition.CenterScreen;

            P.Show(this);
        }

        private void cmsConfig_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.Show();
                this.Activate();
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                Config C = new Config();
               
                C.StartPosition = FormStartPosition.Manual;
                C.Location = new Point(this.Location.X + 150 , this.Location.Y);
                C.Icon = this.Icon;
                C.M = this;
                C.CurrentUserLogin = Environment.UserName;
             
                C.Show(this);
               
            }
            catch (Exception ex) { }
        }

        private void cmsStartMinimize_Click(object sender, EventArgs e)
        {
            DBase.StartMinimize = DBase.StartMinimize == 0 ? 1 : 0;
            DBase.SaveSetting();
         
            RefreshButton();
        }

        private void timerFILE_TRANSFER_Tick(object sender, EventArgs e)
        {
            if (File.Exists(DBase.DetectInstanceFile))
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                try
                {
                    File.Delete(DBase.DetectInstanceFile);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cmsStartWithWindow_Click(object sender, EventArgs e)
        {
            try
            {
                DBase.RegistryDeleteCU("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "JCS");

                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (rk.GetValue("JCS") == null)
                {
                    if (DBase.AutoLogOn == "1")
                    {
                        rk.SetValue("JCS", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP_LOGON");
                    }
                    else rk.SetValue("JCS", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP");
                }
                else rk.DeleteValue("JCS");

                if (rk.GetValue("JCS") == null) this.cmsStartWithWindow.Image = null;
                else this.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
            }
            catch (Exception ex) { }
        }

        private void SPEECH2TEXT_Click(object sender, EventArgs e)
        {
            SPEECH2TEXT F = new SPEECH2TEXT();
            F.Show();
        }

        private void lbButton20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tinhte.vn");
        }
    }
}
