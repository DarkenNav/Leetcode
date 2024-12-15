using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Arrays
{
    /// <summary>
    /// 2558. Take Gifts From the Richest Pile
    /// </summary>
    public class TakeGiftsFromRichestPileCase
        : IArrayLC, IHeapLC, ISimulationLC
    {
        public void Cases()
        {
            // Output: 29
            var result_0 = PickGifts([25,64,9,4,100], k : 4);
            // Output: 4
            var result_1 = PickGifts([1,1,1,1], k : 4);

        }

        public long PickGifts(int[] gifts, int k)
        {
            var pq = new PriorityQueue<int, int>(
                Comparer<int>.Create((x, y) => y - x));
            for(var i = 0; i < gifts.Length; i++)
                pq.Enqueue(i, gifts[i]);
            
            while(pq.Count > 0 && k > 0)
            {
                _ = pq.TryDequeue(out var i, out var count);
                pq.Enqueue(i, Sqrt(count));
                k--;
            }

            long result = 0;
            while(pq.Count > 0)
            {
                _ = pq.TryDequeue(out var i, out var count);
                result += count;
            }
            return result;            
        }

        private int Sqrt(int x)
        {
            if(x == 0 || x == 1) return x;
            var left = 0;
            var right = x;
            while(left <= right)
            {
                var mid = left + (right - left) / 2;
                var pow = (long)mid * mid;
                if(pow > x)
                    right = mid - 1;
                else if(pow < x)
                    left = mid + 1;
                else
                    return mid;
            }
            return right;
        }
    }
}