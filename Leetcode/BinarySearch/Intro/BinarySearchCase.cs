using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Untro
{
    public class BinarySearchCase
    {
        public void Cases()
        {
            var nums_0 = new int[] { -1, 0, 3, 5, 9, 12 };
            var target_0 = 9;
            var result = Search(nums_0, target_0);
        }

        public int Search(int[] nums, int target)
        {
            if (nums.Length < 2 && nums[0] == target)
                return 0;

            int left = 0;
            int right = nums.Length - 1;
            while (left <= right) {
                var mid = left + (right - left) / 2;
                if(nums[mid] == target)
                    return mid;
                else if(nums[mid] < target)
                    left = mid + 1;
                else if(nums[mid] > target)
                    right = mid - 1;
            }

            return -1;
        }
    }
}
