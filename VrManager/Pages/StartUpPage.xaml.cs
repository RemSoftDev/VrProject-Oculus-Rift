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
using System.Windows.Threading;
using VrManager.Data.Abstract;
using VrManager.Data.Concrete;
using VrManager.Data.Entity;
using VrManager.Helpers;

namespace VrManager.Pages
{
    /// <summary>
    /// Interaction logic for StartUpPage.xaml
    /// </summary>
    public partial class StartUpPage : Page
    {
        EntityRepository _rep;
        private bool v;

        public StartUpPage(bool v)
        {
            try
            {
                InitializeComponent();
                App.MainWnd.ShowHomeButton(true);
                _rep = App.Repository;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }


        }

        public StartUpPage()
        {
            try
            {
                InitializeComponent();
                _rep = App.Repository;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new TablesPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void Videos360_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<ModelVideo> videos360 = _rep.Videos.Where(x => x.TypeItem == TypeItem.Video360).ToList();
                App.Frame.Navigate(new ShowVideoListPage(videos360, TypeItem.Video360));
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void SettingTile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new SettingMenuPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void SingIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new AuthorizePage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void SingOut_Click(object sender, RoutedEventArgs e)
        {
            App.IsAuthorized = false;
            try
            {
                var entry = App.Frame.RemoveBackEntry();

                while (entry != null)
                {
                    entry = App.Frame.RemoveBackEntry();
                }

                App.Frame.Navigate(new PageFunction<string>() { RemoveFromJournal = true });
                App.Frame.Navigate(new StartUpPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PermissionsHelper.PermissionsLicense(Videos360, Videos5D, Games, Data, SingIn, SingOut);
                PermissionsHelper.PermissionsAdmin(Data, Statistic);

                if (App.ІsLicensed)
                {
                    if (App.IsAuthorized && App.ІsLicensed)
                    {
                        SingIn.Visibility = Visibility.Collapsed;
                        SingOut.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        SingIn.Visibility = Visibility.Visible;
                        SingOut.Visibility = Visibility.Collapsed;
                    }
                }

                App.MainWnd.ChangeTitle(Title);

                System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void Videos5D_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<ModelVideo> videos360 = _rep.Videos.Where(x => x.TypeItem == TypeItem.Video5D).ToList();
                App.Frame.Navigate(new ShowVideoListPage(videos360, TypeItem.Video5D));
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        private void Games_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new ShowVideoListPage(_rep.Games.ToList(), TypeItem.Game));
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Frame.Navigate(new StatisticPage());
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
    }
}
