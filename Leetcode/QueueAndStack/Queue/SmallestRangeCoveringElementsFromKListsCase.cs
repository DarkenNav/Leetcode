using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue
{
    public class SmallestRangeCoveringElementsFromKListsCase
    {
        public void Cases()
        {
            // Output: [20,24]
            var result_0 = SmallestRange([[4, 10, 15, 24, 26], [0, 9, 12, 20], [5, 18, 22, 30]]);
            // Output: [1,1]
            var result_1 = SmallestRange([[1, 2, 3], [1, 2, 3], [1, 2, 3]]);
        }

        // We define the range [a, b] is smaller
        // than range [c, d] if b - a < d - c or a < c if b - a == d - c.
        // Подход 2: Приоритетная очередь (куча) -------------------------------------
        
        //Descending Sort, Integer
        //var queue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        //Ascending Sort, Object
        //var queue = new PriorityQueue<ObjectA, ObjectB>(Comparer<ObjectB>.Create((x, y) => x.Something.CompareTo(y.Something));

        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var k = nums.Count;
            var pqueue = new PriorityQueue<(int m, int n), int>();
            var maxVal = int.MinValue;
            var rangeStart = 0;
            var rangeEnd = int.MaxValue;

            for(var i = 0; i < k; i++)
            {
                var val = nums[i][0];
                pqueue.Enqueue((i, 0), val);
                maxVal = Math.Max(maxVal, val);
            }

            while (pqueue.Count == k)
            {
                if (pqueue.TryDequeue(out var indexes, out int val))
                {
                    if (maxVal - val < rangeEnd - rangeStart)
                    {
                        rangeStart = val;
                        rangeEnd = maxVal;
                    }

                    var nextN = indexes.n + 1;
                    if (nextN < nums[indexes.m].Count)
                    {
                        var nextVal = nums[indexes.m][nextN];
                        pqueue.Enqueue((indexes.m, nextN), nextVal);
                        maxVal = Math.Max(maxVal, nextVal);
                    }
                }
                else
                    break;
            }

            return [rangeStart, rangeEnd];
        }

        // Подход 1: Оптимальный перебор ---------------------------------------------
        public int[] SmallestRange_1(IList<IList<int>> nums)
        {
            var n = nums.Count;
            var indices = new int[n];
            var range = new int[] { 0, int.MaxValue };
            while (true)
            {
                var curMin = int.MaxValue;
                var curMax = int.MinValue;
                var minListIndex = 0;
                for(var i = 0; i < n; i++ )
                {
                    var currentElement = nums[i][indices[i]];
                    if(currentElement < curMin)
                    {
                        curMin = currentElement;
                        minListIndex = i;
                    }
                    
                    if(currentElement > curMax)
                    {
                        curMax = currentElement;
                    }
                }

                if(curMax - curMin < range[1] - range[0])
                {
                    range[1] = curMax;
                    range[0] = curMin;
                }

                if (++indices[minListIndex] == nums[minListIndex].Count) 
                    break;
            }

            return range;
        }
    }
}
