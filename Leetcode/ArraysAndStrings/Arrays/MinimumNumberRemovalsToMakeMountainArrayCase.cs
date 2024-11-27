using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 1671. Minimum Number of Removals to Make Mountain Array
    public class MinimumNumberRemovalsToMakeMountainArrayCase
    {
        public void Cases()
        {
            // Output: 0
            //var result_0 = MinimumMountainRemovals([1, 3, 1]);
            // Output: 3
            var result_1 = MinimumMountainRemovals([2, 1, 1, 5, 6, 2, 3, 1]);
        }

        public int MinimumMountainRemovals(int[] nums)
        {
            var n = nums.Length;

            var lisLength = new int[n];
            var ldsLength = new int[n];

            Array.Fill(lisLength, 1);
            Array.Fill(ldsLength, 1);

            for (var i = 0; i < n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] > nums[j])
                    {
                        lisLength[i] = Math.Max(lisLength[i], lisLength[j] + 1);
                    }
                }
            }

            for (var i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        ldsLength[i] = Math.Max(ldsLength[i], ldsLength[j] + 1);
                    }
                }
            }

            int minRemovals = int.MaxValue;
            for (var i = 0; i < n; i++)
            {
                if (lisLength[i] > 1 && ldsLength[i] > 1)
                {
                    minRemovals = Math.Min(
                        minRemovals,
                        n - lisLength[i] - ldsLength[i] + 1
                    );
                }
            }

            return minRemovals;
        }
    }
}
