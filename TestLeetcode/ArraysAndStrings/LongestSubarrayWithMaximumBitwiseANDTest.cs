using Leetcode.ArraysAndStrings;
using Leetcode.BinarySearch.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.ArraysAndStrings
{
    public class LongestSubarrayWithMaximumBitwiseANDTest
    {
        // 1 <= nums.length <= 10^5
        // 1 <= nums[i] <= 10^6

        [Test]
        [TestCase(new int[] { 1, 2, 3, 3, 2, 2 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 77 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 3, 2, 2, 3, 3, 3, 3, 2 }, 4)]
        [TestCase(new int[] { 96317, 96317, 96317, 96317, 96317, 96317, 96317, 96317, 96317, 279979 }, 1)]
        [TestCase(new int[] { 96317, 96317, 96317, 96317, 96317, 96317, 96317, 96317, 96317 }, 9)]
        [TestCase(new int[] { 311155, 311155, 311155, 311155, 311155, 311155, 311155, 311155, 201191, 311155 }, 8)]
        public void Test1(int[] nums, int result)
        {
            Assert.That(
                new LongestSubarrayWithMaximumBitwiseAND()
                    .LongestSubarray(nums),
                Is.EqualTo(result)
                );
        }
    }
}
