using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    internal class MissingNumberCase
    {
        internal void Cases()
        {
            // Output: 2
            var result_0 = MissingNumber([3, 0, 1]);
            // Output: 2
            var result_1 = MissingNumber([0, 1]);
            // Output: 8
            var result_2 = MissingNumber([9, 6, 4, 2, 3, 5, 7, 0, 1]);
        }

        public int MissingNumber(int[] nums)
        {
            var n = nums.Length;
            var sum = 0;
            for(var i = 0; i < n + 1; i++)
            {
                sum += i;
            }
            for (var i = 0; i < n; i++)
            {
                sum -= nums[i];
            }
            return sum;
        }
    }
}
