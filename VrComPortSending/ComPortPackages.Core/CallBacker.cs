using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComPortPackages.Core
{
    public class CallBacker
    {
        public static Action<Exception> CallBackException;
        public static Action<string> CallBackMessage;
    }
}
