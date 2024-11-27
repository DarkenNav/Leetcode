using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.DP
{
    public class MaximumSubarrayCase
    {
        public void Cases()
        {
            // Output: 6
            var result_0 = MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]);
            var result_0_0 = SubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]);
            // Output: 1
            var result_1 = MaxSubArray([1]);
            // Output: 23
            var result_2 = MaxSubArray([5, 4, -1, 7, 8]);
        }

        // алгоритм Кадане
        public int MaxSubArray(int[] nums)
        {
            var result = nums[0];
            var maxEnding = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                maxEnding = Math.Max(maxEnding + nums[i], nums[i]);
                result = Math.Max(result, maxEnding);
            }

            return result;
        }

        public List<int> SubArray(int[] nums)
        { 
            var n = nums.Length;

            var resultStart = 0;
            var resultEnd = 0;

            var currentStart = 0;

            var maxSum = nums[0];
            var maxEnding = nums[0];

            for (var i = 1; i < n; i++)
            {
                //maxEnding = Math.Max(maxEnding + nums[i], nums[i]);
                //result = Math.Max(result, maxEnding);
                if(maxEnding + nums[i] < nums[i])
                {
                    maxEnding = nums[i];
                    currentStart = i;
                }
                else
                {
                    maxEnding += nums[i];
                }

                if(maxEnding > maxSum)
                {
                    maxSum = maxEnding;
                    resultStart = currentStart;
                    resultEnd = i;
                }
            }

            return new List<int>(nums[resultStart..(resultEnd+1)]);
        }

    }
}
