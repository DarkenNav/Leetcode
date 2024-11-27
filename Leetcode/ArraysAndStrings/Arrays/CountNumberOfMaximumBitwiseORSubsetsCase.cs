using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 2044. Count Number of Maximum Bitwise-OR Subsets
    public class CountNumberOfMaximumBitwiseORSubsetsCase
    {
        public void Cases()
        {
            // Output: 2
            var result_0 = CountMaxOrSubsets([3, 1]);
            // Output: 7
            var result_1 = CountMaxOrSubsets([2, 2, 2]);
            // Output: 6
            var result_2 = CountMaxOrSubsets([3, 2, 1, 5]);
        }

        // Рекурсия с мемоизацией
        public int CountMaxOrSubsets(int[] nums)
        {
            var n = nums.Length;
            var maxOR = 0;
            for (var i = 0; i < n; i++)
            {
                maxOR |= nums[i];
            }

            var memo = new int?[n][];
            for (var i = 0; i < n; i++)
            {
                memo[i] = new int?[maxOR + 1];
            }

            return CountSubsets(nums, 0, 0, maxOR, memo);
        }

        public int CountSubsets(int[] nums, int index, int currOR, int targetOR, int?[][] memo)
        {
            if(index == nums.Length)
                return currOR == targetOR ? 1: 0;

            if (memo[index][currOR] != null)
                return (int)memo[index][currOR];

            var countWithout = CountSubsets(nums, index + 1, currOR, targetOR, memo);
            var countWitn = CountSubsets(nums, index + 1, currOR | nums[index], targetOR, memo);

            return countWithout + countWitn;
        }

        // Подход 3: Манипуляция битами
        public int CountMaxOrSubsets_1(int[] nums)
        {
            var n = nums.Length;
            var maxOR = 0;
            for (var i = 0; i < n; i++)
            {
                maxOR |= nums[i];
            }

            var total = 1 << n;
            var count = 0;
            for (var i = 0; i < total; i++)
            {
                var currentOR = 0;
                for(var j = 0; j < n; j++)
                {
                    if (((i >> j) & 1) == 1)
                        currentOR |= nums[j];
                }
                if (maxOR == currentOR)
                    count++;
            }

            return count;
        }
    }
}
