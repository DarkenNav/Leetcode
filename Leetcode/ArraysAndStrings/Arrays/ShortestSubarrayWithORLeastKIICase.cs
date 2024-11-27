using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class ShortestSubarrayWithORLeastKIICase
        : IArrayLC, IBitManipulationLC, ISlidingWindowLC
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = MinimumSubarrayLength([1, 2, 3], 2);
            // Output: 3
            var result_1 = MinimumSubarrayLength([2, 1, 8], 10);
            // Output: 1
            var result_2 = MinimumSubarrayLength([1, 2], 0);
        }

        public int MinimumSubarrayLength(int[] nums, int k)
        {
            var minLength = int.MaxValue;
            var start = 0;
            var end = 0;
            var bitCounts = new int[32];

            while (end < nums.Length)
            {
                UpdateBitCounts(bitCounts, nums[end], 1);

                while(start <= end
                    && ConvertBitCountsToNumber(bitCounts) >= k)
                {
                    minLength = Math.Min(minLength, end - start + 1);

                    UpdateBitCounts(bitCounts, nums[start], -1);
                    start++;
                }

                end++;
            }
            return minLength == int.MaxValue ? -1 : minLength;
        }

        private int ConvertBitCountsToNumber(int[] bitCounts)
        {
            var result = 0;
            for (var i = 0; i < bitCounts.Length; i++)
            {
                if(bitCounts[i] != 0)
                {
                    result |= 1 << i;
                }
            }
            return result;
        }

        private void UpdateBitCounts(int[] bitCounts, int num, int delta)
        {
            for (var i = 0; i < bitCounts.Length; i++)
            {
                if(((num >> i) & 1) != 0)
                {
                    bitCounts[i] += delta;
                }
            }
        }
    }
}
