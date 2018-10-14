using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class PCS_Detail : Form
    {

        public int Res = 0;
        public string USERCODE = "";
        public string PASSWORD = "";
        public int isUpdate = 0;
        public int ID = 0;
        public string PCS_ID;
        public string PCS_ID_FROMMAIN = "";

        public PCS_Detail()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            if (isUpdate == 0)
            {
                if (PCS_ID_FROMMAIN != "")
                {
                    edtPCS_ID.Text = PCS_ID_FROMMAIN;
                    this.ActiveControl = edtPCS_NAME;
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            DataTable dt = DHuy.SELECT_NEWROW("USER_PCS");
            dt.Rows[0]["ID"] = ID;
            dt.Rows[0]["USERCODE"] = USERCODE;
            dt.Rows[0]["PCS_ID"] = edtPCS_ID.Text;
            dt.Rows[0]["PASS"] = edtPass.Text;
            if (edtPass.Text == "") dt.Rows[0]["PASS"] = "";
            else dt.Rows[0]["PASS"] =  DHuy.HideFood(edtPass.Text, "ForTheWin", new byte[256]);
            dt.Rows[0]["PCS_NAME"] = edtPCS_NAME.Text;

            int kq = 0;
            if (isUpdate == 0)
            {
                kq = DHuy.INSERT_IDENTITY("USER_PCS", dt);
               
            }
            else
            {
                if( ID > 0)   kq = DHuy.UPDATE("USER_PCS", dt,"ID");
            }

            if (kq > 0)
            {
                Res = 1;
                // MessageBox.Show("Saved!");
                this.Close();
            }
        }
        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            edtPCS_ID.Text = PCS_ID.ToString();
            edtPCS_NAME.Text = Environment.MachineName;
        }

        private void edtPCS_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save_Click(null, null);
            }
        }
    }
}
