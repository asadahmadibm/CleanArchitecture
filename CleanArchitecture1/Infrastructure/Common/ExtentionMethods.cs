using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public static class ExtentionMethods
    {
        public static bool FullContains(this string source, string dest)
        {
            return source.Contains(dest.Replace('ي', 'ی')) || source.Contains(dest.Replace('ی', 'ي'));
        }

        public static string Persiany(this string value)
        {

            return value.Replace('ي', 'ی'); //.Replace('ك', 'ک');
        }
        public static string Arabicy(this string value)
        {
            return value.Replace('ی', 'ي'); //;
        }
        public static string Persiank(this string value)
        {
            return value.Replace('ك', 'ک');
        }
        public static string Arabick(this string value)
        {
            return value.Replace('ک', 'ك');
        }
    }
}
