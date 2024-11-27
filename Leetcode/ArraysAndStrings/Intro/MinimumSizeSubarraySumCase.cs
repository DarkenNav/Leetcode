
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class MinimumSizeSubarraySumCase 
    {
        public void Case()
        {
            var result1 = MinSubArrayLen( 7, new int[] { 2, 3, 1, 2, 4, 3 });
            var result2 = MinSubArrayLen( 4, new int[] { 1, 4, 4 });
            var result3 = MinSubArrayLen( 11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
            var result4 = MinSubArrayLen(1, new int[] { 1 });
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            var length = nums.Length;
            var result = int.MaxValue;
            var left = 0;
            var right = 0;
            var sumCurrentWindow = 0;
            for (right = 0; right < length; right++)
            {
                sumCurrentWindow += nums[right];

                while(sumCurrentWindow >= target)
                {
                    result = Math.Min(result, right - left + 1);
                    sumCurrentWindow -= nums[left];
                    left++;
                }                
            }
            return result == int.MaxValue ? 0: result;
        }
    }
}
