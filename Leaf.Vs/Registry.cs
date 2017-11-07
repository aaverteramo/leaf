using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf.Vs
{
    public static class Registry
    {
        public static void ProjectTypeGuids(string vsVersion)
        {
            var result = Microsoft.Win32.Registry.LocalMachine
                .OpenSubKey("SOFTWARE")
                .OpenSubKey("Microsoft")
                .OpenSubKey("VisualStudio")
                .OpenSubKey(vsVersion)
                .OpenSubKey("Projects");
            var keys = result.GetSubKeyNames();
        }
    }
}
