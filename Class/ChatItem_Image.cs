using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GB
{

    public partial class ChatItem_Image : UserControl
    {
        public int ID = 0;
        public string Text = "";
        public string Head = "";
        public Chat M = null;
        public string ColorString = "";
        
        public Color color1 = Color.White;
        //public Color color2 = Color.Pink;
        public Color color2 = Color.Honeydew;

        public List<Color> L = new List<Color>();
        static Random rnd = new Random();
        public Image I = null;

        public ChatItem_Image()
        {
            InitializeComponent();
           
            L.Add(color1);
            L.Add(color2);
        
        }

        public ChatItem_Image(Image I , string filename)
        {
            InitializeComponent();

            edtPic.Image = I;
            edtUserCode.Text = filename;
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
          
        }
        private void cmsCut_Click(object sender, EventArgs e)
        {
           
        }
        private void cmsCopy_Click(object sender, EventArgs e)
        {
          
        }

        private void cmsRefresh_Click(object sender, EventArgs e)
        {
            M.RefreshChat();
        }

        private void RED_Click(object sender, EventArgs e)
        {
            ColorString = "RED";
            DHuy.RUN_SQL("UPDATE CHAT SET COLOR = '" + ColorString + "' WHERE ID = " + ID);
        }

        private void GREEN_Click(object sender, EventArgs e)
        {
            ColorString = "GREEN";
            DHuy.RUN_SQL("UPDATE CHAT SET COLOR = '" + ColorString + "' WHERE ID = " + ID);
        }

        private void CLEARMARK_Click(object sender, EventArgs e)
        {
            ColorString = "";
            DHuy.RUN_SQL("UPDATE CHAT SET COLOR = '" + ColorString + "' WHERE ID = " + ID);
        }

        private void edtPic_Click(object sender, EventArgs e)
        {
           DataTable dtd =  DHuy.SELECT_SQL( "SELECT FILEDATA,FILENAME FROM Chat WHERE ID = "+ ID);
           string filename = DBase.StringReturn( dtd.Rows[0]["FILENAME"]);
           byte[] Data = (byte[])dtd.Rows[0]["FILEDATA"];
           String SaveFile = Application.StartupPath + "\\" + filename;
           File.WriteAllBytes(SaveFile,Data);
           try
           {
               System.Diagnostics.Process.Start(SaveFile);
           }
           catch (Exception ex) { }
        }

      
        private void edtPic_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void ChatItem_Image_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
