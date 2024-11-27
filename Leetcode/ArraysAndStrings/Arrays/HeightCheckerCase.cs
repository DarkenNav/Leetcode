using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    internal class HeightCheckerCase
    {
        internal void Cases()
        {
            // Output: 3
            var result_0 = HeightChecker([1, 1, 4, 2, 1, 3]);
            // Output: 5
            var result_1 = HeightChecker([5, 1, 2, 3, 4]);
            // Output: 0
            var result_2 = HeightChecker([1, 2, 3, 4, 5]);

        }

        // buble
        public int HeightChecker(int[] heights)
        {
            var n = heights.Length;
            var sorted = new int[n];
            Array.Copy(heights, sorted, n);
            while(true)
            {
                var changes = false;
                for(var i = 1; i < n; i++)
                {
                    if (sorted[i - 1] > sorted[i])
                    {
                        var tmp = sorted[i - 1];
                        sorted[i - 1] = sorted[i];
                        sorted[i] = tmp;
                        changes = true;
                    }
                }
                if (!changes)
                    break;
            }

            var numberOfIndices = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                if (heights[i] != sorted[i])
                    numberOfIndices++;
            }
            return numberOfIndices;
        }

        public int HeightChecker_1(int[] heights)
        {
            var sorted = heights.Order().ToArray();
            var numberOfIndices = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                if (heights[i] != sorted[i])
                    numberOfIndices++;
            }
            return numberOfIndices;
        }

    }
}
