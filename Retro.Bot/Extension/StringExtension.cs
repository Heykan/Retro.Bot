using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Extension
{
    public static class StringExtension
    {
        public static byte[] ToBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ToReadable(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
