using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HConsole
{
    internal static class Convertor
    {
        internal static T TryParse<T>(string input)
        {
            var convertor = TypeDescriptor.GetConverter(typeof(T));

            if (convertor != null)
            {
                return (T)convertor.ConvertFromString(input);
            }
            return default(T);
        }
    }
}
