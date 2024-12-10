using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    /// <summary>
    /// 2554. Maximum Number of Integers to Choose From a Range I
    /// </summary>
    public class MaximumNumberOfIntegersToChooseFromRangeCase
    {
        internal void Cases()
        {
            // Output: 2
            var result_0 = MaxCount([1,6,5], 5, 6);
            // Output: 0
            var result_1 = MaxCount([1,2,3,4,5,6,7], 8, 1);
            // Output: 7
            var result_2 = MaxCount([11], 7, 50);
        }

        public int MaxCount(int[] banned, int n, int maxSum)
        {
            var setBanned = new HashSet<int>();
            for (int i = 0; i < banned.Length; i++)
                setBanned.Add(banned[i]);

            var count = 0;
            for (int i = 1; i <= n; i++)
            {
                if(setBanned.Contains(i))
                    continue;

                maxSum -= i;        
                if(maxSum < 0)
                    return count;

                count++;
            }

            return count;
        }
    }
}