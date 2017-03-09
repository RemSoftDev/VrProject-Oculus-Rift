

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VrManager.Controls;
using VrManager.Data.Entity;
using VrManager.Service;

namespace VrManager.Helpers
{
    class OpenVrPleyerHelper : ProcessorHelper
    {
        private static OpenVrPleyerHelper _vrPlayerForSetting;

        public int? MonitorNumber { get; set; }


        public string PathToVideo { get; set; }
        public string StartupParameters { get; set; } = "-fullscreen:true -screen:0 -xpos:1920 -ypos:0 -pause:true ";
        public string PathToVideoSetting { get; internal set; }
        public ModelVideo Video { get; private set; }

        public OpenVrPleyerHelper(ModelVideo video)
        {
            try
            {
                Video = video;
                NameProcess = "VrPlayer.exe";
#if (DEBUG)
                WorkingDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\VrPlayer\VrPlayer\bin\Debug";
#else
                WorkingDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\VrPlayer";
#endif

                if (!IsProcessOpened)
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    //  proc.UseShellExecute = true;
                    proc.WorkingDirectory = WorkingDirectory;
                    proc.FileName = NameProcess;
                    proc.Verb = "runas";
                    proc.Arguments = StartupParameters + "-config:\"" + video.VrSettingPath + "\" -media:\"" + video.ItemPath + "\"";
                    _currentProcess = new Process { StartInfo = proc };
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public OpenVrPleyerHelper()
        {
            try
            {
                NameProcess = "VrPlayer.exe";
#if (DEBUG)
                WorkingDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\VrPlayer\VrPlayer\bin\Debug";
#else
                WorkingDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\VrPlayer";
#endif

                if (!IsProcessOpened)
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    //      proc.UseShellExecute = true;
                    proc.WorkingDirectory = WorkingDirectory;
                    proc.FileName = NameProcess;
                    proc.Verb = "runas";
                    _currentProcess = new Process { StartInfo = proc };
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        

        public override void LaunchProcess()
        {
            try
            {
                App.MainWnd.Topmost = false;
                MonitorManager maneger = new MonitorManager();

                _currentProcess.Start();
                _currentProcess.WaitForInputIdle();

                while (!IsProcessVrPlayerCreated())
                {
                    Thread.Sleep(100);
                }

                App.MainWnd.WindowState = System.Windows.WindowState.Normal;
                App.MainWnd.WindowState = System.Windows.WindowState.Maximized;

                if (MonitorNumber != null)
                {
                    maneger.SetLocations((int)MonitorNumber);
                }

                switch (MonitorNumber)
                {
                    case 1:
                        MonitorManager.CenteredCursorInLeft();
                        break;
                    case 2:
                        MonitorManager.CenteredCursorInRight();
                        break;
                }

                ClientService service = new ClientService();
                service.ChangeToampostMode(true);

                base.LaunchProcess();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public bool IsProcessVrPlayerCreated()
        {
            try
            {
                IntPtr windowHandl = WinAPI.FindWindow(null, "VR Player");
                return windowHandl != IntPtr.Zero;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return false;
            }
        }

        public static void OpenVrPlayerForSetting()
        {
            try
            {
                _vrPlayerForSetting = new OpenVrPleyerHelper();

                ClientService service = new ClientService();
                _vrPlayerForSetting.LaunchProcess();
                App.MainWnd.Topmost = false;
                App.LockDisplayWindow.Topmost = false;

                service.ChangeToampostMode(false);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static void CloseVrPlayerForSetting()
        {
            try
            {
                _vrPlayerForSetting.Dispose();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }



    }

  
}
