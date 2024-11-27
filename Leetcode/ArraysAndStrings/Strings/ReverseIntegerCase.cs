using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    internal class ReverseIntegerCase
    {
        internal void Cases()
        {
            // 321
            var result = Reverse(123);

            // 0
            var result_1 = Reverse(1534236469);

            // 
            var result_2 = Reverse(-2147483648);
        }

        public int Reverse(int x)
        {
            var negative = x < 0 ? -1 : 1;

            var s = (negative * x).ToString();
            var str = new StringBuilder();
            for (var i = s.Length - 1; i >= 0; i--)
            {
                str.Append(s[i]);
            }

            if (int.TryParse(str.ToString(), out int result))
                return negative * result;

            return 0;
        }

    }
}
