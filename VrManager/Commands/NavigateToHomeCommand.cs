using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VrManager.Multiscreening;
using VrManager.Pages;

namespace VrManager.Commands
{
    class NavigateToHomeCommand : NavigateToCommand
    {
        public override bool CanExecute(object parameter)
        {
            return !IsHomePage();
        }

        public override void Execute(object parameter)
        {
            base.Execute(nameof(StartUpPage)); 
        }

        public bool IsHomePage()
        {
            Frame frame = ScreenManager.Singleton()
                .SecondaryWindowAs<MainWindow>()
                .MainFrame;

            return frame.Content is StartUpPage;
        }


    }
}

