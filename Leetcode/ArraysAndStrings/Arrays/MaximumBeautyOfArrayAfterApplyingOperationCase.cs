using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    /// <summary>
    /// 2779. Maximum Beauty of an Array After Applying Operation
    /// </summary>
    public class MaximumBeautyOfArrayAfterApplyingOperationCase
    {
        public void Cases()
        {
            // Output: 3
            var result_0 = MaximumBeauty([4,6,1,2], 2);
            // Output: 4
            var result_1 = MaximumBeauty([1,1,1,1], 10);

            // Output: 2
            var result_2 = MaximumBeauty([49,26], 12);
        }

        public int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            var max = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                var j = Search(nums, nums[i] + 2 * k);
                max = Math.Max(max, j - i + 1);
            }
            return max;
        }

        private int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            var result = 0;
            while(left <= right)
            {
                var mid = left + (right - left) / 2;
                if(nums[mid] <= target){
                    result = mid;
                    left = mid + 1;
                }
                else
                    right = mid - 1;
            }
            return result;
        }
    }
}