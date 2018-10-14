using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GB
{
    public partial class Chat : Form
    {

        public int PID = 0;
        public string PCID = "";
        public string C = "";
        public int Res = 0;
        public string TextContents = "";
        public string Text = "";
        public DataTable dt = new DataTable();
        public DataTable dtitem = new DataTable();
        public DataTable dtnew = new DataTable();
        public int LastID = 0;
        public bool isAttachMain = true;
        public ZPCT Zmain = null;
        public int MouseSpaceX = 0;
        public int MouseSpaceY = 0;
        public bool isPublic = false;

        public int CONTROL_ID = 0;
        public int REMOTE_ID = 0;

        public int isExit = 0;
        public string Control_Remote = "";

        public Chat()
        {
            InitializeComponent();
       
            panChat.HorizontalScroll.Maximum = 0;
            panChat.AutoScroll = false;
            panChat.VerticalScroll.Visible = false;
            panChat.AutoScroll = true;
        }
        public Chat( bool ispu)
        {
            InitializeComponent();
            if (ispu) isPublic = true;
            
            panChat.HorizontalScroll.Maximum = 0;
            panChat.AutoScroll = false;
            panChat.VerticalScroll.Visible = false;
            panChat.AutoScroll = true;
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            ChatLoad();

            if (Control_Remote != "") Title.Text = "Chat box ( " + Control_Remote + " )";
            else Title.Text = "Public Chat";

            
        }

        public void ChatLoad()
        {
            timer1.Start();
            dtitem = DHuy.SELECT_NEWROW("CHAT");
            ResetInfoID();
            RefreshChat();
            edtChat.Focus();
            this.ActiveControl = edtChat;
        }
        public void ResetInfoID()
        {
            try
            {
                dtitem.Rows[0]["PCS_ID"] = 0;
                dtitem.Rows[0]["NICKNAME"] = Environment.MachineName;
                dtitem.Rows[0]["USERCODE"] = Control_Remote;
             
            }
            catch (Exception ex) { }
        }

        int colorIndex = 0;
        String curNick = "";
        public void RefreshChat()
        {
            dtnew = new DataTable();
            LastID = 0;
            try
            {
                string lastUser = "";
                panChat.Controls.Clear();
                //ChatItem None = new ChatItem();
                //None.BackColor = None.edtText.BackColor = Color.Snow;
                //panChat.Controls.Add(None);
                dt = DHuy.SELECT_SQL("SELECT * FROM CHAT WHERE USERCODE = '" + Control_Remote + "' ORDER BY ID ASC ");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String type = DBase.StringReturn(dt.Rows[i]["TYPE"]);

                    if (type == "")
                    {
                        ChatItem C = new ChatItem();
                        C.Width = panChat.Width;
                        C.M = this;
                        C.ID = DBase.IntReturn(dt.Rows[i]["ID"]);
                        String DataNick = DBase.StringReturn(dt.Rows[i]["NICKNAME"]) + " ";
                        String ColorString = "";
                        String Text = DBase.StringReturn(dt.Rows[i]["TEXT"]);
                        DateTime cdatetime = DBase.DatetimeReturn(dt.Rows[i]["CDATETIME"]);

                        if (curNick == DataNick)
                        {
                            //  C.edtUserCode.ForeColor = C.edtUserCode.BackColor;
                            //  C.edtIcon.Visible = false;
                            ////  else C.edtUserCode.ForeColor = Color.Blue;
                            colorIndex++;
                            //  C.edtIcon.Visible = true;
                            if (colorIndex == C.L.Count) colorIndex = 0;
                            //   C.edtUserCode.ForeColor = Color.Blue;
                        }
                        else
                        {
                            colorIndex++;
                            //  C.edtIcon.Visible = true;
                            if (colorIndex == C.L.Count) colorIndex = 0;
                            //   C.edtUserCode.ForeColor = Color.Blue;
                        }

                        curNick = DataNick;

                        C.BackColor = C.edtText.BackColor = C.L[colorIndex];

                        //   C.edtUserCode.Text = DataNick + ":";
                        C.edtText.Text = DataNick + ": " + Text + "  ( " + cdatetime.ToString("dd/MM HH:mm") + " )";
                        if (ColorString == "RED")
                        {
                            // C.BackColor = Color.Pink;
                            C.edtText.BackColor = Color.Pink;
                        }
                        else if (ColorString == "GREEN")
                        {
                            C.BackColor = Color.Honeydew;
                            C.edtText.BackColor = Color.Honeydew;
                        }

                        panChat.Controls.Add(C);
                    }

                    else if (type.ToUpper() == ".JPG" || type.ToUpper() == ".BMP" || type.ToUpper() == ".PNG" || type.ToUpper() == ".GIF")
                    {
                        try
                        {
                            String FileName = DBase.StringReturn(dt.Rows[i]["FILENAME"]);
                            Image I = DBase.ByteToImage((byte[])dt.Rows[i]["THUMBNAIL"]);
                            ChatItem_Image C = new ChatItem_Image(I, FileName);

                            C.M = this;
                            C.ID = DBase.IntReturn(dt.Rows[i]["ID"]);
                            DateTime cdatetime = DBase.DatetimeReturn(dt.Rows[i]["CDATETIME"]);

                            panChat.Controls.Add(C);
                        }
                        catch (Exception ex) { }

                    }

                    else if (type != "")
                    {
                        try
                        {
                            String FileName = DBase.StringReturn(dt.Rows[i]["FILENAME"]);
                            Image I = null;
                            try
                            {
                                I = DBase.ByteToImage((byte[])dt.Rows[i]["THUMBNAIL"]);
                            }
                            catch (Exception ex) { }
                            ChatItem_Files C = new ChatItem_Files(type, FileName, I);

                            C.M = this;
                            C.ID = DBase.IntReturn(dt.Rows[i]["ID"]);
                            DateTime cdatetime = DBase.DatetimeReturn(dt.Rows[i]["CDATETIME"]);

                            panChat.Controls.Add(C);
                        }
                        catch (Exception ex) { }

                    }

                }

                //ChatItem C2 = new ChatItem();
                
                //panChat.Controls.Add(C2);
            
                panChat.VerticalScroll.Value = panChat.VerticalScroll.Maximum;
            }
            catch (Exception ex) { }

        }
        public void RefreshChat_Append()
        {
            try
            {
                if (dt.Rows.Count > 0) LastID = DBase.IntReturn(dt.Rows[dt.Rows.Count - 1]["ID"]);
                else LastID = 0;
                if (dtnew.Rows.Count > 0) LastID = DBase.IntReturn(dtnew.Rows[dtnew.Rows.Count - 1]["ID"]);
                dtnew = DHuy.SELECT_SQL("SELECT * FROM CHAT WHERE ID > @DATE1 AND USERCODE = '" + Control_Remote + "' ORDER BY ID ASC ", LastID.ToString());
                for (int i = 0; i < dtnew.Rows.Count; i++)
                {
                    String type = DBase.StringReturn(dtnew.Rows[i]["TYPE"]);
                    if (type == "")
                    {
                        ChatItem C = new ChatItem();
                        C.Width = panChat.Width;
                        C.M = this;
                        C.ID = DBase.IntReturn(dtnew.Rows[i]["ID"]);
                        String DataNick = DBase.StringReturn(dtnew.Rows[i]["NICKNAME"]) + " ";

                        String Text = DBase.StringReturn(dtnew.Rows[i]["TEXT"]);
                        DateTime cdatetime = DBase.DatetimeReturn(dtnew.Rows[i]["CDATETIME"]);

                        if (curNick == DataNick)
                        {
                            //C.edtUserCode.ForeColor = C.edtUserCode.BackColor;
                            //C.edtIcon.Visible = false;
                            ////  else C.edtUserCode.ForeColor = Color.Blue;

                            colorIndex++;
                            //  C.edtIcon.Visible = true;
                            if (colorIndex == C.L.Count) colorIndex = 0;
                            // C.edtUserCode.ForeColor = Color.Blue;


                        }
                        else
                        {
                            colorIndex++;
                            //  C.edtIcon.Visible = true;
                            if (colorIndex == C.L.Count) colorIndex = 0;
                            //  C.edtUserCode.ForeColor = Color.Blue;
                        }

                        curNick = DataNick;

                        C.BackColor = C.edtText.BackColor = C.L[colorIndex];

                        //   C.edtUserCode.Text = DataNick + ":";
                        C.edtText.Text = DataNick + ": " + Text + "  ( " + cdatetime.ToString("dd/MM HH:mm") + " )";

                        panChat.Controls.Add(C);
                    }

                    else if (type.ToUpper() == ".JPG" || type.ToUpper() == ".BMP" || type.ToUpper() == ".PNG" || type.ToUpper() == ".GIF")
                    {
                        try
                        {
                            String FileName = DBase.StringReturn(dtnew.Rows[i]["FILENAME"]);
                            Image I = DBase.ByteToImage((byte[])dtnew.Rows[i]["THUMBNAIL"]);
                            ChatItem_Image C = new ChatItem_Image(I, FileName);

                            C.M = this;
                            C.ID = DBase.IntReturn(dt.Rows[i]["ID"]);
                            DateTime cdatetime = DBase.DatetimeReturn(dtnew.Rows[i]["CDATETIME"]);

                            panChat.Controls.Add(C);
                        }
                        catch (Exception ex) { }

                    }

                    else if (type != "")
                    {
                        try
                        {
                            String FileName = DBase.StringReturn(dtnew.Rows[i]["FILENAME"]);
                            Image I = null;
                            try
                            {
                                I = DBase.ByteToImage((byte[])dtnew.Rows[i]["THUMBNAIL"]);
                            }
                            catch (Exception ex) { }
                            ChatItem_Files C = new ChatItem_Files(type, FileName, I);

                            C.M = this;
                            C.ID = DBase.IntReturn(dtnew.Rows[i]["ID"]);
                            DateTime cdatetime = DBase.DatetimeReturn(dtnew.Rows[i]["CDATETIME"]);

                            panChat.Controls.Add(C);
                        }
                        catch (Exception ex) { }

                    }
                }

                if (dtnew.Rows.Count > 0)
                {
                    dt.Merge(dtnew);
                    panChat.VerticalScroll.Value = panChat.VerticalScroll.Maximum;
                }
            }
            catch (Exception ex) { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Text = edtChat.Text;
            if (Text.Replace(" ", "") == "") return;
            dtitem.Rows[0]["TEXT"] = Text;
            dtitem.Rows[0]["TYPE"] = "";
            dtitem.Rows[0]["FILENAME"] = "";
            dtitem.Rows[0]["FILEDATA"] = new byte[3];
            dtitem.Rows[0]["THUMBNAIL"] = new byte[3];
            dtitem.Rows[0]["CDATETIME"] = DHuy.GetServerTime();
            int kq = DHuy.INSERT_IDENTITY("CHAT", dtitem);
            if (kq > 0)
            {
                edtChat.Focus();
                edtChat.Text = "";
                RefreshChat_Append();
            }
        }


        private void lbClose_Click(object sender, EventArgs e)
        {
          //  this.Close();
        }
        private void edtPassword_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Shift)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
                SendKeys.Send("{BKSP}");
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit == 1)
            {

            }
            else
            {
            this.Hide();
            e.Cancel = true;
            }
        }
        private void Chat_LocationChanged(object sender, EventArgs e)
        {
          //  Zmain.AutoAttactDetect();
        }

        private void Chat_SizeChanged(object sender, EventArgs e)
        {
            panChat.Width = this.Width;
            panChat.MaximumSize = this.Size;
            foreach (Control C in panChat.Controls)
            {
                if (C.GetType() == typeof(ChatItem))
                {
                    C.Width = panChat.Width - 2;
                    ((ChatItem)C).edtText_TextChanged(null, null);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshChat_Append();
        }
        private void cmsCut_Click(object sender, EventArgs e)
        {
            edtChat.Cut();
        }
        private void cmsCopy_Click(object sender, EventArgs e)
        {
            edtChat.Copy();
        }
        private void cmsDelete_Click(object sender, EventArgs e)
        {
            edtChat.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
         //   this.Location = Cursor.Position;
        }

        private void panHead_MouseDown(object sender, MouseEventArgs e)
        {
        //    timer2.Start();
        }

        private void panHead_MouseUp(object sender, MouseEventArgs e)
        {
            //this.Location = Cursor.Position;
            //timer2.Stop();
        }
        private void panChat_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                //   this.Text = "Drag...";
            }

            else
                e.Effect = DragDropEffects.None;
        }
        private void panChat_DragDrop(object sender, DragEventArgs e)
        {
            try
            {

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {

                    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (var filePath in files)
                    {
                        FileInfo F = new FileInfo(filePath);
                        int isfolder = DBase.IsFolder(filePath);
                        if (isfolder == 1) continue;
                        byte[] content = new byte[3];
                        content = System.IO.File.ReadAllBytes(filePath);
                        dtitem.Rows[0]["TYPE"] = F.Extension;
                        dtitem.Rows[0]["FILENAME"] = F.Name;
                        dtitem.Rows[0]["THUMBNAIL"] = new byte[3];

                        if (F.Extension.ToUpper() == ".JPG" || F.Extension.ToUpper() == ".PNG" || F.Extension.ToUpper() == ".BMP" || F.Extension.ToUpper() == ".GIF")
                        {

                            try
                            {
                                dtitem.Rows[0]["THUMBNAIL"] = DBase.ImageToByte(DBase.ResizeImage(Image.FromFile(filePath), 50, 50));
                            }
                            catch (Exception ex) { continue; }
                        }
                        else
                        {
                            try
                            {
                                dtitem.Rows[0]["THUMBNAIL"] = DBase.ImageToByte(Icon.ExtractAssociatedIcon(filePath).ToBitmap());
                            }
                            catch (Exception ex) { continue; }
                        }


                        dtitem.Rows[0]["TEXT"] = Text;
                        dtitem.Rows[0]["CDATETIME"] = DHuy.GetServerTime();
                        dtitem.Rows[0]["FILEDATA"] = content;
                        int kq = DHuy.INSERT_IDENTITY("CHAT", dtitem);
                        if (kq > 0)
                        {
                            edtChat.Focus();
                            edtChat.Text = "";
                            RefreshChat_Append();
                        }
                    }

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


     
     
    }
}
