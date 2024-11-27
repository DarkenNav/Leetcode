using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    // 670. Maximum Swap
    public class MaximumSwapCase
    {
        public void Cases()
        {
            // Output: 7236
            var result_0 = MaximumSwap(2736);
            // Output: 9973
            var result_1 = MaximumSwap(9973);
            // Output: 98863
            var result_2 = MaximumSwap(98368);
            // Output: 9913
            var result_3 = MaximumSwap(1993);
        }

        public int MaximumSwap(int num)
        {
            var list = new List<int>();
            while (num > 0)
            {
                list.Add(num % 10);
                num = num / 10;
            }

            // search max number
            var n = list.Count - 1;
            for (var i = 0; i < list.Count; i++)
            {
                var maxIndex = n-i;
                var max = list[n-i];
                for (var j = n - i - 1; j >= 0; j--)
                {
                    if (list[j] >= max && list[n - i] != list[j])
                    {
                        maxIndex = j;
                        max = list[j];
                    }
                }
                // change
                if (maxIndex != n - i)
                {
                    var tmp = list[n-i];
                    list[n-i] = list[maxIndex];
                    list[maxIndex] = tmp;
                    break;
                }
            }
            var result = 0;
            for (var i = 0; i < list.Count; i++)
            {
                result += list[i] * (int)Math.Pow(10, i);
            }

            return result;
        }
    }
}
