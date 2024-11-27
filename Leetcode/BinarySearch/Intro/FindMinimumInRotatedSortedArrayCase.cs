using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class FindMinimumInRotatedSortedArrayCase
    {
        public void Cases()
        {
            // [TestCase(new int[] { 3, 4, 5, 1, 2 }, 1)]
            var result_0 = FindMin(new int[] { 3, 4, 5, 1, 2 });

            // [TestCase(new int[] { 3, 4, 5, 6, 7, 0, 1, 2 }, 0)]
            var result_1 = FindMin(new int[] { 3, 4, 5, 6, 7, 0, 1, 2 });

            var result_2 = FindMin(new int[] { 11, 13, 15, 17 });
        }

        public int FindMin(int[] nums, int left = 0, int right = int.MaxValue)
        {
            if (nums.Length < 2)
                return nums[0];

            if (right == int.MaxValue)
                right = nums.Length - 1;
            if (right - left <= 1)
                return Math.Min(nums[left], nums[right]);

            if (nums[left] < nums[right])
            {
                return nums[left];
            }

            var mid = left + (right - left) / 2;
            if (nums[mid] < nums[left])
                return FindMin(nums, left, mid);

            return FindMin(nums, mid + 1, right);
        }

        public int FindMin_0(int[] nums)
        {
            if (nums.Length < 2)
                return nums[0];

            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                if (right - left > 1)
                {
                    if (nums[left] < nums[right])
                    {
                        return nums[left];
                    }

                    var mid = left + (right - left) / 2;
                    if (nums[mid] < nums[left])
                        right = mid;
                    else left = mid + 1;
                }
                else
                {
                    return Math.Min(nums[left], nums[right]);
                }
            }

            return nums[left];
        }
    }
}
