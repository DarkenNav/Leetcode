using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Arrays
{
    /// <summary>
    /// 3152. Special Array II
    /// </summary>
    public class SpecialArrayIICase
        : IArrayLC, IBinarySearchLC, IPrefixSumLC
    {
        public void Cases()
        {
            // Output: [false]
            var result_0 = IsArraySpecial([3,4,1,2,6], [[0,4]]);
            // Output: [false,true]
            var result_1 = IsArraySpecial([4,3,1,6], [[0,2],[2,3]]);
        }

        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            var prefix = new int[nums.Length];
            for(var i = 1; i < nums.Length; i++)
            {
                if(nums[i] % 2 == nums[i-1] % 2)
                    prefix[i] = prefix[i-1] + 1;
                else
                    prefix[i] = prefix[i-1];
            }

            var results = new bool[queries.Length];
            for(var i = 0; i < queries.Length; i++)
            {
                results[i] = prefix[queries[i][1]] - prefix[queries[i][0]] == 0;
            }

            return results;
        }
    }
}