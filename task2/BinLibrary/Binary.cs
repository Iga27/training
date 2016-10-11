using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinLibrary
{
   public class Binary
    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string ToBinaryString(int x)
        {
            string bin = string.Empty;
            while (x > 0)
            {
                if (x % 2 == 1)
                    bin += "1";
                else
                    bin += "0";

                x /= 2;
            }
            return Reverse(bin);
        }
    }
}
