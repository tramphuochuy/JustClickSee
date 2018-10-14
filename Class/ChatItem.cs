using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{

    public partial class ChatItem : UserControl
    {
        public int ID = 0;
        public string Text = "";
        public string Head = "";
        public Chat M = null;

        
        public Color color1 = Color.Honeydew;
        //public Color color2 = Color.Pink;
        public Color color2 = Color.PowderBlue;

        public List<Color> L = new List<Color>();
        static Random rnd = new Random();

        public ChatItem()
        {
            InitializeComponent();
            edtText.AutoSize = true;
            L.Add(color1);
            L.Add(color2);
        
        }

        public Color NextColor()
        {
            int r = rnd.Next(L.Count);
            return L[r];
        }

        private void cmsDeletePCS_Click(object sender, EventArgs e)
        {
            int kq = DHuy.RUN_SQL("DELETE CHAT WHERE ID =" + ID);
            if (kq > 0) M.RefreshChat();
        }
        private void ChatItem_SizeChanged(object sender, EventArgs e)
        {
          //  edtText.MaximumSize = new Size(this.Width, 0);
        }
        public void edtText_TextChanged(object sender, EventArgs e)
        {
            const int padding = 3;
            int numLines = edtText.GetLineFromCharIndex(edtText.TextLength) + 1;
            int border = edtText.Height - edtText.ClientSize.Height;
            Height = edtText.Font.Height * numLines + padding + border;

        }
        private void cmsCut_Click(object sender, EventArgs e)
        {
            edtText.Cut();
        }
        private void cmsCopy_Click(object sender, EventArgs e)
        {
            edtText.Copy();
        }

        private void cmsRefresh_Click(object sender, EventArgs e)
        {
            M.RefreshChat();
        }
    }
}
