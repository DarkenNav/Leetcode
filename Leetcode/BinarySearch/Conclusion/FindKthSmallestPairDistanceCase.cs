using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Conclusion
{
    public class FindKthSmallestPairDistanceCase
    {
        public void Cases()
        {
            var result_0 = SmallestDistancePair([1, 3, 1], 1);
            var result_1 = SmallestDistancePair([1, 1, 1], 2);
            var result_2 = SmallestDistancePair([1, 6, 1], 3);
        }

        //  more fast O(n^2)
        public int SmallestDistancePair(int[] nums, int k)
        {
            var n = nums.Length;
            var max = nums.Max();

            var distStore = new int[max + 1];

            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    var dist = Math.Abs(nums[j] - nums[i]);
                    distStore[dist]++;
                }
            }

            for (var i = 0; i <= max; i++)
            {
                k -= distStore[i];
                if (k <= 0)
                    return i;
            }

            return 0;
        }

        // long O(n^2)
        public int SmallestDistancePair_0(int[] nums, int k)
        {
            var dist = new List<int>();
            for(var i = 0; i < nums.Length - 1; i++)
            {
                for(var j = i + 1; j < nums.Length; j++)
                {
                    dist.Add(Math.Abs(nums[j] - nums[i]));
                }
            }
            dist.Sort();
            return dist[k-1];
        }
    }
}
