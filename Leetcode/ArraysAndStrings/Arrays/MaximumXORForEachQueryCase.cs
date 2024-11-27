using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 1829. Maximum XOR for Each Query
    public class MaximumXORForEachQueryCase 
        : IArrayLC, IBitManipulationLC, IPrefixSumLC
    {
        public void Cases()
        {
            // Output: [0,3,2,3]
            var result_0 = GetMaximumXor([0, 1, 1, 3] , 2);
            // Output: [5,2,6,5]
            var result_1_0 = GetMaximumXor([2, 3, 4, 7], 3);
            var result_1_1 = GetMaximumXor_Opt([2, 3, 4, 7], 3);
            // Output: [4, 3, 6, 4, 6, 7]
            var result_2_0 = GetMaximumXor([0, 1, 2, 2, 5, 7], 3);
            var result_2_1 = GetMaximumXor_Opt([0, 1, 2, 2, 5, 7], 3);
        }

        public int[] GetMaximumXor(int[] nums, int maximumBit)
        {
            var n = nums.Length;
            var prefixXor = new int[n];
            prefixXor[0] = nums[0];
            for(var i = 1; i < n; i++)
            {
                prefixXor[i] = prefixXor[i - 1] ^ nums[i];
            }

            var result = new int[n];
            var mask = (1 << maximumBit) - 1;

            for (var i = 0; i < n; i++)
            {
                var currentXOR = prefixXor[n - 1 - i];
                result[i] = currentXOR ^ mask;
            }

            return result;
        }

        public int[] GetMaximumXor_Opt(int[] nums, int maximumBit)
        {
            var n = nums.Length;
            var xor = 0;
            for (var i = 0; i < n; i++)
            {
                xor ^= nums[i];
            }

            var result = new int[n];
            var mask = (1 << maximumBit) - 1;

            for (var i = 0; i < n; i++)
            {
                result[i] = xor ^ mask;
                xor ^= nums[n - 1 - i];
            }

            return result;
        }
    }
}
