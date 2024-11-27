using Leetcode.BinarySearch.Intro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class FindMinimumInRotatedSortedArrayTest
    {
        // n == nums.length
        // 1 <= n <= 5000
        // -5000 <= nums[i] <= 5000
        // All the integers of nums are unique.
        // nums is sorted and rotated between 1 and n times.

        [Test]
        [TestCase(new int[] { 3, 4, 5, 1, 2 }, 1)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        [TestCase(new int[] { 11, 13, 15, 17 }, 11)]
        [TestCase(new int[] { 1 }, 1)] 
        public void Test1(int[] nums, int result)
        {
            Assert.That(
                new FindMinimumInRotatedSortedArrayCase().FindMin(nums),
                Is.EqualTo(result)
                );
        }

        // All the integers of nums are NOT unique.
        [Test]
        [TestCase(new int[] { 1, 3, 5 }, 1)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        [TestCase(new int[] { 11, 13, 15, 17 }, 11)]
        [TestCase(new int[] { 2, 2, 2, 0, 1 }, 0)]
        [TestCase(new int[] { 11, 11, 11, 11, 11, 13, 15, 17 }, 11)]
        [TestCase(new int[] { 10, 1, 10, 10, 10 }, 1)]
        [TestCase(new int[] { 3, 5, 1 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        public void Test2(int[] nums, int result)
        {
            Assert.That(
                new FindMinimumInRotatedSortedArrayIICase().FindMin(nums),
                Is.EqualTo(result)
                );
        }
    }
}
