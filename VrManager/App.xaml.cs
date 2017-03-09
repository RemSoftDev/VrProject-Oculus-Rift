using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VrManager.ProgramSetting;
using VrManager.Data.Concrete;
using System.IO;
using VrManager.Helpers;
using VrManager.Pages;
using log4net;
using VrManager.Data.Entity;
using System.Diagnostics;
using log4net.Appender;
using VrManager.Multiscreening;
using VrManager.Commands;

namespace VrManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static bool _isLicensed = false;
        private static Setting _setting;
        public static bool IsAuthorized { get; set; }
        public static ModelUser AuthorizedUser { get; internal set; }
        public static bool ІsLicensed
        {
            get
            {
                return _isLicensed;
            }
            set
            {
                _isLicensed = value;
            }
        }
        public static ProcessorHelper CurrentProceess { get; set; }
        public static ILog Logger { get; private set; } = LogManager.GetLogger("VrManagerLogger");
        public static MainWindow MainWnd { get; set; }
        public static LockScreenWindow LockDisplayWindow { get; set; }
        public static Frame Frame { get; set; }
        public static Setting Setting
        {
            get
            {
                return _setting ?? (_setting = new Setting());
            }

        }
        public static EntityRepository Repository = new EntityRepository();

        public static string PathToBackgroundImage
        {
            get
            {
                try
                {
                    return (App.Setting.PathToFolderFiles + FolderHelper.ConfigBackground + @"\Background.png");
                }
                catch (Exception ex)
                {
                    App.SendException(ex);
                    return null;
                }
            }
        }
        public static int CurentVideoMonitor = 0;

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                if (MonitorManager.IsTwoMonitor)
                {
                    LockDisplayWindow.Close();
                }
                MainWnd.Close();
                Taskbar.Show();

                if (CurrentProceess?.IsProcessOpened ?? false)
                {
                    CurrentProceess.StopProcess();
                }
                Repository.Dispose();
                Logger.Info("End seanse in VrManager!!!!!");
            }
            catch (Exception ex)
            {
                SendException(ex);
            }
        }

        public static void SendException(Exception ex)
        {
            App.Logger.Error($"exeption {ex.Message} ||| in class {nameof(App)} and method {GetStackTraseMethod().GetMethod().Name} \n {ex.StackTrace}");
        }

        public static StackFrame GetStackTraseMethod()
        {
            try
            {
                return _stackTrace.GetFrame(1);
            }
            catch (Exception ex)
            {
                App.Logger.Error($"exeption {ex.Message} ||| in class {nameof(App)} and method  \n {ex.StackTrace}");
                return null;
            }
        }

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                Logger.Info("Start seanse in VrManager!!!!!");
                var a = App.Repository.Setting;
            }
            catch (Exception ex)
            {
                App.Logger.Error($"exeption {ex.Message} (Пожалуста установите Microsoft SQL Server Compact 4.0) ||| in class {nameof(App)} and method {GetStackTraseMethod().GetMethod().Name}");
                MessageBox.Show("Пожалуста установите Microsoft SQL Server Compact 4.0");
                return;
            }
            try
            {
               // MainWnd = new MainWindow();
               
                var _rep = App.Repository;

                ScreenManagerInit();
                

                if (_rep.Setting.FirstOrDefault() == null)
                {
                    _rep.FirstExecute();
                }
                else
                {
                    Setting.Import();
                }

                ObserverUserActivity.StartActivityObserv();

                if (App.Setting.IsKioskMode)
                {
                    Taskbar.Hide();
                    MainWnd.Topmost = true;
                }
                else
                {
                    MainWnd.Topmost = false;
                }

                ShowWindows();

                MonitorManager.RestartPositionWindows();
                CommandInvoker<NavigateToCommand>.Command.Execute(nameof(StartUpPage));
            }
            catch (Exception ex)
            {
                try
                {
                    MainWnd.Show();
                }
                catch
                {
                    App.SendException(ex);
                    MessageBox.Show("Подключите оккулус или второй монитор");
                }

                CommandInvoker<NavigateToCommand>.Command.Execute(nameof(MainSettingPage));
            }

        }

        private static void ShowWindows()
        {
            if (ScreenManager.Singleton().Has2Screens)
            {
                LockDisplayWindow.Show();
            }

            MainWnd.Show();
        }

        private void LoadFontsToStyle()
        {
            //StyleManager.AddIconFont("OpenFileDialog");
        }


        private static void ScreenManagerInit()
        {
            MainWnd = new MainWindow();

            if (ScreenManager.Singleton().Has2Screens)
            {
                LockDisplayWindow = new LockScreenWindow();
                ScreenManager.Singleton().NewWindow(MainWnd, WindowScreenStatus.Secondary);
                ScreenManager.Singleton().NewWindow(LockDisplayWindow, WindowScreenStatus.Primary);
            }
            else
            {
                MessageBox.Show("Пожалуйста подключите второй монитор или окулус");
                return;
            }
        }


        public static void RestartApp()
        {
            try
            {

                var _rep = App.Repository;
                MainWnd = new MainWindow();

                ScreenManagerInit();

                if (_rep.Setting.FirstOrDefault() == null)
                {
                    _rep.FirstExecute();
                }
                else
                {
                    Setting.Import();
                }


                if (App.Setting.IsKioskMode)
                {
                    Taskbar.Hide();
                    MainWnd.Topmost = true;
                }
                else
                {
                    MainWnd.Topmost = false;
                }

                if (MonitorManager.IsTwoMonitor)
                {
                    LockDisplayWindow.Show();
                }
                MainWnd.Show();
                MonitorManager meneger = new MonitorManager();

                if (MonitorManager.IsTwoMonitor)
                {
                    MonitorManager.RestartPositionWindows();
                }

            }
            catch (Exception ex)
            {
                MainWnd.Show();
                App.Frame.Navigate(new MainSettingPage(true));

                SingeltonCommandInvoker<NavigateToCommand>.Command.Execute(new ComandArgs(nameof(MainSettingPage),true));
            }
        }
        public static bool IsVideoMod { get; set; } = false;

        public static RoutedEventHandler LaunchMedia;
        public static RoutedEventHandler StartMedia;
        public static RoutedEventHandler PauseMedia;
        public static RoutedEventHandler StopMedia;
        private static StackTrace _stackTrace = new StackTrace();

        public static void OnLaunchMedia()
        {
            LaunchMedia?.Invoke(null, null);
        }
        public static void OnStartMedia()
        {
            StartMedia?.Invoke(null, null);
        }
        public static void OnPauseMedia()
        {
            PauseMedia?.Invoke(null, null);
        }
        public static void OnStopMedia()
        {
            StopMedia?.Invoke(null, null);
        }

        internal static void SendMessage(string message)
        {
            App.Logger.Info(message);
        }
    }
}
