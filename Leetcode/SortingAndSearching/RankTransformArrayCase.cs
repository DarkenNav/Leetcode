using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching
{
    public class RankTransformArrayCase
    {
        public void Cases()
        {
            // Output: [4,1,2,3]
            var result_0 = ArrayRankTransform([40, 10, 20, 30]);
            // Output: [1,1,1]
            var result_1 = ArrayRankTransform([100, 100, 100]);
            // Output: [5,3,4,2,8,6,7,1,3]
            var result_2 = ArrayRankTransform([37, 12, 28, 9, 100, 56, 80, 5, 12]);
        }

        public int[] ArrayRankTransform(int[] arr)
        {
            var n = arr.Length;
            if(n == 0)
                return [];

            var sorted = arr.Order().ToArray();
            var rangs = new Dictionary<int, int>();
            var rang = 1;
            rangs[sorted[0]] = rang;
            for (var i = 1; i < n; i++)
            {
                if(sorted[i-1] < sorted[i])
                {
                    rangs[sorted[i]] = ++rang;
                }
            }

            var result = new int[n];
            for(var i = 0; i < n; i++)
            {
                result[i] = rangs[arr[i]];
            }

            return result;
        }
    }
}
