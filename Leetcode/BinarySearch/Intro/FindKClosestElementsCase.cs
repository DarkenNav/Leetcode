using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class FindKClosestElementsCase
    {
        public void Cases()
        {
            // 1,2,3,4
            var nums_0 = new int[] { 1, 2, 3, 4, 5 };
            var k_0 = 4;
            var x_0 = -1;
            var result_0 = FindClosestElements(nums_0, k_0, x_0);
            var result_0_1 = printKclosest(nums_0, x_0, k_0, nums_0.Length);

        }

        // |k - x| < |b - x|, or |k - x| == |b - x| and k < b

        private int GetCross(int[] arr, int k, int x)
        {
            var left = 0;
            var right = arr.Length - 1;
            var cross = 0;

            // Find cross where before nums[i] <= x after nums[i] > x
            while (left < right)
            {
                if (arr[right] <= x)
                    return right;
                if (arr[left] > x)
                    return left;

                var mid = left + (right - left) / 2;
                if (arr[mid] <= x && arr[mid + 1] > x)
                    return mid;
                else if (arr[mid] < x)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return cross;
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var result = new HashSet<int>();

            var count = 0;
            var left = GetCross(arr, k, x);
            var right = left + 1;

            // If x in nums -> move left to left
            if (arr[left] == x)
                left--;

            // Compare elements on left and right of crossover point to find the k closest elements
            while (left >= 0 && right < arr.Length && count < k)
            {
                if (x - arr[left] < arr[right] - x)
                    result.Add(arr[left--]);
                else 
                    result.Add(arr[right++]);

                count++;
            }

            while (count < k && left >= 0)
            {
                result.Add(arr[left--]);
                count++;
            }

            while (count < k && right < arr.Length)
            {
                result.Add(arr[right++]);
                count++;
            }

            return [.. result.Order()];
        }

// Рекурсия ---------------------------------------------------------------
        private int findCrossOver(int[] arr, int low,
                            int high, int x)
        {
            // Base cases
            // x is greater than all
            if (arr[high] <= x)
                return high;

            // x is smaller than all
            if (arr[low] > x)
                return low;

            // Find the middle point
            /* low + (high - low)/2 */
            int mid = (low + high) / 2;

            /* If x is same as middle element, then
            return mid */
            if (arr[mid] <= x && arr[mid + 1] > x)
                return mid;

            /* If x is greater than arr[mid], then 
            either arr[mid + 1] is ceiling of x or
            ceiling lies in arr[mid+1...high] */
            if (arr[mid] < x)
                return findCrossOver(arr, mid + 1,
                                          high, x);

            return findCrossOver(arr, low, mid - 1, x);
        }

        // This function prints k closest elements 
        // to x in arr[]. n is the number of 
        // elements in arr[]
        public IList<int> printKclosest(int[] arr, int x,
                                      int k, int n)
        {
            var result = new HashSet<int>();

            // Find the crossover point
            int l = findCrossOver(arr, 0, n - 1, x);

            // Right index to search
            int r = l + 1;

            // To keep track of count of elements
            int count = 0;

            // If x is present in arr[], then reduce 
            // left index Assumption: all elements in
            // arr[] are distinct
            if (arr[l] == x) l--;

            // Compare elements on left and right of 
            // crossover point to find the k closest
            // elements
            while (l >= 0 && r < n && count < k)
            {
                if (x - arr[l] < arr[r] - x)
                    result.Add(arr[l--]);
                else
                    result.Add(arr[r++]);
                count++;
            }

            // If there are no more elements on right 
            // side, then print left elements
            while (count < k && l >= 0)
            {
                result.Add(arr[l--]);
                count++;
            }

            // If there are no more elements on left 
            // side, then print right elements
            while (count < k && r < n)
            {
                result.Add(arr[r++]);
                count++;
            }

            return [.. result.Order()];
        }
    }
}
