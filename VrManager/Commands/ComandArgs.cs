using System.Runtime.CompilerServices;

namespace VrManager.Commands
{
    public class ComandArgs
    {
        public string Uri { get; private set; }

        public object Params1 { get; private set; }
        public object Params2 { get; private set; }

        public ComandArgs(string uri, object param1, object param2 = null)
        {
            Uri = uri;
            Params1 = param1;
            Params2 = param2;
        }
    }
}