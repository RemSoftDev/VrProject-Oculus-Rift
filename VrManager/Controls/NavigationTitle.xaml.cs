using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VrManager.Commands;
using VrManager.Multiscreening;
using VrManager.Pages;

namespace VrManager.Controls
{
    public partial class NavigationTitle
    {
        private void BrowseHome_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !ScreenManager.Singleton().SecondaryWindowAs<MainWindow>().IsHomePage;
        }

        private void AppClose_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void BrowseHome_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new NavigateToCommand().Execute(nameof(StartUpPage));
        }

        private void AppClose_ExecuteAppClose(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
