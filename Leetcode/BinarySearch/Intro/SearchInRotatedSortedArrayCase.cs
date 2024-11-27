using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class SearchInRotatedSortedArrayCase
    {
        public void Cases()
        {
            var nums = new int[] { 8, 1, 2, 3, 4, 5, 6, 7 };
            var result = Search(nums, 6);
        }

        public int Search(int[] nums, int target)
        {
            if(nums.Length < 2)
            {
                return nums[0] == target ? 0 : -1;
            }

            var left = 0;
            var right = nums.Length - 1;
            bool foundRange = false;
            while(left <= right)
            {
                if (nums[left] == target)
                    return left;
                if (nums[right] == target)
                    return right;

                var mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;

                if (!foundRange)
                {
                    if (nums[left] < nums[mid])
                    {
                        if (nums[left] < target && nums[mid] > target)
                        {
                            foundRange = true;                           
                            right = mid - 1;
                        }
                        else
                            left = mid + 1;
                    }
                    else
                    {
                        if (nums[mid] < target && nums[right] > target)
                        {
                            foundRange = true;
                            left = mid + 1;
                        }
                        else
                            right = mid - 1;
                    }
                }
                else
                {
                    if(nums[mid] < target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

            }

            return -1;
        }
    }
}
