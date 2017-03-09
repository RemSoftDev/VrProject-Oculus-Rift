using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VrManager.Navigation;

namespace VrManager.Commands
{
    /// <summary>
    /// Represents a command which 'CanExecure' method ALWAYS returns true.
    /// </summary>
    public abstract class UncoditionalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
    }
}
