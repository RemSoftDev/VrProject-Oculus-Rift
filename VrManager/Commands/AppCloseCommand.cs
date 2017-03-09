using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrManager.Commands
{
    class AppCloseCommand : UncoditionalCommand
    {
        public override bool CanExecute(object parameter)
        {
#if DEBUG
            return true;
#else
            return App.IsAuthorized;
#endif
        }

        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }

    }
}
