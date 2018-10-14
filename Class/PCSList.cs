using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class PCSList : Form
    {
        DataTable dt = new DataTable();
        public PCSList()
        {
            InitializeComponent();
        }

        private void PCSList_Load(object sender, EventArgs e)
        {
           dt=   DHuy.SELECT_SQL("SELECT TOP 2000 * FROM PCS ORDER BY ID DESC ");
           dgv.DataSource = dt;
           dgv.AutoGenerateColumns = false;
           dgv.AutoResizeColumns();
        }
    }
}
