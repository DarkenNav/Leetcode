using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 1497. Check If Array Pairs Are Divisible by k
    public class CheckIfArrayPairsAreDivisibleByKCase
    {
        public void Cases()
        {
            // Output: true
            var result_0 = CanArrange([1, 2, 3, 4, 5, 10, 6, 7, 8, 9], 5);
            // Output: true
            var result_1 = CanArrange([1, 2, 3, 4, 5, 6], 7);
            // Output: false
            var result_2 = CanArrange([1, 2, 3, 4, 5, 6], 10);
        }

        public bool CanArrange(int[] arr, int k)
        {
            var remCount = new Dictionary<int, int>();
            foreach (var i in arr)
            {
                var rem = (i % k + k) % k;
                if(remCount.ContainsKey(rem))
                    remCount[rem]++;
                else
                    remCount[rem] = 1;
            }

            foreach (var i in arr)
            {
                var rem = (i % k + k) % k;
                if (rem == 0)
                {
                    if (remCount[rem] % 2 == 1)
                        return false;
                }
                else if (
                    !remCount.ContainsKey(k - rem) ||
                    remCount[rem] != remCount[k - rem])
                    return false;
            }

            return true;
        }
    }
}
