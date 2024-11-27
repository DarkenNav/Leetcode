using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class SortArrayByParityCase
    {
        public void Cases()
        {
            // Output: [2,4,3,1]
            var result_0 = SortArrayByParity([3, 1, 2, 4]);
            // Output: [0]
            var result_1 = SortArrayByParity([0]);
        }

        public int[] SortArrayByParity(int[] nums)
        {
            var n = nums.Length;
            if(n < 2) return nums;
            var left = 0;
            var right = n - 1;
            while (left < right)
            {
                var evenLeft = nums[left] % 2 == 0;
                var oddRight = nums[right] % 2 != 0;

                if (!evenLeft && !oddRight)
                {
                    var tmp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = tmp;
                }

                if(evenLeft)
                    left++;
                if (oddRight)
                    right--;
            }
            return nums;
        }
    }
}
