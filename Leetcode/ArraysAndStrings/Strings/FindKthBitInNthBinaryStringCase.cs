using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 1545. Find Kth Bit in Nth Binary String
    public class FindKthBitInNthBinaryStringCase
    {
        public void Cases()
        {
            // Output: "0" S3 = "0111001"
            var result_0 = FindKthBit(3, 2);
            // Output: "1"
            var result_1 = FindKthBit(4, 11);
        }

        public char FindKthBit(int n, int k, StringBuilder s = null)
        {
            s = s ?? new StringBuilder("0");
            var l = s.Length;
            if (k > l)
            {
                if (n > 0)
                {
                    var next = new StringBuilder()
                        .Append(s)
                        .Append("1")
                        .Append(InvertAndReverse(s));
                    return FindKthBit(n - 1, k, next);
                }
            }
            return s[k - 1];
        }

        private StringBuilder InvertAndReverse(StringBuilder s)
        {
            var str = new StringBuilder();
            for (var i = s.Length - 1; i >= 0; i--)
            {
                str.Append(s[i] == '1' ? '0' : '1');
            }
            return str;
        }

        // Проверка вычисления S по формуле S0 = 0 -> Si = Si - 1 + "1" + reverse(invert(Si - 1))
        public char FindKthBit_1(int n, int k)
        {
            var list = new List<string>() {"0"};
            for (var i = 1; i < n; i++)
            {
                var s = new StringBuilder(list[i-1])
                    .Append("1")
                    .Append(InvertAndReverse(new StringBuilder(list[i - 1])))
                    .ToString();
                list.Add(s);
            }

            return '0';
        }


        
    }
}
