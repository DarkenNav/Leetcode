using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Arrays
{
    /// <summary>
    /// 2762. Continuous Subarrays
    /// </summary>
    public class ContinuousSubarraysCase
        : ISlidingWindowLC,IArrayLC,IOrderedSetLC,IQueueLC,IHeapLC,IMonotonicQueueLC,
        ITwoPointersLC,IOrderedMapLC,IHashTableLC,IDynamicProgrammingLC,
        ICountingLC,IMathLC,IBinarySearchTreeLC,ISegmentTreeLC,ITreeLC,
        IStackLC,IBinarySearchLC,IMonotonicStackLC,IMemoizationLC,IIteratorLC,
        IGreedyLC,IDepthFirstSearchLC,IRecursionLC
    {
        public void Cases()
        {
            // Output: 8
            var result_0 = ContinuousSubarrays([5,4,2,4]);
            // Output: 6
            var result_1 = ContinuousSubarrays([1,2,3]);
        }

        public long ContinuousSubarrays(int[] nums) 
        {
            var n = nums.Length;
            var left = 0;
            var right = 0;
            var count = 0;
            var pqMin = new PriorityQueue<int, int>(
                Comparer<int>.Create((x,y)=> nums[x] - nums[y])
            );
            var pqMax = new PriorityQueue<int, int>(
                Comparer<int>.Create((x,y)=> nums[y] - nums[x])
            );

            while(right < n)
            {
                pqMin.Enqueue(right, right);
                pqMax.Enqueue(right, right);

                while(left < right 
                    && nums[pqMax.Peek()] - nums[pqMin.Peek()] > 2)
                {
                    left++;
                    while(pqMax.Count > 0 && pqMax.Peek() < left)
                        pqMax.Dequeue();

                    while(pqMin.Count > 0 && pqMin.Peek() < left)
                        pqMin.Dequeue();
                }

                count += right - left + 1;
                right++;
            }
            return count;
        }

        // TLE
        public long ContinuousSubarrays_1(int[] nums) 
        {
            var n = nums.Length;
            long count = 0;
            var left = 0;
            var right = 0;
            var min = int.MaxValue;
            var max = 0;

            var next = new Action(() => {
                left++;
                right = left;
                min = int.MaxValue;
                max = 0;
            });

            while(left < n)
            {
                min = Math.Min(min, nums[right]);
                max = Math.Max(max, nums[right]);

                var div = max - min;
                if(div >= 0 && div <= 2)
                {
                    count++;
                    right++;
                    if(right >= n)
                        next();
                }
                else
                    next();
            }
            return count;
        }

    }
}