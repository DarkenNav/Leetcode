using Leetcode._Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    // 347. Top K Frequent Elements
    public class TopKFrequentElementsCase : ISortingLC
    {
        public void Cases()
        {
            // Output: [1,2]
            var result_0 = TopKFrequent([1, 1, 1, 2, 2, 3], 2);
            // Output: [1]
            var result_1 = TopKFrequent([1], 1);
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            var n = nums.Length;
            var counts = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                counts.TryGetValue(num, out int val);
                counts[num] = val + 1;
            }

            var result = new int[k];
            var i = 0;
            foreach(var count in counts.OrderByDescending(x => x.Value))
            {
                result[i] = count.Key;
                if (++i >= k)
                    break;
            }

            return result;
        }
    }
}
