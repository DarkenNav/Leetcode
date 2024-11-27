using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class ReplaceElementsWithGreatestElementOnRightSideCase
    {
        public void Cases()
        {
            // Output: [18,6,6,6,1,-1]
            var result_0 = ReplaceElements([17, 18, 5, 4, 6, 1]);
            // Output: [-1]
            var result_1 = ReplaceElements([400]);
        }

        public int[] ReplaceElements(int[] arr)
        {
            var n = arr.Length;
            var max = arr[n-1];
            arr[n - 1] = -1;

            for (var i = n - 2; i >= 0; i--)
            {
                var oldMax = max;
                max = Math.Max(max, arr[i]);
                arr[i] = oldMax;
            }
            return arr;
        }
    }
}
