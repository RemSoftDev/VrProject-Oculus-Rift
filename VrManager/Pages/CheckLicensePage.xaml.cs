using Microsoft.Win32;
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
    /// Interaction logic for CreateLicensePage.xaml
    /// </summary>
    public partial class CheckLicensePage : Page
    {
        public CheckLicensePage()
        {
            InitializeComponent();
            App.MainWnd.ChangeTitle(Title);
        }

        private void Btn_FilePicker_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "(*.lic) | *.lic";

                if (dialog.ShowDialog() == true)
                {
                    TB_LicensePath.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void Btn_CheckLicense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Setting.PathToLicense = TB_LicensePath.Text;
                App.Setting.Export();
                App.Frame.Navigate(new StartUpPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TB_LicensePath.Text = App.Setting.PathToLicense;
            
        }

        private void Btn_CreateFileConfig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LicenseProvider license = new LicenseProvider();

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "(*.info) | *.info";
                dialog.FileName = "Client";

                if (dialog.ShowDialog() == true)
                {
                    license.CreateClientFileInfo(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
    }
}
