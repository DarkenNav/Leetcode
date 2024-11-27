using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    public class MinimumNumberChangesToMakeBinaryStringBeautifulCase
    {
        public void Cases()
        {
            // Output: 2
            var result_0 = MinChanges("1001");
            // Output: 1
            var result_1 = MinChanges("10");
            // Output: 0
            var result_2 = MinChanges("0000");
            var result_22 = MinChanges("1111");

            var result_3 = MinChanges("110011");
        }

        public int MinChanges(string s)
        {
            var count = 1;
            var c = s[0];
            var result = 0;
            for(var i = 1; i < s.Length; i++)
            {
                if (s[i] != c)
                {
                    if (count % 2 == 0)
                    {
                        c = s[i];
                        count = 1;
                        continue;
                    }
                    result++;
                }                
                count++;
            }
            return result;
        }
    }
}
