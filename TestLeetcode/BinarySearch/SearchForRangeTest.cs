using Leetcode.BinarySearch.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestLeetcode.BinarySearch
{
    public class SearchForRangeTest
    {
        // 0 <= nums.length <= 10^5
        // -10^9 <= nums[i] <= 10^9
        // nums is a non-decreasing array.
        // -10^9 <= target <= 10^9

        [Test]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
        [TestCase(new int[] { 11 }, 11, new int[] { 0, 0 })]
        [TestCase(new int[] { }, 0, new int[] { -1, -1 })]
        [TestCase(new int[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 }, 7, new int[] { 0, 10 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 0, 0 })]
        [TestCase(new int[] { 1, 3 }, 1, new int[] { 0, 0 })]
        [TestCase(new int[] { 1, 4 }, 4, new int[] { 1, 1 })]
        public void Test1(int[] nums, int target, int[] result)
        {
            Assert.That(
                new SearchForRangeCase().SearchRange(nums, target),
                Is.EqualTo(result)
                );
        }
    }
}
