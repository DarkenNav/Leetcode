using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 2938. Separate Black and White Balls
    public class SeparateBlackAndWhiteBallsCase
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = MinimumSteps("101");
            // Output: 2
            var result_1 = MinimumSteps("100");
            // Output: 0
            var result_2 = MinimumSteps("0111");
        }

        public long MinimumSteps(string s)
        {
            var n = s.Length;
            int whitePos = 0;
            long swaps = 0;

            for (var i = 0; i < n; i++)
            {
                if (s[i] == '0')
                {
                    swaps += i - whitePos;
                    whitePos++;
                }
            }

            return swaps;
        }
    }
}
