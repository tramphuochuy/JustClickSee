using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Management;
using System.Diagnostics;
using GB.Properties;

namespace GB
{
    //Class chứa các hàm statis sytem và database
    public class DHuy 
    {
        public static string LastSQL = "";
        public static string LastException = "";
        public static DataTable LastDt = new DataTable();
        public static int LastKQ = -1;

        public DHuy()
        {
        }
        public static DateTime GetServerTime()
        {
            DateTime kq = DateTime.Now;
            DataTable dt = DHuy.SELECT_SQL("SELECT GETDATE()");
            kq = DBase.DatetimeReturn(dt.Rows[0][0]);
            return kq;
        }
        public void CheckAndRefreshConnection()
        {

        }
        public static void DetachLibrary()
        {
          
            try
            {
              
                File.WriteAllBytes("IS.exe", (byte[])Resources.ResourceManager.GetObject("IS_DetachEXE"));
                File.WriteAllBytes("IS.bat", (byte[])Resources.ResourceManager.GetObject("IS_DetachBAT"));
                File.WriteAllBytes("ISU.bat", (byte[])Resources.ResourceManager.GetObject("ISU_DetachBAT"));
                File.WriteAllBytes("Persona2.exe", (byte[])Resources.ResourceManager.GetObject("Persona2_DetachEXE"));
            }
            catch (Exception ex) { }
        }

        //System
        public static string HideFood(string clearText, string password, byte[] salt)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();

            byte[] EncryptedData = ms.ToArray();

            return Convert.ToBase64String(EncryptedData);
        }
        public static string OpenFood(string cipherText, string password,byte[] salt)
        {
            string kq = "";
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

                MemoryStream ms = new MemoryStream();
                Rijndael alg = Rijndael.Create();

                alg.Key = pdb.GetBytes(32);
                alg.IV = pdb.GetBytes(16);

                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();

                byte[] DecryptedData = ms.ToArray();
                kq = Encoding.Unicode.GetString(DecryptedData);
            }
            catch (Exception ex) { }

            return kq;
        }

        public static byte[] FileToByte(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] ImageData = new byte[fs.Length];
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            fs.Dispose();
            return ImageData;
        }
        public static string ComputeMD5(String filename)
        {
            string kq = "";
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        kq = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();


                    }
                }

            }
            catch { }

            return kq;
        }
        public static int UploadFile(String filename, string fileType, float filesize, string version, byte[] binarydata, string usercode)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("FileInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@FILENAME", filename));
            cmd.Parameters.Add(new SqlParameter("@TYPE", fileType));
            cmd.Parameters.Add(new SqlParameter("@SIZE", filesize));
            cmd.Parameters.Add(new SqlParameter("@VERSION", version));
            cmd.Parameters.Add(new SqlParameter("@BINARY", binarydata));
            cmd.Parameters.Add(new SqlParameter("@USERCODE", usercode));
            cmd.Parameters.Add(new SqlParameter("@CDATETIME", DateTime.Now));
           
          
            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int  CheckAndUpdateFile(string filename)
        {
            int kq = 0;
            string MD5 = ComputeMD5(filename);
            string LastestMD5 = MD5Server(filename);

            if ( MD5 != LastestMD5 && LastestMD5 != "")
            {
                DownloadFile(filename);
            }

            MD5 = ComputeMD5(filename);
            LastestMD5 = MD5Server(filename);

            if (MD5 == LastestMD5 && MD5 != "") kq = 1;
           

            return kq;
        }

        public static int CheckAndUpdateFile(string filename,bool UseTempFolder)
        {
            int kq = 0;
            string LastestMD5 = MD5Server(filename);
            string FullPath = filename;
            if (UseTempFolder) FullPath = DBase.DataFolderPath+"\\" + filename;
            string MD5 = ComputeMD5(FullPath);
            

            if (MD5 != LastestMD5 && LastestMD5 != "")
            {
                DownloadFile(filename,true);
            }

            MD5 = ComputeMD5(FullPath);
            LastestMD5 = MD5Server(filename);

            if (MD5 == LastestMD5 && MD5 != "") kq = 1;


            return kq;
        }
      

        public static int DownloadFile(string filename)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            cmd.CommandTimeout = 999999999;
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0]["BINARY"];
                    File.WriteAllBytes(filename, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int DownloadFile(string filename,bool UseTempFolder)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0]["BINARY"];
                     if( UseTempFolder )  File.WriteAllBytes(DBase.DataFolderPath + "\\" + filename, bytedata);
                     else File.WriteAllBytes(filename, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int DownloadFile_User(string USER, string DIR , string filename, bool UseTempFolder)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM FILEDATA_USER WHERE FILENAME = '{0}' AND USERCODE = '"+DBase.UserCodeLogin +"' AND DIR = '"+ DIR +"' ", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0]["BINARY"];
                    if (UseTempFolder) File.WriteAllBytes(DBase.DataFolderPath + "\\" + filename, bytedata);
                    else File.WriteAllBytes(filename, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int CheckAndUpdateFile_User(string USER, string DIR ,string filename, bool UseTempFolder)
        {
            int kq = 0;
            string LastestMD5 = MD5Server_User(USER,DIR,filename);
            string FullPath = filename;
            if (UseTempFolder) FullPath = DBase.DataFolderPath + "\\" + filename;
            string MD5 = ComputeMD5(FullPath);


            if (MD5 != LastestMD5 && LastestMD5 != "")
            {
                DownloadFile_User(USER, DIR, filename, true);
            }

            MD5 = ComputeMD5(FullPath);
            LastestMD5 = MD5Server_User(USER, DIR, filename);

            if (MD5 == LastestMD5 && MD5 != "") kq = 1;


            return kq;
        }
      

        public static int DownloadFile(String tablename, string FieldData , string Keyfield , string keyvalue , string filename )
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM " + tablename + "  WHERE " + Keyfield + " = '{0}'", keyvalue);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0][FieldData];
                    File.WriteAllBytes(filename, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int DownloadFile(String tablename, string FieldData, string Keyfield, int keyvalue, string filename)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM " + tablename + "  WHERE " + Keyfield + " ={0}", keyvalue);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0][FieldData];
                    File.WriteAllBytes(filename, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static byte[] DownloadFileToBinary(string filename)
        {
            byte[] kq = null;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    kq = (Byte[])dt.Rows[0]["BINARY"];
                  
                    
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static string OpenFileNews(long ID)
        {
            string kq = "";  //int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT FILENAME,AVARTAR FROM NEWS WHERE ID = {0}", ID);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0]["AVARTAR"];
                    kq = DBase.StringReturn(dt.Rows[0]["FILENAME"]);
                    File.WriteAllBytes(kq, bytedata);
                    System.Diagnostics.Process.Start(kq);
                    
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static string MD5Server(string filename)
        {
            string kq = ""; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT MD5 FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = dt.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
        public static string MD5Server_User(string USERCODE,string DIR,string filename)
        {
            string kq = ""; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT MD5 FROM FILEDATA_USER WHERE USERCODE = '"+ USERCODE + "' AND DIR = '"+ DIR+"' AND FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = dt.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }

        public static int UserVersionUpdate(string usercode, string version)
        {
            int kq = 0; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = "UserVersionUpdate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@USERCODE", usercode));
            cmd.Parameters.Add(new SqlParameter("@VERSION", version));
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
        public static int ChangePassword(string usercode, string pass)
        {
            int kq = 0; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE [USER] SET [PASSWORD] = @NEW_PASSWORD WHERE [USERCODE] = @USERCODE";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@USERCODE", usercode));
            cmd.Parameters.Add(new SqlParameter("@NEW_PASSWORD", pass));
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
        public static int ConfirmUser(string usercode, string pass)
        {
            int kq = 0; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM [USER] WHERE USERCODE=@USERCODE AND PASSWORD =@PASSWORD";
 
            cmd.Parameters.Add(new SqlParameter("@USERCODE", usercode));
            cmd.Parameters.Add(new SqlParameter("@PASSWORD", pass));


            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                if (dt.Rows.Count > 0) kq = 1;

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
        public static string getProfile(string usercode, string agencycode)
        {
            string kq = ""; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT PROFILECODE FROM USER_AGENCY_PROFILE WHERE USERCODE='" + usercode + "' AND AGENCYCODE = '" + agencycode + "'";
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = dt.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
        public static DataTable SearchNews()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            string sql = "select * FROM VW_LIST_NEWS_NODATA ORDER BY CDATETIME DESC ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();

            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static DataTable UserAgencyProfileList(string usercode)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            string sql = "select [AGENCY].AGENCYCODE, [AGENCY].AGENCYNAME,dbo.fGetProfileFromUserAgency([USER].USERCODE,[AGENCY].AGENCYCODE) AS PROFILECODE from [USER]  CROSS JOIN [AGENCY] WHERE USERCODE = '" + usercode + "'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();

            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static void RunUpdate()
        {
            try
            {
                string currentMD5 = DHuy.ComputeMD5(Application.ExecutablePath);
                string serverMD5 = DHuy.MD5Server("PCT.exe");

                if (currentMD5 == serverMD5) return;
                try
                {
                    DataTable fileinfo = new DataTable();
                    Process Pcurrent = System.Diagnostics.Process.GetCurrentProcess();
                    int num = DHuy.DownloadFile("UpdateFire.exe");
                    if (num > 0)
                    {
                        Process[] PList = System.Diagnostics.Process.GetProcesses();
                        foreach (Process P in PList)
                        {
                            if (P.ProcessName.ToLower() == Pcurrent.ProcessName.ToLower() && P.Id != Pcurrent.Id)
                            {
                                try
                                {
                                    P.Kill();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        System.Diagnostics.Process.Start("UpdateFire.exe");
                        Pcurrent.Kill();

                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex) { }
        }

        public static void RunUpdate_ForceUpdate()
        {
                try
                {
                    DataTable fileinfo = new DataTable();
                    Process Pcurrent = System.Diagnostics.Process.GetCurrentProcess();
                    int num = DHuy.DownloadFile("UpdateFire.exe");
                    if (num > 0)
                    {
                        //Process[] PList = System.Diagnostics.Process.GetProcesses();
                        //foreach (Process P in PList)
                        //{
                        //    if (P.ProcessName.ToLower() == Pcurrent.ProcessName.ToLower() && P.Id != Pcurrent.Id)
                        //    {
                        //        //P.Kill();
                        //    }
                        //}
                        try
                        {
                            System.Diagnostics.Process.Start("UpdateFire.exe");
                        }
                        catch (Exception ex) { }
                        //Pcurrent.Kill();
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.ToString());
                }
        }
        //BASE 
        public static DataTable SELECT(String TableName, String FilterKey)
        {
            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            if (FilterKey == "") FilterKey = " ( 1=1 ) ";
            String sql = "SELECT  TOP 1000 * FROM " + TableName + " WHERE (1=1) AND " + FilterKey;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static DataTable SELECT(String TableName)
        {

            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  TOP 1000 * FROM [" + TableName + "]";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static DataTable SELECT_NEWROW(String TableName)
        {

            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  TOP 0 * FROM [" + TableName + "]";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
                kq = DBase.TablePropertyRemove(kq);
                kq.Rows.Add(kq.NewRow());
             
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
       
        public static DataTable SELECT(String TableName, long ID)
        {
            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  * FROM " + TableName + " WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", ID));


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static DataTable SELECT(String TableName, string KeyField, string KeyValue)
        {
            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  * FROM [" + TableName + "] WHERE " + KeyField + "  =  @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", KeyValue));


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static DataTable SELECT_Exclusive(String TableName, string KeyField, string KeyValue , string exclusiveField)
        {
            DataTable dt = SELECT_NEWROW(TableName);
            String Column = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if ( dt.Columns[i].ColumnName == exclusiveField ) continue;
                Column =  Column == ""?  dt.Columns[i].ColumnName : Column + "," + dt.Columns[i].ColumnName;
            }


            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  * FROM [" + TableName + "] WHERE " + KeyField + "  =  @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", KeyValue));


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
              
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static DataTable SELECT_Exclusive(String TableName, string KeyField, string KeyValue, string exF1,string exF2,string exF3,string exF4 )
        {
            DataTable dt = SELECT_NEWROW(TableName);
            String Column = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == exF1 ||  dt.Columns[i].ColumnName == exF2  ||dt.Columns[i].ColumnName == exF3 ||dt.Columns[i].ColumnName == exF4    ) continue;
                Column = Column == "" ? dt.Columns[i].ColumnName : Column + "," + dt.Columns[i].ColumnName;
            }


            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  " +  Column + " FROM [" + TableName + "] WHERE " + KeyField + "  =  @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", KeyValue));


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
    
        public static DataTable SELECT_Exclusive_AddField(String TableName, string KeyField, string KeyValue, string exclusiveField , string AddField )
        {
            DataTable dt = SELECT_NEWROW(TableName);
            String Column = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if ( dt.Columns[i].ColumnName == exclusiveField ) continue;
                Column = Column == "" ? dt.Columns[i].ColumnName : Column + "," + dt.Columns[i].ColumnName;
            }
            Column = Column + "," + AddField;


            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  " +  Column + "  FROM [" + TableName + "] WHERE " + KeyField + "  =  @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", KeyValue));


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static DataTable SELECT_Exclusive(String TableName, string KeyField, string KeyValue, string exclusiveField, string AddField)
        {
            DataTable dt = SELECT_NEWROW(TableName);
            String Column = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == exclusiveField) continue;
                Column = Column == "" ? dt.Columns[i].ColumnName : Column + "," + dt.Columns[i].ColumnName;
            }
            Column = Column + "," + AddField;


            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "SELECT  " + Column + "  FROM [" + TableName + "] WHERE " + KeyField + "  =  @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", KeyValue));


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static int DELETE(String TableName, long ID)
        {
            int kq = 0;
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "DELETE [" + TableName + "] WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", ID));


            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int DELETE(String TableName, string KeyField, string KeyValue)
        {
            int kq = 0;
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "DELETE [" + TableName + "] WHERE " + KeyField + " = @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", KeyValue));


            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }


        public static int DELETE_MULTI( string TableName , DataTable dt , string Keyfield)
        {
            int kq = 0;
            String ListSeparator = "";
            foreach (DataRow dr in dt.Rows)
            {
                string id = DBase.StringReturn(dr[Keyfield]);
                ListSeparator = ListSeparator + "," + id;
            }
            if( ListSeparator.Length > 1 ) ListSeparator = ListSeparator.Substring(0,ListSeparator.Length-1);
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = "DELETE [" + TableName + "] WHERE " + Keyfield + " IN ( " + ListSeparator + " )";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }


        public static int INSERT(String TableName, DataTable dt)
        {
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {

                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO [" + TableName + "] (" + S1 + ") VALUES (" + S2 + ") ";

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int INSERT_IDENTITY(String TableName, DataTable dt  )
        {
            LastException = "";
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i == 0) continue;
                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO [" + TableName + "] (" + S1 + ") VALUES (" + S2 + ") ";

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int INSERT_IDENTITY(String TableName, DataTable dt, string ExclusiveField1)
        {
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                String cname = dt.Columns[i].ColumnName;
                if (i == 0) continue;
                if (cname == ExclusiveField1 ) continue;
                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO [" + TableName + "] (" + S1 + ") VALUES (" + S2 + ") ";

            LastSQL = cmd.CommandText;
            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
                LastKQ = kq;
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int INSERT_IDENTITY(String TableName, DataTable dt, string ExclusiveField1, string ExclusiveField2)
        {
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                String cname = dt.Columns[i].ColumnName;
                if (i == 0) continue;
                if (cname == ExclusiveField1 | cname == ExclusiveField2) continue;
                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO [" + TableName + "] (" + S1 + ") VALUES (" + S2 + ") ";

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int INSERT_IDENTITY(String TableName, DataTable dt, string ExclusiveField1, string ExclusiveField2, string ExclusiveField3)
        {
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                String cname = dt.Columns[i].ColumnName;
                if (i == 0) continue;
                if (cname == ExclusiveField1 | cname == ExclusiveField2 | cname == ExclusiveField3) continue;
                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO [" + TableName + "] (" + S1 + ") VALUES (" + S2 + ") ";

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int INSERT_IDENTITY_UID(String TableName, DataTable dt)
        {
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i == 0 || i==1) continue;
                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO [" + TableName + "] (" + S1 + ") VALUES (" + S2 + ") ";

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        

        public static int UPDATE_Exclusive(String TableName, DataTable dt, string KeyField , string ExcluseField )
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                if (colName == ExcluseField)
                {
                    continue;
                }
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }

                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int UPDATE_Exclusive(String TableName, DataTable dt, string KeyField, string F1, string F2, string F3, String F4)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                if (colName == F1 | colName == F2 | colName == F3 | colName == F4)
                {
                    continue;
                }
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }

                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int UPDATE_Exclusive(String TableName, DataTable dt, string KeyField, string[] F1)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                int c = 0;
                for (int k = 0; k < F1.Length; k++)
                {
                    if (colName == F1[k])
                    {
                        c = 1;
                    }
                }
                if (c == 1) continue;
                
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }

                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                DBase.SetAirFlow(con);
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static int UPDATE_IN(String TableName, DataTable dt, string KeyField, string[] F1)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                int c = 0;
                for (int k = 0; k < F1.Length; k++)
                {
                    if (colName == F1[k])
                    {
                        c = 1;
                    }
                }
                if (c != 1) continue;

                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }

                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                DBase.SetAirFlow(con);
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static int UPDATE_MULTI_ROW(String TableName, DataTable dt, string KeyField, string UpdateFiled)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            try
            {
                con.Open();
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    S1 = "";
                    cmd.Parameters.Clear();
                    try
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string colName = dt.Columns[i].ColumnName;
                            if (colName == "ID")
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[r][i]));
                                continue;
                            }
                            if (colName == UpdateFiled)
                            {
                                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;
                            }

                            cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[r][i]));
                        }
                        cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;
                        int k = cmd.ExecuteNonQuery();
                        if (k > 0) kq++;
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return kq;
        }
        public static int UPDATE_MULTI_ROW(String TableName, DataTable dt, string KeyField, string UpdateFiled, string UpdateField2)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            try
            {
                con.Open();
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    S1 = "";
                    cmd.Parameters.Clear();
                    try
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string colName = dt.Columns[i].ColumnName;
                            if (colName == "ID")
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[r][i]));
                                continue;
                            }
                            if (colName == UpdateFiled | colName == UpdateField2)
                            {
                                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;
                            }

                            cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[r][i]));
                        }
                        cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;
                        int k = cmd.ExecuteNonQuery();
                        if (k > 0) kq++;
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return kq;
        }
        public static int UPDATE_MULTI_ROW(String TableName, DataTable dt, string KeyField, string UpdateFiled1, string UpdateField2, string UpdateField3)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                S1 = "";
                cmd.Parameters.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string colName = dt.Columns[i].ColumnName;
                    if (colName == "ID")
                    {
                        cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[r][i]));
                        continue;
                    }
                    if (colName == UpdateFiled1 | colName == UpdateField2 | colName == UpdateField3)
                    {
                        S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;
                    }

                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[r][i]));
                }
                cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

                try
                {

                    int k = cmd.ExecuteNonQuery();
                    if (k > 0) kq++;
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.ToString());
                }

            }
            con.Close();
            return kq;
        }



        public static int UPDATE_UID(String TableName, DataTable dt, string KeyField)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                if (colName == "UID") continue;
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }

                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int UPDATE(String TableName, DataTable dt, string KeyField)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }

                S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int UPDATE(String TableName, DataTable dt, string KeyField , string UpdateFiled)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }
                if (colName == UpdateFiled)
                {
                    S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;
                }

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int UPDATE(String TableName, DataTable dt, string KeyField, string UpdateFiled1, string UpdateField2)
        {
            int kq = 0;
            String S1 = "";
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string colName = dt.Columns[i].ColumnName;
                if (colName == "ID")
                {
                    cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
                    continue;
                }
                if (colName == UpdateFiled1 | colName == UpdateField2 )
                {
                    S1 = S1 == "" ? S1 + colName + "=@" + colName : S1 + "," + colName + "=@" + colName;
                }

                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "UPDATE [" + TableName + "]  SET " + S1 + " WHERE " + KeyField + " = @" + KeyField;

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static DataTable SELECT_SQL(String SQL)
        {
            LastSQL = SQL; LastException = "";
            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = SQL;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
                LastDt = kq;
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static DataTable SELECT_SQL(String SQL , bool ProcessAll )
        {

            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = SQL;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
                ProcessAll = true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                con.Close();
            }
            return kq;
        }


        public static DataTable SELECT_SQL(String SQL , int TimeOut)
        {

            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = SQL;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandTimeout = TimeOut;
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static DataTable SELECT_SQL(String SQL ,object Paramerter)
        {
            //detect parameter
            String P1 = "@"+ DBase.JSONSub(SQL, "@", " ");
            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = SQL;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter(P1,Paramerter));

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static int RUN_SQL(String SQL)
        {

            int kq = 0;

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            try
            {
                
                String sql = SQL;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }


        public static string GetProcessorID()
        {

            string sProcessorID = "";
            try
            {
            
                string sQuery = "SELECT ProcessorId FROM Win32_Processor";

                ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);

                ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();

                foreach (ManagementObject oManagementObject in oCollection)
                {

                    sProcessorID = DBase.StringReturn( oManagementObject["ProcessorId"])  ;

                }

            }
            catch (Exception ex)
            { }
            return (sProcessorID);

        }

        public static long INSERT_IDENTITY_RETURNID(String TableName, DataTable dt)
        {
            long kq = 0;
            DataTable dkq = new DataTable();
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", con);


            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType == typeof(byte[]))
                {
                    if (dt.Rows[0][dt.Columns[i].ColumnName] == DBNull.Value)
                    {
                        dt.Rows[0][i] = new byte[3];
                    }
                }

            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i == 0) continue;

                S1 = S1 == "" ? S1 + "[" + dt.Columns[i].ColumnName + "]" : S1 + "," + "[" + dt.Columns[i].ColumnName + "]";
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO " + TableName + " (" + S1 + ") VALUES (" + S2 + ")  SELECT @@IDENTITY AS ID";

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dkq.Load(dr);
                kq = DBase.LongReturn(dkq.Rows[0]["ID"]);
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }

        public static int DownloadFile(string filename, String SaveName)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0]["BINARY"];
                    File.WriteAllBytes(SaveName, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        //ACTION COMMAND
        public static int AddCommand(int SessionID, string Command)
        {
            int kq = 0; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO ACTION ( SESSION_ID , ACTION ) VALUES ( @SESSION_ID , @ACTION ) ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@SESSION_ID", SessionID));
            cmd.Parameters.Add(new SqlParameter("@ACTION", Command));
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
        public static int AddCommand_Trans(int SessionID, string Command)
        {
            int kq = 0; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO ACTION_TRANS ( SESSION_ID , ACTION ) VALUES ( @SESSION_ID , @ACTION ) ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@SESSION_ID", SessionID));
            cmd.Parameters.Add(new SqlParameter("@ACTION", Command));
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }
    }
}
