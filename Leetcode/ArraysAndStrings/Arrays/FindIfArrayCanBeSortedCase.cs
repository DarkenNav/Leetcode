using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    internal class FindIfArrayCanBeSortedCase : IArrayLC, IBitManipulationLC, ISortingLC
    {
        internal void Cases()
        {
            // Output: true
            var result_0 = CanSortArray([8, 4, 2, 30, 15]);

            // Output: true
            var result_1 = CanSortArray([1]);

            // Output: false
            var result_2 = CanSortArray([3, 16, 8, 4, 2]);
            
        }

        public bool CanSortArray(int[] nums)
        {
            var n = nums.Length;
            if (n == 1) return true;

            var arr = new int[n];
            Array.Copy(nums, arr, n);

            var map = new Dictionary<int, int>();
            for(var d = 0; d < n; d++)
            {
                if(!map.ContainsKey(arr[d]))
                    map[arr[d]] = BitCount(arr[d]);
            }

            var i = 0;
            while(i < n)
            {
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        if (map[arr[j]] != map[arr[j + 1]])
                            return false;

                        var tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
                i++;
            }

            return true;
        }

        private int BitCount(int num)
        {
            var count = 0;
            while(num > 0)
            {
                if ((num & 1) == 1)
                    count++;
                num = num >> 1;
            }

            return count;
        }
    }
}
