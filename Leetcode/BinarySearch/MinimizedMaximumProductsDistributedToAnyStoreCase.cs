using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    // 2064. Minimized Maximum of Products Distributed to Any Store
    public class MinimizedMaximumProductsDistributedToAnyStoreCase
        : IArrayLC, IBinarySearchLC
    {
        public void Cases()
        {
            // Output: 3
            var result_0 = MinimizedMaximum(6, [11, 6]);
            // Output: 5
            var result_1 = MinimizedMaximum(7, [15, 10, 10]);
            // Output: 3
            var result_2 = MinimizedMaximum(1, [100000]);
        }

        public int MinimizedMaximum(int n, int[] quantities)
        {
            var left = 0;
            var right = quantities.Max();
            while (left < right)
            {
                var midle = (right + left) / 2;
                if(CanDistribute(midle, n, quantities))
                    right = midle;
                else
                    left = midle + 1;
            }
            return left;
        }

        private bool CanDistribute(int k, int n, int[] quantities)
        { 
            var j = 0;
            var m = quantities.Length;
            var remaining = quantities[j];
            for (var i = 0; i < n; i++)
            {
                if (remaining <= k)
                {
                    j++;
                    if(j == m)
                        return true;

                    remaining = quantities[j];
                }
                else
                    remaining -= k;
            }

            return false;            
        }
    }
}
