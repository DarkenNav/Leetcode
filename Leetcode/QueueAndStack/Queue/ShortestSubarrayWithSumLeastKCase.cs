using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue
{
    public class ShortestSubarrayWithSumLeastKCase
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = ShortestSubarray([1], 1);
            // Output: -1
            var result_1 = ShortestSubarray([1,2], 4);
            // Output: 3
            var result_2 = ShortestSubarray([2,-1,2], 3);

            // Output: 2
            var result_3 = ShortestSubarray([17,85,93,-45,-21], 150);
        }

        public class MyComparer : IComparer<long>
        {
            public int Compare(long x, long y)
            {
                // replace following with a fancy logic
                return y.CompareTo(x);
            }
        }

        public int ShortestSubarray(int[] nums, int k) 
        {
            var n = nums.Length;
            var shortest = int.MaxValue;
            long totalSum = 0;

            var pqueue = new PriorityQueue<int, long>();
            for(var i = 0; i < n; i++)
            {
                totalSum += (long)nums[i];
                if(totalSum >= k)
                {
                    shortest = Math.Min(shortest, i + 1);
                }
 
                while(pqueue.Count > 0)
                {
                    _ = pqueue.TryPeek(out var indexes, out long sum);
                    if(totalSum - sum < k)
                        break;

                    shortest = Math.Min(shortest, i - indexes);
                    pqueue.Dequeue();
                }

                pqueue.Enqueue(i, totalSum);
            }

            return shortest == int.MaxValue ? -1 : shortest;
        }
    }
}
