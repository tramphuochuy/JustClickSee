using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class BundleConfig : Form
    {
        public int PCS_ID = 0;
        public int ID = 0;
        public string UserCode = "";
        public ZPCT M = null;
        public BundleConfig()
        {
            InitializeComponent();
        }

        private void BundleConfig_Load(object sender, EventArgs e)
        {
            DataTable dtcheck = DHuy.SELECT_SQL("SELECT * FROM USER_PCS WHERE ID = " + ID + "");
            String bundleString = DBase.StringReturn(dtcheck.Rows[0]["BUNDLESTRING"]);
            PCS_ID = DBase.IntReturn(dtcheck.Rows[0]["PCS_ID"]);
            edtPCS_ID.Text = PCS_ID.ToString();
            edtBundleList.Text = bundleString;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int kq = DHuy.RUN_SQL("UPDATE USER_PCS SET BUNDLESTRING= '" + edtBundleList.Text + "' WHERE ID = " + ID);
            if (kq > 0)
            {
                if (M != null) M.RefreshPCS();
                M.panRight.Visible = true;
                this.Close();
            }
        }
    }
}
