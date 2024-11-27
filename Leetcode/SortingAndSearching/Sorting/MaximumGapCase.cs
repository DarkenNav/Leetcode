using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class MaximumGapCase : ISortingLC
    {
        public void Cases()
        {
            // 1 <= nums.length <= 10^5
            // 0 <= nums[i] <= 10^9

            // Output: 3
            var result_0 = MaximumGap([3, 6, 9, 1]);
            // Output: 0
            var result_1 = MaximumGap([10]);
            // Output: 
            var result_2 = MaximumGap([2, 99999999]);
        }

        private const int NUM_DIGIT = 10;
        public int MaximumGap(int[] nums)
        {
            var n = nums.Length;
            if(n < 2) return 0;

            var max = int.MinValue;
            for (var i = 0; i < n; i++) 
            {
                max = Math.Max(max, nums[i]);
            }

            var placeVal = 1;
            while (max / placeVal > 0)
            {
                CountingSort(nums, placeVal);
                placeVal *= NUM_DIGIT;
            }

            var maxDif = int.MinValue;
            for (var i = 0; i < n - 1; i++)
            {
                maxDif = Math.Max(maxDif, nums[i + 1] - nums[i]);
            }

            return maxDif;
        }

        public void CountingSort(int[] arr, int placeVal)
        {
            var n = arr.Length;
            var counts = new int[NUM_DIGIT];
            for (var i = 0; i < n; i++)
            {
                var current = arr[i] / placeVal;
                counts[current % NUM_DIGIT]++;
            }

            var startIndex = 0;
            for (var i = 0; i < NUM_DIGIT; i++)
            {
                var count = counts[i];
                counts[i] = startIndex;
                startIndex += count;
            }

            var sorted = new int[n];
            foreach (var elem in arr)
            {
                var current = elem / placeVal;
                var index = current % NUM_DIGIT;
                sorted[counts[index]] = elem;
                counts[index]++;
            }

            Array.Copy(sorted, arr, n);
        }

    }
}
