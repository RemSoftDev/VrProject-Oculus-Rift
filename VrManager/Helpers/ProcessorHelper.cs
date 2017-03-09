using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VrManager.Data.Abstract;
using VrManager.Pages;

namespace VrManager.Helpers
{
   public abstract class ProcessorHelper : IDisposable
    {
        protected static Process _currentProcess;
        protected static bool _isLongLaunch;
        

        public string WorkingDirectory { get; set; }
        public string NameProcess { get; set; }

        public bool IsProcessOpened { get; protected set; } = false;

        public virtual void LaunchProcess()
        {
            try
            {
                IntPtr gameHandle = WinAPI.FindWindow(null, NameProcess);
                WinAPI.ShowWindow(gameHandle, 3);

                WinAPI.SetForegroundWindow(gameHandle);
                IsProcessOpened = true;
                App.MainWnd.Topmost = App.Setting.IsKioskMode;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        public virtual void StopProcess()
        {
            try
            {
                _currentProcess.Kill();
                _currentProcess.WaitForExit();
                IsProcessOpened = false;
            }
            catch(Exception ex)
            {
                App.SendException(ex);
                WinAPI.TerminateProcess(_currentProcess.Handle, (uint)_currentProcess.ExitCode);
            }
        }

        public IntPtr GetWindowHandl()
        {
            try
            {
                return _currentProcess.Handle;
            }
            catch(Exception ex)
            {
                App.SendException(ex);
                return WinAPI.FindWindow(null, NameProcess);
            }
        }

        public void Dispose()
        {
            try
            {
                StopProcess();
                _currentProcess.Dispose();
            }
            catch(Exception ex)
            {
                App.SendException(ex);
            }
        }

    }
}
