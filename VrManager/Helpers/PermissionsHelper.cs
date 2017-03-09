using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VrManager.Pages;

namespace VrManager.Helpers
{
    public class PermissionsHelper
    {
        public static void PermissionsAdmin(params FrameworkElement[] elements)
        {
            try
            {
                if (App.IsAuthorized)
                {
                    foreach (FrameworkElement element in elements)
                    {
                        element.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    foreach (FrameworkElement element in elements)
                    {
                        element.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static void PermissionsLicense(params FrameworkElement[] elements)
        {
            try
            {
                if (App.ІsLicensed)
                {
                    foreach (FrameworkElement element in elements)
                    {
                        element.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    foreach (FrameworkElement element in elements)
                    {
                        element.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static void NotLicensedPage()
        {
            try
            {
                if (!App.ІsLicensed)
                {
                    App.Frame.Navigate(new StartUpPage());
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static void NotAuthprizePage()
        {
            try
            {
                if (!App.ІsLicensed)
                {
                    App.Frame.Navigate(new StartUpPage());
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
    }
}
