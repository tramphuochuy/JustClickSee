using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GB
{
    public partial class ProcessList : Form
    {
        DataTable dt = new DataTable();
        public Image I = null;

        BackgroundWorker W1 = new BackgroundWorker();

        public ProcessList()
        {
            InitializeComponent();

            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGLoading);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGLoading_Complete);


            DBase.AddColumn(dt, "ICON", typeof(Image));
            DBase.AddColumn(dt, "APPNAME");
            DBase.AddColumn(dt, "PATH");
            dgv.AutoGenerateColumns = false;
        }

        int isbusy = 0;
        public void RefreshData()
        {
            if (isbusy == 0)
            {
                GIF.Location = this.Location;
                GIF.BringToFront();
                GIF.Visible = true;
                GIF.Dock = DockStyle.Fill;
               
                W1.RunWorkerAsync();
            }
        }
        private void ProcessList_Load(object sender, EventArgs e)
        {
            RefreshData();
          

        }


        private void BGLoading(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Process[] PList = Process.GetProcesses();
            DataTable dt2 = DWindow.UseWMIToGetProcesses();
            dt.Clear();
            try
            {
                foreach (Process p in PList)
                {
                    if (p.MainWindowTitle.Length <= 0) continue;
                    string username = p.StartInfo.EnvironmentVariables["username"].ToString();
                    string processname = p.ProcessName;
                    Icon I = null;
                    DataTable dtf = DBase.FilterTable(dt2, "ProcessId = '" + p.Id + "'");
                    if (dtf.Rows.Count > 0)
                    {
                        try
                        {
                            string PATH = DBase.StringReturn(dtf, 0, "ExecutablePath");
                            DataRow dr = dt.NewRow();
                            dr["PATH"] = PATH;
                            I = Icon.ExtractAssociatedIcon(PATH);
                            dr["ICON"] = I.ToBitmap();
                            dr["APPNAME"] = processname;
                            dt.Rows.Add(dr);
                        }
                        catch (Exception) { }
                    }
                }

                dt = DBase.SortTable(dt, "APPNAME");
            }
            catch (Exception) { }
            finally
            {
               
             
            }
        } //Action
        private void BGLoading_Complete(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dgv.DataSource = dt;
            GIF.Visible = false;
            //if (this.SizeChanged) ProcessList_SizeChanged(null, null);
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessList_Load(null, null);
        }

        public string APPNAME = "";
        public int Res = 0;
        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            APPNAME = DBase.StringReturn( dgv.SelectedRows[0].Cells["colAPPNAME"].Value);
            
            if (APPNAME != "")
            {
                Res = 1;
                try
                {
                    I = (Image)dgv.SelectedRows[0].Cells["colICON"].Value;
                   
                }
                catch (Exception) { }

                this.Close();
            }
        }

        private void ProcessList_SizeChanged(object sender, EventArgs e)
        {
            //if (dgv.Controls.OfType<VScrollBar>().First().Visible)
            //{
            //    this.Height = Height + 10;
            //}
            //else
            //{
            //    this.SizeChanged -= ProcessList_SizeChanged;
            //}
        }

    }
}
