using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HConsole
{
    

    /// <summary>
    /// Class for provide function in terms of app ui
    /// </summary>
    public static class App 
    {

        public static void WriteAppHeader()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            var descriptionAttribute = Assembly.GetEntryAssembly()
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                .OfType<AssemblyDescriptionAttribute>()
                .FirstOrDefault();


            string appName = versionInfo.ProductName.ToUpper();
            string version = versionInfo.ProductVersion;
            string copyright = versionInfo.LegalCopyright;
            string desc = (descriptionAttribute != null) ? descriptionAttribute.Description : string.Empty;

            char sideToken = '#';

            ConsoleCore.WriteHorizontalLine();
            ConsoleCore.WriteText(appName, Align.Center, ' ', sideToken);
            ConsoleCore.WriteText(version, Align.Center, ' ', sideToken);
            ConsoleCore.WriteText(copyright, Align.Center, ' ', sideToken);
            ConsoleCore.WriteText(string.Empty, Align.Center, ' ', sideToken);
            ConsoleCore.WriteText(desc, Align.Center, ' ', sideToken);
            ConsoleCore.WriteHorizontalLine();

        }


        public static void WriteAppName(string appName, Align align)
        {
            if (appName == null) appName = string.Empty;
            {
                ConsoleCore.WriteText(appName, align, ' ');
            }
        }

        
    }
}
