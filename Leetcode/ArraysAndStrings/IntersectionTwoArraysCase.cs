using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class IntersectionTwoArraysCase
    {
        public void Cases()
        {
            // Output: [2]
            //var result_0 = Intersection([1, 2, 2, 1], [2, 2]);

            // Output: [9,4]
            //var result_1 = Intersection([4, 9, 5], [9, 4, 9, 8, 4]);

            // Output: [6,4]
            var result_2 = Intersection([4, 7, 9, 7, 6, 7], [5, 0, 0, 6, 1, 6, 2, 2, 4]);
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var set = new HashSet<int>();
            foreach (int i in nums1)
            {
                set.Add(i);
            }
            var setResult = new HashSet<int>();
            foreach (int i in nums2)
            {
                if(set.Contains(i))
                    setResult.Add(i);
            }
            return setResult.ToArray();
        }

        public int[] Intersection_1(int[] nums1, int[] nums2)
        {
            var dictionary = new Dictionary<int, int>();
            var result = new List<int>();

            foreach (int i in nums1)
            {
                dictionary[i] = 1;
            }

            foreach (int i in nums2)
            {
                if(dictionary.ContainsKey(i) && dictionary[i] == 1)
                {
                    result.Add(i);
                    dictionary[i] = 0;
                }
            }

            return result.ToArray();
        }
    }
}
