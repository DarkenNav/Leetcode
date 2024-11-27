using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class SortAnArrayCase
    {
        public void Cases()
        {
            var result_0 = SortArray([5, 2, 3, 1]);
            var result_1 = SortArray([5, 1, 1, 2, 0, 0]);
        }

        public int[] SortArray(int[] nums)
        {
            var result = new int[nums.Length];
            Array.Copy(nums, result, nums.Length);
            HeapSort(result);
            return result;
        }

        private void HeapSort(int[] arr)
        {
            var n = arr.Length;
            for (var i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, n, i);
            }

            for (var i = n - 1; i >= 0; i--)
            {
                var tmp = arr[i];
                arr[i] = arr[0];
                arr[0] = tmp;

                MaxHeapify(arr, i, 0);
            }
        }

        private void MaxHeapify(int[] arr, int heapSize, int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var lagest = index;
            if (left < heapSize && arr[left] > arr[lagest])
            {
                lagest = left;
            }
            if (right < heapSize && arr[right] > arr[lagest])
            {
                lagest = right;
            }

            if (lagest != index)
            {
                var tmp = arr[index];
                arr[index] = arr[lagest];
                arr[lagest] = tmp;
                MaxHeapify(arr, heapSize, lagest);
            }
        }
    }
}
