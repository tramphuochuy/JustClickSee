using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using GB.Properties;

namespace GB
{
    public partial class FileItem : UserControl
    {
        public string ICON = "";
        public int ID = 0;
        public string NAME = "";
        public string SIZE = "";
        public int FileSize = 0;
        public string PATH = "";
        public string FILE = "";
        public int isSelect = 0;
        public int isFolder = 0;
        public FileTransfer F = null;
        public int isRemote = 0;

        public FileItem()
        {
            InitializeComponent();
        }
        public FileItem( String Icon)
        {
            ICON = Icon;
            InitializeComponent();
            lbIcon.Image = (Image)Resources.ResourceManager.GetObject(ICON);
            Refresh();
        }

        public FileItem(String FileTypeWihthDot, bool UseSystemIcon)
        {
            InitializeComponent();
            lbIcon.Image = IconReader.GetFileIcon(FileTypeWihthDot, IconReader.IconSize.Small, false).ToBitmap();
            Refresh();
        }

        public void Select()
        {
            if (isRemote == 0)
            {
                F.SelectedID = ID;
                BackColor = Color.LightBlue;
                F.HerePath = PATH;
                F.edtFilePath.Text = F.HerePath;
                F.ItemSelectRefresh();
            }
            else
            {
                F.SelectedID_REMOTE = ID;
                BackColor = Color.LightBlue;

                F.RemotePath = PATH;
                F.RemoteFileIsFolder = isFolder;
                F.RemoteFileSize = DBase.IntReturn(FileSize);
                F.edtFilePath2.Text = F.RemotePath;
                F.ItemSelectRefresh2();
            }

        }

        public void SetIcon(string icon)
        {
            ICON = icon;
            lbIcon.Image = (Image)Resources.ResourceManager.GetObject(ICON);
            Refresh();
        }


        public void SetSystemIcon(string FileTypeWihthDot)
        {

            lbIcon.Image = IconReader.GetFileIcon(FileTypeWihthDot, IconReader.IconSize.Small, false).ToBitmap();
           // Refresh();
        }

        private void lbText_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void lbText_DoubleClick(object sender, EventArgs e)
        {
            if (isFolder == 1)
            {
                if (isRemote == 0)
                {
                    F.HereLastPath = F.HerePath;
                    F.HerePath = PATH;
                    F.REFRESH1();
                }

                else
                {
                    DHuy.AddCommand_Trans(F.SESSION_TRANS_ID, "FILE_TRANSFER_OPEN;" + F.SESSION_TRANS_ID + ";" + PATH);
                }
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(PATH);
                }
                catch (Exception ex) { }
            }
        }

        private void cmsOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(PATH);
        }
    }
}
