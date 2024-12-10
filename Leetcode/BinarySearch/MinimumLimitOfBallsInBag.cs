using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    /// <summary>
    /// 1760. Minimum Limit of Balls in a Bag
    /// </summary>
    public class MinimumLimitOfBallsInBag
    {
        public void Cases()
        {
            // Output: 3
            var result_0 = MinimumSize([9], 2);
            // Output: 2
            var result_1 = MinimumSize([2,4,8,2], 4);

        }

        public int MinimumSize(int[] nums, int maxOperations)
        {
            var left = 1;
            var right = 0;
            foreach (var num in nums)
                right = Math.Max(num, right);

            while(left < right)
            {
                var mid = (left + right) / 2;
                if(IsPossible(mid, nums, maxOperations))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        private bool IsPossible(int maxBallInBag, int[] nums, int maxOperations)
        {
            var totalOperations = 0;
            foreach(var num in nums)
            {
                var operation = (int)Math.Ceiling(num / (double)maxBallInBag) - 1;
                totalOperations += operation;

                if(totalOperations > maxOperations)
                    return false;
            }
            return true;
        }
    }
}