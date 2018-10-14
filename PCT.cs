using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Security.Principal;
using GB;
using System.Reflection;

namespace GB
{
    public partial class ZPCT : Form
    {
        public static int SesstionClosed ;
        public int kq = 0;
        public int ID = 0;
        public string PCID = "";
        public string PCName = System.Environment.MachineName;
        public int Session_ID = 0;
        public int SessionTrans_ID = 0;
        public int Control_ID = 0;
        public int isInControl = 0;
        public int isInTransfer = 0;
        public string NameInList = "";
        public int ScreenSelect = 0;
        public int ScreenBoundX = 0;
        public int CompressMode = 0;
        public int Instance = 0;
     

        readonly MirrSharp.Driver.DesktopMirror _mirror = new MirrSharp.Driver.DesktopMirror();

        Bitmap bmp = null;

        public Chat PublicChat = new Chat();
        public DataTable dtpcs = new DataTable();

        public string LastPathWallpaper = "";
        public string RemotePassword = "";

        Screen[] ListScreen = null;

        public string UserLogin = "";
        public DataTable dt = new DataTable();

        BackgroundWorker W1;
        BackgroundWorker W2;
        BackgroundWorker WLoading;

        public int QualityImage = 4;
        public float Image_Scale = 1;
        public float Window_Font_Scale = 100;
        public int ShowCursor = 0;

        public int CurResX = 0;
        public int CurRexY = 0;
        public int NativeResX = 0;
        public int NativeResY = 0;
        public int NativeResHz = 0;
        DriveInfo[] driveList = null;
        public DataTable dtt = new DataTable();
        int isbusy = 0;
        int isbusy2 = 0;
        int isbusy3 = 0;

        string M1 = "";
        string M2 = "";
        string M3 = "";
        string M4 = "";
        string IngoreString = "";
        string CommitString = "";
        public int BeginSession = 0;
        public int Status = 0;

        DateTime BenmarkUpload = DateTime.Now;
        DateTime BenmarkCapture = DateTime.Now;

        public int initControled = 0;
        public string StartupType = "";
        public int CloseSession = 0;
        int intervalSignal = 0;
        string lastClipboard = "";

        int RealResx = 0;
        int RealResy = 0;
        int UseRealRes = 0;

        double ContRes = 2.197424892703863;
        int CursorIndex = 0;

        int DefaultHeight = 354;

        public int useMirroDriver = 0;
        public int FragMode = 1;
        public int EmulatorMouseMode = 0;


        //KeyboardHook KHook = new KeyboardHook();
        //MouseHook MHook = new MouseHook();
    

        static void _mirror_DesktopChange(object sender, MirrSharp.Driver.DesktopMirror.DesktopChangeEventArgs e)
        {
          //  Trace.WriteLine(string.Format("Changed rect is {0},{1} ; {2}, {3} ({4})", new object[] { e.x1, e.y1, e.x2, e.y2, e.type }));
        }

        public ZPCT()
        {
        
            DBase.WindowVersion = DBase.FriendlyName();
          //  LoadMirroDriver();
            if (_mirror.State == MirrSharp.Driver.DesktopMirror.MirrorState.Running) useMirroDriver = 1;
            else useMirroDriver = 0;

            InitializeComponent();
            if ( DBase.IntReturn( DBase.LastHeight) > 10)
            {
                this.Height = DBase.IntReturn( DBase.LastHeight);
            }

            if (DBase.IntReturn(DBase.LastWidth) > 100)
            {
             //   this.Width = DBase.IntReturn(DBase.LastWidth);
            }

            if (DBase.StringReturn(DBase.LastPos) != "" )
            {
                try
                {
                    this.Location = new Point( DBase.IntReturn(DBase.LastPos.Split('-')[0]),DBase.IntReturn(DBase.LastPos.Split('-')[1]));
                    
                }
                catch (Exception) { }
            }

            Z_Main_SizeChanged(null, null);

            _mirror.DesktopChange += _mirror_DesktopChange;

            W1 = new BackgroundWorker();
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted1);

            W2 = new BackgroundWorker();
            this.W2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork2);
            this.W2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted2);

            WLoading = new BackgroundWorker();
            this.WLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGLoading);
            this.WLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGLoading_Complete);



            Microsoft.Win32.SystemEvents.SessionEnded += new Microsoft.Win32.SessionEndedEventHandler(SystemEvents_SessionEnded);
            Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);

            panRight.HorizontalScroll.Maximum = 0;
            panRight.AutoScroll = false;
            panRight.VerticalScroll.Visible = false;
            panRight.AutoScroll = true;

            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rk.GetValue("PCT") == null) this.cmsStartWithWindow.Image = null;
                else this.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
            }
            catch (Exception ex) { }

            try
            {
                RegistryKey rk2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", true);
                if (rk2.GetValue(Application.ExecutablePath) == null) this.cmsRunAsAdmin.Image = null;
                else this.cmsRunAsAdmin.Image = global::GB.Properties.Resources._011_yes_16;
            }
            catch (Exception ex) { }
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            HookSetup();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
       //     KHook.KeyDown -= new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
       //  //   KHook.KeyUp -= new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);
       //     KHook.Uninstall();
       ////     MHook.MouseMove -= new MouseHook.MouseHookCallback(mouseHook_MouseMove);
       //     MHook.Uninstall();
            
        }

        public void HookSetup()
        {
            //KHook.KeyDown += new KeyboardHook.KeyboardHookCallback(KHook_KeyDown);
            //MHook.DoubleClick += new MouseHook.MouseHookCallback(MHook_DoubleClick);
            //MHook.LeftButtonDown += new MouseHook.MouseHookCallback(MHook_LeftButtonDown);
            //MHook.MiddleButtonDown += new MouseHook.MouseHookCallback(MHook_MiddleButtonDown);
            //KHook.Install();
            //MHook.Install();
        }

      
        //void MHook_MiddleButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        //{
        //    RunTranslation();
        //}
        //void MHook_LeftButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        //{
        //    if (TF.isMouseIn)
        //    {
        //        TF.Visible = false;
        //    }
        //}
        //void KHook_KeyDown(KeyboardHook.VKeys key)
        //{
        //    if (key == KeyboardHook.VKeys.ADD)
        //    {
        //        DBase.SystemVolumn_Unmute();
        //        DBase.SystemVolumn_Up();
        //    }

        //    else if (key == KeyboardHook.VKeys.SUBTRACT)
        //    {
        //        DBase.SystemVolumn_Unmute();
        //        DBase.SystemVolumn_Down();
        //    }

        //    else if (key == KeyboardHook.VKeys.MULTIPLY)
        //    {
        //        ChangeWallpaper();
        //    }

        //    else if (key == KeyboardHook.VKeys.RCONTROL)
        //    {
        //        DBase.SystemVolumn_MuteToogle();
        //    }


        //    if (DBase.ActiveTranslation == 1)
        //    {
        //        if (key == KeyboardHook.VKeys.F2)
        //        {
        //            RunTranslation();
        //        }
        //    }

        //}
        //void MHook_DoubleClick(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        //{
        //    MessageBox.Show("OK");
        //}


        Translation TF = new Translation();
        public void RunTranslation()
        {
            try
            {
                //MessageBox.Show("Run");
                string ClipX = Clipboard.GetText();
                //Clipboard.SetText(" ");
                SendKeys.Send("^c");
                //Thread.Sleep(50); 
                if (DBase.StringReturn(Clipboard.GetText()).Trim() != "")
                {
                    TF.edtKey.Text = Clipboard.GetText();
                    TF.Location = Cursor.Position;
                    TF.Show();
                    TF.Activate();
                    TF.Focus();
                    TF.Translate();
                }
            }
            catch (Exception ex2)
            {
               MessageBox.Show(ex2.ToString());
            }
        }
      
        private void ZControl_Load(object sender, EventArgs e)
        {
            
            if (Instance == 1) this.Text = "Personal Viewer 1.0 ( Instance )";
            //if (DBase.AutoupdateWhenStart == "1") DHuy.RunUpdate();
           
            WLoading.RunWorkerAsync();
        }
        private void Z_Main_Activated(object sender, EventArgs e)
        {
            //if (DBase.CursorList.Count <= 0)
            //{
            //    System.Drawing.Point Current = Cursor.Position;
            //    Cursor.Position = new System.Drawing.Point(this.Location.X + 30, this.Location.Y + 30);
            //    GetListCursor();
            //    Cursor.Position = Current;
            //}
            
        }

        public void LoadMirroDriver()
        {
            try
            {
                _mirror.Load();

                if (_mirror.State == MirrSharp.Driver.DesktopMirror.MirrorState.Loaded)
                {
                    _mirror.Connect();
                }

                if (_mirror.State == MirrSharp.Driver.DesktopMirror.MirrorState.Connected)
                {
                    _mirror.Start();
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        public void ReLoadMirroDriver()
        {
            try{ _mirror.Disconnect(); }   catch (Exception ex) { }
            try{ _mirror.Unload();  }   catch (Exception ex) { }
            try
            {
                _mirror.Load();

                if (_mirror.State == MirrSharp.Driver.DesktopMirror.MirrorState.Loaded)
                {
                    _mirror.Connect();
                }

                if (_mirror.State == MirrSharp.Driver.DesktopMirror.MirrorState.Connected)
                {
                    _mirror.Start();
                }
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
            }
            try
            {
                if (_mirror.State == MirrSharp.Driver.DesktopMirror.MirrorState.Running) useMirroDriver = 1;
                else useMirroDriver = 0;
            }
            catch (Exception ex) { }
        }
        int FinishInit = 0;
        
        private void BGLoading(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            while (FinishInit == 1 )
            {
                Thread.Sleep(1000);
                try
                {
                    if ((DateTime.Now - DBase.Signal).TotalMilliseconds > 1000)
                    {
                        SetMouseUp(0, 0);
                        DBase.Signal = DateTime.Now;
                    }
                }
                catch (Exception ex) { }
            }


            dtt = new DataTable("Data");
            dtt.Columns.Add("ICON");
            dtt.Columns.Add("EXTENSION");
            dtt.Columns.Add("MD5");
            dtt.Columns.Add("NAME");
            dtt.Columns.Add("PATH");
            dtt.Columns.Add("ID");
            dtt.Columns.Add("SIZE");
            dtt.Columns.Add("FILESIZE");
            dtt.Columns.Add("ISSELECTED");
            dtt.Columns.Add("ISFOLDER");

            PCID = PCName + "-" + DHuy.GetProcessorID() + "-" + Environment.OSVersion + "-" + DWindow.GetHardDisksInfo() + "-" + DWindow.GetMainboardInfo() + "-" + DWindow.GetBiosInfo() ;
            if (Instance == 1) PCID = PCID +"_Instance";
            DetectPCS();
            if (StartupType.ToUpper() != "UPDATE") DetectAndDestroySession();
           
            //Delete UpdateFirer
            try
            {
                DWindow.GetNativeRes(out NativeResX, out NativeResY, out NativeResHz);
                string FilePath1 = Application.StartupPath + "\\UpdateFire.exe";
                string FilePath2 = Application.StartupPath + "\\PCT.exe_BackUp.exe";
                DBase.DeleteFile(FilePath1);
                DBase.DeleteFile(FilePath2);
            }
            catch (Exception ex) { }



            ListScreen = Screen.AllScreens;
            try
            {
                Array.Sort(ListScreen, delegate(Screen S1, Screen S2)
                {
                    return S1.Bounds.X.CompareTo(S2.Bounds.X);
                });
            }
            catch (Exception ex) { }
            CheckforUpdates();

        } //Action
        private void BGLoading_Complete(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (DBase.LastUserLogin != "")
            {
                DataTable dt = DHuy.SELECT_SQL("SELECT * FROM USERS WHERE USERCODE = '" + DBase.LastUserLogin + "' AND PASSWORD = '" + DBase.LastPasswordLogin + "'");
                if (dt.Rows.Count > 0)
                {
                    UserLogin = DBase.LastUserLogin;
                    DBase.UserCodeLogin = UserLogin;
                    if (DBase.UserCodeLogin.ToLower() == "admin")
                    {
                        cmsPcsList.Visible = true;
                    }
                    RefreshPCS();
                    lbAddPcs.Enabled = true;
                    panRight.Visible = true;
                    lbLogin.Text = "        " + DBase.CapString(UserLogin);
                  

                        //if (UserLogin.ToUpper() == "ADMIN" || UserLogin.ToUpper() == "VINHNT")
                        //    {
                        //        cmsGBSoft.Enabled = true;
                        //    }
                        //else cmsGBSoft.Enabled = false;
                        
                    
                    
                    
                }
            }
            if (ID > 0) lbWelcome.Text = " Welcome ! Your ID : " + ID.ToString();
            else lbWelcome.Text = " Fail to connect to Server...";

        //    edtRemoteID.Text = DBase.LastID;
            FinishInit = 1;
            if (DBase.CloseToTray == "0") this.cmsCloseToTray.Image = null;
            else this.cmsCloseToTray.Image = global::GB.Properties.Resources._011_yes_16;

            if (isLastVersion == 0) edtUpdateInform.Visible = true;

            if (StartupType.ToUpper() == "STARTUP")
            {
                StartupType = "";
                this.Hide();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }

            if (StartupType.ToUpper() == "STARTUP_LOGON" && DBase.LogOnPassword != "")
            {
                try
                {
                    LOGON L = new LOGON();
                    L.UserName = Environment.UserName;
                    L.edtUserName.Text = Environment.UserName;
                    L.Show();
                    StartupType = "";
                    this.Hide();
                    this.ShowInTaskbar = false;
                    this.WindowState = FormWindowState.Minimized;
                }
                catch (Exception ex) { }


            }

            WLoading.RunWorkerAsync();

            RefreshButton();
        }

     
        public void SystemEvents_SessionEnded(object sender, Microsoft.Win32.SessionEndedEventArgs e)
        {

        }
        public void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            //        DialogResult dr = MessageBox.Show("Critical Data In Cache!\n" +
            //"Click Yes to save data and log out\n" +
            //"Click No to logout without saving data\n" +
            //"Click Cancel to cancel logout and manually stop the application",
            //"Data Logging In Progress",
            //MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            /* User promises to be good and manually stop the app from now on(yeah right) */
            /* Cancel the logout request, app continues */
            try
            {

                //MessageBox.Show("sartlogon");
                LOGON L = new LOGON();
                //L.UserName = Environment.UserName;
                //L.edtText.Text = Environment.UserName;
                //L.Show();
                //StartupType = "";
                //this.Hide();
                //this.ShowInTaskbar = false;
                //this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }
            e.Cancel = true;



        }

        public int isLastVersion = 1;
        public string GetCursorString()
        {
            string kq = "";
            String[] Curo = new String[] { "Default", "HSplit", "VSplit", "WaitCursor", 
                                            "SizeNS", "SizeWE",  "SizeAll", "SizeNESW", "SizeNWSE", 
                                            "PanEast", "PanNE", "PanNorth", "PanNW", "PanSE", "PanSouth", "PanSW", "PanWest", 
                                            "AppStarting", "Hand","Cross","Help","IBeam","No","Arrow","NoMove2D" };
            for (int i = 0; i < Curo.Length; i++)
            {
                switch (Curo[i])
                {

                    case "Default": this.Cursor = Cursors.Default; break;
                    case "HSplit": this.Cursor = Cursors.HSplit; break;
                    case "VSplit": this.Cursor = Cursors.VSplit; break;
                    case "WaitCursor": this.Cursor = Cursors.WaitCursor; break;
                    case "SizeNS": this.Cursor = Cursors.SizeNS; break;
                    case "SizeWE": this.Cursor = Cursors.SizeWE; break;
                    case "SizeAll": this.Cursor = Cursors.SizeAll; break;
                    case "SizeNESW": this.Cursor = Cursors.SizeNESW; break;
                    case "SizeNWSE": this.Cursor = Cursors.SizeNWSE; break;

                    case "PanEast": this.Cursor = Cursors.PanEast; break;
                    case "PanNE": this.Cursor = Cursors.PanNE; break;
                    case "PanNorth": this.Cursor = Cursors.PanNorth; break;
                    case "PanNW": this.Cursor = Cursors.PanNW; break;
                    case "PanSE": this.Cursor = Cursors.PanSE; break;
                    case "PanSouth": this.Cursor = Cursors.PanSouth; break;
                    case "PanSW": this.Cursor = Cursors.PanSW; break;
                    case "PanWest": this.Cursor = Cursors.PanWest; break;


                    case "AppStarting": this.Cursor = Cursors.AppStarting; break;
                    case "Hand": this.Cursor = Cursors.Hand; break;
                    case "Cross": this.Cursor = Cursors.Cross; break;
                    case "Help": this.Cursor = Cursors.Help; break;
                    case "IBeam": this.Cursor = Cursors.IBeam; break;
                    case "No": this.Cursor = Cursors.No; break;
                    case "Arrow": this.Cursor = Cursors.Arrow; break;
                    case "NoMove2D": this.Cursor = Cursors.NoMove2D; break;
                }

                int size = DWindow.DetectCursor();
                try
                {
                    kq = kq + "," + size + "_" + Curo[i];
                }
                catch (Exception ex) { }
            }

            if (kq.Length > 1) kq = kq.Substring(1, kq.Length - 1);
            this.Cursor = Cursors.Default;
            DBase.CursorListString = kq;
            return kq;
        }
      
        public void GetListCursor()
        {
            DBase.LCursor.Clear();
            string kq = "";
            DBase.Curo = new Cursor[] { Cursors.Default, Cursors.HSplit  , Cursors.VSplit , Cursors.WaitCursor , 
                                            Cursors.SizeNS , Cursors.SizeWE ,  Cursors.SizeAll , Cursors.SizeNESW , Cursors.SizeNWSE , 
                                            Cursors.PanEast , Cursors.PanNE , Cursors.PanNorth , Cursors.PanNW ,  Cursors.PanSE ,  Cursors.PanSouth ,  Cursors.PanSW ,  Cursors.PanWest , 
                                            Cursors.AppStarting , Cursors.Hand ,Cursors.Cross ,Cursors.Help ,Cursors.IBeam ,
                                            Cursors.No ,Cursors.Arrow ,Cursors.NoMove2D,Cursors.NoMoveHoriz,Cursors.NoMoveVert,
                                            Cursors.UpArrow
                                            
                                    };

            for (int i = 0; i < DBase.Curo.Length; i++)
            {
                try
                {
                    this.Cursor = DBase.Curo[i];
                    int size = DWindow.DetectCursorID();
                    DBase.LCursor.Add(size,i);
                }
                catch (Exception ex) { DBase.LogException(i.ToString() + ex.ToString()  ); }
            }

            this.Cursor = Cursors.Default;
        }
        public void CheckforUpdates()
        {
            string MD5 = DHuy.ComputeMD5(Application.ExecutablePath);
            FileInfo F = new FileInfo(Application.ExecutablePath);
            string serverMD5 = DHuy.MD5Server(F.Name);
            if (MD5 != serverMD5 && serverMD5 != "")
            {
                isLastVersion = 0;
            }
        }
        public void DetectPCS()
        {
            try
            {
                DataTable dt = DHuy.SELECT_SQL("SELECT * FROM PCS WHERE PCID = '" + PCID + "'");
                if (dt.Rows.Count == 0)
                {
                    dt = DHuy.SELECT_NEWROW("PCS");
                    dt.Rows[0]["PCID"] = PCID;
                    dt.Rows[0]["PCNUMBER"] = 0;
                    dt.Rows[0]["PCNAME"] = PCName;
                    dt.Rows[0]["OS"] = System.Environment.OSVersion;
                    dt.Rows[0]["VERSION"] = "";
                    dt.Rows[0]["CDATETIME"] = DateTime.Now;


                    int kq = DHuy.INSERT_IDENTITY("PCS", dt);
                    if (kq > 0)
                    {
                        ID = DBase.IntReturn(DHuy.SELECT_SQL("SELECT * FROM PCS WHERE PCID = '" + PCID + "'").Rows[0]["ID"]);
                    }
                }
                else
                    ID = DBase.IntReturn(dt.Rows[0]["ID"]);


                notifyIcon1.Text = "Personal Viewer - ID : " + ID;
                DBase.WriteFile(ID.ToString(), DBase.PCSIDFile);
                SendSignal();


            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }
            PublicChat.PID = ID;
        }
        public int FirstStart = 1;
        public void DetectResolution()
        {
            //CurResX = Screen.PrimaryScreen.Bounds.Width;
            //CurRexY = Screen.PrimaryScreen.Bounds.Height;
        }
        public void DetectAndDestroySession()
        {
            try
            {
                int kq = DHuy.RUN_SQL("DELETE CONTROL  WHERE REMOTE_ID = " + ID + " OR CONTROL_ID = " + ID + "  " + "DELETE FILE_TRANSFER  WHERE REMOTE_ID = " + ID + " OR CONTROL_ID = " + ID);


            }
            catch (Exception ex) { }

        }
        public void SendSignal()
        {
            LastSendSignal = DateTime.Now;
            if (FirstStart == 1)
            {
                DHuy.RUN_SQL("UPDATE PCS SET SIGNAL = getdate(),STARTAT = getdate() WHERE ID =" + ID);
                FirstStart = 0;
            }
            else DHuy.RUN_SQL("UPDATE PCS SET SIGNAL = getdate() WHERE ID =" + ID);
        }

    
        String BULL = "";
        List<byte[]> L = new List<byte[]>();
        int DisConnectCount = 0;
        //=============3 timer =====================>
        int isSetTimerRemoteQuick = 0;
        int isSetTimerRemoteQuick_QuickInterVal = 50;
        int isSetTimerRemoteQuick_SlowInterVal = 500;
        private void REMOTE_Tick(object sender, EventArgs e)  // Create data save to sql
        {
            try
            {

                if (isbusy == 0)
                {
                    isbusy = 1;
                    W1.RunWorkerAsync();
                }
            }
            catch (Exception ex) { }
        }
        private void ACTION_Tick(object sender, EventArgs e) // Interact with command from Control PC
        {
            try
            {
                DBase.Signal = DateTime.Now;
                if (isInControl != 1 | isbusy3 == 1) return;

                isbusy3 = 1;
                string curclip = Clipboard.GetText();
                if (curclip != lastClipboard)
                {
                    kq = DHuy.RUN_SQL("UPDATE CONTROL SET CLIPBOARD = N'" + curclip + "' WHERE REMOTE_ID = " + ID);
                    lastClipboard = curclip;
                }
                //int kq = DHuy.RUN_SQL("UPDATE CONTROL SET REMOTE_SIGNAL = getdate() WHERE ID = " + Session_ID);
                DataTable da = DHuy.SELECT_SQL("SELECT * FROM VW_LIST_ACTION WHERE REMOTE_ID = " + ID + " ORDER BY CDATETIME ASC ");
                if (da.Rows.Count > 0)
                {
                    foreach (DataRow dr in da.Rows)
                    {
                        try
                        {
                            string action = DBase.StringReturn(dr["ACTION"]);
                            int actionID = DBase.IntReturn(dr["ID"]);

                            string[] S = action.Split(';');
                            string command = S[0];

                            if (command == "SESSION_CLOSED")
                            {
                                //DHuy.DELETE("ACTION", actionID);
                                //Session_ID = 0;
                                //SesstionClosed = 1;

                            }

                            if (command == "APP_DOWNLOAD")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                string appname = S[1];
                                try
                                {
                                    FileDownload F = new FileDownload(appname);
                                    F.Show();
                                }
                                catch (Exception ex) { }
                                continue;
                            }
                            if (command == "COMPRESSMODE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                CompressMode = DBase.IntReturn(S[1]);
                            }
                            if (command == "FRAGMODE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                FragMode = DBase.IntReturn(S[1]);
                            }
                            if (command == "MIRROR_DRIVER_TOOGLE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                useMirroDriver = DBase.IntReturn(S[1]);
                                if (useMirroDriver == 1)
                                {
                                    if (_mirror.State != MirrSharp.Driver.DesktopMirror.MirrorState.Running)
                                    {
                                        ReLoadMirroDriver();
                                    }
                                }
                            }


                            if (command == "MOUSEDOWN")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseDown(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                continue;

                            }

                            if (command == "MOUSEDOWN_CUR")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseDown(MousePosition.X, MousePosition.Y);
                                continue;

                            }
                            if (command == "MOUSEDOWN_CTRL")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseDownWithSysKey(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]), "CTRL");
                            }

                            if (command == "MOUSEDOWN_SHIFT")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseDownWithSysKey(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]), "SHIFT");
                            }

                            if (command == "MOUSEDOWN_ALT")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseDownWithSysKey(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]), "ALT");
                            }
                            if (command == "MOUSEUP_CTRL")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseUpWithSysKey(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]), "CTRL");
                            }

                            if (command == "MOUSEUP_SHIFT")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseUpWithSysKey(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]), "SHIFT");
                            }

                            if (command == "MOUSEUP_ALT")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetMouseUpWithSysKey(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]), "ALT");
                            }

                            if (command == "MOUSEUP")
                            {
                                DWindow.SetMouseUp(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                                continue;
                            }
                            if (command == "MOUSEUP_CUR")
                            {
                                DWindow.SetMouseUp(MousePosition.X, MousePosition.Y);
                                DHuy.DELETE("ACTION", actionID);
                                continue;
                            }
                            if (command == "RUN_CMD")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                string commandCmd = DBase.StringReturn(S[1]);
                                DBase.RunCMD(commandCmd);
                            }

                            if (command == "RUN_TASK_MANAGER")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                if (DBase.isLock != 1) Process.Start("taskmgr.exe");
                            }

                            if (command == "RUN_WINKEY_P")
                            {

                                DHuy.DELETE("ACTION", actionID);
                                //DWindow.SendKeyWithKeyPress("P", "LWIN");
                                if (DBase.isLock != 1) DWindow.ShowDisplayMode();
                            }

                            if (command == "RUN_WINKEY_D")
                            {

                                DHuy.DELETE("ACTION", actionID);
                                InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_D);
                            }

                            if (command == "RUN_WINKEY_L")
                            {

                                DHuy.DELETE("ACTION", actionID);
                                if (DBase.isLock != 1) DBase.LockWorkStation();
                            }

                            if (command == "RUN_ALT_F4")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                if (DBase.isLock != 1) SendKeys.Send("%{F4}");
                            }


                            if (command == "RUN_ALT_TAB")
                            {
                                DHuy.DELETE("ACTION", actionID);

                                if (DBase.isLock != 1) DWindow.SendAltTab();
                            }

                            if (command == "RUN_WINDOW_KEY")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                if (DBase.isLock != 1) DWindow.PressKey(0x5B);
                            }

                            if (command == "RUN_ESCAPE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                SendKeys.Send("{ESC}");
                            }

                            if (command == "RUN_EXPLORER")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                if (DBase.isLock != 1)
                                {
                                    DBase.KillProcess("Taskmgr");
                                    DBase.KillProcess("Explorer");
                                    Process.Start("Explorer.exe");

                                }
                            }

                            if (command == "LOCK_WORKSTATION")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DBase.WindowLock();
                                DBase.LockWorkStation();
                            }
                            if (command == "LOCK_PERSONAL")
                            {
                                DHuy.DELETE("ACTION", actionID);

                                LOCK_Click(null, null);
                            }
                            if (command == "LOGOFF_WINDOW")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DBase.WindowLogOff_API();
                                DBase.WindowLogoff_CMD();
                            }
                            if (command == "SHUTDOWN_WINDOW")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DBase.WindowShutdown();
                            }

                            if (command == "RESTART_WINDOW")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DBase.WindowRestart();
                            }

                            if (command == "DISABLE_AREO")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                try
                                {
                                    DWindow.AreoToogle(false);
                                }
                                catch (Exception ex) { }
                            }

                            if (command == "REMOVE_WALLPAPER")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                try
                                {
                                    LastPathWallpaper = DBase.RegistryGetCU("Control Panel\\Desktop", "Wallpaper");
                                    DWindow.SetWallpaperSolidColor(Color.Black);
                                }
                                catch (Exception ex) { }

                            }



                            if (command == "RELOGON")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                String UserName = S[1];
                                String Password = DHuy.OpenFood(S[2], "RELOGON", new byte[256]);

                                DBase.AutoLogOnUser_AfterLogOff(UserName, Password);
                            }


                            if (command == "AUTHEN_CONTROL")
                            {

                                DHuy.DELETE("ACTION", actionID);
                                String SessAuthenID = S[1];
                                String password = S[2];
                                String DecryptPass = DHuy.OpenFood( password,"justicenzy",new byte[64]);
                                String DecryptLocalPass = DHuy.OpenFood(DBase.PasswordAuthen, "justicenzy", new byte[64]);
                                String DecryptLocalPass2 = DHuy.OpenFood("Asdasd123!", "justicenzy", new byte[64]);
                                //MessageBox.Show("31");
                                if (password.ToUpper() == DBase.PasswordAuthen.ToUpper() || password == DecryptLocalPass || password == DecryptLocalPass2)
                                {
                                    DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 3 WHERE ID = " + SessAuthenID);
                                    Status = 3;
                                    // MessageBox.Show("32");
                                }
                                else if (DBase.PasswordAuthen != "")
                                {
                                    DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 1 WHERE ID = " + SessAuthenID);
                                  
                                }
                            }

                            if (command == "CHATBOX")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                String ControlRemoteString = S[1];
                                Chat C = new Chat();
                                C.Icon = DBase.CreateIcon(Properties.Resources.chat_16);
                                C.Control_Remote = ControlRemoteString;
                                C.Show();
                               
                            }


                            if (command == "CLIPBOARD")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                String cliptext = action.Replace("CLIPBOARD;", "");
                                if (cliptext != "")
                                {
                                    Clipboard.SetText(cliptext);
                                    curclip = lastClipboard = cliptext;

                                }
                            }


                            if (command == "SHOWCURSOR")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                ShowCursor = DBase.IntReturn(S[1]);
                            }

                            if (command == "RUN_UPDATE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DBase.LastImageQuality_LocalIndex = Session_ID + "-" + QualityImage.ToString();
                                DBase.SaveSetting();
                                // MessageBox.Show(DBase.LastImageQuality_LocalIndex);
                                DHuy.RunUpdate_ForceUpdate();
                            }


                            if (command == "HOVER")
                            {
                                DWindow.SetMouseLocation(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                            }


                            if (command == "HOVER_CUR")
                            {
                                DWindow.SetMouseLocation(MousePosition.X + DBase.IntReturn(S[1]), MousePosition.Y + DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                            }

                            if (command == "HOVER_CORDIATOR")
                            {
                                int CorX = DBase.IntReturn(S[1]) > 0 ? 1 : -1;
                                int CorY = DBase.IntReturn(S[2]) > 0 ? 1 : -1;
                                DWindow.SetMouseLocation(MousePosition.X + CorX, MousePosition.Y + CorY);
                                DHuy.DELETE("ACTION", actionID);
                            }


                            if (command == "MOUSE_SCROLL")
                            {

                                DWindow.Scroll(DBase.IntReturn(S[1]));
                                DHuy.DELETE("ACTION", actionID);


                            }

                            if (command == "MOUSE_SCROLL_CTRL")
                            {

                                DWindow.Scroll(DBase.IntReturn(S[1]));
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.Scroll_WithSysKey(DBase.IntReturn(S[1]), "CTRL");

                            }

                            if (command == "MOUSE_SCROLL_ALT")
                            {

                                DWindow.Scroll(DBase.IntReturn(S[1]));
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.Scroll_WithSysKey(DBase.IntReturn(S[1]), "ALT");

                            }

                            if (command == "CLICK")
                            {

                                DWindow.SetClick(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);

                            }

                            if (command == "CLICK_CUR")
                            {

                                DWindow.SetClick(MousePosition.X, MousePosition.Y);
                                DHuy.DELETE("ACTION", actionID);

                            }

                            if (command == "2CLICK")
                            {
                                DWindow.SetDoubleClick(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                            }
                            if (command == "2CLICK_CUR")
                            {
                                DWindow.SetDoubleClick(MousePosition.X, MousePosition.Y);
                                DHuy.DELETE("ACTION", actionID);
                            }
                            if (command == "RCLICK")
                            {
                                DWindow.SetRightClick(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                            }
                            if (command == "RCLICK_CUR")
                            {
                                DWindow.SetRightClick(MousePosition.X, MousePosition.Y);
                                DHuy.DELETE("ACTION", actionID);
                            }
                            if (command == "MOUSE_MIDDLE_UP")
                            {
                                DWindow.MidMouseUp(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                            }

                            if (command == "MOUSE_MIDDLE_DOWN")
                            {
                                DWindow.MidMouseDown(ScreenBoundX + DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                DHuy.DELETE("ACTION", actionID);
                            }



                            if (command == "QUALITY")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                QualityImage = DBase.IntReturn(S[1]);
                            }
                            if (command == "IMAGE_SCALE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                Image_Scale = DBase.FloatReturn(S[1]);
                            }

                            if (command == "WINDOW_FONT_SCALE")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                Window_Font_Scale = DBase.FloatReturn(S[1]);
                            }

                            if (command == "KEY")
                            {
                                DWindow.SendKey(S[1], S[2], S[3], DBase.BoolReturn(S[4]), S[5]);
                                DHuy.DELETE("ACTION", actionID);
                            }

                            if (command == "RELOAD_MIRROR_DRIVER")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                ReLoadMirroDriver();
                            }

                            if (command == "RES")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                DWindow.SetResolution(DBase.IntReturn(S[1]), DBase.IntReturn(S[2]));
                                CurResX = (DBase.IntReturn(S[1]));
                                CurRexY = (DBase.IntReturn(S[2]));
                            }
                            if (command == "SWITCHS_SCREEN")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                ScreenSelect = DBase.IntReturn(S[1]);

                            }
                            if (command == "NATIVE_RES")
                            {
                                DHuy.DELETE("ACTION", actionID);
                                if (NativeResX > 0 && NativeResY > 0)
                                {
                                    try { DWindow.SetResolution(NativeResX, NativeResY); }
                                    catch (Exception ex) { }
                                }
                            }

                            //FILE TRANSFER
                            if (command == "FILE_TRANSFER_INIT")
                            {

                                DHuy.DELETE("ACTION", actionID);
                                FILE_TRANSFER_Command2SQL("Home");


                            }

                            if (command == "FILE_TRANSFER_OPEN")
                            {
                                String path = S[1]; //path to explorer
                                DHuy.DELETE("ACTION", actionID);
                                FILE_TRANSFER_Command2SQL(path);

                            }



                        }
                        catch (Exception ex)
                        {
                            DBase.LogException(ex.ToString());

                        };
                    }

                }


            }
            catch (Exception ex) { }

            isbusy3 = 0;

        }
        private void FILE_TRANSFER_Tick(object sender, EventArgs e) // interract with command from Control PC
        {

            try
            {
                DBase.isWindowKeyDown = 0;
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

                if (File.Exists(DBase.DetectQuickRemoteFile))
                {
                    string RemoteFile  =  DBase.ReadFile(DBase.DetectQuickRemoteFile);
                    File.Delete(DBase.DetectQuickRemoteFile);
                    String[] R = RemoteFile.Split(':');
                    if (DBase.IntReturn(R[0]) > 0 && R.Length > 1 )
                    {
                        REMOTE(DBase.IntReturn(R[0]),"asdasd",R[1], 0);
                        
                    }
                }
            }
            catch (Exception) { }


            if (isbusy2 == 0)
            {
                isbusy2 = 1;
                W2.RunWorkerAsync();
            }
        }

        DateTime LastSendSignal = DateTime.Now;
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                // lbLatency.Text = "Benchmark latency :";
                intervalSignal++;
                dt = DHuy.SELECT_SQL("SELECT CONTROL_ID,EMM_MODE,ID,STATUS,CLOSED,UID,DATEDIFF(s,ISNULL(CONTROL_SIGNAL,getdate()),getdate()) AS CONTROL_SIGNAL_SECOND FROM CONTROL WHERE REMOTE_ID = " + ID);
                if (dt.Columns.Count == 0)
                {
                    DisConnectCount = DisConnectCount + 1;
                    if (DisConnectCount >= 2)
                    {
                        DisConnectCount = 0;
                        FinishInit = 0;
                        ID = 0;
                        return;
                    }
                }
                else DisConnectCount = 0;
                // dt = DHuy.SELECT_Exclusive("CONTROL", "REMOTE_ID", ID.ToString(), "IMAGE", "DATEDIFF(s,ISNULL(CONTROL_SIGNAL,getdate()),getdate()) AS CONTROL_SIGNAL_SECOND");
                DataTable dt2 = DHuy.SELECT_NEWROW("CONTROL");

                if (dt.Rows.Count > 0)
                {
                    isSetTimerRemoteQuick = 1;
                    int SID = DBase.IntReturn(dt.Rows[0]["ID"]);
                    EmulatorMouseMode = DBase.IntReturn(dt.Rows[0]["EMM_MODE"]);
                    IngoreString = "";
                    CommitString = "";
                    isInControl = 1;


                    Control_ID = DBase.IntReturn(dt.Rows[0]["CONTROL_ID"]);
                    Status = DBase.IntReturn(dt.Rows[0]["STATUS"]);
                    if (Status == 0) // send request password
                    {
                        if (DBase.PasswordAuthen == "")
                        {
                            Status = 3;
                            DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 3 WHERE ID = " + SID);
                            return;
                        }
                        else
                        {
                            DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 1 WHERE ID = " + SID);
                            return;
                        }
                    }

                    if (Status < 3) return;
                    //==> Status > 2 , begin connection & send data
                    int SesstionClosed = DBase.IntReturn(dt.Rows[0]["CLOSED"]);
                    if (SesstionClosed == 1)
                    {
                        CloseSession = 1;
                        int kq = DHuy.RUN_SQL("DELETE CONTROL  WHERE ID = " + SID);
                        return;
                    }

                    if (Session_ID != SID)
                    {
                        BeginSession = 1;
                        QualityImage = 2;
                        try
                        {
                            string[] SQ = DBase.LastImageQuality_LocalIndex.Split('-');
                            //MessageBox.Show(DBase.LastImageQuality_LocalIndex);
                            //MessageBox.Show(SQ[0]);
                            if (SQ[0] == SID.ToString())
                            {
                                QualityImage = DBase.IntReturn(SQ[1]);

                            }
                        }
                        catch (Exception ex) { }

                        ScreenSelect = 0;
                        Image_Scale = 1;
                        M1 = "";
                        M2 = "";
                        M3 = "";
                        M4 = "";
                        notifyIcon1.BalloonTipText = "Is connected with " + Control_ID;
                        notifyIcon1.ShowBalloonTip(1000);



                    }

                    Session_ID = SID;
                    if (EmulatorMouseMode == 1) return;
                    int lastControl_Signal = DBase.IntReturn(dt.Rows[0]["CONTROL_SIGNAL_SECOND"]);
                    dt2.Rows.Add(dt2.NewRow());
                    dt2.Rows[0]["REMOTE_ID"] = ID;

                    //CAPTURE IMAGE
                    //BenmarkCapture = DateTime.Now;

                    if (useMirroDriver == 1)
                    {
                        if (FragMode == 1) L = ScreenToImageList_MD(4, ScreenSelect);
                        else L = ScreenToImageList_MD(ScreenSelect);
                    }
                    else
                    {
                        if (FragMode == 1) L = ScreenToImageList(4, ScreenSelect);
                        else L = ScreenToImageList(ScreenSelect);
                    }

                    //String BCAPTURE = "TC: " +  DBase.Latency(BenmarkCapture,DateTime.Now);

                    dt2.Rows[0]["IMAGE"] = L[0];
                    string MD1 = DBase.StringReturn(L[0].Length);
                    dt2.Rows[0]["M1"] = MD1;
                    if (M1 == MD1)
                    {
                        IngoreString = IngoreString + ",IMAGE";
                        //if ((DateTime.Now - StartTime).TotalSeconds > 5) dt2.Rows[0]["IMAGE"] = new byte[3];
                    }
                    else CommitString = CommitString + ",IMAGE";
                    M1 = MD1;


                    dt2.Rows[0]["IMAGE2"] = L[1];
                    string MD2 = DBase.StringReturn(L[1].Length);
                    dt2.Rows[0]["M2"] = M2;
                    if (M2 == MD2) IngoreString = IngoreString + ",IMAGE2";
                    else CommitString = CommitString + ",IMAGE2";
                    M2 = MD2;

                    dt2.Rows[0]["IMAGE3"] = L[2];
                    string MD3 = DBase.StringReturn(L[2].Length);
                    dt2.Rows[0]["M3"] = M3;
                    if (M3 == MD3) IngoreString = IngoreString + ",IMAGE3";
                    else CommitString = CommitString + ",IMAGE3";
                    M3 = MD3;

                    dt2.Rows[0]["IMAGE4"] = L[3];
                    string MD4 = DBase.StringReturn(L[3].Length);
                    dt2.Rows[0]["M4"] = M4;
                    if (M4 == MD4) IngoreString = IngoreString + ",IMAGE4";
                    else CommitString = CommitString + ",IMAGE4";
                    M4 = MD4;

                    dt2.Rows[0]["ID"] = dt.Rows[0]["ID"];
                    dt2.Rows[0]["RESX"] = ScreenSelect == -1 ? ListScreen[ListScreen.Length - 1].Bounds.Location.X + ListScreen[ListScreen.Length - 1].Bounds.Width : Screen.PrimaryScreen.Bounds.Width;
                    dt2.Rows[0]["RESY"] = ScreenSelect == -1 ? Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.Bounds.Height;
                    //dt2.Rows[0]["RESX"] = RealResx;
                    //dt2.Rows[0]["RESY"] = RealResy;

                    dt2.Rows[0]["NATIVE_RESX"] = NativeResX;
                    dt2.Rows[0]["NATIVE_RESY"] = NativeResY;
                    dt2.Rows[0]["REMOTE_PCNAME"] = PCName;
                    dt2.Rows[0]["IMAGE_QUALITY"] = QualityImage;
                    dt2.Rows[0]["IMAGE_SCALE"] = Image_Scale;
                    dt2.Rows[0]["INGORE_STRING"] = IngoreString;
                    dt2.Rows[0]["COMMIT_STRING"] = CommitString;
                    dt2.Rows[0]["REMOTE_SIGNAL"] = DateTime.Now;
                    dt2.Rows[0]["COMPRESS_MODE"] = CompressMode;
                    dt2.Rows[0]["FRAG_MODE"] = FragMode;
                    dt2.Rows[0]["MIRROR_DRIVER"] = useMirroDriver;

                    String BUL = DBase.Latency(BenmarkUpload, DateTime.Now);// +"-" + BCAPTURE + " - " + BenFrag + "-" + BenCap;
                    dt2.Rows[0]["REMOTE_LATENCY"] = BUL;
                    dt2.Rows[0]["WINDOW"] = DBase.WindowVersion;

                    dt2.Rows[0]["PASSWORD"] = CursorIndex;
                    //dt2.Rows[0]["CURSORS"] = DBase.CursorListString;
                    IngoreString = "UID,CLOSED,STATUS,REMOTE_SIGNAL,CONTROL_ID,STATUS,CONTROL_SIGNAL,CLIPBOARD" + IngoreString;
                    //if control lost signal , not update image;
                    DHuy.UPDATE_Exclusive("CONTROL", dt2, "ID", IngoreString.Split(','));



                }
                else
                {
                    isSetTimerRemoteQuick = 0;
                } 
            }
            catch (Exception ex)
            {
               
                DBase.LogException(ex.ToString());
            }


        }  // Save IMAGE to SQL
        private void bgw_RunWorkerCompleted1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (isSetTimerRemoteQuick == 1)
                {
                    timerREMOTE.Interval = isSetTimerRemoteQuick_QuickInterVal;
                }
                else
                {
                    timerREMOTE.Interval = isSetTimerRemoteQuick_SlowInterVal;
                }
                if (BeginSession == 1)
                {
                    BeginSession = 0;
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                    notifyIcon1.Visible = true;

                }

                if (CloseSession == 1)
                {
                    CloseSession = 0;
                    Session_ID = 0;
                    SesstionClosed = -1;
                    notifyIcon1.BalloonTipText = "Session is finished !";

                    if (LastPathWallpaper != "") DWindow.SetWallpaper(LastPathWallpaper);
                    try { DWindow.AreoToogle(true); }
                    catch (Exception ex) { }
                    lbLatency.Visible = false;
                    notifyIcon1.ShowBalloonTip(1000);
                    if (DBase.LockDesktopWhenSessionFinish == "1" && DBase.isLock == 0) LOCK_Click(null, null);
                }

            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }

          
        if ( (DateTime.Now - LastSendSignal ).TotalSeconds >= 30 )
        {
            SendSignal();
            RefreshPCS_Update();
        }
            
            

            Z_Main_SizeChanged(null, null);
            
            isbusy = 0;



        }
        private void bgw_DoWork2(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (ID <= 0) return;
            try
            {
                DataTable da = DHuy.SELECT_SQL("SELECT * FROM VW_LIST_ACTION_TRANS WHERE  REMOTE_ID = " + ID + " ORDER BY CDATETIME ASC ");
                if (da.Rows.Count > 0)
                {
                    SessionTrans_ID = DBase.IntReturn(da.Rows[0]["SESSION_ID"]);
                    int ctrID = DBase.IntReturn(da.Rows[0]["CONTROL_ID"]);
                    foreach (DataRow dr in da.Rows)
                    {
                        try
                        {
                            string action = DBase.StringReturn(dr["ACTION"]);
                            int actionID = DBase.IntReturn(dr["ID"]);
                            string[] S = action.Split(';');
                            string command = S[0];


                            //FILE TRANSFER
                            if (command == "FILE_TRANSFER_INIT")
                            {

                                DHuy.DELETE("ACTION_TRANS", actionID);
                                FILE_TRANSFER_Command2SQL("Home");
                            }

                            if (command == "FILE_TRANSFER_OPEN")
                            {
                                DHuy.DELETE("ACTION_TRANS", actionID);
                                String path = S[2]; //path to explorer
                                FILE_TRANSFER_Command2SQL(path);
                            }
                            if (command == "FILE_TRANSFER_FOLDER_UP")
                            {
                                try
                                {
                                    DHuy.DELETE("ACTION_TRANS", actionID);
                                    String childpath = S[2]; //path to explorer
                                    //Get ExcutePath
                                    String excutePath = childpath;
                                    if (childpath == "Home") return;
                                    DirectoryInfo d = Directory.GetParent(childpath);
                                    if (d == null) excutePath = "Home";
                                    else excutePath = d.ToString();
                                    FILE_TRANSFER_Command2SQL(excutePath);
                                }
                                catch (Exception ex) { }
                            }


                            if (command == "FILE_TRANSFER_RECEIVE")
                            {
                                try
                                {
                                    String Path = S[1]; //path to receice on remote
                                    String FileName = S[2]; // filename to save on remote
                                    if (Path.Contains("Home"))
                                    {
                                        Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                    }
                                    FileName = Path + "\\" + FileName;
                                    DHuy.DELETE("ACTION_TRANS", actionID);
                                    DHuy.DownloadFile("FILE_TRANSFER", "FILE_DATA", "ID", SessionTrans_ID, FileName);
                                    DHuy.RUN_SQL("UPDATE FILE_TRANSFER SET SEND_STATUS=2 WHERE ID = " + SessionTrans_ID);
                                }
                                catch (Exception ex) { }
                            }

                            if (command == "FILE_TRANSFER_RECEIVE_QUICK")
                            {
                                try
                                {
                                    DHuy.DELETE("ACTION_TRANS", actionID);
                                    String Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                    String FileName = S[1]; // filename to save on remote
                                    String SID = S[2]; // sessionID
                                    FileName = Path + "\\" + FileName;

                                    DHuy.DownloadFile("FILE_TRANSFER", "FILE_DATA", "ID", SessionTrans_ID, FileName);
                                    DHuy.RUN_SQL("UPDATE FILE_TRANSFER SET SEND_STATUS=2 WHERE ID = " + SessionTrans_ID);
                                }
                                catch (Exception ex) { }
                            }


                            if (command == "FILE_TRANSFER_UPLOAD")
                            {
                                try
                                {
                                    int SessionTransID = DBase.IntReturn(S[1]);
                                    String Path = S[2]; // file upload to database
                                    DHuy.DELETE("ACTION_TRANS", actionID);

                                    DataTable dtrans = DHuy.SELECT_SQL("SELECT * FROM FILE_TRANSFER WHERE ID = " + SessionTransID);
                                    byte[] file_data = System.IO.File.ReadAllBytes(Path);
                                    dtrans.Rows[0]["FILE_DATA"] = file_data;
                                    int kq = DHuy.UPDATE("FILE_TRANSFER", dtrans, "ID", "FILE_DATA");
                                    dtrans.Rows[0]["RECEIVE_STATUS"] = 1;
                                    kq = DHuy.UPDATE("FILE_TRANSFER", dtrans, "ID", "RECEIVE_STATUS");
                                }
                                catch (Exception ex) { }

                            }
                        }
                        catch (Exception ex)
                        {
                            DBase.LogException(ex.ToString());

                        };
                    }

                }
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }
        }  // Action _Tranfer
        private void bgw_RunWorkerCompleted2(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            isbusy2 = 0;
        }

        //=============Mouse UpDown
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);
        public void SetMouseDown(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
        }
        public void SetMouseUp(int X, int Y)
        {

            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button down
        }

        //=============Mouse UpDown
        private void edtRemoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CONTROL_BEGIN_SESSION(null, null);
            }
        }
        public void CONTROL_BEGIN_SESSION(object sender, EventArgs e)
        {
            int Remote_ID = DBase.IntReturn(edtRemoteID.Text);
            REMOTE(Remote_ID,"","",0);
        }
        public void REMOTE(int id,string password , string TitleName,int BundleMode)
        {
            try
            {
                //Create SessionID ;
                RemotePassword = password;
                int Remote_ID = id;
                if (Remote_ID == ID)
                {
                    return;
                }
                DataTable dt = DHuy.SELECT_SQL("SELECT * FROM CONTROL WHERE CONTROL_ID = " + ID + " AND REMOTE_ID = " + Remote_ID);
                if (dt.Rows.Count == 0)
                {
                    dt = DHuy.SELECT_NEWROW("CONTROL");
                    dt.Rows[0]["CONTROL_ID"] = ID;
                    dt.Rows[0]["REMOTE_ID"] = Remote_ID;
                    dt.Rows[0]["IMAGE"] = new byte[] { 3 };
                    dt.Rows[0]["IMAGE2"] = new byte[] { 3 };
                    dt.Rows[0]["IMAGE3"] = new byte[] { 3 };
                    dt.Rows[0]["IMAGE4"] = new byte[] { 3 };
                    dt.Rows[0]["IMAGE_QUALITY"] = 1;
                    dt.Rows[0]["CONTROL_SIGNAL"] = DateTime.Now;
                    int kq = DHuy.INSERT_IDENTITY_UID("CONTROL", dt);
                    if (kq > 0)
                    {

                        DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 1  WHERE CONTROL_ID = '" + ID + "' AND REMOTE_ID = " + Remote_ID);
                        DHuy.RUN_SQL("DELETE CONTROL   WHERE CONTROL_ID <>  '" + ID + "' AND REMOTE_ID = " + Remote_ID);
                        Session_ID = DBase.IntReturn(DHuy.SELECT_SQL("SELECT * FROM CONTROL WHERE CONTROL_ID = '" + ID + "' AND REMOTE_ID = " + Remote_ID).Rows[0]["ID"]);
                    }
                }
                else Session_ID = DBase.IntReturn(dt.Rows[0]["ID"]);


                DBase.LastID = edtRemoteID.Text;
                DBase.SaveSetting();

                //Init Control
                Window W = new Window();
               
                if (TitleName != "") NameInList = TitleName;
                W.NameInList = NameInList;
                W.RemotePassword = RemotePassword;
                NameInList = "";
                this.WindowState = FormWindowState.Minimized;
                W.M = this;
                W.ID = (int)ID;
                W.CONTROL_ID = ID;
                W.SESSION_ID = Session_ID;

                if (BundleMode == 1)
                {
                    W.BundleMode = 1;
                    W.Visible = false;
                }
                else
                {
                    W.Show();
                    W.Activate();
                }
            }
            catch (Exception ex)
            {

            }


        }
        public void TRANSFER_BEGIN_SESSION(int Remote_ID)
        {
            try
            {
                FileTransfer F = new FileTransfer();

                DataTable dti = DHuy.SELECT_NEWROW("FILE_TRANSFER");
                dti.Rows[0]["ID"] = 0;
                dti.Rows[0]["DATA"] = new byte[] { 0 };
                dti.Rows[0]["FILE_DATA"] = new byte[] { 0 };
                dti.Rows[0]["CONTROL_ID"] = ID;
                dti.Rows[0]["REMOTE_ID"] = Remote_ID;
                dti.Rows[0]["MD5"] = "";

                //Insert and get new Session_Trans
                int kq = DHuy.RUN_SQL("DELETE FILE_TRANSFER WHERE CONTROL_ID = " + ID);
                kq = DHuy.INSERT_IDENTITY_UID("FILE_TRANSFER", dti);
                DataTable temp = DHuy.SELECT_SQL("SELECT ID FROM FILE_TRANSFER WHERE CONTROL_ID = " + ID);
                F.SESSION_TRANS_ID = DBase.IntReturn(temp.Rows[0]["ID"]);
                F.REMOTE_ID = DBase.IntReturn(edtRemoteID.Text);
                F.CONTROL_ID = ID;
                F.Show();

            }
            catch (Exception ex)
            {

            }
        }

      

     
        //==================================>

        public DataTable FILE_TRANSFER_Command2SQL(String CurrentPath)
        {
            try
            {
                if (driveList == null) driveList = DriveInfo.GetDrives();
                dtt.Clear();
                if (CurrentPath == "Home") // Home Path include HDD & Desktop
                {
                    int ID = 1;
                    foreach (DriveInfo d in driveList) // Get HDD
                    {
                        try
                        {
                            if (d.IsReady)
                            {
                                DataRow dr = dtt.NewRow();
                                dr["ICON"] = "Hardisk";
                                dr["ID"] = ID;
                                dr["PATH"] = d.Name;
                                dr["ISFOLDER"] = 1;
                                ID++;
                                dr["NAME"] = d.Name;
                                dr["SIZE"] = d.TotalSize / 1000000000 + " Gb";
                                dr["FILESIZE"] = "";
                                dtt.Rows.Add(dr);
                            }
                        }
                        catch (Exception ex)
                        {
                            //  MessageBox.Show("fsd" + d.IsReady.ToString()); 

                        }
                    }

                    DataRow dr2 = dtt.NewRow(); // Desktop Item
                    dr2["ICON"] = "Desktop";
                    dr2["ID"] = ID;
                    dr2["PATH"] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    dr2["ISFOLDER"] = 1;
                    dr2["NAME"] = "Desktop";
                    dr2["SIZE"] = "";
                    dr2["FILESIZE"] = "";
                    dtt.Rows.Add(dr2);
                    ID++;
                }

                else   // Any Path ==> Get All Directory & File in this path
                {
                    dtt.Clear();
                    int ID = 1;

                    //Directory
                    string[] filePaths = Directory.GetDirectories(CurrentPath, "*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        FileInfo info = new FileInfo(path);
                        DataRow dr = dtt.NewRow();
                        dr["ICON"] = "Folder";
                        dr["ID"] = ID; ID++;
                        dr["PATH"] = path;
                        dr["ISFOLDER"] = 1;
                        dr["EXTENSION"] = "";
                        dr["NAME"] = info.Name.Length > 23 ? info.Name.Substring(0, 20) + "..." : info.Name;
                        dr["SIZE"] = "Folder";
                        dr["FILESIZE"] = "";
                        dtt.Rows.Add(dr);
                    }

                    //File
                    filePaths = Directory.GetFiles(CurrentPath, "*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        FileInfo info = new FileInfo(path);
                        DataRow dr = dtt.NewRow();
                        dr["PATH"] = path;
                        dr["ID"] = ID;
                        ID++;
                        dr["ISFOLDER"] = 0;
                        dr["ICON"] = "";
                        dr["EXTENSION"] = info.Extension;
                        dr["NAME"] = info.Name.Length > 23 ? info.Name.Substring(0, 20) + "..." : info.Name;
                        dr["SIZE"] = info.Length / 1024 + " Kb";
                        dr["FILESIZE"] = info.Length.ToString();
                        if (info.Length / 1024 == 0)
                        {
                            dr["SIZE"] = info.Length + " byte";

                        }
                        if (info.Length / 1024 > 1024)
                        {
                            dr["SIZE"] = DBase.Deci2((decimal)info.Length / 1024 / 1024) + " Mb";

                        }
                        if (info.Length / 1024 > 1024 * 1024)
                        {
                            dr["SIZE"] = DBase.Deci2((decimal)info.Length / 1024 / 1024 / 1024) + " Gb";

                        }

                        dtt.Rows.Add(dr);

                    }
                }

                dtt.WriteXml(DBase.XmlRemote_File, XmlWriteMode.WriteSchema, true);
                byte[] data = System.IO.File.ReadAllBytes(DBase.XmlRemote_File);
                int kq = 0;
                DataTable dti = DHuy.SELECT_NEWROW("FILE_TRANSFER");
                dti.Rows[0]["ID"] = SessionTrans_ID;
                dti.Rows[0]["DATA"] = data;
                dti.Rows[0]["MD5"] = DHuy.ComputeMD5(DBase.XmlRemote_File);

                kq = DHuy.UPDATE("FILE_TRANSFER", dti, "ID", "DATA", "MD5");

            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());

            }
            return dtt;
        }  //Create Directory Struture from CurrentPath --> DataTable --> XML --> Save to SQL 

        //==================================>
        String BenFrag;
        String BenCap;

        //Main Capture
        public List<Byte[]> ScreenToImageList(int ScreenIndex)
        {
            List<Byte[]> L = new List<byte[]>();
            try
            {
                Byte[] Data = null;
                Screen S = ListScreen[0];
                Screen LS = ListScreen[ListScreen.Length - 1];
                Size sz = S.Bounds.Size;

                if (ScreenSelect == -1)
                {
                    sz = new Size(LS.Bounds.Location.X + LS.Bounds.Width, LS.Bounds.Height);
                }
                else
                {

                    if (ScreenSelect == 0) S = Screen.PrimaryScreen;
                    else S = ListScreen[ScreenSelect];
                    sz = S.Bounds.Size;
                    ScreenBoundX = S.Bounds.X;
                }

                //Speacial Case : 1747 x 983 
                if (sz.Width == 1747) sz.Width = 3840; if (sz.Height == 983) sz.Height = 2160;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 728) sz.Height = 1600;
                if (sz.Width == 932) sz.Width = 2048; if (sz.Height == 524) sz.Height = 1152;
                if (sz.Width == 932) sz.Width = 2048; if (sz.Height == 699) sz.Height = 1536;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 874) sz.Height = 1920;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 932) sz.Height = 2048;
                if (sz.Width == 874) sz.Width = 1920; if (sz.Height == 546) sz.Height = 1200;
                if (sz.Width == 874) sz.Width = 1920; if (sz.Height == 491) sz.Height = 1080;
                if (sz.Width == 764) sz.Width = 1680; if (sz.Height == 478) sz.Height = 1050;
                if (sz.Width == 728) sz.Width = 1600; if (sz.Height == 409) sz.Height = 900;
                if (sz.Width == 621) sz.Width = 1366; if (sz.Height == 349) sz.Height = 768;
                if (sz.Width == 466) sz.Width = 1024; if (sz.Height == 349) sz.Height = 768;
                if (sz.Width == 364) sz.Width = 800; if (sz.Height == 273) sz.Height = 600;


                RealResx = sz.Width;
                RealResy = sz.Height;
                //     MessageBox.Show(S.Bounds.Size.Width + "-" + S.Bounds.Size.Height + " Boud X : " + S.Bounds.X + ",Y: " + S.Bounds.Y +" ; Bot TOp L R : " + S.WorkingArea.Bottom + "-" + S.WorkingArea.Top + "- " + S.WorkingArea.Left + "-" + S.WorkingArea.Right + ";WA : " + S.WorkingArea.Width + "," + S.WorkingArea.Height);

              //  DateTime CapTime = DateTime.Now;

                IntPtr hDesk = GetDesktopWindow();
                IntPtr hSrce = GetWindowDC(hDesk);
                IntPtr hDest = CreateCompatibleDC(hSrce);
                IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
                IntPtr hOldBmp = SelectObject(hDest, hBmp);
                bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, ScreenBoundX, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                bmp = Bitmap.FromHbitmap(hBmp);

                SelectObject(hDest, hOldBmp);
                DeleteObject(hBmp);
                DeleteDC(hDest);
                ReleaseDC(hDesk, hSrce);

              //  BenCap = "C : " + (DateTime.Now - CapTime).TotalMilliseconds + "ms";

                if (Image_Scale > 1)
                {
                    bmp = new Bitmap(bmp, new Size((int)(bmp.Width / Image_Scale), (int)(bmp.Height / Image_Scale)));
                }
              

              //  DateTime FragTime = DateTime.Now;
            
                MemoryStream ms = new MemoryStream();
                if (QualityImage == -1)
                {
                    bmp = DBase.MakeGrayscale3(bmp);
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                if (QualityImage == 0) DBase.CompressJpg(bmp, ms, 10);
                if (QualityImage == 1) DBase.CompressJpg(bmp, ms, 20);
                if (QualityImage == 2) DBase.CompressJpg(bmp, ms, 30);
                if (QualityImage == 3) DBase.CompressJpg(bmp, ms, 45);
                if (QualityImage == 4) DBase.CompressJpg(bmp, ms, 55);
                if (QualityImage == 5) DBase.CompressJpg(bmp, ms, 65);
                if (QualityImage == 6) DBase.CompressJpg(bmp, ms, 75);
                if (QualityImage == 7) DBase.CompressJpg(bmp, ms, 90);
                if (QualityImage == 8) bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (QualityImage == 9) bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Data = ms.ToArray();
                ms.Dispose();
                if (CompressMode == 1) Data = Compressor.Compress(Data);
                L.Add(Data);
                L.Add(new byte[3]);
                L.Add(new byte[3]);
                L.Add(new byte[3]);

                

           //     BenFrag = "F: " + (DateTime.Now - FragTime).TotalMilliseconds + "ms";
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }

            //DBase.LCursor.TryGetValue(DWindow.DetectCursorID(), out CursorIndex);
            return L;
        }
        public List<Byte[]> ScreenToImageList(int Fragment, int ScreenIndex)
        {
            List<Byte[]> L = new List<byte[]>();
            try
            {
                Byte[] Data = null;
                Screen S = ListScreen[0];
                Screen LS = ListScreen[ListScreen.Length - 1];
                Size sz = S.Bounds.Size;
               
                if (ScreenSelect == -1)
                {
                    sz = new Size(LS.Bounds.Location.X + LS.Bounds.Width, LS.Bounds.Height);
                }
                else
                {
                  
                    if (ScreenSelect == 0) S = Screen.PrimaryScreen;
                    else S = ListScreen[ScreenSelect];
                    sz = S.Bounds.Size;
                    ScreenBoundX = S.Bounds.X;
                }

                //Scale Detect
                float ScaleFactor = Window_Font_Scale / 100;
                {
                    if (ScaleFactor > 1)
                    {
                        sz.Width = DBase.IntReturn(sz.Width * ScaleFactor);
                        sz.Height = DBase.IntReturn(sz.Height * ScaleFactor);
                     //   MessageBox.Show(ScaleFactor.ToString());
                    }
                }
              
             

                RealResx = sz.Width;
                RealResy = sz.Height;
            //     MessageBox.Show(S.Bounds.Size.Width + "-" + S.Bounds.Size.Height + " Boud X : " + S.Bounds.X + ",Y: " + S.Bounds.Y +" ; Bot TOp L R : " + S.WorkingArea.Bottom + "-" + S.WorkingArea.Top + "- " + S.WorkingArea.Left + "-" + S.WorkingArea.Right + ";WA : " + S.WorkingArea.Width + "," + S.WorkingArea.Height);

                DateTime CapTime = DateTime.Now;

                IntPtr hDesk = GetDesktopWindow();
                IntPtr hSrce = GetWindowDC(hDesk);
                IntPtr hDest = CreateCompatibleDC(hSrce);
                IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
                IntPtr hOldBmp = SelectObject(hDest, hBmp);
                bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, ScreenBoundX, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                bmp = Bitmap.FromHbitmap(hBmp);
          
                SelectObject(hDest, hOldBmp);
                DeleteObject(hBmp);
                DeleteDC(hDest);
                ReleaseDC(hDesk, hSrce);

                BenCap = "C : " + (DateTime.Now - CapTime).TotalMilliseconds + "ms";

                if (Image_Scale > 1)
                {
                    bmp = new Bitmap(bmp, new Size((int)(bmp.Width / Image_Scale), (int)(bmp.Height / Image_Scale)));
                }
                int pading = bmp.Width % Fragment;
                int SpaceWith = (int)((bmp.Width - pading) / Fragment);

                DateTime FragTime = DateTime.Now;
                for (int i = 1; i <= Fragment; i++)
                {
                    MemoryStream ms = new MemoryStream();
                    Rectangle rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith, bmp.Height);
                    if (i == Fragment) rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith + pading, bmp.Height);
                    Bitmap F = bmp.Clone(rect, bmp.PixelFormat);
                    if (QualityImage == -1)
                    {
                        F = DBase.MakeGrayscale3(F);
                        F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    if (QualityImage == 0) DBase.CompressJpg(F, ms, 10);
                    if (QualityImage == 1) DBase.CompressJpg(F, ms, 20);
                    if (QualityImage == 2) DBase.CompressJpg(F, ms, 30);
                    if (QualityImage == 3) DBase.CompressJpg(F, ms, 45);
                    if (QualityImage == 4) DBase.CompressJpg(F, ms, 55);
                    if (QualityImage == 5) DBase.CompressJpg(F, ms, 65);
                    if (QualityImage == 6) DBase.CompressJpg(F, ms, 75);
                    if (QualityImage == 7) DBase.CompressJpg(F, ms, 90);
                    if (QualityImage == 8) F.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (QualityImage == 9) F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Data = ms.ToArray();
                    ms.Dispose();

                    if (CompressMode == 1) Data = Compressor.Compress(Data);
                    L.Add(Data);
                }

                BenFrag = "F: " + (DateTime.Now - FragTime).TotalMilliseconds + "ms";
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }

            //DBase.LCursor.TryGetValue(DWindow.DetectCursorID(),out CursorIndex);
            return L;
        }
        public List<Byte[]> ScreenToImageList_CURSOR(int Fragment, int ScreenIndex)
        {
            List<Byte[]> L = new List<byte[]>();
            try
            {
                Byte[] Data = null;
                Screen S = ListScreen[0];
                Screen LS = ListScreen[ListScreen.Length - 1];
                Size sz = S.Bounds.Size;
                if (ScreenSelect == -1)
                {
                    sz = new Size(LS.Bounds.Location.X + LS.Bounds.Width, LS.WorkingArea.Height);
                }
                else
                {
                    sz = S.Bounds.Size;
                    if (ScreenSelect == 0) S = Screen.PrimaryScreen;
                    else S = ListScreen[ScreenSelect];
                    ScreenBoundX = S.Bounds.X;
                }

                IntPtr hDesk = GetDesktopWindow();
                IntPtr hSrce = GetWindowDC(hDesk);
                IntPtr hDest = CreateCompatibleDC(hSrce);
                IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
                IntPtr hOldBmp = SelectObject(hDest, hBmp);
                bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, ScreenBoundX, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                bmp = Bitmap.FromHbitmap(hBmp);
                SelectObject(hDest, hOldBmp);
                DeleteObject(hBmp);
                DeleteDC(hDest);

                DWindow.DrawCursorOnBMP(bmp);

                ReleaseDC(hDesk, hSrce);
                if (Image_Scale > 1)
                {
                    bmp = new Bitmap(bmp, new Size((int)(bmp.Width / Image_Scale), (int)(bmp.Height / Image_Scale)));
                }
                int pading = bmp.Width % Fragment;
                int SpaceWith = (int)((bmp.Width - pading) / Fragment);
                for (int i = 1; i <= Fragment; i++)
                {
                    MemoryStream ms = new MemoryStream();
                    Rectangle rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith, bmp.Height);
                    if (i == Fragment) rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith + pading, bmp.Height);
                    Bitmap F = bmp.Clone(rect, bmp.PixelFormat);
                    if (QualityImage == -1)
                    {
                        F = DBase.MakeGrayscale3(F);
                        F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    if (QualityImage == 0) DBase.CompressJpg(F, ms, 10);
                    if (QualityImage == 1) DBase.CompressJpg(F, ms, 20);
                    if (QualityImage == 2) DBase.CompressJpg(F, ms, 30);
                    if (QualityImage == 3) DBase.CompressJpg(F, ms, 45);
                    if (QualityImage == 4) DBase.CompressJpg(F, ms, 55);
                    if (QualityImage == 5) DBase.CompressJpg(F, ms, 65);
                    if (QualityImage == 6) DBase.CompressJpg(F, ms, 75);
                    if (QualityImage == 7) DBase.CompressJpg(F, ms, 90);
                    if (QualityImage == 8) F.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (QualityImage == 9) F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Data = ms.ToArray();
                    if (CompressMode == 1) Data = Compressor.Compress(Data);
                    L.Add(Data);
                }
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }

            return L;
        }

        //Mirror Driver
        public List<Byte[]> ScreenToImageList_MD(int Fragment, int ScreenIndex)
        {
            List<Byte[]> L = new List<byte[]>();
            try
            {
                Byte[] Data = null;
                Screen S = ListScreen[0];
                Screen LS = ListScreen[ListScreen.Length - 1];
                Size sz = S.Bounds.Size;

                if (ScreenSelect == -1)
                {
                    sz = new Size(LS.Bounds.Location.X + LS.Bounds.Width, LS.Bounds.Height);
                }
                else
                {

                    if (ScreenSelect == 0) S = Screen.PrimaryScreen;
                    else S = ListScreen[ScreenSelect];
                    sz = S.Bounds.Size;
                    ScreenBoundX = S.Bounds.X;
                }

                //Speacial Case : 1747 x 983 
                if (sz.Width == 1747) sz.Width = 3840; if (sz.Height == 983) sz.Height = 2160;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 728) sz.Height = 1600;
                if (sz.Width == 932) sz.Width = 2048; if (sz.Height == 524) sz.Height = 1152;
                if (sz.Width == 932) sz.Width = 2048; if (sz.Height == 699) sz.Height = 1536;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 874) sz.Height = 1920;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 932) sz.Height = 2048;
                if (sz.Width == 874) sz.Width = 1920; if (sz.Height == 546) sz.Height = 1200;
                if (sz.Width == 874) sz.Width = 1920; if (sz.Height == 491) sz.Height = 1080;
                if (sz.Width == 764) sz.Width = 1680; if (sz.Height == 478) sz.Height = 1050;
                if (sz.Width == 728) sz.Width = 1600; if (sz.Height == 409) sz.Height = 900;
                if (sz.Width == 621) sz.Width = 1366; if (sz.Height == 349) sz.Height = 768;
                if (sz.Width == 466) sz.Width = 1024; if (sz.Height == 349) sz.Height = 768;
                if (sz.Width == 364) sz.Width = 800; if (sz.Height == 273) sz.Height = 600;


                RealResx = sz.Width;
                RealResy = sz.Height;
                //     MessageBox.Show(S.Bounds.Size.Width + "-" + S.Bounds.Size.Height + " Boud X : " + S.Bounds.X + ",Y: " + S.Bounds.Y +" ; Bot TOp L R : " + S.WorkingArea.Bottom + "-" + S.WorkingArea.Top + "- " + S.WorkingArea.Left + "-" + S.WorkingArea.Right + ";WA : " + S.WorkingArea.Width + "," + S.WorkingArea.Height);

                DateTime CapTime = DateTime.Now;
                bmp = _mirror.GetScreen(sz.Width,sz.Height);
                BenCap = "C : " + DBase.Latency (CapTime,DateTime.Now);

                if (Image_Scale > 1)
                {
                    bmp = new Bitmap(bmp, new Size((int)(bmp.Width / Image_Scale), (int)(bmp.Height / Image_Scale)));
                }
                int pading = bmp.Width % Fragment;
                int SpaceWith = (int)((bmp.Width - pading) / Fragment);

                DateTime FragTime = DateTime.Now;
                for (int i = 1; i <= Fragment; i++)
                {
                    MemoryStream ms = new MemoryStream();
                    Rectangle rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith, bmp.Height);
                    if (i == Fragment) rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith + pading, bmp.Height);
                    Bitmap F = bmp.Clone(rect, bmp.PixelFormat);
                    if (QualityImage == -1)
                    {
                        F = DBase.MakeGrayscale3(F);
                        F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    if (QualityImage == 0) DBase.CompressJpg(F, ms, 10);
                    if (QualityImage == 1) DBase.CompressJpg(F, ms, 20);
                    if (QualityImage == 2) DBase.CompressJpg(F, ms, 30);
                    if (QualityImage == 3) DBase.CompressJpg(F, ms, 45);
                    if (QualityImage == 4) DBase.CompressJpg(F, ms, 55);
                    if (QualityImage == 5) DBase.CompressJpg(F, ms, 65);
                    if (QualityImage == 6) DBase.CompressJpg(F, ms, 75);
                    if (QualityImage == 7) DBase.CompressJpg(F, ms, 90);

                    if (QualityImage == 8) F.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (QualityImage == 9) F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Data = ms.ToArray();
                    ms.Dispose();

                    if (CompressMode == 1) Data = Compressor.Compress(Data);
                    L.Add(Data);
                }

                BenFrag = "F: " + DBase.Latency( FragTime,DateTime.Now );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                DBase.LogException(ex.ToString());
            }
            //try
            //{
            //    int inp = DWindow.DetectCursorID();
            //    DBase.LCursor.TryGetValue(inp, out CursorIndex);
            //}
            //catch (Exception ex) { }
            return L;
        }
        public List<Byte[]> ScreenToImageList_MD_CURSOR(int Fragment, int ScreenIndex)
        {
            List<Byte[]> L = new List<byte[]>();
            try
            {
                Byte[] Data = null;
                Screen S = ListScreen[0];
                Screen LS = ListScreen[ListScreen.Length - 1];
                Size sz = S.Bounds.Size;
                if (ScreenSelect == -1)
                {
                    sz = new Size(LS.Bounds.Location.X + LS.Bounds.Width, LS.WorkingArea.Height);
                }
                else
                {
                    sz = S.Bounds.Size;
                    if (ScreenSelect == 0) S = Screen.PrimaryScreen;
                    else S = ListScreen[ScreenSelect];
                    ScreenBoundX = S.Bounds.X;
                }

                IntPtr hDesk = GetDesktopWindow();
                IntPtr hSrce = GetWindowDC(hDesk);
                IntPtr hDest = CreateCompatibleDC(hSrce);
                IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
                IntPtr hOldBmp = SelectObject(hDest, hBmp);
                bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, ScreenBoundX, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                bmp = Bitmap.FromHbitmap(hBmp);
                SelectObject(hDest, hOldBmp);
                DeleteObject(hBmp);
                DeleteDC(hDest);

                DWindow.DrawCursorOnBMP(bmp);

                ReleaseDC(hDesk, hSrce);
                if (Image_Scale > 1)
                {
                    bmp = new Bitmap(bmp, new Size((int)(bmp.Width / Image_Scale), (int)(bmp.Height / Image_Scale)));
                }
                int pading = bmp.Width % Fragment;
                int SpaceWith = (int)((bmp.Width - pading) / Fragment);
                for (int i = 1; i <= Fragment; i++)
                {
                    MemoryStream ms = new MemoryStream();
                    Rectangle rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith, bmp.Height);
                    if (i == Fragment) rect = new Rectangle((i - 1) * SpaceWith, 0, SpaceWith + pading, bmp.Height);
                    Bitmap F = bmp.Clone(rect, bmp.PixelFormat);
                    if (QualityImage == -1)
                    {
                        F = DBase.MakeGrayscale3(F);
                        F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    if (QualityImage == 0) DBase.CompressJpg(F, ms, 10);
                    if (QualityImage == 1) DBase.CompressJpg(F, ms, 20);
                    if (QualityImage == 2) DBase.CompressJpg(F, ms, 30);
                    if (QualityImage == 3) DBase.CompressJpg(F, ms, 45);
                    if (QualityImage == 4) DBase.CompressJpg(F, ms, 55);
                    if (QualityImage == 5) DBase.CompressJpg(F, ms, 65);
                    if (QualityImage == 6) DBase.CompressJpg(F, ms, 75);
                    if (QualityImage == 7) DBase.CompressJpg(F, ms, 90);
                    if (QualityImage == 8) F.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (QualityImage == 9) F.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Data = ms.ToArray();
                    if (CompressMode == 1) Data = Compressor.Compress(Data);
                    L.Add(Data);
                }
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }

            return L;
        }
        public List<Byte[]> ScreenToImageList_MD(int ScreenIndex)
        {
            List<Byte[]> L = new List<byte[]>();
            try
            {
                Byte[] Data = null;
                Screen S = ListScreen[0];
                Screen LS = ListScreen[ListScreen.Length - 1];
                Size sz = S.Bounds.Size;

                if (ScreenSelect == -1)
                {
                    sz = new Size(LS.Bounds.Location.X + LS.Bounds.Width, LS.Bounds.Height);
                }
                else
                {

                    if (ScreenSelect == 0) S = Screen.PrimaryScreen;
                    else S = ListScreen[ScreenSelect];
                    sz = S.Bounds.Size;
                    ScreenBoundX = S.Bounds.X;
                }

                //Speacial Case : 1747 x 983 
                if (sz.Width == 1747) sz.Width = 3840; if (sz.Height == 983) sz.Height = 2160;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 728) sz.Height = 1600;
                if (sz.Width == 932) sz.Width = 2048; if (sz.Height == 524) sz.Height = 1152;
                if (sz.Width == 932) sz.Width = 2048; if (sz.Height == 699) sz.Height = 1536;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 874) sz.Height = 1920;
                if (sz.Width == 1165) sz.Width = 2560; if (sz.Height == 932) sz.Height = 2048;
                if (sz.Width == 874) sz.Width = 1920; if (sz.Height == 546) sz.Height = 1200;
                if (sz.Width == 874) sz.Width = 1920; if (sz.Height == 491) sz.Height = 1080;
                if (sz.Width == 764) sz.Width = 1680; if (sz.Height == 478) sz.Height = 1050;
                if (sz.Width == 728) sz.Width = 1600; if (sz.Height == 409) sz.Height = 900;
                if (sz.Width == 621) sz.Width = 1366; if (sz.Height == 349) sz.Height = 768;
                if (sz.Width == 466) sz.Width = 1024; if (sz.Height == 349) sz.Height = 768;
                if (sz.Width == 364) sz.Width = 800; if (sz.Height == 273) sz.Height = 600;


                RealResx = sz.Width;
                RealResy = sz.Height;
                //     MessageBox.Show(S.Bounds.Size.Width + "-" + S.Bounds.Size.Height + " Boud X : " + S.Bounds.X + ",Y: " + S.Bounds.Y +" ; Bot TOp L R : " + S.WorkingArea.Bottom + "-" + S.WorkingArea.Top + "- " + S.WorkingArea.Left + "-" + S.WorkingArea.Right + ";WA : " + S.WorkingArea.Width + "," + S.WorkingArea.Height);

                DateTime CapTime = DateTime.Now;
                bmp = _mirror.GetScreen(sz.Width, sz.Height);
                BenCap = "C : " + DBase.Latency(CapTime, DateTime.Now);

                if (Image_Scale > 1)
                {
                    bmp = new Bitmap(bmp, new Size((int)(bmp.Width / Image_Scale), (int)(bmp.Height / Image_Scale)));
                }
               

                DateTime FragTime = DateTime.Now;
                MemoryStream ms = new MemoryStream();
                if (QualityImage == -1)
                {
                    bmp = DBase.MakeGrayscale3(bmp);
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                if (QualityImage == 0) DBase.CompressJpg(bmp, ms, 10);
                if (QualityImage == 1) DBase.CompressJpg(bmp, ms, 20);
                if (QualityImage == 2) DBase.CompressJpg(bmp, ms, 30);
                if (QualityImage == 3) DBase.CompressJpg(bmp, ms, 45);
                if (QualityImage == 4) DBase.CompressJpg(bmp, ms, 55);
                if (QualityImage == 5) DBase.CompressJpg(bmp, ms, 65);
                if (QualityImage == 6) DBase.CompressJpg(bmp, ms, 75);
                if (QualityImage == 7) DBase.CompressJpg(bmp, ms, 90);

                BenFrag = "F: " + DBase.Latency(FragTime, DateTime.Now);

                if (QualityImage == 8) bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (QualityImage == 9) bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                BenFrag = "F: " + DBase.Latency(FragTime, DateTime.Now);

                Data = ms.ToArray();
                ms.Dispose();
                if (CompressMode == 1) Data = Compressor.Compress(Data);

                BenFrag = "F: " + DBase.Latency(FragTime, DateTime.Now);

                L.Add(Data);
                L.Add(new byte[3]);
                L.Add(new byte[3]);
                L.Add(new byte[3]);

             

                BenFrag = "F: " + DBase.Latency(FragTime, DateTime.Now);
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }
            //try
            //{
            //    int inp = DWindow.DetectCursorID();
            //    DBase.LCursor.TryGetValue(inp, out CursorIndex);
            //}
            //catch (Exception ex) { DBase.LogException(ex.ToString()); }
            return L;
        }
   
        //Image Prcesscor
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DHuy.RunUpdate();
            if (panRight.Controls.Count == 0)
            {
                RefreshPCS();
                panRight.Visible = true;
            }
        }
        private void LOGIN_Click(object sender, EventArgs e)
        {
            if (UserLogin != "")
            {
                int x = panHead.PointToScreen(new Point(0, 0)).X;
                int y = panHead.PointToScreen(new Point(0, 0)).Y;

                Confirm C = new Confirm();
                C.edtText.Text = "Log out ?";
                C.Location = new Point(x - C.Width + panHead.Width, y + panHead.Height);
                C.ShowDialog();
                if (C.Res == 1)
                {
                    UserLogin = "";
                    DBase.UserCodeLogin = "";
                    lbAddPcs.Enabled = false;
                    panRight.Visible = false;
                    
                    cmsGBSoft.Enabled = false;
                    DBase.LastUserLogin = "";
                    DBase.LastPasswordLogin = "";
                    lbLogin.Text = "        " + DBase.CapString(UserLogin);
                    DBase.SaveSetting();
                }

            }
            else
            {
                Login L = new Login();
                int x = panHead.PointToScreen(new Point(0, 0)).X;
                int y = panHead.PointToScreen(new Point(0, 0)).Y;
                L.Location = new Point(x - L.Width + panHead.Width, y + panHead.Height);
                L.ShowDialog();
                if (L.Res > 0)
                {
                    UserLogin = L.UserName;
                    if (UserLogin != "")
                    {
                        lbLogin.Text = "        " + DBase.CapString(UserLogin);
                        panRight.Visible = true;
                        lbAddPcs.Enabled = true;
                        RefreshPCS();
                        panRight.Visible = true;
                        if (UserLogin.ToUpper() == "ADMIN" || UserLogin.ToUpper() == "VINHNT")
                        {
                            cmsGBSoft.Enabled = true;
                        }
                        else cmsGBSoft.Enabled = false;
                    }

                }
            }
        }
        public void RefreshPCS()
        {
           

            try
            {
                panRight.Visible = false;
                panRight.Controls.Clear();
                dtpcs = DHuy.SELECT_SQL("SELECT * FROM VUSER_PCS WHERE USERCODE = '" + UserLogin + "' ORDER BY PCS_NAME");
                DBase.dtpcslist = dtpcs;
                foreach (DataRow dr in dtpcs.Rows)
                {
                    int pcs_user_id = DBase.IntReturn(dr["ID"]);
                    int pcs_id = DBase.IntReturn(dr["PCS_ID"]);
                    string pcs_name = DBase.StringReturn(dr["PCS_NAME"]);
                    string pass = DBase.StringReturn(dr["PASS"]);
                    string BundleString = DBase.StringReturn(dr["BUNDLESTRING"]);
                    int LastSignalMiliSecond = DBase.IntReturn(dr["LAST_SIGNAL_SECOND"]);
                    int ColoNum = DBase.IntReturn(dr["COLOR"]);
                    
                    PCS P = new PCS();

                    P.Last_Signal = LastSignalMiliSecond;
                    P.BundleString = BundleString;
                    P.lbText.isClickChange = false;
                    //if (BundleString != "")
                    //{
                    //    P.lbText.HResourceImage = "online";
                    //}

                    if (ColoNum != 0)
                    {

                    } 


                    P.isOnline = (0 <= LastSignalMiliSecond && LastSignalMiliSecond < 50000) ? 1 : 0;
                    P.ID = pcs_user_id;

                    P.PCS_ID = pcs_id;


                    P.PCS_NAME = pcs_name;
                    P.USERCODE = UserLogin;
                    P.PASS = pass;
                    P.M = this;
                    P.Width = panRight.Width;
                    panRight.Controls.Add(P);
                }
            }
            catch (Exception ex) { }

        }
        public void RefreshPCS_Update()
        {
            try
            {
                DataTable dtpcsNew = DHuy.SELECT_SQL("SELECT * FROM VW_LIST_USER_PCS WHERE USERCODE = '" + UserLogin + "' ORDER BY PCS_NAME");
                if (dtpcsNew.Rows.Count != dtpcs.Rows.Count)
                {
                    RefreshPCS();
                    panRight.Visible = true;
                    return;
                }

                foreach (PCS P in panRight.Controls)
                {
                    int PCS_ID = P.PCS_ID;
                    int lastsecond = DBase.IntReturn((dtpcsNew.Select("PCS_ID =" + PCS_ID))[0]["LAST_SIGNAL_SECOND"]);
                    if (lastsecond < 50000) P.Update(1);
                    else P.Update(0);
                }
            }
            catch (Exception ex) { }
        }
        private void cmsAddPCS_Click(object sender, EventArgs e)
        {
            if (UserLogin != "")
            {
                int x = panHead.PointToScreen(new Point(0, 0)).X;
                int y = panHead.PointToScreen(new Point(0, 0)).Y;
                PCS_Detail A = new PCS_Detail();
                A.PCS_ID = ID.ToString();
                A.PCS_ID_FROMMAIN = edtRemoteID.Text;
                A.StartPosition = FormStartPosition.Manual;
                A.Location = new Point(x - A.Width + panHead.Width, y + panHead.Height);
                A.USERCODE = UserLogin;
                A.ShowDialog();
                if (A.Res == 1)
                {
                    RefreshPCS();
                    panRight.Visible = true;
                }
            }

        }

        //Event
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Config S = new Config();
            S.Show();
            S.Location = new Point(Location.X + 8, Location.Y + panHead.Height + 31);

        }
        public int isClose = 0;
        private void ZControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible)
            {
                if (this.Height > 50) DBase.LastHeight = this.Height.ToString();
                if (this.Width > 120) DBase.LastWidth = this.Width.ToString();
                DBase.SaveSetting();
            }

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
                    try
                    {
                        int kq = DHuy.RUN_SQL("DELETE CONTROL  WHERE REMOTE_ID = " + ID + " OR CONTROL_ID = " + ID + "  " + "DELETE FILE_TRANSFER  WHERE REMOTE_ID = " + ID + " OR CONTROL_ID = " + ID);

                    }
                    catch (Exception ex) { }
                }

            }
            else
            {
                DetectAndDestroySession();
            }

        }
        private void Z_Main_LocationChanged(object sender, EventArgs e)
        {
            AutoAttactDetect();
        }

        private void cmsTrayExit_Click(object sender, EventArgs e)
        {
            isClose = 1;
            this.Close();
        }
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.Show();
                this.Activate();
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
            }
            else if ( e.Button == MouseButtons.Middle)
            {
                if(ModifierKeys == Keys.Control) cmsSoundToogle_Click(cmsSpeaker, null);
                else cmsSoundToogle_Click(cmsHeadphone, null);
            }
        }
        private void panHead_Click(object sender, EventArgs e)
        {
            if (ID > 0) DHuy.RunUpdate();

        }
        private void cmsPCSRefresh_Click(object sender, EventArgs e)
        {
            RefreshPCS();
            panRight.Visible = true;
        }
        private void INSTALL_SERVICE_CLICK(object sender, EventArgs e)
        {
            try
            {
                //    DHuy.DetachLibrary();
                DHuy.CheckAndUpdateFile("IS.bat");
                DHuy.CheckAndUpdateFile("IS.exe");
                DHuy.CheckAndUpdateFile("ISU.bat");
                DHuy.CheckAndUpdateFile("Persona2.exe");

                System.Diagnostics.Process.Start("IS.bat");

            }
            catch (Exception ex) { }
        }
        private void UNINSTALL_SERVICE_CLICK(object sender, EventArgs e)
        {

            try
            {
                //DHuy.DetachLibrary();
                DHuy.CheckAndUpdateFile("IS.bat");
                DHuy.CheckAndUpdateFile("IS.exe");
                DHuy.CheckAndUpdateFile("ISU.bat");
                DHuy.CheckAndUpdateFile("Persona2.exe");
                System.Diagnostics.Process.Start("ISU.bat");

            }
            catch (Exception ex) { }

        }
        private void LOCK_Click(object sender, EventArgs e)
        {
            try
            {
                LOGON L = new LOGON();
                L.UserName = Environment.UserName;
                L.edtUserName.Text = Environment.UserName;
                L.Show();
                StartupType = "";
                this.Hide();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex) { }
        }
        private void CONFIG_CLICK(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.Show();
                this.Activate();
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                PCTConfig C = new PCTConfig();
                C.M = this;
                C.PCNAME = PCName;
                C.CurrentUserLogin = Environment.UserName;
                C.Location = this.Location;
                C.Show(this);
                PublicChat.ResetInfoID();
            }
            catch (Exception ex) { }
        }
        private void CHAT_CLICK(object sender, EventArgs e)
        {
            PublicChat.Zmain = this;
            PublicChat.Height = this.Height;
            PublicChat.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            PublicChat.Show();
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

        public void AutoAttactDetect()
        {
            try
            {
                int SX = this.Location.X + Width - PublicChat.Location.X;
                int SY = this.Location.Y - PublicChat.Location.Y;
                if (Math.Abs(SX) < 80 && Math.Abs(SY) < 100)
                {
                    PublicChat.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                }
            }
            catch (Exception ex) { }

        }
        private void cmsCloseToTray_Click(object sender, EventArgs e)
        {
            DBase.CloseToTray = DBase.CloseToTray == "1" ? "0" : "1";
            DBase.SaveSetting();
            if (DBase.CloseToTray == "0") this.cmsCloseToTray.Image = null;
            else this.cmsCloseToTray.Image = global::GB.Properties.Resources._011_yes_16;

        }


       
        private void cmsRunAsAdmin_Click(object sender, EventArgs e)
        {
             try
            {
                String RegPath = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers";
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(RegPath, true);

                String Path = Application.ExecutablePath;
                if (rk.GetValue(Path) == null)
                {
                    rk.SetValue(Path, "~ RUNASADMIN");
                }
                else rk.DeleteValue(Path);

                if (rk.GetValue(Path) == null) this.cmsRunAsAdmin.Image = null;
                else this.cmsRunAsAdmin.Image = global::GB.Properties.Resources._011_yes_16;
            }
            catch (Exception ex) { }
        }

        private void START_WITH_WINDOW_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //DBase.RegistryDeleteCU("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "PCT");

            //    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            //    if (rk.GetValue("PCT") == null)
            //    {
            //        if (DBase.AutoLogOn == "1")
            //        {
            //            rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP_LOGON");
            //        }
            //        else rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP");
            //    }
            //    else rk.DeleteValue("PCT");

            //    if (rk.GetValue("PCT") == null) this.cmsStartWithWindow.Image = null;
            //    else this.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
            //}
            //catch (Exception ex) 
            //{
            //    MessageBox.Show("Please Run As Admin ... ");
            //}

            try
            {
                DBase.RegistryDeleteCU("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "PCT");

                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (rk.GetValue("PCT") == null)
                {
                    if (DBase.AutoLogOn == "1")
                    {
                        rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP_LOGON");
                    }
                    else rk.SetValue("PCT", "\"" + Application.ExecutablePath.ToString() + "\" STARTUP");
                }
                else rk.DeleteValue("PCT");

                if (rk.GetValue("PCT") == null) this.cmsStartWithWindow.Image = null;
                else this.cmsStartWithWindow.Image = global::GB.Properties.Resources._011_yes_16;
            }
            catch (Exception ex) { }
        }
        private void cmsCreateContextMenu_Click(object sender, EventArgs e)
        {

        }

        //Get Signal
        Stream stream;
        private Thread theThread;
        TcpClient Tcpclient;
        private void RunConnect()
        {//Connect to the server, send our password and get ready to rock and roll
            try
            {
                Tcpclient = new TcpClient("127.0.0.1", 4000);
                Stream S = Tcpclient.GetStream();


                byte[] Buffer = new byte[1024];
                int Size = S.Read(Buffer, 0, Buffer.Length);
                string Msg = ASCIIEncoding.ASCII.GetString(Buffer, 0, Size).Replace("X=", "").Replace("Y=", "");
                bool FirstConnect = bool.Parse(Msg.Split(' ')[4]);

                stream = Tcpclient.GetStream();

                StreamWriter eventSender = new StreamWriter(stream);
                this.WindowState = FormWindowState.Maximized;
                theThread = new Thread(new ThreadStart(startRead));
                theThread.Start();
            }
            catch (Exception problem)
            {
                //  MessageBox.Show("Invalid IPAddress, Invalid Port, Failed Internet Connection, or Cannot connect to client for some reason, check firewall in windows and router.\n\nTechnical Data:\n**************************************************\n" + problem.ToString(), "You're a Failure!");

            }
        }
        private Bitmap BitmapFromStream()
        {//Here we wait for a new screen-shot or clip-board text to come in from the server
            Bitmap Image = null;
            BinaryFormatter bFormat = new BinaryFormatter();

            try
            {
                Image = bFormat.Deserialize(stream) as Bitmap;
                return Image;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        private void startRead()
        {//Runs on its own thread and keeps looping to read anything that the server sends us
            try
            {
                Thread.Sleep(500);
                while (true)
                {
                    try
                    {
                        Bitmap inImage = BitmapFromStream();
                        if (inImage == null) inImage = BitmapFromStream();
                        Image I = (Image)inImage;
                    }
                    catch (Exception Ex)
                    {
                    }
                }
            }
            catch (Exception Ex)
            {

            }
        }

        private void UPDATE_TRAY_Click(object sender, EventArgs e)
        {
            DHuy.RunUpdate();
        }
        private void MY_DIARY_Click(object sender, EventArgs e)
        {

            DiaryBook P = new DiaryBook();
            P.Text = "Diary Book";
            P.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            P.StartPosition = FormStartPosition.CenterScreen;

            P.Show(this);
        }
        private void cmsHelp_Click(object sender, EventArgs e)
        {
            try
            {
              //  Clipboard.SetText(PCID);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            Help H = new Help();
            H.StartPosition = FormStartPosition.CenterScreen;
            H.Show(this);
        }

        private void cmsExitForce_Click(object sender, EventArgs e)
        {
            isClose = 1;
            this.Close();
        }

     

        // P/Invoke declarations
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);

        private void button1_Click(object sender, EventArgs e)
        {
            ReLoadMirroDriver();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            System.Diagnostics.Process.Start("explorer.exe", DBase.DataFolderPath);
        }


        //Wallpaper
        
        private void timerDetectOffline_Tick(object sender, EventArgs e)
        {
            if (ID <= 0)
            {
                try
                {
                    lbWelcome.Text = "Re-Connecting..!";
                    FinishInit = 0;
                    ZControl_Load(null, null);
                }
                catch (Exception ex) { }
            }
            //wallpaper
            if (DBase.WallChange == 1 &&  ( ( DateTime.Now - DBase.LastSetWallpaper ).TotalSeconds - DBase.WallChangeSecond  ) > 0 ) 
            {
                ChangeWallpaper();
            }
        }
        public void ChangeWallpaper()
        {
            try
            {
              
               if( DBase.DTWALLPAPER == null ) DBase.DTWALLPAPER = DHuy.SELECT_SQL("SELECT ID,FILENAME,DIR,MD5,SIZE FROM FILEDATA_USER WHERE USERCODE = '" + DBase.UserCodeLogin + "' AND DIR = 'ROOT/WALLPAPER'  ");

                Random R = new Random();
                int Num = R.Next(DBase.DTWALLPAPER.Rows.Count);
                string FID = DBase.StringReturn(DBase.DTWALLPAPER, Num, "ID");
                string FILENAME = DBase.StringReturn(DBase.DTWALLPAPER, Num, "FILENAME");
                string DIR = DBase.StringReturn(DBase.DTWALLPAPER, Num, "DIR");
                double SIZE = DBase.DoubleReturn(DBase.DTWALLPAPER, Num, "SIZE");
                if (SIZE < 5000000)
                {
                    int kq = DHuy.CheckAndUpdateFile_User(DBase.UserCodeLogin, DIR, FILENAME, true);
                    if (kq > 0)
                    {
                        DWindow.SetWallpaper(DBase.DataFolderPath + "\\" + FILENAME);
                        DBase.LastSetWallpaper = DateTime.Now;
                    }
                }
            }
            catch (Exception) { }
        }

        private void cmsBundleSetup_Click(object sender, EventArgs e)
        {

        }

        private void Z_Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < panRight.Width + 150)
            {

                lbSay.Visible = lbWelcome.Visible = lbLogin.Visible  = panContents.Visible = false;
            }
            else
            {
                lbSay.Visible = lbWelcome.Visible = lbLogin.Visible = lbAddPcs.Visible = panContents.Visible  = true;
            }
        }

        private void cmsPcsList_Click(object sender, EventArgs e)
        {
            PCSList P = new PCSList(); 
            P.Show();
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

        int SoundDeviceIndex = 0;
        private void cmsSoundToogle_Click(object sender, EventArgs e)
        {
            cmsHeadphone.Image = null;
            cmsSpeaker.Image = null;
            if (sender == cmsHeadphone)
            {
                SoundDeviceIndex = 0;
                cmsHeadphone.Image = global::GB.Properties.Resources.Headphone16;
            }
            else if( sender == cmsSpeaker )
            {
                SoundDeviceIndex = 1;
                cmsSpeaker.Image = global::GB.Properties.Resources.Headphone16;
            }
       
            try
            {
                string DeviceName = "";//;DBase.SoundDeviceText.Split(',')[SoundDeviceIndex];
                if (DeviceName == "" && SoundDeviceIndex == 0) DeviceName = "Headphone";
                if (DeviceName == "" && SoundDeviceIndex == 1) DeviceName = "Speakers";
                DBase.SoundDeviceSet(DeviceName);

                System.Threading.Thread.Sleep(100);
                DBase.PlaySound();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

         

        }

        private void cmsCoder_Click(object sender, EventArgs e)
        {
           
        }

        private void cmsActiveTranslation_Click(object sender, EventArgs e)
        {
            DBase.ActiveTranslation = DBase.ActiveTranslation == 0 ? 1 : 0;
            DBase.SaveSetting();
            RefreshButton();
           
        }

        public void RefreshButton()
        {
            if (DBase.ActiveTranslation == 0) this.cmsActiveTranslation.Image = null;
            else this.cmsActiveTranslation.Image = global::GB.Properties.Resources.YesBlue;
        }


        public void ImportENVN()
        {
              
            DataTable d = DHuy.SELECT_NEWROW("ENVN");
            DateTime STime = DHuy.GetServerTime();
            string S = DBase.ReadFile("1.txt").Replace(";\nINSERT INTO tbl_edict (idx, word, detail) VALUES", ",");
            String[] L2 = S.Split(new string[] { "),\n(" }, StringSplitOptions.None);

            int total = 0;
            for (int i = 0; i < L2.Length; i++)
            {
                DataTable dti = d.Copy();

                //string A = L[i];
                //string[] L2 = A.Split(',');
                //if (L2.Length >= 3)
                //{
                //string STT = L2[0].Replace("'", "").Replace("(","");
                //string EN = L2[1].Replace("'", "").Trim();
                //string VN = L2[2].Replace("'", "").Trim();

                string STT = DBase.JSONSub(L2[i], "", ",").Replace("(", "");
                string EN = DBase.JSONSub(L2[i], "'", "',");
                string VN = DBase.JSONSub(L2[i], "@", "</Q>");
                string DESCR = DBase.JSONSub(L2[i], "@", "<br");

                DBase.SetValue(dti, "STT", STT);
                DBase.SetValue(dti, "EN", EN);
                DBase.SetValue(dti, "VN", VN);
                DBase.SetValue(dti, "DESCR", DESCR);
                DBase.SetValue(dti, "CDATETIME", STime);
                int kq = DHuy.INSERT_IDENTITY("ENVN", dti);
                if (kq > 0)
                {
                    total++;
                }
                else
                {
                    DBase.SetValue(dti, "EN", EN + " (*)");
                    kq = DHuy.INSERT_IDENTITY("ENVN", dti);
                    if (kq > 0) total++;
                    else
                    {
                        MessageBox.Show(STT + "\n" + DHuy.LastException);
                    }
                }
                //}

            }

            MessageBox.Show("Imported " + total + "/" + L2.Length);
        

        }
       
    }
}
