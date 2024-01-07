using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Core.Utils.Cryptography
{
    public class Hash
    {
        public static char[] CharactersArray = new char[]
           {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
        'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F',
        'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
           };

        public static short GetHash(char ch)
        {
            for (short i = 0; i < CharactersArray.Length; i++)
                if (CharactersArray[i] == ch)
                    return i;

            throw new IndexOutOfRangeException(ch + " is not in the hash array.");
        }

        public static string GetCellChar(short cellId) => CharactersArray[cellId / 64] + "" + CharactersArray[cellId % 64];

        public static short GetCellIdFromHash(string cellCode)
        {
            char char1 = cellCode[0], char2 = cellCode[1];
            short code1 = 0, code2 = 0, a = 0;

            while (a < CharactersArray.Length)
            {
                if (CharactersArray[a] == char1)
                    code1 = (short)(a * 64);

                if (CharactersArray[a] == char2)
                    code2 = a;

                a++;
            }
            return (short)(code1 + code2);
        }
    }
}
