using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VrManager.Extensions;

namespace VrManager.Multiscreening
{
    public class ScreenManager
    {
        #region Singleton
        private static Lazy<ScreenManager> _signleton = new Lazy<ScreenManager>();
        public static ScreenManager Singleton() => _signleton.Value;
        #endregion

        private Screen[] _availableScreens = Screen.AllScreens;
        private readonly Dictionary<WindowScreenStatus, Window> _availableWindows =
            new Dictionary<WindowScreenStatus, Window>
            {
                { WindowScreenStatus.Primary, null },
                { WindowScreenStatus.Secondary, null }
            };

        public bool Has2Screens => _availableScreens.Length == 2;

        #region ...WindowAs<T>()
        private T WindowAs<T>(WindowScreenStatus windowStatus) where T : Window => (T)_availableWindows[windowStatus];

        /// <summary>
        /// Returns current primary window casted to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T PrimaryWindowAs<T>() where T : Window => WindowAs<T>(WindowScreenStatus.Primary);

        /// <summary>
        /// Returns current seconadry window casted to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SecondaryWindowAs<T>() where T : Window => WindowAs<T>(WindowScreenStatus.Secondary);
        #endregion

        private void FitToScreen(Window window, Screen screen)
        {
            window.Width = screen.WorkingArea.Width;
            window.Left = screen.WorkingArea.Left;
            window.Height = screen.WorkingArea.Height;
            window.Top = screen.WorkingArea.Top;
        }

        private Screen GetScreen(WindowScreenStatus windowStatus)
        {
            return _availableScreens.First(
                screen => {
                    return screen.Primary == windowStatus.IsPrimary();
                    } );
               
        }

        public Window NewWindow(Window window, WindowScreenStatus windowStatus)
        {
            _availableWindows[windowStatus] = window;
            FitToScreen(window, GetScreen(windowStatus));

            return window;
        }

    }
}
