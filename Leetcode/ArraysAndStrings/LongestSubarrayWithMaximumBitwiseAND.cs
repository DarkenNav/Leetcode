using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 2419. Longest Subarray With Maximum Bitwise AND
    public class LongestSubarrayWithMaximumBitwiseAND
    {
        public void Cases()
        {
           //var result = LongestSubarray(new int[] { 311155, 311155, 311155, 311155, 311155, 311155, 311155, 311155, 201191, 311155 });
           var result = LongestSubarray(new int[] { 96317, 96317, 96317, 96317, 96317, 96317, 96317, 96317, 96317, 279979 });
        }

        public int LongestSubarray(int[] nums)
        {
            var max = 0;
            var count = 0;
            var maxCount = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    count = 0;
                    maxCount = 0;
                    max = nums[i];
                }
                
                if (nums[i] == max)
                {
                    count++;
                }
                else
                    count = 0;

                if(maxCount < count)
                    maxCount = count;
            }
            return maxCount;
        }
    }
}
