using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace GB
{
    public partial class FileTransfer : Form
    {
        public DataTable dt = new DataTable();
        public int SelectedID = 0;
        public int SelectedID_REMOTE = 0;

        public DataTable[] dtlist;

        public string HerePath = "Home";
        public string HereLastPath = "Home";
        public string RemotePath = "Home";
        public string HereLastRemotePath = "Home";

        public string HereFile = "";
        public string RemoteFile = "";

        public int RemoteFileIsFolder = 0;
        public int RemoteFileSize = 0;
        string Remote_File_MD5 = "";

        DriveInfo[] Drives;
        String[] PathList;
        public int SESSION_TRANS_ID = 0;
        public DataTable dremote = new DataTable("Data");
        int kq = 0;
        public int CONTROL_ID = 0;
        public int REMOTE_ID = 0;


        public FileTransfer()
        {
            InitializeComponent();
            try
            {
                Drives = DriveInfo.GetDrives();
            }
            catch (Exception ex)
            {
            }
          
        }
        public FileTransfer( int CID , int RID , string FilePath)
        {
            InitializeComponent();
            try
            {
                DataTable dti = DHuy.SELECT_NEWROW("FILE_TRANSFER");
                String key = DBase.biDateTimeSave(DateTime.Now);
                dti.Rows[0]["ID"] = 0;
                dti.Rows[0]["DATA"] = new byte[3];
                dti.Rows[0]["FILE_DATA"] = new byte[3];
                dti.Rows[0]["CONTROL_ID"] = CID;
                dti.Rows[0]["REMOTE_ID"] = RID;
                dti.Rows[0]["MD5"] = key;
                kq = DHuy.INSERT_IDENTITY_UID("FILE_TRANSFER", dti);
                DataTable temp = DHuy.SELECT_SQL("SELECT * FROM FILE_TRANSFER WHERE MD5 = '" + key + "'");
                SESSION_TRANS_ID = DBase.IntReturn(temp.Rows[0]["ID"]);
                

                REMOTE_ID = RID;
                CONTROL_ID = CID;


                FileTransfer_Process P = new FileTransfer_Process();
                P.isSend = 1;
                P.dt = temp;
                P.Here_File = FilePath;
                P.Remote_File = "Home";
                P.SESSION_TRANS_ID = SESSION_TRANS_ID;
                P.F = this;
                P.StartPosition = FormStartPosition.CenterParent;
                P.Show(this);
                //this.Close();

            }
            catch (Exception ex)
            {

            }

        }

        private void FileExplorer_Load(object sender, EventArgs e)
        {
            try
            {
                kq = DHuy.AddCommand_Trans(SESSION_TRANS_ID, "FILE_TRANSFER_INIT;" + SESSION_TRANS_ID);
                HOME1_Click(null, null);
                timer1.Start();
                this.Text = "Session : " + SESSION_TRANS_ID + " - " + CONTROL_ID + " --> " + REMOTE_ID;
            }
            catch (Exception ex) { }
        }

        private void HOME1_Click(object sender, EventArgs e)
        {
            HerePath = "Home";
            REFRESH1();
        }
        private void HOME2_Click(object sender, EventArgs e)
        {
            DHuy.AddCommand_Trans(SESSION_TRANS_ID, "FILE_TRANSFER_INIT;" + SESSION_TRANS_ID);
        }

        public void REFRESH1()
        {
            try
            {
                edtFilePath.Text = HerePath;
                if (HerePath == "Home")
                {
                    panContent1.Controls.Clear();
                    int ID = 1;
                    foreach (DriveInfo d in Drives)
                    {
                        if (d.IsReady)
                        {
                            FileItem F = new FileItem("Hardisk");
                            F.ID = ID;
                            F.PATH = d.Name;
                            F.isFolder = 1;
                            F.Width = panContent1.Width - 2;
                            ID++;
                            F.lbText.Text = d.Name;
                            F.lbSize.Text = d.TotalSize / 1000000000 + " Gb";
                            F.F = this;
                            panContent1.Controls.Add(F);
                        }
                    }

                    FileItem F1 = new FileItem("Desktop");
                    F1.ID = ID;
                  
                    ID++;
                    F1.PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    F1.isFolder = 1;
                    F1.Width = panContent1.Width - 2;
                    ID++;
                    F1.lbText.Text = "Desktop";
                    F1.lbSize.Text = "";
                    F1.F = this;
                    panContent1.Controls.Add(F1);

                }

                else
                {
                     //Directory search return exception if folder is unacess
                    string[] filePaths = Directory.GetDirectories(HerePath, "*", SearchOption.TopDirectoryOnly);
                    panContent1.Controls.Clear();
                    int ID = 1;
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        FileInfo info = new FileInfo(path);
                        FileItem F = new FileItem("Folder");
                        F.ID = ID;
                        ID++;
                        F.PATH = path;
                        F.Width = panContent1.Width - 2;
                        F.isFolder = 1;
                        F.lbText.Text = info.Name.Length > 23 ? info.Name.Substring(0, 20) + "..." : info.Name;
                        F.lbSize.Text = "Folder";
                        F.F = this;
                        panContent1.Controls.Add(F);

                    }

                    //File
                    filePaths = Directory.GetFiles(HerePath, "*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        FileInfo info = new FileInfo(path);
                        FileItem F = new FileItem(info.Extension.ToLower(),true);
                        F.ID = ID;
                        ID++;
                        F.PATH = path;
                        F.Width = panContent1.Width - 2;
                        F.isFolder = 0;
                  
                        //if (info.Extension.ToLower() == ".exe") F.SetSystemIcon(".exe");
                        //if (info.Extension.ToLower() == ".png") F.SetIcon("PNG");
                        //if (info.Extension.ToLower() == ".txt" | info.Extension.ToLower() == ".docx") F.SetIcon("TXT");
                        //if (info.Extension.ToLower() == ".dll") F.SetIcon("DLL");
                        //if (info.Extension.ToLower() == ".ini") F.SetIcon("INI");
                        //if (info.Extension.ToLower() == ".mp3" | info.Extension.ToLower() == ".wav") F.SetIcon("MP3");
                        //if (info.Extension.ToLower() == ".mp4" | info.Extension.ToLower() == ".mkv" | info.Extension.ToLower() == ".flv") F.SetIcon("VIDEO");
                        //if (info.Extension.ToLower() == "") F.SetIcon("NULL");
                        //if (info.Extension.ToLower() == ".bat") F.SetIcon("BAT");
                        //if (info.Extension.ToLower() == ".xls" | info.Extension.ToLower() == ".xlsx") F.SetIcon("EXCEL");

                        F.lbText.Text = info.Name.Length > 23 ? info.Name.Substring(0, 20) + "..." : info.Name;
                        F.lbSize.Text = info.Length / 1024 + " Kb";
                        if (info.Length / 1024 == 0)
                        {
                            F.lbSize.Text = info.Length + " byte";
                            F.lbSize.ForeColor = Color.Gray;
                        }
                        if (info.Length / 1024 > 1024)
                        {
                            F.lbSize.Text = DBase.Deci2((decimal)info.Length / 1024 / 1024) + " Mb";
                            F.lbSize.ForeColor = F.lbText.ForeColor = Color.Black;
                        }
                        if (info.Length / 1024 > 1024 * 1024)
                        {
                            F.lbSize.Text = DBase.Deci2((decimal)info.Length / 1024 / 1024 / 1024) + " Gb";
                            F.lbSize.ForeColor = F.lbText.ForeColor = Color.DarkBlue;
                        }
                        F.F = this;
                        panContent1.Controls.Add(F);

                    }




                }
            }
            catch (Exception ex) 
            {

                HerePath = HereLastPath;
            }
        }
        public void REFRESH2()
        {
            try
            {
                dremote.Clear();
                try
                {
                    dremote.ReadXml(DBase.XmlRemote_File);
                    if (dremote.Rows.Count == 0)
                    {
                        int x = 0;
                        int y = 3 / x;
                    }
                }
                catch (Exception ex)
                {
                    dremote = new DataTable("Data");
                    dremote.Columns.Add("ICON", typeof(String));
                    dremote.Columns.Add("NAME", typeof(String));
                    dremote.Columns.Add("PATH", typeof(String));
                    dremote.Columns.Add("SIZE", typeof(String));
                    dremote.Columns.Add("EXTENSION", typeof(String));
                    dremote.Columns.Add("ISFOLDER", typeof(String));
                    dremote.Columns.Add("FILESIZE", typeof(String));
                    String S = DBase.ReadFile(DBase.XmlRemote_File);
                    var r = System.Xml.XmlReader.Create(new System.IO.StringReader(S));
                    
                    try
                    {
                        while (r.Read())
                        {
                            if (r.NodeType == XmlNodeType.Element && r.LocalName == "DATA")
                            {
                                string icon = r.GetAttribute("ICON");
                                string NAME = r.GetAttribute("NAME");
                                string PATH = r.GetAttribute("PATH");
                                string SIZE = r.GetAttribute("SIZE");
                                string EXTENSION = r.GetAttribute("EXTENSION");
                                string ISFOLDER = r.GetAttribute("ISFOLDER");

                                DataRow dr = dremote.NewRow();
                                dr["ICON"] = r.GetAttribute("ICON");
                                dr["NAME"] = r.GetAttribute("NAME");
                                dr["PATH"] = r.GetAttribute("PATH");
                                dr["SIZE"] = r.GetAttribute("SIZE");
                                dr["FILESIZE"] = r.GetAttribute("FILESIZE");
                                dr["EXTENSION"] = r.GetAttribute("EXTENSION");
                                dr["ISFOLDER"] = r.GetAttribute("ISFOLDER");
                                dremote.Rows.Add(dr);
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                    }
                   
                }
                panContent2.Controls.Clear();
                int ID = 1000000;

                foreach (DataRow dr in dremote.Rows)
                {
                    string icon = DBase.StringReturn(dr["ICON"]);
                    string extension = DBase.StringReturn(dr["EXTENSION"]);

                    FileItem F = new FileItem(icon);
                    if ( icon == "" ) F=  new FileItem(extension,true);
                    F.ID = ID;
                    F.isRemote = 1;
                    ID++;
                    F.PATH = DBase.StringReturn(dr["PATH"]);
                    F.Width = panContent1.Width - 2;
                    F.isFolder = DBase.IntReturn(dr["ISFOLDER"]);
                    String filename = DBase.StringReturn(dr["NAME"]);
                    if (filename.Length > 30)
                    {
                        filename = filename.Substring(0, 30);
                    }
                    F.lbText.Text = filename;
                  
                    F.lbSize.Text = DBase.StringReturn(dr["SIZE"]);
                    F.FileSize = DBase.IntReturn(dr["FILESIZE"]);
                    F.SIZE = DBase.StringReturn(dr["SIZE"]);
                    F.F = this;
                    panContent2.Controls.Add(F);

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ItemSelectRefresh()
        {
            foreach (FileItem F in panContent1.Controls)
            {
                if (F.ID == SelectedID)
                {
                    F.BackColor = Color.LightBlue;
                    HerePath = F.PATH;
                    HereFile = F.FILE;
                }
                else F.BackColor = Color.White;
            }
        }
        public void ItemSelectRefresh2()
        {
            foreach (FileItem F in panContent2.Controls)
            {
                if (F.ID == SelectedID_REMOTE) F.BackColor = Color.LightBlue;
                else F.BackColor = Color.White;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (HerePath == "Home") return;
            DirectoryInfo d = Directory.GetParent(HerePath);
            if (d == null) HerePath = "Home";
            else HerePath = d.ToString();
            REFRESH1();
        }
        private void UP2_Click(object sender, EventArgs e)
        {
            DHuy.AddCommand_Trans(SESSION_TRANS_ID, "FILE_TRANSFER_FOLDER_UP;" + SESSION_TRANS_ID + ";" + RemotePath);
        }
        private void panContents_MouseEnter(object sender, EventArgs e)
        {
            panContent1.Focus();
        }
        private void panContent2_MouseEnter(object sender, EventArgs e)
        {
            panContent2.Focus();
        }

        private void FileTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DHuy.RUN_SQL("DELETE FILE_TRANSFER WHERE ID =" + SESSION_TRANS_ID );
        }

        //SEND/RECEIVE
        private void SEND(object sender, EventArgs e)
        {
            DataTable dt= DHuy.SELECT_SQL("SELECT * FROM FILE_TRANSFER WHERE ID = " + SESSION_TRANS_ID );
            if (DBase.IsFolder(HerePath) == 1) return;
       
            if (dt.Rows.Count > 0)
            {
                FileTransfer_Process P = new FileTransfer_Process();
                P.isSend = 1;
                P.dt = dt;
                P.Here_File = HerePath;
                P.Remote_File = RemotePath;
                P.SESSION_TRANS_ID = SESSION_TRANS_ID;
                P.F = this;
                P.Location = new Point(Location.X + (Width - P.Width) / 2, Location.Y + (Height - P.Height) / 2);
                P.Show();

            }
            else
            {
                Confirm C = new Confirm();
                C.SetColor(Color.LightCoral);
                C.edtText.Text = "Session is expired ! ... Close ? ";
                C.StartPosition = FormStartPosition.Manual;
                C.Location = new Point(Location.X + (Width - C.Width) / 2, Location.Y + (Height - C.Height) / 2);
                C.ShowDialog(this);
                if (C.Res == 1)
                    this.Close();
            }
        }
        private void RECEIVE(object sender, EventArgs e)
        {
            DataTable dt= DHuy.SELECT_SQL("SELECT * FROM FILE_TRANSFER WHERE ID = " + SESSION_TRANS_ID );
            if (RemoteFileIsFolder == 1) return;
            if (RemoteFileSize <= 0 || RemoteFileSize > 50000000 ) return;
            if (dt.Rows.Count > 0)
            {
                FileTransfer_Process P = new FileTransfer_Process();
                P.isSend = 0;
                P.dt = dt;
                P.Here_File = HerePath;
                P.Remote_File = RemotePath;
                P.SESSION_TRANS_ID = SESSION_TRANS_ID;
                P.F = this;
                P.Location = new Point(Location.X + (Width - P.Width) / 2, Location.Y + (Height - P.Height) / 2);
                P.Show();

            }
            else
            {
                Confirm C = new Confirm();
                
                C.SetColor(Color.LightCoral);
                C.edtText.Text = "Session is expired ! ... Close ? ";
                C.StartPosition = FormStartPosition.Manual;
                C.Location = new Point(Location.X + (Width - C.Width) / 2, Location.Y + (Height - C.Height) / 2);
                C.ShowDialog(this);
                if (C.Res == 1)
                    this.Close();
            }
        }

        //TIMER
        private void FILE_TRANSFER_LIST_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable da = DHuy.SELECT_SQL("SELECT MD5 FROM FILE_TRANSFER WHERE ID = " + SESSION_TRANS_ID + " ORDER BY CDATETIME ASC ");
                if (da.Rows.Count > 0)
                {
                    string md5 = DBase.StringReturn(da.Rows[0]["MD5"]);
                    if (md5 != Remote_File_MD5)
                    {
                        Remote_File_MD5 = md5;
                        DHuy.DownloadFile("FILE_TRANSFER", "DATA", "ID", SESSION_TRANS_ID, DBase.XmlRemote_File);
                        REFRESH2();
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void btnUp2_Click(object sender, EventArgs e)
        {

        }

       

    }


    
}
