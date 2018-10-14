using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Globalization;
using GB;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Net;
using System.Runtime.InteropServices;
using Google.Cloud.Translation.V2;


namespace GB
{


    public static class DBase
    {
        public static string SR = "";
        public static string SPEECH_STATUS = "";
        public static string AgencyCodeLogin = "";
        public static bool API_Working = false;
        public static TranslationClient GTC = null ;
        public static DataTable DTADDRESS = new DataTable();
        public static DataTable DTAPP = new DataTable();
        public static string AppPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\") + 1);
        public static DateTime LastSetWallpaper = DateTime.Now;
        public static DateTime StarupTime = DateTime.Now;
        public static DataTable DTWALLPAPER = null;
        //Save settings
        public static DataTable dtpcslist = new DataTable();
        public static string LastID = "";
        public static string LastUserLogin = "";
        public static string LastUserLogin2 = "";
        public static string LastPasswordLogin = "";
        public static string CloseToTray = "";
        public static string ShowCursor = "1";
        public static string PasswordAuthen = ""; // blank = disable password ( public )
        public static string NickName = ""; // blank = disable password ( public )
        public static string AutoLogOn = "";
        public static string LogOnPassword = "";
        public static string LockDesktopWhenSessionFinish = "";
        public static string AutoupdateWhenStart = "";
        public static string DisableLockScreen = "";
        public static string DisableAreoThemWhenConnect = "";
        public static string LastImageQuality = "";
        public static string LastWallpaper = "";
        public static string LastImageQuality_LocalIndex = "";
        public static string LastHeight = "";
        public static string LastWidth = "";
        public static string LastPos = "";
        public static string SizeMemory = "";
        public static string SoundDeviceText = "";
        public static int ActiveTranslation = 0;
        public static int WallChange = 0;
        public static int WallChangeSecond = 60;
        public static int ShowException = 0;
        public static int StartMinimize = 1;
        public static string TargetLanguage1Setting ="vi-Vietnamese";
        public static string TargetLanguage2Setting = "en-English";



        public static string[] SoundToogleList = new string[] { "", "" };

        public static Byte[] Window7 = (Byte[])new ImageConverter().ConvertTo((System.Drawing.Image)Properties.Resources.Bundle, typeof(Byte[]));


        public static int CurrentSessionID = 0;

        public static Dictionary<int, Cursor> CursorList = new Dictionary<int, Cursor>();
        public static string CursorListString = "";

        public static DateTime Signal = DateTime.Now;
        public static int isLock = 0;
        public static int isWindowKeyDown = 0;
        public static Cursor[] Curo = null;
        public static Dictionary<int, int> LCursor = new Dictionary<int, int>();
        public static String WindowVersion = Environment.OSVersion.VersionString ;
        //Settings

        public static string TargetLanguage1 = "vi";
        public static string TargetLanguage2 = "en";

        public static string TargetLanguage1Name = "Vietnamese";
        public static string TargetLanguage2Name = "English";

        public static String ReadFile(String Path)

        {
            StreamReader sr = null;
            String kq = "";
            try
            {
                sr = File.OpenText(Path);
                kq = sr.ReadToEnd();
                sr.Dispose();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }
            return kq;
        }
        public static int WriteFile(String S, String FileName)
        {
            int kq = 1;
            try
            {
                System.IO.File.WriteAllText(FileName,S);
            }
            catch (Exception ex) { kq = 0; }
            return kq;
        }
        public static void LoadSetting()
        {
            
            StreamReader sr = null;
            try
            {

                sr = File.OpenText(DBase.SettingFile);
                string line = sr.ReadToEnd();
                line = DHuy.OpenFood(line, "Asdasd123!", new byte[512]);

                String[] SS = line.Split(';');

                DBase.LastID = DBase.StringReturn(SS[0]);
                DBase.LastUserLogin = DBase.StringReturn(SS[1]);
                DBase.LastPasswordLogin = DBase.StringReturn(SS[2]);
                DBase.CloseToTray = DBase.StringReturn(SS[3]);

                DBase.LastUserLogin2 = DBase.StringReturn(SS[4]);
                DBase.ShowCursor = DBase.StringReturn(SS[5]);
                DBase.PasswordAuthen = DBase.StringReturn(SS[6]);
                DBase.NickName = DBase.StringReturn(SS[7]);



                DBase.AutoLogOn = DBase.StringReturn(SS[8]);
                DBase.LogOnPassword = DBase.StringReturn(SS[9]);
                DBase.LockDesktopWhenSessionFinish = DBase.StringReturn(SS[10]);
                DBase.AutoupdateWhenStart = DBase.StringReturn(SS[11]);
                DBase.DisableLockScreen = DBase.StringReturn(SS[12]);
                DBase.DisableAreoThemWhenConnect = DBase.StringReturn(SS[13]);
                DBase.LastImageQuality = DBase.StringReturn(SS[14]);
                DBase.LastImageQuality_LocalIndex = DBase.StringReturn(SS[15]);
                DBase.LastHeight = DBase.StringReturn(SS[16]);
                DBase.SizeMemory = DBase.StringReturn(SS[17]);
                DBase.LastWidth = DBase.StringReturn(SS[18]);
                DBase.LastPos = DBase.StringReturn(SS[19]);
                DBase.SoundDeviceText = DBase.StringReturn(SS[20]);
                DBase.WallChange = DBase.IntReturn(SS[21]);
                DBase.WallChangeSecond = DBase.IntReturn(SS[22]);
                DBase.ActiveTranslation = DBase.IntReturn(SS[23]);
                DBase.ShowException = DBase.IntReturn(SS[24]);
                DBase.StartMinimize = DBase.IntReturn(SS[25]);
                DBase.TargetLanguage1Setting = DBase.StringReturn(SS[26]);
                DBase.TargetLanguage2Setting = DBase.StringReturn(SS[27]);
                try
                {
                    DBase.SoundToogleList = new string[2] { DBase.SoundDeviceText.Split(',')[0], DBase.SoundDeviceText.Split(',')[1] };
                }
                catch (Exception) { }
                sr.Dispose();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (DBase.TargetLanguage1Setting == "") TargetLanguage1Setting = "vi-Vietnamese";
                if (DBase.TargetLanguage2Setting == "") TargetLanguage2Setting = "en-English";
                if (DBase.PasswordAuthen == "") DBase.PasswordAuthen = DHuy.HideFood("", "justicenzy", new byte[64]);
                if (DBase.NickName == "") DBase.NickName = Environment.MachineName;
                if (CloseToTray == "") CloseToTray = "1";
                if (DisableAreoThemWhenConnect == "") DisableAreoThemWhenConnect = "0";
                if (LastImageQuality == "") LastImageQuality = "Normal";
                if (LastImageQuality_LocalIndex == "") LastImageQuality = "5";
                if (sr != null) sr.Dispose();
            }
            try
            {

                DBase.TargetLanguage1 = DBase.TargetLanguage1Setting.Split('-')[0];
                DBase.TargetLanguage2 = DBase.TargetLanguage2Setting.Split('-')[0];
                DBase.TargetLanguage1Name = DBase.TargetLanguage1Setting.Split('-')[1];
                DBase.TargetLanguage2Name = DBase.TargetLanguage2Setting.Split('-')[1];

            }
            catch (Exception) { }

        }
        public static void SaveSetting()
        {
            try
            {
                String encryptString =
                                            LastID + ";" + LastUserLogin + ";" + LastPasswordLogin + ";" + CloseToTray + ";"
                                            + LastUserLogin2 + ";" + ShowCursor + ";" + PasswordAuthen + ";" + NickName + ";"
                                            + AutoLogOn + ";" + LogOnPassword + ";" + LockDesktopWhenSessionFinish
                                            + ";" + AutoupdateWhenStart + ";" + DisableLockScreen + ";" + DisableAreoThemWhenConnect
                                             + ";" + LastImageQuality + ";" + LastImageQuality_LocalIndex + ";" + LastHeight + ";" + SizeMemory
                                             + ";" + LastWidth
                                             + ";" + LastPos
                                             + ";" + SoundDeviceText
                                              + ";" + WallChange
                                               + ";" + WallChangeSecond
                                                + ";" + ActiveTranslation
                                                    + ";" + ShowException
                                                        + ";" + StartMinimize
                                                          + ";" + TargetLanguage1Setting
                                                            + ";" + TargetLanguage2Setting
                                            ;
                System.IO.File.WriteAllText(DBase.SettingFile, DHuy.HideFood(encryptString, "Asdasd123!", new byte[512]));
            }
            catch (Exception ex) { }
        }

        public static string WallpaperPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Wallpper";
        public static string DataFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\PCT";
        public static string MonitorFile = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Control.ini";
        public static string XmlRemote_File = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Data.xml";
        public static string SettingFile = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\JustclickSee.ini";
        public static string PCSIDFile = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\PCS.afk";
        public static string DetectInstanceFile = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\JCS_Detected";
        public static string DetectQuickRemoteFile = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\QuickRemote.ini";
        public static string LogDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\PCT_LogFile";
        public static string LogDirectoryWithSplash = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\PCT_LogFile\\";

        //public static string MonitorFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Control.ini";
        //public static string XmlRemote_File = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Data.xml";
        //public static string SettingFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PCT.ini";
        //public static string PCSIDFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PCS.afk";
        //public static string DetectInstanceFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Persona";
        //public static string DetectQuickRemoteFile = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\QuickRemote.ini";
        //public static string LogDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PCT_LogFile";

        public static string ConnectionString = "";
        public static int DebugMode = 0;
        public static bool firstRead = true;

        //login
        public static string UserCodeLogin = "";
        
        public static Cursor CursorFromString(int Size , string CursorString )
        {
            Cursor kq = Cursors.Default;
            try
            {

                string cname = DBase.JSONSub(CursorString, Size.ToString() + "_", ",");

                switch (cname)
                {
                    case "Default": return Cursors.Default;
                    case "HSplit": return Cursors.HSplit;
                    case "VSplit": return Cursors.VSplit;
                    case "WaitCursor": return Cursors.WaitCursor;
                    case "SizeNS": return Cursors.SizeNS;
                    case "SizeWE": return Cursors.SizeWE;
                    case "SizeAll": return Cursors.SizeAll;
                    case "SizeNESW": return Cursors.SizeNESW;
                    case "SizeNWSE": return Cursors.SizeNWSE;
                    case "PanEast": return Cursors.PanEast;
                    case "PanNE": return Cursors.PanNE;
                    case "PanNorth": return Cursors.PanNorth;
                    case "PanNW": return Cursors.PanNW;
                    case "PanSE": return Cursors.PanSE;
                    case "PanSouth": return Cursors.PanSouth;
                    case "PanSW": return Cursors.PanSW;
                    case "PanWest": return Cursors.PanWest;

                    case "AppStarting": return Cursors.AppStarting;
                    case "Hand": return Cursors.Hand;
                    case "Cross": return Cursors.Cross;
                    case "Help": return Cursors.Help;
                    case "IBeam": return Cursors.IBeam;
                    case "No": return Cursors.No;
                    case "Arrow": return Cursors.Arrow;
                    case "NoMove2D": return Cursors.NoMove2D;
                  

                    default: return Cursors.Default;
                }
            }
            catch (Exception ex) { }
            return kq;

        }

        //Permission
        public static bool ADMIN;
        public static bool SPU;
        public static bool UINV;
        public static bool URPT;

        public static int isbootreport = 0;

        public static string QuotedString(string str)
        {
            return "'" + str + "'";
        }

        public static Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static byte[] ImageToByte(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static string JSONSub(String APIRES, String Starsplit, String EndSplit)
        {
            string kq = "";
            try
            {
                int T1 = APIRES.IndexOf(Starsplit);
                APIRES = APIRES.Substring(T1, APIRES.Length - T1);
                kq = APIRES.Substring(APIRES.IndexOf(Starsplit) + Starsplit.Length, APIRES.IndexOf(EndSplit) - APIRES.IndexOf(Starsplit) - Starsplit.Length);

            }
            catch (Exception ex) { }
            return kq;

        }

        public static string JSONSub(String APIRES, String Starsplit, bool EndString)
        {
            string kq = "";
            try
            {
                int T1 = APIRES.IndexOf(Starsplit);
                APIRES = APIRES.Substring(T1, APIRES.Length - T1);
                kq = APIRES.Substring(APIRES.IndexOf(Starsplit) + Starsplit.Length, (APIRES.Length) - APIRES.IndexOf(Starsplit) - Starsplit.Length);

            }
            catch (Exception ex) { }
            return kq;

        }

        public static string JSONSub(String APIRES, String Starsplit)
        {
            string kq = "";
            try
            {

                APIRES = APIRES.Substring(APIRES.IndexOf(Starsplit), APIRES.Length - APIRES.IndexOf(Starsplit));

                int EndIndex = APIRES.IndexOf(',');
                kq = APIRES.Substring(0 + Starsplit.Length, EndIndex - Starsplit.Length);


            }
            catch (Exception ex) { }
            return kq;

        }

        public static Icon CreateIcon(Bitmap B)
        {
            Icon Kq = null;
            try
            {
                Kq = Icon.FromHandle(B.GetHicon());
            }
            catch (Exception ex) { }
            return Kq;
        }

        public static Icon CreateIcon(Image B)
        {
            Icon Kq = null;
            try
            {
                Bitmap b = new Bitmap(B);
                Kq = Icon.FromHandle(b.GetHicon());
            }
            catch (Exception ex) { }
            return Kq;
        }

        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public static string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }


        // Floor Datetime
        public static DateTime FloorDateTime(DateTime d)
        {
            DateTime kq;
            kq = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);

            return kq;
        }

        //function DB----------------------------------------------------------------------------
        public static object LookupValue(DataTable dt, string keyField, object keyValue, string outField)
        {
            int dataRowCount = dt.Rows.Count;
            bool match;

            for (int i = 0; i < dataRowCount; i++)
            {
                match = true;
                DataRow row = dt.Rows[i];

                if (!row[keyField].Equals(keyValue))
                    match = false;

                if (match)
                    return row[outField];
            }

            return null;
        }

        public static int GetRowIndexInDataSource(DataTable dt, string keyfield, object keyvalue)
        {
            int dataRowCout = dt.Rows.Count;
            bool match;

            for (int i = 0; i < dataRowCout; i++)
            {
                match = true;
                DataRow row = dt.Rows[i];

                if (!row[keyfield].Equals(keyvalue))
                    match = false;

                if (match)
                    return i;
            }

            return -1;
        }

        public static void GotoRecord(CurrencyManager cm, DataTable dt, string keyfield, object keyvalue)
        {
            int dataRowCout = dt.Rows.Count;
            bool match;
            int gotorow = 0;

            for (int i = 0; i < dataRowCout; i++)
            {
                match = true;
                DataRow row = dt.Rows[i];

                if (!row[keyfield].Equals(keyvalue))
                    match = false;

                if (match)
                {
                    gotorow = i;
                    break;
                }
            }

            cm.Position = gotorow;
        }



        public static int ExecSQL(string str, SqlConnection cnn)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(str, cnn);

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public static object ExecScalarSQL(string str, SqlConnection cnn)
        {
            SqlCommand cmd;
            object ob;
            try
            {
                cmd = new SqlCommand(str, cnn);
                try
                {
                    ob = cmd.ExecuteScalar();
                    return ob;
                }
                catch (SqlException)
                {
                    return DBNull.Value;
                }
            }
            catch
            {
                return DBNull.Value;
            }
        }

        public static DataTable FillTable(string str, SqlConnection cnn)
        {
            DataTable datatable;
            SqlDataAdapter da;

            try
            {
                da = new SqlDataAdapter(str, cnn);
                datatable = new DataTable();

                try
                {
                    da.Fill(datatable);
                }
                catch (SqlException)
                {
                    return null;
                }
                return datatable;
            }
            catch
            {
                return null;
            }
        }

        public static void SetSystemFormat()
        {
            int[] ARR = { 3, 2, 2 };
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            System.Globalization.DateTimeFormatInfo dateTimeInfo = new System.Globalization.DateTimeFormatInfo();
            System.Globalization.NumberFormatInfo NumberInfo = new System.Globalization.NumberFormatInfo();
            //  Thread.CurrentThread.CurrentCulture = cultureInfo;


            dateTimeInfo.DateSeparator = "/";
            dateTimeInfo.LongDatePattern = "dd/MMM/yyyy";
            dateTimeInfo.ShortDatePattern = "dd/MM/yyyy";
            dateTimeInfo.LongTimePattern = "hh:mm:ss tt";
            dateTimeInfo.ShortTimePattern = "hh:mm tt";

            //NumberInfo.CurrencySymbol = "Rs"; 
            NumberInfo.CurrencyDecimalDigits = 3;
            NumberInfo.CurrencyDecimalSeparator = ".";
            NumberInfo.CurrencyGroupSizes = ARR;
            NumberInfo.CurrencyGroupSeparator = ",";
            NumberInfo.PositiveInfinitySymbol = " ";

            //dateTimeInfo.SetAllDateTimePatterns = "dd/MM/yyyy,hh:mm:ss tt"; 
            cultureInfo.DateTimeFormat = dateTimeInfo;
            cultureInfo.NumberFormat = NumberInfo;
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }


        //huy

        public static string getLineNumber(int zeronum, int input) // Create LineNumber From int 
        {
            string kq = "";
            try
            {
                string zero = "";
                for (int i = 1; i <= zeronum; i++)
                {
                    zero = "0" + zero;
                }

                kq = zero.Substring(0, (zeronum - input.ToString().Length)) + input.ToString();
            }
            catch (Exception ex) { };

            return kq;
        }

        public static string getLineNumber_Space(int zeronum, int input) // Create LineNumber From int 
        {
            string zero = "";
            for (int i = 1; i <= zeronum; i++)
            {
                zero = " " + zero;
            }

            string kq = zero.Substring(0, (zeronum - input.ToString().Length)) + input.ToString();
            return kq;
        }
        public static bool isInt(string number)  //Check Int
        {
            bool kq = true;
            try
            {
                Int64.Parse(number);
            }
            catch (Exception)
            {
                kq = false;
            }

            return kq;
        }

        public static bool isDouble(object number) //Check double
        {
            bool kq = true;
            try
            {
                Double.Parse(number.ToString());
            }
            catch (Exception)
            {
                kq = false;
            }

            return kq;
        }

        public static bool isBoolean(object number) //Check double
        {
            bool kq = true;
            try
            {
                Boolean.Parse(number.ToString());
            }
            catch (Exception)
            {
                kq = false;
            }

            return kq;
        }

        public static DateTime DatetimeReturn(object d) //return DateTime from object
        {
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = d == null ? new DateTime(1900, 1, 1) : (d.ToString() == "" ? new DateTime(1900, 1, 1) : (DateTime)d);
            }
            catch (Exception ex)
            {
                try
                {
                    kq = DateTime.Parse(d.ToString());
                }
                catch (Exception exs)
                {
                }
            }
            return kq;
        }

        public static DateTime DatetimeReturn_NowIfNull(object d) //return DateTime from object
        {
            DateTime kq = DateTime.Now;
            try
            {
                kq = d == null ? kq : (d.ToString() == "" ? kq : (DateTime)d);
            }
            catch (Exception ex)
            {
                try
                {
                    kq = DateTime.Parse(d.ToString());
                }
                catch (Exception exs)
                {
                }
            }
            return kq;
        }

        public static string DatetimeReturnString(object d) //return DateTime from object
        {
            String S = "";
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = d == null ? new DateTime(1900, 1, 1) : (d.ToString() == "" ? new DateTime(1900, 1, 1) : (DateTime)d);
                if (kq.Year == 1900)
                {
                    S = "";
                }
                else
                {
                    S = kq.ToString();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    S = "";
                }
                catch (Exception exs)
                {
                }
            }

            return S;
        }

        public static DateTime DatetimeReturn_DD_MM_YYYY(String S) //return DateTime from object
        {
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = DateTime.ParseExact(S, "dd/MM/yyyy",
                                        System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
            }
            return kq;
        }

        public static DateTime DatetimeReturnByFormat(String S, String formatddmmyy) //return DateTime from object
        {
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = DateTime.ParseExact(S, formatddmmyy,
                                        System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
            }
            return kq;
        }

        public static string StringReturn(object d) //return String from object
        {
            return d == null ? "" : d.ToString();
        }

        public static double DoubleReturn(object d) //return number from object
        {
            return (isDouble(d) ? double.Parse(d.ToString()) : 0);
        }

        public static decimal DecimalReturn(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString(), nfi) : 0);
        }
        public static string DecimalReturn1Places(object d)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n1", nfi) : "0");
        }
        public static string Deci2(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n2", nfi) : "0");
        }
        public static string DecimalReturn3Places(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n3", nfi) : "0");
        }

        public static string DecimalReturn4Places(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n4", nfi) : "0");
        }
       
        public static string Latency(DateTime d1, DateTime d2)
        {
            string kq = "";
            try
            {
                int value = DBase.IntReturn( (d2 - d1).TotalMilliseconds);
                kq = DBase.getLineNumber(3, value);
            }
            catch (Exception ex) { }
            return kq;
        }

        public static float FloatReturn(object d) //return number from object
        {
            return (isDouble(d) ? float.Parse(d.ToString()) : 0);
        }


        public static long LongReturn(object d) //return number from object
        {
            return (isDouble(d) ? long.Parse(d.ToString()) : 0);
        }

        public static int IntReturn(object d)  //return number from object
        {
            return (isDouble(d) ? (int)double.Parse(d.ToString()) : 0);
        }

        public static bool BoolReturn(object d)  //return number from object
        {
            return (isBoolean(d) ? (bool)Boolean.Parse(d.ToString()) : false);
        }

        public static string Fect(DataTable dt, string filedname)
        {
            string kq = "";

            kq = StringReturn(dt.Rows[0][filedname]);

            return kq;
        }

        public static DateTime FectDateTime(DataTable dt, string filedname)
        {

            return DatetimeReturn(dt.Rows[0][filedname]);
        }

        public static string Tach(string s)
        {
            return "\r\n" + s;
        }

        public static string biDate(DateTime d)
        {
            string kq = "";
            kq = d.Year.ToString().Substring(d.Year.ToString().Length - 2, 2) + d.Month.ToString() + d.Day.ToString() + d.Hour.ToString() + d.Minute.ToString();

            return kq;
        }

        public static string biDate2(DateTime d)
        {
            string kq = "";
            kq = d.Year.ToString() + (d.Month < 10 ? "0" + d.Month.ToString() : d.Month.ToString()) + (d.Day < 10 ? "0" + d.Day.ToString() : d.Day.ToString());

            return kq;
        }

        public static string biDate3(DateTime d)
        {
            string kq = "";
            kq = d.Year.ToString().Substring((d.Year.ToString().Length - 2), 2) + (d.Month < 10 ? "0" + d.Month.ToString() : d.Month.ToString()) + (d.Day < 10 ? "0" + d.Day.ToString() : d.Day.ToString()) + getLineNumber(2, d.Hour) + getLineNumber(2, d.Minute);

            return kq;
        }

        //Transform
        public static string IntColumn(int X)
        {
            string kq = " ";

            for (int i = 0; i < X.ToString().Length; i++)
            {

                kq = kq + X.ToString().Substring(i, 1) + "\r\n";
            }

            return kq;

        }

        //Supoprt Connection
        public static void SetAirFlow(SqlConnection con)
        {
            using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", con))
            { comm.ExecuteNonQuery(); }
        }

        public static bool Debuging = false;
        public static bool IsDebug()
        {
            Debuging = System.Diagnostics.Debugger.IsAttached;
            return Debuging;
        }

       

        public static int dgvRowCountByCheckboxColumn(DataGridView dgv, string columnName)
        {
            int kq = 0;

            foreach (DataGridViewRow drv in dgv.Rows)
            {
                string check = DBase.StringReturn(drv.Cells[columnName].Value);
                if (check.ToLower() == "true")
                {
                    kq++;
                }
            }
            return kq;
        }
        public static DataTable GetTableColumns(string TableName)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + TableName + "'");
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static int CheckIdentity(String TableName, string Columname)
        {

            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DBase.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("select columnproperty(object_id(N'" + TableName + "'),'" + Columname + "','IsIdentity')");
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = DBase.IntReturn(dt.Rows[0][0]);


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
        public static int isOnline = 1;

        public static DataTable ConvertTable(DataTable dt)
        {
            DataTable kq = dt.Clone();
            for (int i = dt.Columns.Count - 1; i > 0; i--)
            {
                if (dt.Columns[i].ColumnName.Contains("DATE"))
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = dt.Columns[i].ColumnName;
                    dc.DataType = typeof(DateTime);
                    dt.Columns.RemoveAt(i);
                    //   dc.SetOrdinal(i);
                    dt.Columns.Add(dc);
                    dt.Columns[dc.ColumnName].SetOrdinal(i);

                }

            }
            return dt;
        }
        public static DataTable TablePropertyRemove(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].AllowDBNull = true;
                dt.Columns[i].ReadOnly = false;
            }
            return dt;
        }
        public static void GetFood(bool Static)
        {
            String encrypt = "3DIJDa0+VGAaFKwo17/nnoTAU4owRwNwTZDbE8aYJ1/vvvy6cgHg/+tn0O3YLje67pB1e6cakHGJDtMP1gz7hgthjFZPLpwrisWaT8QvTFLOep5PBCVbW/U3STP9M4OoJglOKn9O1KLaIi7EFkojG9w+0pU6J7f/EyC7Y4Ih6iQ=";
            DBase.ConnectionString = DHuy.OpenFood(encrypt, "dgvRowCountByCheckboxColumn()", new byte[128]);
        }

        //BASE 
        public static DataTable SELECT(String TableName, String FilterKey)
        {
            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            if (FilterKey == "") FilterKey = " ( 1=1 ) ";
            String sql = "SELECT   * FROM " + TableName + " WHERE (1=1) AND " + FilterKey;
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
                kq.Rows.Add(kq.NewRow());
                kq = DBase.TablePropertyRemove(kq);
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
                //MessageBox.Show(ex.ToString());
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

        public static string biDateTimeSave(DateTime d)
        {
            string kq = "";
            kq = d.Year.ToString() + "_" + (d.Month < 10 ? "0" + d.Month.ToString() : d.Month.ToString()) + "_" + (d.Day < 10 ? "0" + d.Day.ToString() : d.Day.ToString()) + "_" + getLineNumber(2, d.Hour) + getLineNumber(2, d.Minute) + getLineNumber(2, d.Second);

            return kq;
        }
        public static int INSERT_IDENTITY(String TableName, DataTable dt)
        {
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
        public static int RUN_SQL(String SQL)
        {

            int kq = 0;
            SqlConnection con = new SqlConnection(DBase.ConnectionString);
            String sql = SQL;
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
        public static string CapString(string Input)
        {
            string kq = Input;
            try
            {
                string a = Input.Substring(0, 1).ToUpper();
                kq = a + Input.Substring(1, Input.Length - 1);
            }
            catch (Exception ex) { }


            return kq;
        }

        public static bool BoolReturn(DataTable dt, int RowIndex, string FieldName)
        {
            bool kq = false;
            try
            {
                kq = DBase.BoolReturn(dt.Rows[RowIndex][FieldName]);
            }
            catch (Exception ex) { }
            return kq;
        }

        //Bold control
        public static void BoldLabel(Label L)
        {
            L.Font = new Font(L.Font.FontFamily, L.Font.Size, FontStyle.Bold);

        }
        public static void DeleteFile(String FilePath)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(FilePath);
                if (!exists)
                    File.Delete(FilePath);
            }
            catch (Exception ex) { }
        }
        public static void CopyFile(String FilePath, String ToPath)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(FilePath);

                if (!exists) File.Copy(FilePath, ToPath);
            }
            catch (Exception ex) { }
        }

        //Imgae
        public static long getObjectLenght(object o)
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }
            return size;
        }
        public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {

            Bitmap result = new Bitmap(width, height);
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            return result;
        }
        public static Bitmap ResizeImage(Bitmap mg, Size newSize)
        {
            double ratio = 0d;
            double myThumbWidth = 0d;
            double myThumbHeight = 0d;
            int x = 0;
            int y = 0;

            Bitmap bp;

            if ((mg.Width / Convert.ToDouble(newSize.Width)) > (mg.Height /
            Convert.ToDouble(newSize.Height)))
                ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(newSize.Width);
            else
                ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(newSize.Height);
            myThumbHeight = Math.Ceiling(mg.Height / ratio);
            myThumbWidth = Math.Ceiling(mg.Width / ratio);

            //Size thumbSize = new Size((int)myThumbWidth, (int)myThumbHeight);
            Size thumbSize = new Size((int)newSize.Width, (int)newSize.Height);
            bp = new Bitmap(newSize.Width, newSize.Height);
            x = (newSize.Width - thumbSize.Width) / 2;
            y = (newSize.Height - thumbSize.Height);
            // Had to add System.Drawing class in front of Graphics ---
            System.Drawing.Graphics g = Graphics.FromImage(bp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
            g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);

            return bp;

        }
        public static void CompressJpg(Bitmap bitmap, string filenameSave, long Percent)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == "image/jpeg")
                    ici = codec;
            }

            EncoderParameters ep = new EncoderParameters();
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Percent);
            bitmap.Save(filenameSave + "_Compress.jpg", ici, ep);

        }
        public static void CompressJpg(Bitmap bitmap, MemoryStream ms, long Percent)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == "image/jpeg")
                    ici = codec;
            }

            EncoderParameters ep = new EncoderParameters();
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Percent);
            bitmap.Save(ms, ici, ep);

        }
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
        public static void SetIconLabel(Icon I)
        {


        }

        public static List<String> GetColorList()
        {
            List<string> colors = new List<string>();

            foreach (string colorName in Enum.GetNames(typeof(KnownColor)))
            {
                //cast the colorName into a KnownColor
                KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
                //check if the knownColor variable is a System color
                if (knownColor > KnownColor.Transparent)
                {
                    //add it to our list
                    colors.Add(colorName);
                }
            }

            return colors;
        }


        //Registry // SET
        public static void RegistrySetLM(String Key, String Field, String value)
        {

            RegistryKey rk = Registry.LocalMachine.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) rk.DeleteValue(Field);
            rk.SetValue(Field, value);
        }
        public static void RegistrySetLM(String Key, String Field, String value, bool DWORD)
        {

            RegistryKey rk = Registry.LocalMachine.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) rk.DeleteValue(Field);
            if (DWORD) rk.SetValue(Field, value, RegistryValueKind.DWord);
            else rk.SetValue(Field, value);
        }
        public static void RegistrySetCU(String Key, String Field, String value)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(Key, true);
                if (rk.GetValue(Field) != null) rk.DeleteValue(Field);
                rk.SetValue(Field, value);
            }
            catch (Exception ex) { }
        }    //CURENT USER
        public static void RegistrySetCU(String Key, String Field, String value, bool DWORD)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) rk.DeleteValue(Field);
            if (DWORD) rk.SetValue(Field, value, RegistryValueKind.DWord);
            else rk.SetValue(Field, value);
        }
        public static void RegistrySetCC(String Key, String Field, String value)
        {

            RegistryKey rk = Registry.CurrentConfig.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) rk.DeleteValue(Field);
            rk.SetValue(Field, value);
        }

        //Registry // Delete
        public static void RegistryDeleteLM(String Key, String Field)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) rk.DeleteValue(Field);

        }
        public static void RegistryDeleteCU(String Key, String Field)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(Key, true);
                if (rk.GetValue(Field) != null) rk.DeleteValue(Field);
            }
            catch (Exception ex) { }

        }
        public static void RegistryDeleteCC(String Key, String Field)
        {
            RegistryKey rk = Registry.CurrentConfig.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) rk.DeleteValue(Field);

        }

        //Registry // Get
        public static string RegistryGetLM(String Key, String Field)
        {
            string kq = "";
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(Key, true);
            if (rk.GetValue(Field) != null) kq = rk.GetValue(Field).ToString();
            return kq;
        }
        public static string RegistryGetCU(String Key, String Field)
        {
            string kq = "";
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(Key, true);
                if (rk.GetValue(Field) != null) kq = rk.GetValue(Field).ToString();
            }
            catch (Exception ex) { }
            return kq;
        }

        //Registry // AutoLogon 
        public static void AutoLogOnUser(String Username, string Password)
        {
            try
            {
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoRestartShell", "0", true);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "ForceAutoLogon", "1", true);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultDomainName", Username);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultUserName", Password);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoAdminLogon", "1");
                RegEncryption R = new RegEncryption("DefaultPassword"); R.SetSecret(Password);


            }
            catch (Exception ex) { }

        }
        public static void AutoLogOnUser_AfterLogOff(String Username, string Password)
        {
            try
            {
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoRestartShell", "1", true);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "ForceAutoLogon", "1", true);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultDomainName", Password);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "DefaultUserName", Username);
                DBase.RegistrySetLM("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", "AutoAdminLogon", "1");
                RegEncryption R = new RegEncryption("DefaultPassword"); R.SetSecret(Password);

                WindowLogOff_API();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("access"))
                {
                    //MessageBox.Show("Permission Deny!");
                }
            }

        }
        //Intergrate ContextMenu
        public static void RegisterContextMenu(string fileType, string shellKeyName, string menuText, string menuCommand)
        {
            Debug.Assert(!string.IsNullOrEmpty(fileType) &&
                !string.IsNullOrEmpty(shellKeyName) &&
                !string.IsNullOrEmpty(menuText) &&
                !string.IsNullOrEmpty(menuCommand));

            // create full path to registry location
            string regPath = string.Format(@"{0}\shell\{1}", fileType, shellKeyName);

            // add context menu to the registry
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(regPath))
            {
                key.SetValue(null, menuText);
            }

            // add command that is invoked to the registry
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(
                string.Format(@"{0}\command", regPath)))
            {
                key.SetValue(null, menuCommand);
            }
        }
        public static void UnregisterContextMenu(string fileType, string shellKeyName)
        {
            Debug.Assert(!string.IsNullOrEmpty(fileType) &&
                !string.IsNullOrEmpty(shellKeyName));

            string regPath = string.Format(@"{0}\shell\{1}", fileType, shellKeyName);
            Registry.ClassesRoot.DeleteSubKeyTree(regPath);
        }


        //RemoteDesktop Helper
        public static bool IsIP4Address(string Host)
        {//123.123.123.123
            if (Host.Split('.').Length != 4 || Host.Length > 23 || Host.ToLower().IndexOf(".com") > 1)
                return false;
            if (Host.Length > 15) return false;
            IPAddress IP;
            return IPAddress.TryParse(Host, out IP);
        }
        public static string XorString(string Value, int Shift, bool Outbound)
        {
            if (Outbound)
                Value = Value.Replace(" ", "#SS#");
            string Output = "";
            int Ch = 0;


            for (int f = 0; f <= Value.Length - 1; f++)
            {
                Ch = Convert.ToInt32(Value[f]);
                if (Outbound && Ch == 113)
                    Ch = Convert.ToInt32('¬');
                else if (!Outbound && Ch == 172)
                    Ch = 113;
                else
                    Ch ^= Shift;
                Output += char.ConvertFromUtf32(Ch);
            }
            if (!Outbound)
                return Output.Replace("#SS#", " ");
            else
                return Output;
        }
        public static string GetIP(string Host)
        {
            try
            {
                IPHostEntry IPE = Dns.GetHostEntry(Host);
                foreach (IPAddress IP in IPE.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) return IP.ToString();
                }
            }
            catch { ;}
            return "";

        }
        public static bool IsUserAdministrator()
        {
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        //ScreenPanel
        public static void TakeScreenshot(Panel panel, string filePath)
        {
            if (panel == null)
                throw new ArgumentNullException("panel");

            if (filePath == null)
                throw new ArgumentNullException("filePath");

            // get parent form (may not be a direct parent)
            Form form = panel.FindForm();
            if (form == null)
                throw new ArgumentException(null, "panel");

            // remember form position
            int w = form.Width;
            int h = form.Height;
            int l = form.Left;
            int t = form.Top;

            // get panel virtual size
            Rectangle display = panel.DisplayRectangle;

            // get panel position relative to parent form
            Point panelLocation = panel.PointToScreen(panel.Location);
            Size panelPosition = new Size(panelLocation.X - form.Location.X, panelLocation.Y - form.Location.Y);

            // resize form and move it outside the screen
            int neededWidth = panelPosition.Width + display.Width;
            int neededHeight = panelPosition.Height + display.Height;
            form.SetBounds(0, -neededHeight, neededWidth, neededHeight, BoundsSpecified.All);

            // resize panel (useless if panel has a dock)
            int pw = panel.Width;
            int ph = panel.Height;
            panel.SetBounds(0, 0, display.Width, display.Height, BoundsSpecified.Size);

            // render the panel on a bitmap
            try
            {
                Bitmap bmp = new Bitmap(display.Width, display.Height);
                panel.DrawToBitmap(bmp, display);
                bmp.Save(filePath);
            }
            finally
            {
                // restore
                panel.SetBounds(0, 0, pw, ph, BoundsSpecified.Size);
                form.SetBounds(l, t, w, h, BoundsSpecified.All);
            }
        }

        //System
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        public static void KillProcess(string ProcessName)
        {
            try
            {
                Process[] PList = Process.GetProcesses();
                foreach (Process p in PList)
                {
                    string processname = p.ProcessName;
                    if (processname.ToLower() == ProcessName.ToLower())
                    {
                        p.Kill();
                        //    MessageBox.Show("Kill");
                    }
                }
            }
            catch (Exception ex) { }
        }

        //Process
        public static void RunProcess(String exeFileName, String paramater)
        {


        }

        //Window Power
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        [DllImport("user32")]
        public static extern void LockWorkStation();

        public static void WindowRestart()
        {

            Process.Start("shutdown", " /f /r /t 0"); // 

        }

        public static void WindowLogoff_CMD()
        {
            try
            {
                DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff", "0", true);
            }
            catch (Exception ex) { }
            Process.Start("shutdown", " /f /l /t 0 "); // 

        }
        public static void WindowLogOff_API()
        {
            try
            {
                DBase.RegistrySetCU("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff", "0", true);
            }
            catch (Exception ex) { }
            ExitWindowsEx(0, 0);
        }

        public static void WindowShutdown()
        {
            Process.Start("shutdown", " /f /s /t 0"); // 

        }
     
        public static void WindowLock()
        {
            LockWorkStation();
        }

        public static void WindowHibernate()
        {
            SetSuspendState(true, true, true);
        }
        public static void WindowSleep()
        {
            SetSuspendState(false, true, true);
        }
        private static void StartShutDown(string param)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = "/C shutdown " + param;
            Process.Start(proc);
        }

        public static int IsFolder(string Path)
        {
            int kq = -1;
            try
            {

                FileAttributes attr = File.GetAttributes(Path);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    kq = 1;
                else
                    kq = 0;
            }
            catch (Exception ex)
            {

            }
            return kq;
        }

        //RunCMD  // list http://www.adp-gmbh.ch/win/misc/environment_variables.html
        public static string RunCMD(String strCommand)
        {
            string kq = "";
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "cmd /c " + strCommand);
                Process p = new Process();
                p.StartInfo = procStartInfo;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                kq = p.StandardOutput.ReadToEnd();

             
            }
            catch (Exception ex) { }
            finally
            {
              //  Clipboard.SetText(kq);
            }
            return kq;
        }

        public static void LogException(String Exception)
        {
            try
            {
                if (!Directory.Exists(DBase.LogDirectory)) Directory.CreateDirectory(DBase.LogDirectory);
                System.IO.File.WriteAllText(DBase.LogDirectory + "\\" + "PCT_Log_" + DBase.biDateTimeSave(DateTime.Now) + ".txt", Exception);
            }
            catch (Exception ex) { }
        }

        public static void LayerImage(System.Drawing.Image Current, int LayerOpacity)
        {
            Bitmap bitmap = new Bitmap(Current);
            int h = bitmap.Height;
            int w = bitmap.Width;
            Bitmap backg = new Bitmap(w, h + 20);
            Graphics g = null;
            try
            {
                g = Graphics.FromImage(backg);
                g.Clear(Color.White);
                Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                RectangleF rectf = new RectangleF(70, 90, 90, 50);
                Color color = Color.FromArgb(255, 128, 128, 128);
                Point atpoint = new Point(backg.Width / 2, backg.Height - 10);
                SolidBrush brush = new SolidBrush(color);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString("BRAND AMBASSADOR", font, brush, atpoint, sf);
                g.Dispose();
                MemoryStream m = new MemoryStream();
                backg.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch { }

            Color pixel = new Color();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    backg.SetPixel(x, y, Color.FromArgb(LayerOpacity, pixel));
                }
            }
            //MemoryStream m1 = new MemoryStream();
            //backg.Save(m1, System.Drawing.Imaging.ImageFormat.Jpeg);
            //m1.WriteTo(OutputStream);
            //m1.Dispose();
           
        }

        public static void SoundDeviceSet(string DeviceName)
        {
            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe");
                string cmd1 = " setdefaultsounddevice \"" + DeviceName + "\" 1";
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.LogDirectory + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static void ShowControlForm(Control U, String Title, Icon I)
        {

            Form F = new Form();
            F.StartPosition = FormStartPosition.CenterScreen;
            F.Icon = I;
            F.Text = Title;
            F.Size = U.Size;
            F.Controls.Add(U);
            U.Dock = DockStyle.Fill;
            F.Show();
            F.WindowState = FormWindowState.Normal;
            F.Activate();
        }
       

        public static void ShowControlFormNearBy(Control U, String Title, Icon I, Form FNearBy , int X ,int Y)
        {

            Form F = new Form();
            F.StartPosition = FormStartPosition.Manual;
            F.Location = new Point(FNearBy.Location.X + X, FNearBy.Location.Y + Y);
            F.Icon = I;
            F.Text = Title;
            F.Size = U.Size;
            F.Controls.Add(U);
            U.Dock = DockStyle.Fill;
            F.Show();
            F.WindowState = FormWindowState.Normal;
            F.Activate();
        }

        public static void DownloadAndRun(String FileName)
        {

            DHuy.DownloadFile(FileName, true);
            System.Diagnostics.Process.Start(DBase.LogDirectoryWithSplash + FileName);

        }

        public static void PlaySound()
        {
            DHuy.DownloadFile("SoundTick.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(DBase.AppPath + "SoundTick.wav");
            player.Play();
        }

        public static  IntPtr GetEXEHandler(String ExactEXENAME_Nonexe)
        {
            IntPtr kq = new IntPtr();
            Process[] processes = Process.GetProcessesByName(ExactEXENAME_Nonexe);

            foreach (Process p in processes)
            {
                 kq = p.MainWindowHandle;

                // do something with windowHandle
            }
            return kq;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        //   SetWindowPos(handle, 0, 0, 0, form.Bounds.Width, form.Bounds.Height, SWP_NOZORDER | SWP_SHOWWINDOW);


        public static String StringReturn(DataTable dt, int RowIndex, string FieldName)
        {
            string kq = "";
            try
            {
                kq = DBase.StringReturn(dt.Rows[RowIndex][FieldName]);
            }
            catch (Exception ex) { }
            return kq;
        }

        public static double DoubleReturn(DataTable dt, int RowIndex, string FieldName)
        {
            double kq = 0;
            try
            {
                kq = DBase.DoubleReturn(dt.Rows[RowIndex][FieldName]);
            }
            catch (Exception ex) { }
            return kq;
        }

        public static void SystemVolumn(int Percent, bool Say)
        {
            int Max = 65535;
            int Min = 0;
            int Value = Percent * Max / 100;
            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe",true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe",true);
                string cmd1 = " setsysvolume  " + Value;
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.DataFolderPath + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
              
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static void SystemVolumn_Up()
        {
            int Max = 65535;
            int Min = 0;
           
            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                string cmd1 = " changesysvolume 2000";
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.DataFolderPath + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static void SystemVolumn_Down()
        {
            int Max = 65535;
            int Min = 0;

            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                string cmd1 = " changesysvolume -2000";
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.DataFolderPath + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static void SystemVolumn_Mute()
        {
            //http://www.nirsoft.net/utils/nircmd.html
            int Max = 65535;
            int Min = 0;
            int Value = 0;
            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                string cmd1 = " mutesysvolume 1 ";
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.DataFolderPath + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static void SystemVolumn_MuteToogle()
        {
            //http://www.nirsoft.net/utils/nircmd.html
            int Max = 65535;
            int Min = 0;
            int Value = 0;
            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                string cmd1 = " mutesysvolume 2 ";
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.DataFolderPath + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static void SystemVolumn_Unmute()
        {
            //http://www.nirsoft.net/utils/nircmd.html
            int Max = 65535;
            int Min = 0;
            int Value = 0;
            try
            {
                int kq = DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                if (kq == 0) DHuy.CheckAndUpdateFile("NIRCMDC.exe", true);
                string cmd1 = " mutesysvolume 0 ";
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DBase.DataFolderPath + "\\NIRCMDC.exe", "/c " + cmd1);
                //procStartInfo.WorkingDirectory = DBase.LogDirectory + "\\";
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

        public static DataTable RemoveColumn(DataTable dt, String col)
        {

            try
            {
                string[] List = col.Split(',');
                foreach (string c in List)
                {

                    dt.Columns.Remove(c.Trim());
                }

            }
            catch (Exception ex) { }
            return dt;
        }
        public static DataTable AddColumn(DataTable dt, String ColName)
        {
            try
            {
                dt.Columns.Add(ColName, typeof(String));
            }
            catch (Exception e) { }
            return dt;
        }
        public static DataTable AddColumn(DataTable dt, String ColName, Type T)
        {
            try
            {
                dt.Columns.Add(ColName, T);
            }
            catch (Exception e) { }
            return dt;
        }
        public static DataTable AddColumn(DataTable dt, Type T, string ColNamesPharseSepare)
        {
            String[] S = ColNamesPharseSepare.Split(',');
            try
            {
                foreach (string C in S)
                {
                    dt.Columns.Add(C, T);
                }
            }
            catch (Exception e) { }
            return dt;
        }
        public static DataTable AddColumn(DataTable dt, String ColName, Type T, object defaultValue)
        {
            try
            {
                DataColumn dr = new DataColumn();
                dr.ColumnName = ColName;
                dr.DataType = T;
                dr.DefaultValue = defaultValue;
                dt.Columns.Add(dr);
            }
            catch (Exception e) { }
            return dt;
        }

        public static int SetValue(DataTable dt, string Column, object Value)
        {
            int kq = 0;
            try
            {

                dt.Rows[0][Column] = Value;
                kq = 1;
            }
            catch (Exception ex)
            {

            }
            return kq;

        }

        public static int SetValue(DataTable dt, int RowIndex, string Column, object Value)
        {
            int kq = 0;
            try
            {

                dt.Rows[RowIndex][Column] = Value;
                kq = 1;
            }
            catch (Exception ex)
            {

            }
            return kq;

        }

        public static DataTable SortTable(DataTable dt, string expression)
        {
            DataTable kq = dt;
            try
            {

                dt.DefaultView.Sort = expression;
                int x = dt.Rows.Count;
                dt.DefaultView.RowFilter = string.Empty;
                kq = dt.DefaultView.ToTable(false);
            }
            catch (Exception ex) { }
            return kq;
        }

        public static DataTable FilterTable(DataTable dt, string filterCondition)
        {
            return FilterTableAdvanced(dt, filterCondition);

        }
        public static DataTable FilterTable(DataTable dt, string filterCondition, string SortString)
        {
            DataTable kq = new DataTable();
            try
            {
                kq = FilterTableAdvanced(dt, filterCondition);
            }
            catch (Exception ex)
            { }
            kq = DBase.SortTable(kq, SortString);
            return kq;


        }

        public static DataTable FilterTableAdvanced(DataTable dt, string filterCondition)
        {
            DataTable kq = new DataTable();
            try
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = filterCondition;
                kq = dv.ToTable();

            }
            catch (Exception ex)
            { }
            return kq;


        }

        public static void RestartExplorer()
        {
            Process[]  PList = Process.GetProcesses();
            try
            {
                foreach (Process p in PList)
                {
                   
                    string processname = p.ProcessName;
                    if (processname.ToLower() == "explorer")
                    {
                        p.Kill();
                        break;
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                System.Diagnostics.Process.Start("Explorer.exe");
            }
            
        }

        public static void SetEnvirmoment()
        {
            int kq = DHuy.CheckAndUpdateFile("JustClickSee.json",true);
            if (kq == 0)
            {
                MessageBox.Show("Fail to download json api !");
                return;
            }
          
            string credential_path = DBase.DataFolderPath + "\\JustClickSee.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path, EnvironmentVariableTarget.User);
           // System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path, EnvironmentVariableTarget.Process);
           // System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path, EnvironmentVariableTarget.Machine);
            DBase.RestartExplorer();
        }

        public static int HandleLocation_Top = 0 ;
        public static string ActiveApplicationName()
        {
            string kq = "";
            try
            {
              
                IntPtr hWnd = DWindow.GetForegroundWindow();
                int procId = 0;
                DWindow.GetWindowThreadProcessId(hWnd, out procId);
                var proc = Process.GetProcessById((int)procId);
                kq = proc.ProcessName;

                GB.DWindow.RECT rct = new GB.DWindow.RECT();
                DWindow.GetWindowRect(hWnd, ref rct);
                HandleLocation_Top = rct.Top;

                //if ((DateTime.Now - proc.StartTime).TotalMilliseconds <= 2000)
                //{
                //    kq = "";
                //}
                //MessageBox.Show(proc.ProcessName);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }

            return kq;
        }

        public static string AppentString(String S, String Append, string SepareChar)
        {
            return S != "" ? S + SepareChar + Append : Append;
        }

        public static void StartExplorer()
        {

            //Process[] procs = Process.GetProcessesByName("explorer");
            //foreach (Process p in procs)
            //{
            //    p.Kill();
            //}

            //// Revive explorer
            //Process.Start("explorer.exe");

            //// Wait for explorer window to appear
            //ShellWindows windows;
            //while ((windows = new SHDocVw.ShellWindows()).Count == 0)
            //{
            //    Thread.Sleep(50);
            //}

            //foreach (InternetExplorer p in windows)
            //{
            //    // Close explorer window
            //    if (Path.GetFileNameWithoutExtension(p.FullName.ToLower()) == "explorer")
            //        p.Quit();
            //}
        }

        //Time
        public static string Int2Time(int time)
        {

            string kq = "00:00";
            try
            {
                int hour = time / 60;
                int mintue = time % 60;

                kq = getLineNumber(2, hour) + ":" + getLineNumber(2, mintue);
            }
            catch (Exception ex)
            {

            }
            return kq;

        }

    }
}