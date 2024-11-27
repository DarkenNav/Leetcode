using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    internal class CountingSortCase : ISortingLC
    {
        internal void Cases()
        {
            int[] arr_0 = [5, 4, 5, 5, 1, 1, 3];
            CountingSort(arr_0);
        }

        public void CountingSort(int[] arr)
        {
            var n = arr.Length;
            var max = int.MinValue;
            for(var i = 0; i < n; i++)
            {
                if(arr[i] > max) max = arr[i];
            }

            var counts = new int[max + 1];
            for(var i = 0; i < n; i++)
            {
                counts[arr[i]]++;
            }

            var startIndex = 0;
            for(var i = 0; i < max + 1; i++)
            {
                var count = counts[i];
                counts[i] = startIndex;
                startIndex += count;
            }

            var sorted = new int[n];
            for(var i = 0; i < n; i++)
            {
                var elem = arr[i];
                sorted[counts[elem]] = elem;
                counts[elem]++;
            }

            for (var i = 0; i < n; i++)
            {
                arr[i] = sorted[i];
            }
        }
    }
}
