using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class RunningSumOf1dArrayCase
    {
        // 1480. Running Sum of 1d Array
        public void Cases()
        {
            // Output: [1,3,6,10]
            var result_0 = RunningSum([1, 2, 3, 4]);
            // Output: [1,2,3,4,5]
            var result_1 = RunningSum([1, 1, 1, 1, 1]);
            // Output: [3,4,6,16,17]
            var result_2 = RunningSum([3, 1, 2, 10, 1]);
        }

        public int[] RunningSum(int[] nums)
        {
            var n = nums.Length;
            var result = new int[n];
            result[0] = nums[0];
            for (var i = 1; i < n; i++)
            {
                result[i] = result[i-1] + nums[i];
            }
            return result;
        }
    }
}
