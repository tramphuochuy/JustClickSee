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
    public partial class FileDownload : Form
    {
        BackgroundWorker W1;
        public int Res = 0;
      
        public DataTable dt = new DataTable();
        public FileInfo Finfo = null;
        public int kq = 0;
        public int isClose = 0;
        public string FileName = "";

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Load
        public FileDownload(String filename)
        {
            InitializeComponent();
            Text = filename;
            FileName = filename;
            edtFileName.Text = FileName;
            W1 = new BackgroundWorker();
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted1);
           
        }
        private void FileTransfer_Process_Load(object sender, EventArgs e)
        {
            try
            {
               
                    W1.RunWorkerAsync();
              
            }
            catch (Exception ex) { }
        }


      
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        
            try
            {
                DHuy.CheckAndUpdateFile(FileName,true);
           
            }
            catch (Exception ex) { }

        }
        private void bgw_RunWorkerCompleted1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
                System.Diagnostics.Process.Start(DBase.DataFolderPath + "\\"+ FileName);
                isClose = 1;
                this.Close();
        }
        private void TIMER_STATUS_Tick(object sender, EventArgs e)
        {
            if (isClose == 1) this.Close();
            try
            {
              
                
            }
            catch (Exception ex) { }
        }



       
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
