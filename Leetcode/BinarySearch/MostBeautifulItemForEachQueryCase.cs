using Leetcode._Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    // 2070. Most Beautiful Item for Each Query
    internal class MostBeautifulItemForEachQueryCase
        : IArrayLC, IBinarySearchLC, ISortingLC
    {
        internal void Cases()
        {
            // Output: [2,4,5,5,6,6]
            var result_0 = MaximumBeauty([[1, 2], [3, 22], [2, 4], [5, 6], [3, 5], [33, 55]], [1, 2, 3, 4, 5, 6, 7]);
            // Output: [4]
            var result_1 = MaximumBeauty([[1, 2], [1, 2], [10, 8], [1, 4]], [1, 1, 11, 3, 3, 3, 3, 3]);
            // Output: [0]
            var result_2 = MaximumBeauty([[10, 1000]], [5]);
        }

        // items[i] = [pricei, beautyi]
        public int[] MaximumBeauty(int[][] items, int[] queries)
        {
            var n = queries.Length;
            var result = new int[n];

            Array.Sort(items, (a, b) => { return a[0].CompareTo(b[0]); });

            var sortedQueries = new int[n][];
            for (var i = 0; i < n; i++)
            {
                sortedQueries[i] = [queries[i], i];
            }
            Array.Sort(sortedQueries, (a, b) => { return a[0].CompareTo(b[0]); });

            var itemIndex = 0;
            var maxBeautyi = 0;
            for(var i = 0; i < n; i++)
            {
                var query = sortedQueries[i][0];
                var originalIndex = sortedQueries[i][1];

                while(itemIndex < items.Length && items[itemIndex][0] <= query)
                {
                    maxBeautyi = Math.Max(maxBeautyi, items[itemIndex][1]);
                    itemIndex++;
                }

                result[originalIndex] = maxBeautyi;
            }

            return result;
        }

        // TLE
        public int[] MaximumBeauty_1(int[][] items, int[] queries)
        {
            var n = queries.Length;
            var result = new int[n];

            Array.Sort(items, (a,b) => { return a[0].CompareTo(b[0]); });

            var map = new Dictionary<int, int>();
            var sortedQueries = new int[n][];
            for(var i = 0; i < n; i++)
            {
                sortedQueries[i] = [queries[i], i];
            }
            Array.Sort(sortedQueries, (a, b) => { return a[0].CompareTo(b[0]); });

            foreach(var query in sortedQueries)
            {
                if (map.TryGetValue(query[0], out int beautyi))
                {
                    result[query[1]] = beautyi;
                }
                else
                {
                    var maxBeauty = MaxBeauty(items, query[0]);
                    map[query[0]] = maxBeauty;
                    result[query[1]] = maxBeauty;
                }
            }

            return result;
        }

        private int MaxBeauty(int[][] items, int targetPrice)
        {
            var n = items.Length;
            var left = 0;
            var right = n - 1;
            var mid = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (items[mid][0] > targetPrice)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            var maxBeautyi = 0;
            for (var i = 0; i <= right; i++)
            {
                if(maxBeautyi < items[i][1])
                {
                    maxBeautyi = items[i][1];  
                }
            }

            return maxBeautyi;
        }
    }
}
