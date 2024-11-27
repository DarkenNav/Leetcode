using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 1963. Minimum Number of Swaps to Make the String Balanced
    public class MinimumNumberSwapsMakeStringBalancedCase
    {
        public void Cases()
        {
            // 1
            var result_0 = MinSwaps("][][");
            // 2
            var result_1 = MinSwaps("]]][[[");
            // 0
            var result_2 = MinSwaps("[]");
        }

        public int MinSwaps(string s)
        {
            var n = s.Length;
            var unbalanced = 0;
            var openCount = 0;
            for(var i = 0; i < n; i++)
            {
                if (s[i] == '[')
                    openCount++;
                else
                {
                    if (openCount == 0)
                        unbalanced++;
                    else
                        openCount--;
                }
            }
            //  Each swap fixes two brackets—one unbalanced [ and one unbalanced ].
            //  So, the minimum number of swaps is half the total number of unbalanced closing brackets.
            return (unbalanced + 1) / 2;
        }

    }
}
