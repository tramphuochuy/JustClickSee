using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;




namespace GB
{
    public partial class Popup : UserControl
    {
        public string key = "";
        public string[] keyCompare;
        public string res = "";
        DataTable temp = new DataTable();
        public int isShow = 0;
        public int RowIndex = 0;

        DataTable dtInventory = new DataTable();

       

        public TextBox T = null;



        public Popup()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = false;

        }

        private void FilterPopup_Load(object sender, EventArgs e)
        {

        }

        public void Next()
        {
            try
            {
                dgv.Rows[dgv.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex) { }

        }
        public void Previous()
        {
            try
            {
                dgv.Rows[dgv.SelectedRows[0].Index - 1].Selected = true;
            }
            catch (Exception ex) { }


        }
        public void UpdateIcon(DataTable dt)
        {
            DBase.AddColumn(dt, "ICON", typeof(Image));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              //  DBase.SetValue(dt, i, "ICON", Properties.Resources.RemoveBlack);
            }
        }
        private void edtKey_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (edtKey.Text == "" || edtKey.Text.Length > 10)
                {
                    this.Visible = false;
                    return;
                }

                if (edtKey.Text == " ")
                {
                    temp = DBase.DTADDRESS;
                    dgv.DataSource = temp;
                    return;
                }
                edtKey.SelectionLength = 0;
                edtKey.SelectionStart = edtKey.Text.Length;
                string filter = "URL like '%" + edtKey.Text.Trim() + "%'";

                DataRow[] drs = DBase.DTADDRESS.Select(filter);
                if (drs.Length == 0)
                {
                    temp = new DataTable();
                    this.Visible = false;
                }
                else
                {
                    // temp = drs.CopyToDataTable();
                }

            }
            catch (Exception ex)
            {
                temp = new DataTable();
            }
            finally
            {

                //temp = DBase.TopRowTable(temp, 5);
                this.Height = temp.Rows.Count * dgv.RowTemplate.Height + 20;
                //temp = DBase.SortTable(temp, "URLLEN ASC");
                UpdateIcon(temp);
                dgv.DataSource = temp;
                if (temp.Rows.Count == 0) this.Visible = false;

            }
        }

        public void FilterPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                res = "";
                try
                {
                    res = DBase.StringReturn(dgv.SelectedRows[0].Cells["COLURL"].Value);

                }
                catch (Exception ex)
                {

                }



                this.Hide();
                if (e != null) e.Cancel = true;
                isShow = 0;
            }
            catch (Exception ex) { }
        }
        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgv.Rows[e.RowIndex].Selected = true;
        }

        //SAVE
        public void SELECT_CLICK(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                res = DBase.StringReturn(dgv.SelectedRows[0].Cells["COLURL"].Value);
                dgv.Focus();
                Visible = false;
                //Z.AcceptInput(res, T);
            }
            catch (Exception) { };
        }

        private void FilterPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //     this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                SELECT_CLICK(null, null);
                //   this.Close();
            }

            if (e.KeyCode == Keys.Down)
            {
                Next();
            }

            if (e.KeyCode == Keys.Up)
            {
                Next();
            }

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string COL = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (COL == "ICON")
                {
                    string ID = DBase.StringReturn(dgv.SelectedRows[0].Cells["COLID"].Value);
                    DHuy.RUN_SQL("DELETE WEBBOOK WHERE ID = "+ ID +"");
                    temp = DBase.FilterTable(temp, "ID <> " + ID);
                    DBase.DTADDRESS = DBase.FilterTable(DBase.DTADDRESS, "ID <> " + ID);
                }
                else
                {
                    res = DBase.StringReturn(dgv.SelectedRows[0].Cells["COLURL"].Value);
                    dgv.Focus();
                    Visible = false;
                    //Z.AcceptInput(res, T);
                }
            }
            catch (Exception) { };
        }

    }
}
