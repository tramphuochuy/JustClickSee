using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class APPTRANSLATE_DETAIL : Form
    {
        public string TableName = "APPTRANSLATE";
        public DataTable dt = new DataTable();
        public DataTable dtCol = new DataTable();
        public string ID = "";
        public string KEYCOL = "";
        public int Identity = 0;
        public int res = 0;
        public int type = 0;
        public APPTRANSLATE Parent = null;
        public int Clone = 0;


        public APPTRANSLATE_DETAIL()
        {
            InitializeComponent();
            dtCol = DBase.GetTableColumns(TableName);

        }

        private void APPTRANSLATE_DETAIL_Load(object sender, EventArgs e)
        {
           
            if (ID != "") // Update
            {
                type = 1; // 0 - insert ; 1 - update
                dt = DHuy.SELECT(TableName, KEYCOL,ID);
                
            }
            else
            {
                
                    dt = DHuy.SELECT_NEWROW(TableName);
                    DBase.SetValue(dt, "USERCODE", DBase.UserCodeLogin);
                    DBase.SetValue(dt, "DOUBLECLICK", false);
                    DBase.SetValue(dt, "HOLDCLICK", true);
                    DBase.SetValue(dt, "ENABLE", true);
                 foreach (DataColumn dc in dt.Columns)
                {

                    if (dc.ColumnName == "CUSERCODE" || dc.ColumnName == "UUSERCODE")
                    {
                        dt.Rows[0][dc.ColumnName] = DBase.UserCodeLogin;

                    }

                    if (dc.ColumnName == "CREATEDBYAGY" || dc.ColumnName == "UPDATEDBYAGY")
                    {
                        //dt.Rows[0][dc.ColumnName] = DBase.AgencyCodeLogin;

                    }


                    string sqlType = dc.DataType.ToString();
                    if (sqlType == "System.DateTime")
                    {
                        dt.Rows[0][dc.ColumnName] = DBase.DatetimeReturn_NowIfNull(dt.Columns[dc.ColumnName]);
                    }
                }

                
            }

            foreach (Control C in this.Controls)
                {
                    if (!C.Name.Contains("edt")) continue;
                    String ColName = C.Name.Replace("edt", "");
                    string sqlType = dt.Rows[0][ColName].GetType().ToString();
                    
                    if (sqlType == "System.DateTime")
                    {
                        DateTimePicker D = (DateTimePicker)C;
                        D.Value = DBase.DatetimeReturn(dt.Rows[0][C.Name.Replace("edt", "")]);

                    }
                    else
                    {
//                        if (C.GetType() == typeof(TextPopup))
//                        {
//                            TextPopup T = (TextPopup)C;
//                            T.StopEvent();
//                            T.Text = DBase.StringReturn(dt.Rows[0][C.Name.Replace("edt", "")]);
//                            T.StartEvent();
//                        }
                         if (C.GetType() == typeof(ComboBox))
                        {
                            ComboBox T = (ComboBox)C;
                            T.Text = DBase.StringReturn(dt.Rows[0][C.Name.Replace("edt", "")]);
                           
                        }

                        else if (C.GetType() == typeof(CheckBox))
                        {
                            CheckBox T = (CheckBox)C;
                            T.Checked = DBase.BoolReturn(dt.Rows[0][C.Name.Replace("edt", "")]);

                        }

                        
                    else if (C.GetType() == typeof(PictureBox))
                         {
                             PictureBox T = (PictureBox)C;
                             T.Click += new System.EventHandler(this.edtIMAGE_Click);
                             try
                             {
                                 System.IO.MemoryStream ms = new System.IO.MemoryStream((Byte[])(dt.Rows[0][C.Name.Replace("edt", "")]));
                                 T.Image = Image.FromStream(ms);
                               //  ms.Dispose();
                             }
                             catch (Exception ex) { }
                         }
                      
                        else
                        {
                        C.Text = DBase.StringReturn(dt.Rows[0][C.Name.Replace("edt", "")]);
                        }
                    }
                }
            //Asign Value Change Event
            foreach (Control C in this.Controls)
            {
                    C.TextChanged += new System.EventHandler(this.TextChange);
            }

            //Asign Checkchange Event
            foreach (Control C in this.Controls)
            {
                if ( C.GetType() == typeof(CheckBox) )
                {
                  ((CheckBox)C).CheckedChanged += new System.EventHandler(this.CheckedChanged);
                }
            }

            //Remove Readonly
            foreach (DataColumn col in dt.Columns)  col.ReadOnly = false;
            

        }

         private void Save_Click(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
               
                if (C.GetType() == typeof(PictureBox))
                {
                    try
                    {
                        try
                        {
                            dt.Rows[0][C.Name.Replace("edt", "")] = new byte[3];
                            dt.Rows[0][C.Name.Replace("edt", "")] = DBase.ImageToByte(((PictureBox)C).Image);
                         
                        }
                        catch (Exception ex)
                        {
                            dt.Rows[0][C.Name.Replace("edt", "")] = DBase.ImageToByte(Properties.Resources.GoogleTrans24);
                        } 
                       
                    }
                    catch (Exception ex) { }
                }


            }

            int kq = 0;
            if (type == 0 || Clone == 1 )
            {
                    kq = (int)DHuy.INSERT_IDENTITY_RETURNID(TableName, dt);
                    if (kq > 0)
                    {
                        DBase.DTAPP = DHuy.SELECT_SQL("SELECT APPNAME,ENABLE,SHORTKEY,DOUBLECLICK,HOLDCLICK FROM APPTRANSLATE WHERE USERCODE ='ADMIN'");
                            //MessageBox.Show("Insert Succesful!");
                            if (Parent != null)  Parent.RefreshInsert(kq.ToString());
                             this.Close();
                    }
            }
            else if( type == 1 )
            {
                    kq = DHuy.UPDATE(TableName,dt,KEYCOL);
                    if (kq > 0) 
                    {
                        DBase.DTAPP = DHuy.SELECT_SQL("SELECT APPNAME,ENABLE,SHORTKEY,DOUBLECLICK,HOLDCLICK FROM APPTRANSLATE WHERE USERCODE ='ADMIN'");
                        //MessageBox.Show("Saved!");
                       if (Parent != null)  Parent.RefreshSelect();
                         this.Close();
                    }
            }

           
          
        }

        private void TextChange(object sender, EventArgs e)
        {
            Control C = (Control)sender;
            if (dt.Rows.Count <= 0) return;
            if (C.GetType() == typeof(DateTimePicker))
            {
                dt.Rows[0][C.Name.Replace("edt","")] = ((DateTimePicker)C).Value ;

            }
            else if (C.GetType() == typeof(TextBox) )
            {
                try
                {
                    dt.Rows[0][C.Name.Replace("edt", "")] = ((TextBox)C).Text;
                }
                catch (Exception ex)
                {
                     if (((TextBox)C).Text != "")  MessageBox.Show("Input Incorrect");
                 
                }
            }

            else if (C.GetType() == typeof(ComboBox))
            {
                dt.Rows[0][C.Name.Replace("edt", "")] = ((ComboBox)C).Text;
            }

           

            else if (C.GetType() == typeof(NumericUpDown))
            {
                dt.Rows[0][C.Name.Replace("edt", "")] = DBase.StringReturn(((NumericUpDown)C).Value);
            }

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            Control C = (Control)sender;
            if (dt.Rows.Count <= 0) return;
            if (C.GetType() == typeof(CheckBox))
            {
                dt.Rows[0][C.Name.Replace("edt", "")] = ((CheckBox)C).Checked;

            }
        }

        private void edtIMAGE_Click(object sender, EventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = "Image files (*.png)|*.png;*.bmp;*.jpg|All files (*.*)|*.*";
            O.ShowDialog();
            if (O.FileName != "")
            {
                ((PictureBox)sender).Image = Image.FromFile(O.FileName);
            }
            else ((PictureBox)sender).Image = null;
        }

        private void edtSHORTKEY_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void edtSHORTKEY_KeyDown(object sender, KeyEventArgs e)
        {
            string KEYBIND = "";
            try
            {
                if (e.Control && e.Shift && e.Alt)
                {
                    KEYBIND = "CRT+ALT+SHIFT";
                }

                else if (e.Control && e.Shift)
                {
                    KEYBIND = "CRT+ALT";
                }

                else if (e.Control && e.Alt)
                {
                    KEYBIND = "CRT+SHIFT";
                }
                else if (e.Control)
                {
                    KEYBIND = "CRT";
                }

           
                KEYBIND = DBase.AppentString(KEYBIND,e.KeyCode.ToString(),"+");

                
            }
            catch (Exception) { }

            edtSHORTKEY.Text = KEYBIND;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProcessList F = new ProcessList();
            F.StartPosition = FormStartPosition.Manual;
            F.Icon = DBase.CreateIcon(btnAdd.Image);
            F.Location = new Point(this.Location.X + 50 , this.Location.Y + 50);
            F.ShowDialog();
            if (F.Res > 0)
            {
                edtAPPNAME.Text = F.APPNAME;
                if (F.I != null)
                {
                    edtICON.Image = F.I;
                }
                else edtICON.Image = null;
            }
        }


    }
}

