using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class SearchForRangeCase
    {
        public void Cases()
        {
            var result = SearchRange(new int[] { 1, 4 }, 4);

            // Попробовать решение с двумя поисками (log n) начала и конца диапазона по очереди
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 1)
                return nums[0] == target ? [0, 0] : [-1, -1];

            var left = 0;
            var right = nums.Length - 1;
            var index = -1;
            while (left <= right) { 
                var mid = left + (right - left) / 2;
                if(nums[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (nums[mid] < target)
                    left = mid + 1;
                else if(nums[mid] > target)
                    right = mid - 1;
            }

            if(index == -1)
                return [-1, -1];

            while (left < right)
            {
                if (nums[left] != target)
                    left++;
                if(nums[right] != target)
                    right--;

                if (nums[left] == target && nums[right] == target)
                    break;
            }
            return [left, right];
        }
    }
}
