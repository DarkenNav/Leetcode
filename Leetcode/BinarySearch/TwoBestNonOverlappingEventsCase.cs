using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.BinarySearch
{
    /// <summary>
    /// 2054. Two Best Non-Overlapping Events
    /// </summary>
    public class TwoBestNonOverlappingEventsCase
        : IArrayLC, IBinarySearchLC, IDynamicProgrammingLC, ISortingLC, IHeapLC
    {
        public void Cases()
        {
            // Output: 4
            var result_0 = MaxTwoEvents([[1,3,2],[4,5,2],[2,4,3]]);
            // Output: 5
            var result_1 = MaxTwoEvents([[1,3,2],[4,5,2],[1,5,5]]);
            // Output: 8
            var result_2 = MaxTwoEvents([[1,5,3],[1,5,1],[6,6,5]]);
        }

        public int MaxTwoEvents(int[][] events)
        {
            var pq = 
                new PriorityQueue<(int endTime, int val), int>();
            
            Array.Sort(events, (x, y) => x[0] - y[0]);

            var maxVal = 0;
            var maxSum = 0;
            foreach(var e in events)
            {
                while(pq.Count > 0 && pq.Peek().endTime < e[0])
                {
                    maxVal = Math.Max(maxVal, pq.Peek().val);
                    pq.Dequeue();
                }

                maxSum = Math.Max(maxSum, maxVal + e[2]);
                pq.Enqueue((e[1], e[2]), e[1]);
            }


            return maxSum;
        }

    }
}