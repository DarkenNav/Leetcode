using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    // 2563. Count the Number of Fair Pairs
    public class CountNumberFairPairsCase
        : IArrayLC, ITwoPointersLC, IBinarySearchLC, ISortingLC
    {
        public void Cases()
        {
            // Output: 6
            var result_0 = CountFairPairs([0, 1, 7, 4, 4, 5], 3, 6);
            // Output: 1
            var result_1 = CountFairPairs([1, 7, 9, 2, 5], 11, 11);
        }

        public long CountFairPairs(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            return LowerBound(nums, upper + 1) - LowerBound(nums, lower);
        }

        private long LowerBound(int[] nums, int value)
        {
            var left = 0;
            var right = nums.Length - 1;
            long result = 0;
            while (left < right)
            {
                var sum = nums[left] + nums[right];
                if (sum < value)
                {
                    result += right - left;
                    left++;
                }
                else
                    right--;
            }
            return result;
        }
    }
}
