using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GB
{
    public partial class CODER : Form
    {
        DataTable dt = new DataTable();
        int isbusy = 0;
        string SearchKey = "";
        bool LoadAll = false;

        BackgroundWorker W1;
        public string ID = "";
        public string KEYCOL ="ID" ; 
        public string colKEYCOL ="colID" ; 
        public string TableName = "CODER";
        public CODER()
        {
            InitializeComponent();
            GIF.Location = dgv.Location;
            GIF.Size = dgv.Size;
            W1 = new BackgroundWorker();
            this.W1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.W1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted1);
          
        }

        public void Refresh()
        {
           if (isbusy == 0)
            {
                GIF.Visible = true;
                W1.RunWorkerAsync();
            }

        }

        public void RefreshSelect()
        {
            try
            {
            string ID = DBase.StringReturn(dgv.SelectedRows[0].Cells[colKEYCOL].Value);
            DataTable temp = DHuy.SELECT(TableName,KEYCOL, ID.ToString());
            if (dt != null)
            {
                try
                {
                    DBase.TablePropertyRemove(dt);
                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt.Rows[d][KEYCOL].ToString() == ID.ToString())
                        {
                            dt.Rows[d].ItemArray = temp.Rows[0].ItemArray;
                            break;
                        }
                    }
                   
                }
                catch (Exception ex) { }
            }
            }
            catch (Exception ex) { }
        }

       public void RefreshInsert(string ID)
        {
            try
            {
                DataTable temp = DHuy.SELECT(TableName, KEYCOL, ID.ToString());
                if (dt != null)
                {
                    try
                    {
                        DBase.TablePropertyRemove(dt);
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = temp.Rows[0].ItemArray;
                        dt.Rows.Add(dr);
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }
        }
        private void Sample_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            isbusy = 1;
            try
            {
                if (LoadAll == true) dt = DHuy.SELECT_SQL("SELECT  * FROM " + TableName );
                else dt = DHuy.SELECT_SQL("SELECT Top 300 *  FROM " +  TableName );
            }
            catch (Exception ex)
            {

                //    MessageBox.Show(ex.ToString()); 

            }

        }
        private void bgw_RunWorkerCompleted1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            isbusy = 0;
            try
            {
                dgv.DataSource = dt;
                GIF.Visible = false;
                if(dt.Rows.Count < 1000) dgv.AutoResizeColumns();
              
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }



        private void Insert_Click(object sender, EventArgs e)
        {
            CODER_DETAIL P = new CODER_DETAIL();
            P.KEYCOL = KEYCOL;
            P.Icon = DBase.CreateIcon(btnAdd.Image);
            P.Parent = this;
            P.ShowDialog();
            if (P.res == 1)
            {
                Refresh();
            }
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
             {
                string keyvalue = DBase.StringReturn(dgv.SelectedRows[0].Cells[colKEYCOL].Value);

                if ( keyvalue != "")
                {
                    CODER_DETAIL P = new CODER_DETAIL();
                    P.ID = keyvalue;
                    P.Parent = this;
                    P.KEYCOL = KEYCOL;
                    P.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmsClone_Click(object sender, EventArgs e)
        {
            try
            {
                string keyvalue = DBase.StringReturn(dgv.SelectedRows[0].Cells[colKEYCOL].Value);
              
                if (keyvalue != "")
                {
                    CODER_DETAIL P = new CODER_DETAIL();
                    P.ID = keyvalue;
                    P.Clone = 1;
                    P.Parent = this;
                    P.KEYCOL = KEYCOL;
                    P.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            String DeleteString = "";
            int kq = 0;
             try
            {
                
                 DataGridViewSelectedRowCollection array = dgv.SelectedRows;

                 if (MessageBox.Show("Delete " + array.Count.ToString() + " Data ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                        foreach (DataGridViewRow dr in array)
                        {
                            string keyvalue = DBase.StringReturn(dr.Cells[colKEYCOL].Value);
                            if (keyvalue != "")
                            {
                               int res = DHuy.DELETE(TableName, KEYCOL, keyvalue);
                               if (res > 0) 
                                {
                                        kq++;
                                        DeleteString = DeleteString + ",'" + keyvalue + "'";
                                }
                            }
                        }
                    }

                
            }
            catch (Exception ex) {}
            if ( kq > 0 ) 
            {
                DeleteString = DeleteString.Substring(1,DeleteString.Length-1);
                var rows = dt.Select(KEYCOL +" IN (" + DeleteString + ")");
                foreach (var row in rows)   row.Delete();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            Edit_Click(null, null);
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string clip = dgv.SelectedCells[0].Value.ToString();
                Clipboard.SetText(clip);

            }
            catch (Exception)
            {

            }
        }

       private void Export_Click(object sender, EventArgs e)
        {
       
          //  DBase.ExportExcel_Xlsx(dgvView,TableName + ".xlsx");
        }


   


        

      
    }
}

