
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching
{
    // Task 1048. Longest String Chain
    public class MergeSortedArrayCase 
    {
        public void Cases()
        {
            // Выход: [1,2,2,3,5,6]
            var nums1_1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var nums2_1 = new int[] { 2, 5, 6 };
            Merge(nums1_1, 3, nums2_1, 3);
            // Вывод: [1]
            var nums1_2 = new int[] { 1 };
            var nums2_2 = new int[] { };
            Merge(nums1_2, 1, nums2_2, 0);
            // Вывод: [1]
            var nums1_3 = new int[] { 0 };
            var nums2_3 = new int[] { 1 };
            Merge(nums1_3, 0, nums2_3, 1);
            // Вывод: [1,2]
            var nums1_4 = new int[] { 2,0 };
            var nums2_4 = new int[] { 1 };
            Merge(nums1_4, 1, nums2_4, 1);

        }

        // --- O(n)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (var i = m + n - 1; i >= 0; i--)
            {
                if(n - 1 >= 0 && m - 1 >= 0)
                {
                    if (nums1[m - 1] <= nums2[n - 1])
                        nums1[i] = nums2[--n];
                    else
                        nums1[i] = nums1[--m];
                }
                else if(n - 1 >= 0)
                    nums1[i] = nums2[--n];
                else if (m - 1 >= 0)
                    nums1[i] = nums1[--m];
            }
        }

        // Order() -- O(n^2)
        public void Merge_1(int[] nums1, int m, int[] nums2, int n)
        {
            if(n < 1) return;

            var lenght = nums1.Length;
            var result = new int[lenght];
            nums1.CopyTo( result, 0);

            for (int i = 0; i < nums2.Length; i++)
            {
                result[m + i] = nums2[i];
            }

            result.Order().ToArray().CopyTo(nums1, 0);
        }
    }
}
