using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace VrManager.Helpers
{
    public static class ObserverUserActivity
    {
        private static DispatcherTimer TimerObserver;

        private static TimeSpan _timeFOrCheck = new TimeSpan(0, 0, 5);
        public static TimeSpan TimeForCheck
        {
            get
            {
                return _timeFOrCheck;
            }
            set
            {
                _timeFOrCheck = value;
            }
        }
        public static TimeSpan CurrentTime { get; set; }
        public static bool IsUserActive { get; private set; }
        public static bool IsAdvertisingShowing { get; private set; } = false;
        

        public static event EventHandler HideAdvertising;
        public static event EventHandler ShowAdvertising;

        public static void StartActivityObserv()
        {
            try
            {
                TimerObserver = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromSeconds(1)
                };


                App.MainWnd.SetAdvertisingVideo(GetUriVideoList());

                TimerObserver.Tick += TimerObserver_Tick;
                App.MainWnd.MouseMove += HookMouse;
                try
                {
                    App.LockDisplayWindow.MouseMove += HookMouse;
                }
                catch
                {
                    MessageBox.Show("Подключите пожалуйста второй монитор или Окулус");
                }
                App.MainWnd.KeyUp += HookKey;
                App.LockDisplayWindow.KeyUp += HookKey;

                CurrentTime = new TimeSpan(0, 0, 0);
                TimerObserver.Start();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private static List<Uri> GetUriVideoList()
        {
            try
            {
                string pathToFolder = App.Setting.PathToFolderFiles + @"\Video\AdvertisingVideo";
                string[] allFileInDirectory = Directory.GetFiles(pathToFolder);
                List<Uri> list = new List<Uri>();

                foreach (string file in allFileInDirectory)
                {
                    list.Add(new Uri(file));
                }

                if (list.Count == 0)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }

        public static void ResumeActivityObserv()
        {
            try
            {
                if (!TimerObserver.IsEnabled)
                {
                    TimerObserver.Start();
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        public static void EndActivityObserv()
        {
            try
            {
                TimerObserver.Stop();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private static void HookComplited()
        {
            try
            {
                if (IsAdvertisingShowing)
                {
                    HideAdvertising?.Invoke(TimerObserver, new EventArgs());
                    IsAdvertisingShowing = false;
                }
                IsUserActive = true;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private static void HookKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                HookComplited();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private static void HookMouse(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                IsUserActive = true;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private static void TimerObserver_Tick(object sender, EventArgs e)
        {
            try {
                CurrentTime += TimeSpan.FromSeconds(1);

                if (CurrentTime == TimeForCheck)
                {
                    if (IsUserActive && !IsAdvertisingShowing)
                    {
                        HideAdvertising?.Invoke(TimerObserver, new EventArgs());
                    }
                    else
                    {
                        IsAdvertisingShowing = true;
                        ShowAdvertising?.Invoke(TimerObserver, new EventArgs());
                    }

                    IsUserActive = false;
                    CurrentTime = new TimeSpan(0, 0, 0);
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

    }

       
}
