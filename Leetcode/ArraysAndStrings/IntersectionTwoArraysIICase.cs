using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class IntersectionTwoArraysIICase
    {
        public void Cases()
        {
            // Output: [2,2]
            var result_0 = Intersect([1, 2, 2, 1], [2, 2]);

            // Output: [4,9]
            var result_1 = Intersect([4, 9, 5], [9, 4, 9, 8, 4]);

            // Output: [6,4]
            var result_2 = Intersect([4, 7, 9, 7, 6, 4, 7], [5, 0, 4, 0, 6, 1, 6, 2, 2, 4]);
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var dictionary = new Dictionary<int, int>();
            var result = new List<int>();

            foreach (int i in nums1)
            {
                if (dictionary.ContainsKey(i))
                    dictionary[i]++;
                else
                    dictionary[i] = 1;
            }

            foreach (int i in nums2)
            {
                if(dictionary.ContainsKey(i) && dictionary[i] >= 1)
                {
                    result.Add(i);
                    dictionary[i]--;
                }
            }

            return [.. result];
        }
    }
}
