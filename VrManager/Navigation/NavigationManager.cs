using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VrManager.Pages;

namespace VrManager.Navigation
{
    public sealed class NavigationManager
    {
        private NavigationManager() { }

        private static readonly NavigationManager _singleton = new NavigationManager();
        private readonly IList<Page> _history = new List<Page>();

        public static NavigationManager Singleton { get => _singleton; }

        public IList<Page> History { get => _singleton._history; }
        public Frame Frame { get; private set; }
        public bool CanGoBack { get => _singleton.Frame.CanGoBack; }
        public bool CanGoForward { get => _singleton.Frame.CanGoForward; }
        //   public bool CanGoHome { get => _singleton.Frame.Content is typeof(this.GetPageByName(_homePage));}
        //public bool CanGoHome
        //{
        //    //get
        //    //{
        //    //    var page = _singleton.Frame.Content; 
                
        //    //    if()
        //}
    

    //public void Memorize(Page page) => _singleton._history.Add(page);
    //public void RemoveLast() => _singleton._history.RemoveAt(_singleton._history.Count - 1);
    //public void GoBack() => _singleton.Frame.GoBack();
    //public void GoForward() => _singleton.Frame.GoForward();
    public void GoHome()
    {
        Frame.Navigate(GetPageByName("StartUpPage"));
    }

    public Page GetPageByName(string pageName)
    {
        switch (pageName)
        {
            case "AuthorizePage": return new AuthorizePage();
            case "ChangePasswordPage": return new ChangePasswordPage();
            case "CheckLicensePage": return new CheckLicensePage();
            case "GameAddOrEditDialogPage": return new GameAddOrEditDialogPage(); //To Do Realise
            case "InstallAdditionalComponentPage": return new InstallAdditionalComponentPage();
            case "MainSettingPage": return new MainSettingPage(); //To Do Main Setting
            case "PersonalizationSettingsPage": return new PersonalizationSettingsPage();
            case "SettingMenuPage": return new SettingMenuPage();
            case "StartUpPage": return new StartUpPage();
            case "StatisticPage": return new StatisticPage();
            case "TablesPage": return new TablesPage();
            case "TestSendingCOMPage": return new TestSendingCOMPage();
            case "TestServicePage": return new TestServicePage();
            case "VideoAddOrEditDialogPage": return new VideoAddOrEditDialogPage(); //To Do Realise

            default: throw new ArgumentException();
        }
    }

}
}


