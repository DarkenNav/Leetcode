using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Conclusion
{
    public class MedianTwoSortedArraysCase
    {
        public void Cases()
        {
            // Output: 2.00000
            var result_0 = FindMedianSortedArrays([1, 3], [2]);
            // Output: 2.50000
            var result_1 = FindMedianSortedArrays([1, 2], [3, 4]);
        }

        //  O((n + m)*log (n + m))
        public double FindMedianSortedArrays_1(int[] nums1, int[] nums2)
        {
            var full = nums1.Concat(nums2).ToArray();
            Array.Sort(full);

            var n = full.Length;
            if(n % 2 == 0)
            {
                var mid = n / 2;
                return (full[mid] + full[mid - 1]) / 2.0;
            }

            return full[n / 2];
        }

        //  O(log(min(n, m))
        // Наша цель — найти точки в обоих массивах, такие,
        // что все элементы в первом наборе будут меньше,
        // чем все элементы в элементах в другом наборе
        // (наборе, содержащем элементы с правой стороны). 
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var n = nums1.Length;
            var m = nums2.Length;

            if(n > m)
                return FindMedianSortedArrays(nums2, nums1);

            var low = 0;
            var high = n;
            while (low <= high)
            {
                var mid1 = (low + high) / 2;
                var mid2 = (n + m + 1) / 2 - mid1;

                // Find elements to the left and right of partition in arr1
                var leftNums1 = (mid1 == 0 ? int.MinValue : nums1[mid1 - 1]);
                var rightNums1 = (mid1 == n ? int.MaxValue : nums1[mid1]);

                // Find elements to the left and right of partition in arr2
                var leftNums2 = (mid2 == 0 ? int.MinValue : nums2[mid2 - 1]);
                var rightNums2 = (mid2 == m ? int.MaxValue : nums2[mid2]);

                if(leftNums1 <= rightNums2 && leftNums2 <= rightNums1)
                {
                    if ((n + m) % 2 == 0)
                    {
                        var mid = n / 2;
                        return (Math.Max(leftNums1, leftNums2) +
                            Math.Min(rightNums1, rightNums2)) / 2.0;
                    }

                    return Math.Max(leftNums1, leftNums2);
                }

                if(leftNums1 > rightNums2)
                    high = mid1 - 1;
                else
                    low = mid1 + 1;
            }
            return 0;
        }
    }
}
