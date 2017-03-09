using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VrManager.Multiscreening;

namespace VrManager.Extensions
{
    public static class Extensions
    {
        public static bool IsPrimary(this WindowScreenStatus @this) => @this == WindowScreenStatus.Primary;
    }
}
