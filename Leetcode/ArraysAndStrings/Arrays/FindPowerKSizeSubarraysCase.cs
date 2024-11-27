using Leetcode._Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3254. Find the Power of K-Size Subarrays I
namespace Leetcode.ArraysAndStrings
{
    public class FindPowerKSizeSubarraysCase
        : IArrayLC, ISlidingWindowLC
    {
        public void Cases()
        {
            // Output: [3,4,-1,-1,-1]
            var result_0 = ResultsArray([1,2,3,4,3,2,5], 3);
            // Output: [-1,-1]
            var result_1 = ResultsArray([2,2,2,2,2], 4);
            // Output: [-1,3,-1,3,-1]
            var result_2 = ResultsArray([3,2,3,2,3,2], 2);

            // Output: [1]
            var result_3 = ResultsArray([1], 1);
            // Output: [1,1]
            var result_4 = ResultsArray([1,1], 1);
            // Output: [-1]
            var result_5 = ResultsArray([1,1], 2);

            // Output: [-1,4]
            var result_6 = ResultsArray([1,3,4], 2);
        }

        public int[] ResultsArray(int[] nums, int k) 
        {
            var n = nums.Length;
            if(k == 1)
                return nums;

            var result = new int[n-k+1];
            for(var i = 0; i < n - k + 1; i++)
            {
                int j;
                for(j = i + 1; j < i + k; j++)
                {
                    if(nums[j] != nums[j-1] + 1)
                        break;
                }

                if(j - i < k) result[i] = -1;
                else result[i] = nums[i+k-1];
            }

            return result;
        }
    }
}