using System;
using System.Collections.Generic;
 
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Gma.UserActivityMonitorDemo;
using Google.Cloud.Translation.V2;

namespace GB
{
    //http://www.nirsoft.net/utils/nircmd.html
    static class Program
    {


       //public static KeyboardHook kh;
        [STAThread]
        static void Main( string[] para )
        {
            try
            {
                DBase.GetFood(true);
                DBase.LoadSetting();
            
                try
                {
                    if (!Directory.Exists(DBase.LogDirectory))
                    {
                        Directory.CreateDirectory(DBase.LogDirectory);
                    }
                    if (!Directory.Exists(DBase.WallpaperPath))
                    {
                        Directory.CreateDirectory(DBase.WallpaperPath);
                    }

                    if (!Directory.Exists(DBase.DataFolderPath))
                    {
                        Directory.CreateDirectory(DBase.DataFolderPath);
                    }
                }
                catch (Exception ex) { }
            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DBase.SetSystemFormat();

                Process[] P;
                P = Process.GetProcesses();
                int count = 0;
                int curSessionID = System.Diagnostics.Process.GetCurrentProcess().SessionId;
                int StartnewInstance = 0;
                foreach (Process p in P)
                {
                    string processname = p.ProcessName;
                    if (processname.ToLower() == "JustClickSee".ToLower())
                    {
                        if (p.SessionId != curSessionID)
                        {
                            try
                            {
                                p.Kill();
                                StartnewInstance = 1;
                            }
                            catch (Exception ex)
                            {
                            StartnewInstance = 1;

                            }
                        }
                        else count++;
                    }
                }

                if (count > 1 )
                {
                    if (!File.Exists(DBase.DetectInstanceFile)) File.Create(DBase.DetectInstanceFile);
                    return;
                }
                else
                {
                    ZMain Z = new ZMain();
                    Z.Visible = false;
                    Application.Run(Z);
                }
            }
            catch (Exception ex)
            {
               if( DBase.ShowException == 1 ) MessageBox.Show("Main error Proram" + ex.ToString());
            }


        }
    }
}
