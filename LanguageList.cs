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
    public partial class LanguageList : Form
    {
        DataTable dt = new DataTable();
        public Image I = null;

        BackgroundWorker W1 = new BackgroundWorker();

        public LanguageList()
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
         
            try
            {
                dt = DHuy.SELECT_SQL("SELECT * FROM LANGUAGE");
                DBase.AddColumn(dt,"ICON",typeof(Image));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DBase.SetValue(dt, i, "ICON", Properties.Resources.Trans16);
                }
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
            APPNAME = DBase.StringReturn( dgv.SelectedRows[0].Cells["colCODE"].Value) + "-"+DBase.StringReturn(dgv.SelectedRows[0].Cells["colNAME"].Value);
     
            if (APPNAME != "")
            {
                Res = 1;
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
