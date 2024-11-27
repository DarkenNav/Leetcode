using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class HeapSortCase
    {
        public void Cases()
        {
            int[] arr_0 = [1, 5, 6, 7, 8, 3, 5, 3, 123, 3, 2, 5, 11];
            HeapSort(arr_0);
        }

        public void HeapSort(int[] arr)
        {
            var n = arr.Length;
            for(var i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, n, i);
            }

            for(var i = n - 1; i >= 0; i--)
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
            if(left < heapSize && arr[left] > arr[lagest])
            {
                lagest = left;
            }
            if(right < heapSize && arr[right] > arr[lagest])
            {
                lagest = right;
            }

            if(lagest != index)
            {
                var tmp = arr[index];
                arr[index] = arr[lagest]; 
                arr[lagest] = tmp;
                MaxHeapify(arr, heapSize, lagest);
            }
        }
    }
}
