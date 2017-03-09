using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VrManager.Navigation;
using VrManager.Pages;
using VrManager.Multiscreening;
using VrManager.Data.Entity;
using VrManager.Data.Abstract;

namespace VrManager.Commands
{
    class NavigateToCommand : UncoditionalCommand
    {
        public override bool CanExecute(object parameter)
        {
            var pageName = parameter as string;

            if (!string.IsNullOrWhiteSpace(pageName) && pageName.Contains("Page"))
            {
                if (File.Exists($@"Pages\{pageName}"))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            if (parameter is string)
            {
                Page page = GetPageByName((string)parameter);
                ScreenManager.Singleton().SecondaryWindowAs<MainWindow>().NavigateTo(page);
            }
            if(parameter is ComandArgs)
            {
                ComandArgs args = (ComandArgs)parameter;
                Page page = GetPageByName(args.Uri, args.Params1, args.Params2);
                ScreenManager.Singleton().SecondaryWindowAs<MainWindow>().NavigateTo(page);
            }
          
        }

        private Page GetPageByName(string pageName)
        {
            switch (pageName)
            {
                case (nameof(StartUpPage)): return new StartUpPage();
                case (nameof(AuthorizePage)): return new AuthorizePage();
                case (nameof(ChangePasswordPage)): return new ChangePasswordPage();
                case (nameof(CheckLicensePage)): return new CheckLicensePage();
                case (nameof(GameAddOrEditDialogPage)): return new GameAddOrEditDialogPage();
                case (nameof(InstallAdditionalComponentPage)): return new InstallAdditionalComponentPage();
                case (nameof(MainSettingPage)): return new MainSettingPage();
                case (nameof(PersonalizationSettingsPage)): return new PersonalizationSettingsPage();
                case (nameof(SettingMenuPage)): return new SettingMenuPage();
                case (nameof(StatisticPage)): return new StatisticPage();
                case (nameof(TablesPage)): return new TablesPage();
                case (nameof(TestSendingCOMPage)): return new TestSendingCOMPage();
                case (nameof(TestServicePage)): return new TestServicePage();
                case (nameof(VideoAddOrEditDialogPage)): return new VideoAddOrEditDialogPage();
                case (nameof(VideoControlerPage)): return new VideoControlerPage();

                default: throw new ArgumentException();
            }
        }

        private Page GetPageByName(string pageName, object param1, object param2 = null)
        {
            switch (pageName)
            {
                case (nameof(StartUpPage)):
                    {
                        bool p = (bool)param1;
                        return new StartUpPage(p);
                    }

                case (nameof(AuthorizePage)):
                    {
                        bool p = (bool)param1;
                        return new AuthorizePage(p);
                    }

                case (nameof(GameAddOrEditDialogPage)):
                    {
                        ModelGame p = (ModelGame)param1;
                        return new GameAddOrEditDialogPage(p);
                    }

                case (nameof(MainSettingPage)):
                    {
                        bool p = (bool)param1;
                        return new MainSettingPage(p);
                    }

                case (nameof(TablesPage)):
                    {
                        TypeItem p = (TypeItem)param1;
                        return new TablesPage(p);
                    }

                case (nameof(VideoAddOrEditDialogPage)):
                    {
                        if(param2 == null)
                        {
                            TypeItem p = (TypeItem)param1;
                            return new VideoAddOrEditDialogPage(p);
                        }
                        else
                        {
                            TypeItem p1 = (TypeItem)param1;
                            ModelVideo p2 = (ModelVideo)param2;
                            return new VideoAddOrEditDialogPage(p1, p2);
                        }
                    }
                case (nameof(VideoControlerPage)):
                    {
                        if(param1 is ModelVideo)
                        {
                            ModelVideo p = (ModelVideo)param1;
                            return new VideoControlerPage(p);
                        }
                        else
                        {
                            ModelGame p = (ModelGame)param1;
                            return new VideoControlerPage(p);
                        }
                    }

                default: throw new ArgumentException();
            }
        }
    }
}
