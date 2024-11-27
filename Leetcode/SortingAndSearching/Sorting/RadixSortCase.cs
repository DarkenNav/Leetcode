using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class RadixSortCase : ISortingLC
    {
        public void Cases()
        {
            var arr_0 = new int[] { 1256, 2336, 4443, 736, 831, 11907 };
            RadixSort(arr_0, 10);
        }

        public void RadixSort(int[] arr, int numDigit)
        {
            var max = arr.Max();

            var placeVal = 1;
            while(max / placeVal > 0)
            {
                CountingSort(arr, placeVal, numDigit);
                placeVal *= numDigit;
            }
        }

        public void CountingSort(int[] arr, int placeVal, int numDigit)
        {
            var n = arr.Length;
            var counts = new int[numDigit];
            for(var i = 0; i < n; i++)
            {
                var current = arr[i] / placeVal;
                counts[current % numDigit]++;
            }

            var startIndex = 0;
            for(var i = 0; i < numDigit; i++)
            {
                var count = counts[i];
                counts[i] = startIndex;
                startIndex += count;
            }

            var sorted = new int[n];
            foreach(var elem in arr)
            {
                var current = elem / placeVal;
                var index = current % numDigit;
                sorted[counts[index]] = elem;
                counts[index]++;
            }

            Array.Copy(sorted, arr, n);
        }
    }
}
