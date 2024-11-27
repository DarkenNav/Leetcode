using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    // 179. Largest Number
    public class LargestNumberCase
    {
        public void Cases()
        {
            var result_0 = LargestNumber([10, 2]);
            var result_1 = LargestNumber([3, 30, 34, 5, 9]);
        }

        private class CustomStringComparer : IComparer<String>
        {
            public int Compare(string? x, string? y)
            {
                return (x + y).CompareTo(y + x);
            }
        }

        public string LargestNumber(int[] nums)
        {
            var strSorted = nums
                .Select(x => x.ToString())
                .OrderByDescending(x => x, new CustomStringComparer())
                .ToArray();

            if (strSorted[0].Equals("0"))
                return "0";

            return string.Join("", strSorted);
        }
    }
}
