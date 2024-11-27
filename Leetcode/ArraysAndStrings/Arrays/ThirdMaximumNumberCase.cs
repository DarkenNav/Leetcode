using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    internal class ThirdMaximumNumberCase
    {
        //1 <= nums.length <= 10^4
        //-2^31 <= nums[i] <= 2^31 - 1
        internal void Cases()
        {
            // Output: 1
            var result_0 = ThirdMax([3, 2, 1]);
            // Output: 2
            var result_1 = ThirdMax([1, 2]);
            // Output: 1
            var result_2 = ThirdMax([2, 2, 3, 1]);
            // Output: 5
            var result_3 = ThirdMax([5, 2, 2]);
            // Output: 2
            var result_4 = ThirdMax([1, 2, 2, 5, 3, 5]);
        }

        // O(n)
        public int ThirdMax(int[] nums)
        {
            var n = nums.Length;
            int? first = null;
            int? second = null;
            int? third = nums[0];
            for (var i = 1; i < n; i++)
            {
                if (third == nums[i] || second == nums[i] || first == nums[i])
                    continue;

                if (third < nums[i])
                {
                    first = second;
                    second = third;
                    third = nums[i];
                }
                else if (second == null || second < nums[i])
                {
                    first = second;
                    second = nums[i];
                }
                else if (first == null || first < nums[i])
                {
                    first = nums[i];
                }
            }
            return (int)(first ?? third);
        }        

        // Order() -- O(n^2)
        public int ThirdMax_1(int[] nums)
        {
            var n = nums.Length;
            var sorted = nums.Order().ToArray();
            var third = 0;
            for ( var i = n - 1; i >= 0; i--)
            {
                if (i == 0 || sorted[i] != sorted[i - 1])
                    third++;

                if (third == 3)
                    return sorted[i];
            }
            return sorted[n - 1];
        }
    }
}
