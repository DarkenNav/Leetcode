using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class FindPeakElementCase
    {
        public void Cases()
        {
            // 2
            var result = FindPeakElement(new int[] { 1, 2, 3, 1 });
        }

        public int FindPeakElement(int[] nums)
        {
            if(nums.Length == 1)
                return 0;

            var left = 0;
            var right = nums.Length - 1;
            while (left < right) 
            { 
                var mid = left +(right - left) / 2;
                if ((mid + 1 > nums.Length || nums[mid] > nums[mid+1])
                    && (mid - 1 < 0 || nums[mid] > nums[mid - 1]))
                {
                    return mid;
                }
                else if(mid + 1 < nums.Length && nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }
    }
}
