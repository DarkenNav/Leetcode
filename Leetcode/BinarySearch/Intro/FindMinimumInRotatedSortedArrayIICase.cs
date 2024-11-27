using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class FindMinimumInRotatedSortedArrayIICase
    {
        public void Cases()
        {
            var result_0 = FindMin([1, 3, 5]);

            var result_1 = FindMin([2, 2, 2, 0, 1]);

            var result_2 = FindMin([11, 11, 11, 11, 11, 13, 15, 17]);

            var result_3 = FindMin([10, 1, 10, 10, 10]);

            var result_4 = FindMin([3, 5, 1]);
        }

        public int FindMin(int[] nums, int left = 0, int right = int.MaxValue)
        {
            if (nums.Length == 1)
                return nums[0];

            if(right == int.MaxValue)
                right = nums.Length - 1;

            if (left + 1 < nums.Length && right > left)
            {
                if (nums[left] >= nums[right])
                    return FindMin(nums, ++left, right);
                else
                    return FindMin(nums, left, --right);
            }

            return nums[left];
        }
    }
}
