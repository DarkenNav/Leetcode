using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Leetcode._Interfaces;
using Microsoft.VisualBasic;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 2461. Maximum Sum of Distinct Subarrays With Length K
    public class MaximumSumDistinctSubarraysWithLengthK
        : IArrayLC, ISlidingWindowLC, IHashTableLC
    {
        public void Cases()
        {
            // Output: 15
            var result_0 = MaximumSubarraySum([1,5,4,2,9,9,9], 3);
            // Output: 0
            var result_1 = MaximumSubarraySum([4,4,4], 3);
            
            // Output: 24
            var result_2 = MaximumSubarraySum([1,1,1,7,8,9], 3);
            // Output: 82
            var result_3 = MaximumSubarraySum([14,2,11,19,6,18,8,20,11], 6);
        }

        public long MaximumSubarraySum(int[] nums, int k) 
        {
            var n = nums.Length;
            long maxSum = 0;
            long sum = 0;
            var frequency = new HashSet<int>();
            for(var i = 0; i < n - k + 1; i++)
            {
                if(frequency.Count < k)
                    sum = GetSumSubarray(nums, frequency, i, k);
                else
                {
                    frequency.Remove(nums[i-1]);
                    if(frequency.Add(nums[i+k-1]))
                        sum = sum - nums[i-1] + nums[i+k-1];
                }
                maxSum = Math.Max(maxSum, sum);
            }
            return maxSum;
        }

        private long GetSumSubarray(int[] nums, HashSet<int> frequency, int i, int k)
        {
            long sum = 0;
            frequency.Clear();
            for(var j = 0; j < k; j++)
            {
                if(frequency.Add(nums[i+j]))
                    sum += nums[i+j];
                else
                    return 0;
            }
            return sum;
        }
    }
}
