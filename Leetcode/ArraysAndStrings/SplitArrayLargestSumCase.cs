using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class SplitArrayLargestSumCase
    {
        public void Cases()
        {
            // Output: 18
            var result_0 = SplitArray([7, 2, 5, 10, 8], 2);
            // Output: 9
            var result_1 = SplitArray([1, 2, 3, 4, 5], 2);
        }

        // Return the minimized largest sum of the split.
        public int SplitArray(int[] nums, int k)
        {
            var start = 0;
            var end = 0;
            foreach (var i in nums)
            {
                if(start < i)
                    start = i;
                end += i;
            }

            var result = 0;
            while (start <= end)
            {
                var mid = (start + end) / 2;
                if (CheckSum(mid, nums, k))
                { 
                    result = mid;
                    end = mid - 1;
                }
                else
                    start = mid + 1;
            }
            return result;
        }

        private bool CheckSum(int mid, int[] nums, int k)
        {
            var sum = 0;
            var count = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > mid)
                    return false;

                sum += nums[i];
                if(sum > mid)
                {
                    count++;
                    sum = nums[i];
                }
            }
            count++;

            return count <= k;
        }

    }
}
