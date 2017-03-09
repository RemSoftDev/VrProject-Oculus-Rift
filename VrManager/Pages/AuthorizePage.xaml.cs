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
using VrManager.Data.Concrete;
using VrManager.Data.Entity;
using VrManager.Helpers;

namespace VrManager.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
        private bool _close = false;

        public AuthorizePage()
        {
            try
            {
                InitializeComponent();
                App.MainWnd.ChangeTitle(Title);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        public AuthorizePage(bool close)
        {
            try
            {
                InitializeComponent();
                _close = close;
                App.MainWnd.ChangeTitle("Выход");
                Authorize.Visibility = Visibility.Collapsed;
                AuthorizeEndOut.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = TB_Login.Text;
                string password = Hesher.MD5Hash(TB_Password.Password);
                bool userExist = false;
                ModelUser findedUser = null;

                foreach (ModelUser user in App.Repository.Users)
                {
                    if (login == user.Login)
                    {
                        userExist = true;
                        findedUser = user;
                    }
                }

                if (!userExist)
                {
                    ShowValidMessageLogin();
                    return;
                }

                if (password == findedUser.Password)
                {
                    if (_close)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        App.IsAuthorized = true;
                        var entry = App.Frame.RemoveBackEntry();

                        while (entry != null)
                        {
                            entry = App.Frame.RemoveBackEntry();
                        }

                        App.Frame.Navigate(new PageFunction<string>() { RemoveFromJournal = true });
                        App.AuthorizedUser = findedUser;
                        App.Frame.Navigate(new StartUpPage());
                    }
                }
                else
                {
                    ShowValidMessagePassword();
                    return;
                }
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
                App.MainWnd.ChangeTitle(Title);
                FocusManager.SetFocusedElement(this, TB_Login);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void ShowValidMessageLogin()
        {
            try
            {
                PasswordValidMessage.Visibility = Visibility.Collapsed;
                LoginValidMessage.Visibility = Visibility.Visible;
                LoginValidMessage.Text = "Пользуватель с таким именем не найден";
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void ShowValidMessagePassword()
        {
            try
            {
                LoginValidMessage.Visibility = Visibility.Collapsed;
                PasswordValidMessage.Visibility = Visibility.Visible;
                PasswordValidMessage.Text = "Неверный пароль";
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }


    }
}
