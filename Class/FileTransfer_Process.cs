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
    public partial class FileTransfer_Process : Form
    {
        BackgroundWorker W1;
        public int Res = 0;
        public int SESSION_TRANS_ID = 0;
        public int Status = 0;
        public string TextContents = "";

        public string Here_File = "";
        public float Here_Size =  0;
        public string Here_FileName = "";

        public string Remote_File = "";
        public float Remote_Size = 0;
        public string Remote_FileName = "";

        public FileTransfer F = null;
        public int isSend = 0;
        public DataTable dt = new DataTable();
        public FileInfo Finfo = null;
        public int kq = 0;
        public int isClose = 0;

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Load
        public FileTransfer_Process()
        {
            InitializeComponent();
            W1 = new BackgroundWorker();
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted1);
           
        }
        private void FileTransfer_Process_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (isSend == 1)
                {
                    Finfo = new FileInfo(Here_File);
                    this.Text = Finfo.FullName;
                    Here_FileName = Finfo.Name;
                    edtFileName.Text = (Here_FileName.Length > 23 ? Here_FileName.Substring(0, 20) + "..." : Here_FileName) + "  ( 50Kb/s )";
                    progressBar1.Maximum = (int)Finfo.Length;
                    timer1.Start();
                    W1.RunWorkerAsync();
                }
                else if (isSend == 0)  // Send command to remote for upload
                {
                    string Remote_FileName = Path.GetFileName(Remote_File);
                    edtFileName.Text = (Remote_FileName.Length > 23 ? Remote_FileName.Substring(0, 20) + "..." : Remote_FileName) + "  ( 50Kb/s )";
                    DHuy.AddCommand_Trans(SESSION_TRANS_ID, "FILE_TRANSFER_UPLOAD;" + SESSION_TRANS_ID + ";" + Remote_File);
                    timer1.Start();
                }
            }
            catch (Exception ex) { }
        }


        int isbusy = 0;
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            isbusy = 1;
            try
            {
                if (isSend == 1)
                {
                    byte[] file_data = System.IO.File.ReadAllBytes(Here_File);

                    dt.Rows[0]["FILE_DATA"] = file_data;
                    kq = DHuy.UPDATE("FILE_TRANSFER", dt, "ID", "FILE_DATA");
                    dt.Rows[0]["SEND_STATUS"] = 1;
                    kq = DHuy.UPDATE("FILE_TRANSFER", dt, "ID", "SEND_STATUS");
                    DHuy.AddCommand_Trans(SESSION_TRANS_ID, "FILE_TRANSFER_RECEIVE;" + Remote_File + ";" + Here_FileName);
                }
                else
                {
                    if (Here_File == "Home") Here_File = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    DHuy.DownloadFile("FILE_TRANSFER", "FILE_DATA", "ID", SESSION_TRANS_ID, Here_File + "\\" + Path.GetFileName(Remote_File));
                }
                
            }
            catch (Exception ex) { }

        }
        private void bgw_RunWorkerCompleted1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            isbusy = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Maximum / 2;
            if (isSend == 0)
            {
                DHuy.RUN_SQL("UPDATE FILE_TRANSFER SET SEND_STATUS = 0 , RECEIVE_STATUS=0 WHERE ID = " + SESSION_TRANS_ID);
                isClose = 1;
                this.Close();
            }

        }
        private void TIMER_STATUS_Tick(object sender, EventArgs e)
        {
            if (isClose == 1) this.Close();
            try
            {
                if (isSend == 1) //send
                {
                    DataTable da = DHuy.SELECT_SQL("SELECT SEND_STATUS FROM FILE_TRANSFER WHERE ID = " + SESSION_TRANS_ID + " ORDER BY CDATETIME ASC ");
                    if (da.Rows.Count > 0)
                    {
                        int status = DBase.IntReturn(da.Rows[0]["SEND_STATUS"]);
                        if (status == 2)
                        {
                            
                            DHuy.RUN_SQL("UPDATE FILE_TRANSFER SET SEND_STATUS = 0 , RECEIVE_STATUS=0 WHERE ID = " + SESSION_TRANS_ID);
                            isClose = 1;
                            this.Close();
                            F.TopMost = true;
                        }
                    }
                }

                else if (isSend == 0) //receive
                {
                    DataTable da = DHuy.SELECT_SQL("SELECT RECEIVE_STATUS FROM FILE_TRANSFER WHERE ID = " + SESSION_TRANS_ID + " ORDER BY CDATETIME ASC ");
                    if (da.Rows.Count > 0)
                    {
                        int status = DBase.IntReturn(da.Rows[0]["RECEIVE_STATUS"]);
                        if (status == 1)
                        {
                            timer1.Stop();
                            W1.RunWorkerAsync();
                        }
                    }

                }

            }
            catch (Exception ex) { }
        }



        //Mousedownup
        private void panHead_MouseDown(object sender, MouseEventArgs e)
        {
               timer2.Start();
        }

        private void panHead_MouseUp(object sender, MouseEventArgs e)
        {
            this.Location = Cursor.Position;
            timer2.Stop();
        }

     

    


      
    }
}
