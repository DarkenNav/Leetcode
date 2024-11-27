using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class KthLargestElementInAnArrayCase
    {
        public void Cases()
        {
            // Output: 5 
            var result_0 = FindKthLargest([3, 2, 1, 5, 6, 4], 2);
            // Output: 4
            var result_1 = FindKthLargest([3, 2, 3, 1, 2, 4, 5, 5, 6], 4);
        }

        public int FindKthLargest(int[] nums, int k)
        {
            var n = nums.Length;
            if (n == 1) return nums[0];

            var heap = new int[n];
            Array.Copy(nums, heap, nums.Length);

            for (var i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(heap, n, i);
            }

            for (var i = n - 1; i >= n - k; i--)
            {
                var tmp = heap[i];
                heap[i] = heap[0];
                heap[0] = tmp;

                MaxHeapify(heap, i, 0);
            }

            return heap[n - k];
        }

        private void MaxHeapify(int[] arr, int size, int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var lagest = index;

            if(left < size && arr[left] > arr[lagest])
            {
                lagest = left;
            }
            if (right < size && arr[right] > arr[lagest])
            {
                lagest = right;
            }

            if(lagest != index)
            {
                var tmp = arr[index]; 
                arr[index] = arr[lagest];
                arr[lagest] = tmp;
                MaxHeapify(arr, size, lagest);
            }
        }

        // Submission Result: Time Limit Exceeded
        public int FindKthLargest_2(int[] nums, int k)
        {
            var n = nums.Length;
            if (n == 1) return nums[0];

            var map = new bool[n];
            var max = int.MinValue;
            var indexMax = 0;
            for (var j = 0; j < k; j++)
            {
                max = int.MinValue;
                var left = 0;
                var right = n - 1;
                while(left <= right)
                {
                    if (!map[left] && max < nums[left])
                    {
                        max = nums[left];
                        indexMax = left;
                    }
                    if (!map[right] && max < nums[right])
                    {
                        max = nums[right];
                        indexMax = right;
                    }
                    left++;
                    right--;
                }

                map[indexMax] = true;
            }
            return max;
        }

        // Submission Result: Time Limit Exceeded
        public int FindKthLargest_1(int[] nums, int k)
        {
            var n = nums.Length;
            var map = new bool[n];
            var max = int.MinValue;
            var indexMax = 0;
            for (var j = 0; j < k; j++)
            {
                max = int.MinValue;
                for (var i = 0; i < n; i++)
                {
                    if(!map[i] && max < nums[i])
                    {
                        max = nums[i];
                        indexMax = i;
                    }
                }
                map[indexMax] = true;
            }
            return max;
        }
    }
}
