using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GB
{
    public partial class Window : Form
    {
        public string WindowVersion = "";
        public int SetWindowIcon = 0;
        public int ID = 0;
        public string RemotePassword = "";
        public int Status = 0;
        public bool isConnect = false;
        public int CONTROL_ID = 0;
        public int REMOTE_ID = 0;
        public int SESSION_ID = 0;
        public int CompressMode = 0;
        public int CursorSize = 0;
        public string CursorString = "";
        public int ImageQuality = 2;
        public float Image_Scale = 1;
        public float Window_Font_Scale = 100;
        public int ResX = 0;
        public int ResY = 0;
        DataTable dt = new DataTable();
        DataTable data = new DataTable();
        BackgroundWorker W1;
        BackgroundWorker W2;
        BackgroundWorker WInfo;
        public int GitchCount = 0;
        Chat ChatBox = new Chat();
        public string Remote_PCName = "";
        public string NameInList = "";
        public int ShowImageFrag = 0;
        public int ScreenSelect = 0;
        public int CurX = 0;
        public int CurY = 0;
        public int DiffRes = 0;
        public int lastSignal = 0;
        public ZPCT M = null;

        public float xfactor = 1;
        public float yfactor = 1;

        public int RealX = 0;
        public int RealY = 0;
        public float xScale = 1;
        public float yScale = 1;


        public int padingx = 15;
        public int padingy = 39;
        public int SubHeight = 50;
        public int Showcursor = 0;
        public string clipboard = "";
        public int SpaceX = 0;
        public int SpaceY = 0;
        public string lastClipboard = "";
        ConfirmPassword P = new ConfirmPassword();
        int isbusy1 = 0;
        int isbusy2 = 0;
        Image ImageData = null;
        int Inited = 0;
        int interval = 0;
        DateTime LastImage = DateTime.Now;
        DateTime QuerryTime = DateTime.Now;
        int LatencyQuerry = 0;
        DateTime QuerryTime2 = DateTime.Now;
        int LatencyQuerry2 = 0;
        Image Image1;
        Image Image2;
        Image Image3;
        Image Image4;
        int ImageW = 0;
        int ImageH  = 0;
        byte[] B1;
        byte[] B2;
        byte[] B3;
        byte[] B4;
        string M1 = "";
        string M2 = "";
        string M3 = "";
        string M4 = "";
        int isGitch = 0;
        int intervalGetImage = 0;
        int Retry = 0;
        string RemoteLatency = "";
        int isbusyInfo = 0;
        string sqlClip = "";
        String MoveAction = "";
        int MoveActionInterval = 0;
        DateTime KeyStart = DateTime.Now;
        int MouseDownCount = 0;
        int MouseMoveCount = 0;
        int LostConnection = 0;
        int CursorIndex = 0;

        int useMirroDriver = -1;
        int FragMode = -1;
        int FormActive = 0;
        int ReadClipBoard = 0;
        public int BundleMode = 0;
        public int BundleFinish = 0;


        public void MouseHasntMoved()
        {
        //Do something
        }


        public Window()
        {
            InitializeComponent();
            
            timerInfo.Start();
            timerData.Start();

            panContent.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panContent_MouseWheel);


            W1 = new BackgroundWorker();
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted1);
            W2 = new BackgroundWorker();
            this.W2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork2);
            this.W2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted2);

            WInfo = new BackgroundWorker();
            this.WInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWorkInfo);
            this.WInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompletedInfo);


        }
        private void Window_Load(object sender, EventArgs e)
        {
           
            //lastClipboard = Clipboard.GetText();
            if (Showcursor == 0) this.cmsShowCursor.Image = null;
            else this.cmsShowCursor.Image = global::GB.Properties.Resources.Thunder;
          
        }
        //INFO
        private void Info_Tick(object sender, EventArgs e)
        {
            if (isbusyInfo == 0)
            {
                isbusyInfo = 1;
                WInfo.RunWorkerAsync();
            }
            
        }
        private void Data_Tick(object sender, EventArgs e)
        {
            try
            {
                //if (!isConnect) this.Hide();
                //else this.Show();

                if (isbusy1 == 1) return;
                W1.RunWorkerAsync();
            }
            catch (Exception ex) { DBase.LogException(ex.ToString()); }
        }

        private void bgw_DoWorkInfo(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
                try
                {
                    dt = DHuy.SELECT_SQL("SELECT REMOTE_ID,WINDOW,FRAG_MODE,MIRROR_DRIVER,CURSORS,PASSWORD,COMPRESS_MODE,REMOTE_LATENCY,IMAGE_QUALITY,IMAGE_SCALE,RESX,RESY,REMOTE_PCNAME,DATEDIFF(ms,ISNULL(REMOTE_SIGNAL,dateadd(D,-1, getdate())),getdate()) AS LAST_SIGNAL,CLIPBOARD FROM CONTROL WHERE ID = " + SESSION_ID, 100);
                }
                catch (Exception ex) { DBase.LogException(ex.ToString()); }
        }   //Get Session Info
        private void bgw_RunWorkerCompletedInfo(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    LostConnection = 0;
                    REMOTE_ID = DBase.IntReturn(dt.Rows[0]["REMOTE_ID"]);
                    WindowVersion = DBase.StringReturn(dt.Rows[0]["WINDOW"]);
                    if (SetWindowIcon == 0 && WindowVersion != "" )
                    {
                        if (WindowVersion.ToUpper().Contains("WINDOWS 7"))
                        {
                            this.Icon = DBase.CreateIcon(Properties.Resources.Window);
                            SetWindowIcon = 1;
                        }
                        else if (WindowVersion.ToUpper().Contains("WINDOWS 10"))
                        {
                            this.Icon = DBase.CreateIcon(Properties.Resources.Window10);
                            SetWindowIcon = 1;
                        }
                        else if (WindowVersion.ToUpper().Contains("WINDOWS 8"))
                        {
                            this.Icon = DBase.CreateIcon(Properties.Resources.Window8);
                            SetWindowIcon = 1;
                        }
                        else
                        {
                            this.Icon = DBase.CreateIcon(Properties.Resources.Window);
                            SetWindowIcon = 1;
                        }

                    }
                    //int curIndex = DBase.IntReturn(dt.Rows[0]["PASSWORD"]);
                    //if (CursorIndex != curIndex)
                    //{
                    //    CursorIndex = curIndex;
                    //    this.Cursor = DBase.Curo[curIndex];
                    //}

                    RemoteLatency = DBase.StringReturn(dt.Rows[0]["REMOTE_LATENCY"]);
                    ImageQuality = DBase.IntReturn(dt.Rows[0]["IMAGE_QUALITY"]);
                    int newCompressMode = DBase.IntReturn(dt.Rows[0]["COMPRESS_MODE"]);
                    int newFragMode = DBase.IntReturn(dt.Rows[0]["FRAG_MODE"]);
                    int newMirroDriver = DBase.IntReturn(dt.Rows[0]["MIRROR_DRIVER"]);

                    if (newCompressMode != CompressMode)
                    {
                        CompressMode = newCompressMode;
                        edtCompress.Image = CompressMode==1? global::GB.Properties.Resources.check:null;

                    }

                    if (newMirroDriver != useMirroDriver)
                    {
                        useMirroDriver = newMirroDriver;
                        cmsUseMirroDriver.Image = useMirroDriver == 1 ? global::GB.Properties.Resources.check : null;

                    }

                    if (newFragMode != FragMode)
                    {
                        FragMode = newFragMode;
                        cmsUseImageFrag.Image = FragMode == 1 ? global::GB.Properties.Resources.check : null;

                    }


                    int newResX = DBase.IntReturn(dt.Rows[0]["RESX"]);
                    if (newResX != ResX) // new resolution detect
                    {
                        ResX = newResX;


                        Inited = 0;
                    }
                    Image_Scale = DBase.IntReturn(dt.Rows[0]["IMAGE_SCALE"]);
                    ResY = DBase.IntReturn(dt.Rows[0]["RESY"]);
                    lastSignal = DBase.IntReturn(dt.Rows[0]["LAST_SIGNAL"]);
                    Remote_PCName = DBase.StringReturn(dt.Rows[0]["REMOTE_PCNAME"]);
                    if (FormActive == 0 && ReadClipBoard == 0 ) {
                        ReadClipBoard = 1;
                        sqlClip = DBase.StringReturn(dt.Rows[0]["CLIPBOARD"]);
                        Clipboard.SetText(sqlClip);
                        clipboard = Clipboard.GetText();
                    }
                   
                    if (NameInList == "") NameInList = Remote_PCName;
                }
                else
                {
                    lastSignal = -1;
                    LostConnection = 1;
                    Retry++;
                }

                if (Inited == 0 & ResX > 0 & ResY > 0)
                {
                    Inited = 1;
                    timerInfo.Interval = 3000;
                   
                    if ((ResY + padingy) > Screen.PrimaryScreen.Bounds.Height)
                    {
                        ST:
                        int H = Screen.PrimaryScreen.WorkingArea.Height - SubHeight ;

                        int contentY = H - padingy;
                        int contentX = (int)((float)contentY * (float)ResX / (float)ResY);
                        int W = contentX + padingx;

                        if (W > Screen.PrimaryScreen.WorkingArea.Width)
                        {
                            SubHeight = SubHeight + 30;
                            goto ST;
                        }
                        this.Width = W;
                        this.Height = H;


                        xfactor = (float)ResX / (float)panContent.Width / ImageW;
                        yfactor = (float)ResY / (float)panContent.Height / ImageH;

                    }
                    else
                    {
                        this.Width = ResX + padingx;
                        this.Height = ResY + padingy;
                        xfactor = (float)ResX / (float)panContent.Width;
                        yfactor = (float)ResY / (float)panContent.Height;

                    }
                    try
                    {
                        SpaceX = 0;
                        SpaceY = 0;
                        int newx = this.Width - padingx;
                        int newy = (int)((float)ResY * (float)newx / (float)ResX);
                        this.Height = newy + padingy;

                        xfactor = (float)ResX / (float)panContent.Width;
                        yfactor = (float)ResY / (float)panContent.Height;
                    }
                    catch (Exception ex) { }
                    CenterToScreen();
                }


                if (lastSignal == -1)
                {
                    Text = "Connecting..." + Retry + "/30 ";
                }

               
            }
            catch (Exception ex) { DBase.LogException(ex.ToString());  }
            isbusyInfo = 0;
        }

        //IMAGE
        String BenQ = "";
        String BenFrag = "";
        String BenImageLoad = "";
        DateTime TotalTime = DateTime.Now;
        String BenTotal = "";
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            isbusy1 = 1;

            TotalTime = DateTime.Now;
            intervalGetImage++; if (intervalGetImage > 100000000) intervalGetImage = 1;
            string IString = "";
            DateTime DStart = DateTime.Now;
        
            if (!isConnect)
            {
                data = DHuy.SELECT_SQL("SELECT STATUS from CONTROL WHERE ID = " + SESSION_ID);
                if (data.Rows.Count > 0)
                {
                    Status = DBase.IntReturn(data.Rows[0]["STATUS"]);
                    if (Status == 3)
                    {
                        isConnect = true;
                        if (DBase.DisableAreoThemWhenConnect == "1")
                        {
                            DISABLE_AREO_Click(null, null);
                            REMOVE_WALLPAPER_Click(null, null);
                        }
                        try
                        {
                            foreach (ToolStripItem T in cmsQuality.DropDownItems)
                            {
                                try
                                {

                                    if (T.Text == DBase.LastImageQuality)
                                    {
                                        QUALITY_Click(T, null);
                                    }
                                }
                                catch (Exception ex) { DBase.LogException(ex.ToString()); }
                            }
                        }
                        catch (Exception ex) { }

                    }
                }
                return;
            }

            //Status = 2 , begin process data 
            if (isGitch == 1 || intervalGetImage < 100)
            {
                isGitch = 2;
                data = DHuy.SELECT_SQL("SELECT * from CONTROL WHERE ID = " + SESSION_ID);
            }
            else data = DHuy.SELECT_SQL("CONTROL_GET_IMAGE_FRAMENT " + SESSION_ID);
            //BenQ = DBase.Latency(DStart, DateTime.Now);

          
            if (data.Rows.Count == 0)
            {
                return;
            }
            try
            {   
                String m1 = DBase.StringReturn(data.Rows[0]["M1"]);
                String m2 = DBase.StringReturn(data.Rows[0]["M2"]);
                String m3 = DBase.StringReturn(data.Rows[0]["M3"]);
                String m4 = DBase.StringReturn(data.Rows[0]["M4"]);
                IString = DBase.StringReturn(data.Rows[0]["INGORE_STRING"]);
             

                //DStart = DateTime.Now;

                if (data.Columns.Contains("IMAGE"))
                {
                    if (CompressMode == 1)
                    {
                        B1 = (Byte[])(data.Rows[0]["IMAGE"]);
                        B1 = Compressor.Decompress(B1);
                    }
                    else B1 = (Byte[])(data.Rows[0]["IMAGE"]);
                }
                if (data.Columns.Contains("IMAGE2"))
                {
                    if (CompressMode == 1) B2 = Compressor.Decompress((Byte[])(data.Rows[0]["IMAGE2"]));
                    else B2 = (Byte[])(data.Rows[0]["IMAGE2"]);

                }
                if (data.Columns.Contains("IMAGE3"))
                {
                    if (CompressMode == 1) B3 = Compressor.Decompress((Byte[])(data.Rows[0]["IMAGE3"]));
                    else B3 = (Byte[])(data.Rows[0]["IMAGE3"]);

                }
                if (data.Columns.Contains("IMAGE4"))
                {
                    if (CompressMode == 1) B4 = Compressor.Decompress((Byte[])(data.Rows[0]["IMAGE4"]));
                    else B4 = (Byte[])(data.Rows[0]["IMAGE4"]);

                }

                if (isGitch != 2)
                {
                    if (m1 != DBase.StringReturn(B1.Length) | m2 != DBase.StringReturn(B2.Length) | m3 != DBase.StringReturn(B3.Length) | m4 != DBase.StringReturn(B4.Length))
                    {
                        GitchCount++;
                        isGitch = 1;
                    }
                }
                else isGitch = 0;

                M1 = m1;
                M2 = m2;
                M3 = m3;
                M4 = m4;

              
          

                MemoryStream ms =  new MemoryStream(B1);
                MemoryStream ms2 = B2.Length == 3 ? null : new MemoryStream(B2);
                MemoryStream ms3 = B3.Length == 3 ? null : new MemoryStream(B3);
                MemoryStream ms4 = B4.Length == 3 ? null :  new MemoryStream(B4);

                 Image1 = Image.FromStream(ms);
                 Image2 = ms2 == null ? null : Image.FromStream(ms2);
                 Image3 = ms3 == null ? null : Image.FromStream(ms3);
                 Image4 = ms4 == null ? null : Image.FromStream(ms4);


                 if (FragMode == 1)
                 {
                     ImageData = new Bitmap((int)(Image1.PhysicalDimension.Width + (Image2 == null ? 0 : Image2.PhysicalDimension.Width) + (Image3 == null ? 0 : Image3.PhysicalDimension.Width) + (Image4 == null ? 0 : Image4.PhysicalDimension.Width)), (int)Image1.PhysicalDimension.Height);
                     ImageW = ImageData.Width;
                     ImageH = ImageData.Height;
                     using (Graphics g = Graphics.FromImage(ImageData))
                     {
                         g.DrawImage(Image1, 0, 0);
                         if (IString.Contains("IMAGE") & ShowImageFrag == 1) g.DrawRectangle(Pens.Red, 1, 0, Image1.Width - 1, Image1.Height);

                         g.DrawImage(Image2, Image1.Width, 0);
                         if (IString.Contains("IMAGE2") & ShowImageFrag == 1) g.DrawRectangle(Pens.Red, Image1.Width + 1, 0, Image2.Width - 1, Image2.Height);

                         g.DrawImage(Image3, Image1.Width * 2, 0);
                         if (IString.Contains("IMAGE3") & ShowImageFrag == 1) g.DrawRectangle(Pens.Red, Image1.Width + Image2.Width + 1, 0, Image3.Width - 1, Image3.Height);

                         g.DrawImage(Image4, Image1.Width * 3, 0);
                         if (IString.Contains("IMAGE4") & ShowImageFrag == 1) g.DrawRectangle(Pens.Red, Image1.Width + Image2.Width + Image3.Width + 1, 0, Image4.Width - 1, Image4.Height);
                     }
                 }
                 else
                 {
                     ImageData = Image1;
                 }

                ms.Dispose();
                if ( ms2 != null )ms2.Dispose();
                if ( ms3 != null) ms3.Dispose();
                if ( ms4 != null) ms4.Dispose();

             //   BenFrag = DBase.Latency(DStart, DateTime.Now);
                
               
            }
            catch (Exception ex) { DBase.LogException(ex.ToString()); }

        } // for get image
        private void bgw_RunWorkerCompleted1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!isConnect)
            {
                try
                {
                    Status = DBase.IntReturn(data.Rows[0]["STATUS"]);
                    if (Status == 1)
                    {
                        if (RemotePassword == "")
                        {
                            P = new ConfirmPassword();
                            P.ShowDialog(this);
                            if (P.Res == 1)
                            {
                                string commmand = "AUTHEN_CONTROL;" + SESSION_ID + ";" + DHuy.HideFood(P.Text, "justicenzy", new byte[64]);
                                DHuy.AddCommand(SESSION_ID, commmand);
                                DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 2 WHERE STATUS = 1 AND ID = " + SESSION_ID);
                                Status = 2;
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            string commmand = "AUTHEN_CONTROL;" + SESSION_ID + ";" + DHuy.HideFood(RemotePassword, "justicenzy", new byte[64]);
                            RemotePassword = "";
                            DHuy.AddCommand(SESSION_ID, commmand);
                            DHuy.RUN_SQL("UPDATE CONTROL SET STATUS = 2 WHERE STATUS = 1 AND ID = " + SESSION_ID);
                            Status = 2;
                        }
                    }
                }
                catch (Exception ex) { DBase.LogException(ex.ToString()); }
            }

            try
            {
                if (isConnect)
                {
                    try
                    {
                        DateTime BenS = DateTime.Now;
                        //if (panContent.Width != ImageData.Width)
                        //{
                        //    if (this.WindowState == FormWindowState.Normal)
                        //    {
                        //        ImageData = new Bitmap(ImageData, new Size(panContent.Width, panContent.Height));
                        //    }
                        //}
                        panContent.Image = ImageData;
                        BenImageLoad = DBase.Latency(BenS, DateTime.Now);
                        if (BundleMode == 1 && BundleFinish == 0 && this.Width != 567)
                        {
                            BundleFinish = 1;
                            try
                            {
                                string action = "IMAGE_SCALE;4";
                                int kq = DHuy.AddCommand(SESSION_ID, action);

                                String MemSize = DBase.JSONSub(DBase.SizeMemory, REMOTE_ID.ToString() + ":", ",");
                                String[] Mem = MemSize.Split(':');
                                Point P = new Point(DBase.IntReturn(Mem[0]), DBase.IntReturn(Mem[1]));
                                int MemWidth = DBase.IntReturn(Mem[2]);

                                if (MemWidth != 0 && P.X < Screen.PrimaryScreen.WorkingArea.Width && P.Y < Screen.PrimaryScreen.WorkingArea.Height)
                                {
                                    this.Location = P;
                                    this.Width = MemWidth;
                                }
                            }
                            catch (Exception ex)
                            {
                                //  MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                Visible = true;
                                Show();
                                Activate();
                            }

                        }
                       
                    }
                    catch (Exception ex) { }

                    BenTotal = DBase.Latency(TotalTime, DateTime.Now);
                    if (lastSignal > 0) Text = NameInList + " - S : " + SESSION_ID.ToString() + " - R : " + REMOTE_ID + " (" + ResX + "x" + ResY + ") - Q : " + BenQ + "-Frag : " + BenFrag + " - Img : " + BenImageLoad + " Total : " + BenTotal + "   G : " + GitchCount + "      RL : " + RemoteLatency + " - MD : " + useMirroDriver + " - C : " + CursorSize;
                
                }
                else Text = "Connecting to your partner...";
                LastImage = DateTime.Now;

                isbusy1 = 0;
                interval++;
            }
            catch (Exception ex) { DBase.LogException(ex.ToString()); }
            //}
      }

        //ACTION
        private void bgw_DoWork2(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        try
        {
            isbusy2 = 1;
            int kq = DHuy.AddCommand(SESSION_ID, MoveAction);
        }
        catch (Exception ex) { DBase.LogException(ex.ToString()); }
    }  // for mouse move action
        private void bgw_RunWorkerCompleted2(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            isbusy2 = 0;
        }

        //event
        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            int kq = DHuy.RUN_SQL("UPDATE CONTROL SET CLOSED = 1 WHERE ID = " + SESSION_ID + " DELETE FILE_TRANSFER  WHERE REMOTE_ID = " + ID + " OR CONTROL_ID = " + ID);

            if (BundleMode == 1)
            {
                String[] Ls = DBase.SizeMemory.Split(',');
                foreach (String S in Ls)
                {
                    if (S.Split(':')[0] == REMOTE_ID.ToString())
                    {
                        DBase.SizeMemory =  DBase.SizeMemory.Replace(S+",", "");
                     
                    }
                }

                DBase.SizeMemory =  DBase.SizeMemory + REMOTE_ID + ":" + this.Location.X + ":" + this.Location.Y + ":" + this.Width + ",";
                DBase.SaveSetting();
            }

        }
        private void dgv_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                this.Text = "Drag...";
            }

            else
                e.Effect = DragDropEffects.None;
        }
        private void dgv_DragDrop(object sender, DragEventArgs e)
        {
            this.Text = "";
            int i = 0;
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (var filePath in files)
                    {

                        String name = Path.GetFileName(filePath);
                        FileInfo fi = new FileInfo(filePath);
                        FileTransfer F = new FileTransfer(CONTROL_ID, REMOTE_ID, filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                DBase.LogException(ex.ToString());
            }

            if (i > 0)
            {
                this.Text = "Droped " + i.ToString() + " files...";

            }
        }

        //ACTIONS
        private void panContent_MouseEnter(object sender, EventArgs e)
        {
            if (Form.ActiveForm == this)
            {
                panContent.Focus();
            }
        }

        int MoveTimerInterval = 0;
        private void TMove_Tick(object sender, EventArgs e)
        {
            MoveTimerInterval++;
            if (MoveTimerInterval % 20 == 1)
            {
                string action = "HOVER;" + CurX + ";" + CurY;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                TMove.Stop();
            }
            
        }
        private void panContent_MouseMove(object sender, MouseEventArgs e)
        {
            MoveActionInterval++; if (MoveActionInterval > 10000) MoveActionInterval = 1;
            if (Form.ActiveForm == this)
            {
                try
                {
                    CurX = e.Location.X;
                    CurY = e.Location.Y;
                    CurX = (int)((float)(CurX-SpaceX) * xfactor);
                    CurY = (int)((float)(CurY-SpaceY) * yfactor);
                    MoveAction = "HOVER;" + CurX + ";" + CurY;
                    if (MoveActionInterval % 20 == 0)
                    {
                        if (isbusy2 == 0)
                        {
                            MouseMoveCount++;
                            W2.RunWorkerAsync();
                        }
                    }
                }
                catch (Exception ex) { DBase.LogException(ex.ToString()); }
               
                TMove.Start();
            }
        }
        private void panContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (LostConnection == 1) return;

            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSEDOWN_CTRL;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
            }
            else if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSEDOWN_SHIFT;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
            }

            else if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSEDOWN_ALT;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X-SpaceX) * xfactor);
                Y = (int)((float)(Y-SpaceY) * yfactor);


                string action = "MOUSEDOWN;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
             
            }

            
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSE_MIDDLE_DOWN;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);

            }
        }
        private void panContent_MouseUp(object sender, MouseEventArgs e)
        {
            if (LostConnection == 1) return;

            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSEUP_CTRL;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
            }

            else if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSEUP_SHIFT;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
            }

            else if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);


                string action = "MOUSEUP_ALT;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
                MouseDownCount++;
            }


            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X-SpaceX) * xfactor);
                Y = (int)((float)(Y-SpaceY) * yfactor);

                string action = "MOUSEUP;" + X + ";" + Y;

                int kq = DHuy.AddCommand(SESSION_ID, action);
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X - SpaceX) * xfactor);
                Y = (int)((float)(Y - SpaceY) * yfactor);

                string action = "MOUSE_MIDDLE_UP;" + X + ";" + Y;

                int kq = DHuy.AddCommand(SESSION_ID, action);
            }

        }
        private void panContent_MouseClick(object sender, MouseEventArgs e)
        {
            if (LostConnection == 1) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int X = e.Location.X;
                int Y = e.Location.Y;

                X = (int)((float)(X-SpaceX) * xfactor);
                Y = (int)((float)(Y-SpaceY) * yfactor);

                string action = "RCLICK;" + X + ";" + Y;

                int kq = DHuy.AddCommand(SESSION_ID, action);
            }
        }
        private void panContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    int X = e.Location.X;
            //    int Y = e.Location.Y;

            //    string action = "2CLICK;" + X + ";" + Y;

            //    int kq = DHuy.AddCommand(SESSION_ID, action);
            //}
        }
        private void panContent_MouseWheel(object sender, MouseEventArgs e)
        {
            if (LostConnection == 1) return;
            if (( ModifierKeys & Keys.Control )== Keys.Control)
            {
                string action = "MOUSE_SCROLL_CTRL;" + e.Delta;
                int kq = DHuy.AddCommand(SESSION_ID, action);
            }
            else
            {
                string action = "MOUSE_SCROLL;" + e.Delta;
                int kq = DHuy.AddCommand(SESSION_ID, action);

            }


            
        }
        private void panContent_MouseHover(object sender, EventArgs e)
        {
            string action = "HOVER;" + CurX + ";" + CurY;

            int kq = DHuy.AddCommand(SESSION_ID, action);
        }
        private void Window_MouseHover(object sender, EventArgs e)
        {
            string action = "HOVER;" + CurX + ";" + CurY;

            int kq = DHuy.AddCommand(SESSION_ID, action);
        }

        private void Window_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                timerData.Stop();
                timerInfo.Stop();
            }
            else
            {
                if (WindowState == FormWindowState.Maximized) // maximize , with & heght dynamic changed not follow rule
                {
                    //check if newX = this.width            1024 - 768        ==>           1920 --> ?
                    int newX = this.Width;
                    int newY = (int)((float)(this.Width*panContent.Image.Height) / panContent.Image.Width);
                    if (newY > this.Height)  // can't render newY ==> change newY = this.heigh;   1024 768  ==> ? --> 1080
                    {
                        newY = this.Height;
                        newX = (int)((float)(this.Height * panContent.Image.Width) / panContent.Image.Height);
                        SpaceY = 0;
                        SpaceX  = (int)((float)(this.Width - newX) / 2);
                    }
                    else
                    {
                        newX = this.Width;
                        //newY = newY;
                        SpaceX = 0;
                        SpaceY = (int)((float)(this.Height - newY) / 2);
                    }

                    xfactor = (float)ResX / (float)newX;
                    yfactor = (float)ResY / (float)newY;


                    
                }
                else
                {
                    SpaceX = 0;
                    SpaceY = 0;
                    int newx = this.Width - padingx;
                    int newy = (int)((float)ResY * (float)newx / (float)ResX);
                    this.Height = newy + padingy;

                    xfactor = (float)ResX / (float)panContent.Width;
                    yfactor = (float)ResY / (float)panContent.Height;



                    timerData.Start();
                    timerInfo.Start();
                }

              
                
                foreach (ToolStripItem T in cmsResolution.DropDownItems)
                {
                    try
                    {

                        int a = DBase.IntReturn(T.Text.Split('x')[0]);
                        int b = DBase.IntReturn(T.Text.Split('x')[1]);
                        if (ImageW == a & ImageH == b) T.Image = global::GB.Properties.Resources.check;
                        else T.Image = null;
                    }
                    catch (Exception ex) { DBase.LogException(ex.ToString());  }
                }
            }

        }
        private void panContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && DBase.isWindowKeyDown == 1)
            {
                string cmd = "RUN_WINKEY_P;";
                DHuy.AddCommand(SESSION_ID, cmd);
                return;
            }

            if (e.KeyCode == Keys.D && DBase.isWindowKeyDown == 1 && DBase.isLock == 0)
            {
                string cmd = "RUN_WINKEY_D;";
                DHuy.AddCommand(SESSION_ID, cmd);
                return;
            }

            if (e.KeyCode == Keys.L && DBase.isWindowKeyDown == 1 && DBase.isLock == 0)
            {
                string cmd = "RUN_WINKEY_L;";
              //  MessageBox.Show("RUN WL ");
                DHuy.AddCommand(SESSION_ID, cmd);
                return;
            }

            if (LostConnection == 1) return;
            if (e.KeyCode == Keys.ShiftKey) return;
            if (e.KeyCode == Keys.ControlKey) return;
            if (e.KeyCode == (Keys.RButton | Keys.ShiftKey)) return;

            bool CapsLock = (((ushort)DWindow.GetKeyState(0x14)) & 0xffff) != 0;
            //bool NumLock = (((ushort)DWindow.GetKeyState(0x90)) & 0xffff) != 0;
            //bool ScrollLock = (((ushort)DWindow.GetKeyState(0x91)) & 0xffff) != 0;
            String action = "";
            String Syskey1 = "";
            String Syskey2 = "";
            String Syskey3 = "";
            if (e.Modifiers == Keys.Shift) Syskey1 = "ShiftKey";
            if (e.Modifiers == Keys.Control) Syskey2 = "ControlKey";
            if (e.Modifiers == Keys.Alt) Syskey3 = "AltKey";

            if (e.Modifiers == ( Keys.Shift | Keys.Control) )
            {
                Syskey1 = "ShiftKey";
                Syskey2 = "ControlKey";
            }

            if (e.Modifiers == (Keys.Shift | Keys.Control | Keys.Alt))
            {
                Syskey1 = "ShiftKey";
                Syskey2 = "ControlKey";
                Syskey2 = "AltKey";
            }


            action = "KEY;" + Syskey1 + ";" + Syskey2 +  ";" + e.KeyCode + ";" + CapsLock + ";" + Syskey3 ;

            int kq = DHuy.AddCommand(SESSION_ID, action);
        }
        private void Window_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = e.KeyChar.ToString();
           

        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LWin)
            {
                e.Handled = true;
            }
        }
  
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                cmsFullScreen_Click(null, null);
                return;
            }
          base.WndProc(ref m);
        }

        //FILE TRANSFER
        private void cmsFILE_TRANSFER_Click(object sender, EventArgs e)
        {
            M.TRANSFER_BEGIN_SESSION(REMOTE_ID);
        }
      
        //Clipboard Synch
        private void Window_Activated(object sender, EventArgs e)
        {
            FormActive = 1;
            KeyboardManager.DisableSystemKeys();
            DBase.CurrentSessionID = SESSION_ID;
            string curclip = Clipboard.GetText();
         
            //send Command change clipboard
            String command = "CLIPBOARD;" + curclip;
            DHuy.AddCommand(SESSION_ID, command);

            
        }
        private void Window_Deactivate(object sender, EventArgs e)
        {
            FormActive = 0;
            ReadClipBoard = 0;
            lastClipboard = Clipboard.GetText();
            DBase.CurrentSessionID = 0;
            KeyboardManager.EnableSystemKeys();
        }


        //OPTIONS
        private void cmsFullScreen_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
               
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }

        }
        private void QUALITY_Click(object sender, EventArgs e)
        {
            int value = 1;
            string text = ((ToolStripMenuItem)sender).Text;
            if (text == "Gray Color") value = -1;
            if (text == "Fastest") value = 0;
            if (text == "Bad") value = 1;
            if (text == "Fair") value = 2;
            if (text == "Compress") value = 3;
            if (text == "Normal") value = 4;
            if (text == "Better") value = 5;
            if (text == "Nice") value = 6;
            if (text == "Good") value = 7;
            if (text == "Great") value = 8;
            if (text == "Best") value = 9;
            string action = "QUALITY;" + value;

            foreach (ToolStripItem T in cmsQuality.DropDownItems)
            {
                try
                {
                    if (T == sender) T.Image = global::GB.Properties.Resources.check;
                    else T.Image = null;
                }
                catch (Exception ex) { DBase.LogException(ex.ToString()); }
            }

            int kq = DHuy.AddCommand(SESSION_ID, action);
            if (kq > 0)
            {
                DBase.LastImageQuality = text.Replace("cms", "");
                DBase.SaveSetting();
            }


        }
        private void SCALE_Click(object sender, EventArgs e)
        {
            float value = 1;
            string text = ((ToolStripMenuItem)sender).Text;
            text = text.Replace("x", "");
            value = DBase.FloatReturn(text);
            Image_Scale = value;
            string action = "IMAGE_SCALE;" + value;

            int kq = DHuy.AddCommand(SESSION_ID, action);

            foreach (ToolStripItem T in cmsScale.DropDownItems)
            {
                try
                {
                    if (T == sender) T.Image = global::GB.Properties.Resources.check;
                    else T.Image = null;
                }
                catch (Exception ex) { DBase.LogException(ex.ToString()); }
            }
        }
        private void WINDOW_FONT_SCALE_Click(object sender, EventArgs e)
        {
            float value = 1;
            string text = ((ToolStripMenuItem)sender).Text;
            text = text.Replace("%", "");
            value = DBase.FloatReturn(text);
            Window_Font_Scale = value;
            string action = "WINDOW_FONT_SCALE;" + value;

            int kq = DHuy.AddCommand(SESSION_ID, action);

            foreach (ToolStripItem T in cmsScale.DropDownItems)
            {
                try
                {
                    if (T == sender) T.Image = global::GB.Properties.Resources.check;
                    else T.Image = null;
                }
                catch (Exception ex) { DBase.LogException(ex.ToString()); }
            }
        }
        private void RESOLUTION_Click(object sender, EventArgs e)
        {
            string text = ((ToolStripMenuItem)sender).Text;
            text.Replace(" ", "");
            if (text == "Native")
            {
                string action = "NATIVE_RES;";
                int kq = DHuy.AddCommand(SESSION_ID, action);
            }
            else
            {
                int X = DBase.IntReturn(text.Split('x')[0]);
                int Y = DBase.IntReturn(text.Split('x')[1]);

                string action = "RES;" + X + ";" + Y;
                int kq = DHuy.AddCommand(SESSION_ID, action);
            }

         
           
        }
        private void MULTISCREEN_Click(object sender, EventArgs e)
        {
            string text = ((ToolStripMenuItem)sender).Text;
            int value = DBase.IntReturn(text.Substring(text.Length - 1, 1)) - 1;
            if (text.ToLower().Contains("primary")) value = 0;
            if (text.ToLower().Contains("eyefinity")) value = -1;

            string action = "SWITCHS_SCREEN;" + value;
            int kq = DHuy.AddCommand(SESSION_ID, action);

        }
    
        private void MOUSE_DOWN_CONTROL_PANEL(object sender, MouseEventArgs e)
        {
            DWindow.SetRightClick_NoMoveCursor(Cursor.Position.X - e.X, Cursor.Position.Y - e.Y);
        }
        private void cmsImageFrag_Click(object sender, EventArgs e)
        {
            ShowImageFrag = ShowImageFrag == 0 ? 1 : 0;
            if (ShowImageFrag == 0) this.cmsImageFrag.Image = null;
            else cmsImageFrag.Image = global::GB.Properties.Resources._011_yes_16;
        }
        private void OPTION_SHOW_CURSOR_Click(object sender, EventArgs e)
        {
            Showcursor = Showcursor == 1 ? 0 : 1;
            if (Showcursor == 0) this.cmsShowCursor.Image = null;
            else this.cmsShowCursor.Image = global::GB.Properties.Resources.Thunder;

            string action = "SHOWCURSOR;" + Showcursor ;
            int kq = DHuy.AddCommand(SESSION_ID, action);
        }
        private void OPTION_UPDATE_Click(object sender, EventArgs e)
        {
            string action = "RUN_UPDATE;";
            int kq = DHuy.AddCommand(SESSION_ID, action);
        }
        private void CHATBOX_Click(object sender, EventArgs e)
        {
            Chat C = new Chat();
            String ControlString =CONTROL_ID + "_"+REMOTE_ID;
            string action = "CHATBOX;" + ControlString;
            C.Control_Remote = ControlString;
            DHuy.AddCommand(SESSION_ID, action);
            C.Icon = DBase.CreateIcon(cmsChatBox.Image);
            C.Show();
        }
        private void RELOGON_Click(object sender, EventArgs e)
        {
            ConfirmAuthencation C = new ConfirmAuthencation();
            C.ShowDialog(this);
            if( C.Res == 1 )
            {
                string cmd = "RELOGON;" + C.UserName + ";" + C.Password;
                DHuy.AddCommand(SESSION_ID, cmd);
            }
        }
        private void REMOVE_WALLPAPER_Click(object sender, EventArgs e)
        {

            string cmd = "REMOVE_WALLPAPER;";
            DHuy.AddCommand(SESSION_ID, cmd);
            
        }
        private void DISABLE_AREO_Click(object sender, EventArgs e)
        {

            string cmd = "DISABLE_AREO;";
            DHuy.AddCommand(SESSION_ID, cmd);
            
        }
        private void RESTART_Click(object sender, EventArgs e)
        {
            string cmd = "RESTART_WINDOW;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void SHUTDOWN_Click(object sender, EventArgs e)
        {
            string cmd = "SHUTDOWN_WINDOW;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void cmsLock_Click(object sender, EventArgs e)
        {
            string cmd = "LOCK_WORKSTATION;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }

        private void LOCK_PERSONAL_Click(object sender, EventArgs e)
        {
            string cmd = "LOCK_PERSONAL;";  //Personal Lock
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void LOG_OFF_WINDOW_Click(object sender, EventArgs e)
        {
            string cmd = "LOGOFF_WINDOW;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void cmsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RUN_EXPLORER_Click(object sender, EventArgs e)
        {
            string cmd = "RUN_EXPLORER;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void cmsTaskManager_Click(object sender, EventArgs e)
        {
            string cmd = "RUN_TASK_MANAGER;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void edtCompress_Click(object sender, EventArgs e)
        {
            int value = CompressMode == 0 ? 1 : 0;
            string cmd = "COMPRESSMODE;" + value; 
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void TOOGLE_FRAG_MODE_Click(object sender, EventArgs e)
        {
            int value = FragMode == 0 ? 1 : 0;
            string cmd = "FRAGMODE;" + value; 
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void TOOGLE_MIRROR_DRIVER_Click(object sender, EventArgs e)
        {
            int value = useMirroDriver == 0 ? 1 : 0;
            string cmd = "MIRROR_DRIVER_TOOGLE;" + value;
            DHuy.AddCommand(SESSION_ID, cmd);
        }

        private void cmsCMD_Click(object sender, EventArgs e)
        {
          

            RunCMD R = new RunCMD();
            R.Location = this.Location;
            R.SESSION_ID = SESSION_ID;
            R.REMOTE_ID = REMOTE_ID;
            R.CONTROL_ID = CONTROL_ID;
            R.Show();

        }

        private void APP_DOWNLOAD_Click(object sender, EventArgs e)
        {
            string appname = ((ToolStripMenuItem)sender).Tag.ToString();
            string cmd = "APP_DOWNLOAD;" + appname;
            DHuy.AddCommand(SESSION_ID, cmd);
        }
        private void RELOAD_MIRRO_DRIVER_Click(object sender, EventArgs e)
        {

            string cmd = "RELOAD_MIRROR_DRIVER;";
            DHuy.AddCommand(SESSION_ID, cmd);
        }

       


    }
}
