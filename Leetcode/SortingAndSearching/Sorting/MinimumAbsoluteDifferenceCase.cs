using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class MinimumAbsoluteDifferenceCase : ISortingLC
    {
        public void Cases()
        {
            // Output: [[1, 2],[2, 3],[3, 4]]
            var result_0 = MinimumAbsDifference([4, 2, 1, 3]);
            // Output: [[1,3]]
            var result_1 = MinimumAbsDifference([1, 3, 6, 10, 15]);
            // Output: [[-14,-10],[19,23],[23,27]]
            var result_2 = MinimumAbsDifference([3, 8, -10, 23, 19, -4, -14, 27]);
        }

        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            var n = arr.Length;
            var sorted = new int[n];
            Array.Copy(arr, sorted, n);
            Array.Sort(sorted);

            var min = int.MaxValue;
            for(var i = 0; i < n - 1; i++)
            {
                var absDif = Math.Abs(sorted[i] - sorted[i+1]);
                min = Math.Min(min, absDif);
            }

            var result = new List<IList<int>>();
            for (var i = 0; i < n - 1; i++)
            {
                var absDif = Math.Abs(sorted[i] - sorted[i + 1]);
                if (absDif == min)
                    result.Add([sorted[i], sorted[i + 1]]);
            }

            return result;
        }
    }
}
