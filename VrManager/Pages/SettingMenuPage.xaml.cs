using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VrManager.Helpers;

namespace VrManager.Pages
{
    /// <summary>
    /// Interaction logic for SettingMenu.xaml
    /// </summary>
    public partial class SettingMenuPage : Page
    {
        public SettingMenuPage()
        {
            InitializeComponent();
        }

        private void MainSettingTile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new MainSettingPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void PersonalizationSettingTile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new PersonalizationSettingsPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void thisPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                App.MainWnd.ChangeTitle(Title);
                PermissionsHelper.PermissionsLicense(MainSettingTile, PersonalizationSettingTile, ChangePasswordTile, OpenSettingPlayer);
                PermissionsHelper.PermissionsAdmin(MainSettingTile, PersonalizationSettingTile, ChangePasswordTile, OpenSettingPlayer);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void ChangePasswordTile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new ChangePasswordPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void ChangeFileLicense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new CheckLicensePage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void OpenSettingPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenVrPleyerHelper.OpenVrPlayerForSetting();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }

        }

        private void thisPage_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenVrPleyerHelper.CloseVrPlayerForSetting();
                App.MainWnd.Topmost = App.Setting.IsKioskMode;
                App.LockDisplayWindow.Topmost = App.Setting.IsKioskMode;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
    }
}
