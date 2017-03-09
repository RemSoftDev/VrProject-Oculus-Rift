using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VrManager.Commands
{
    public class SingeltonCommandInvoker<TCommand>
        where TCommand : ICommand,new()
    {
        private static TCommand _command;
        public static TCommand Command
        {
            get
            {
                if(_command == null)
                {
                    _command = new TCommand();
                }

                return _command;
            }
        }

    }
}
