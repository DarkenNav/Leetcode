using Leetcode.BinarySearch.Intro;
using Leetcode.BinarySearch.Untro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class SearchInRotatedSortedArrayTest
    {
        [Test]
        // 1 <= nums.length <= 5000
        // -10^4 <= nums[i] <= 10^4
        // -104 <= target <= 104
        [TestCase(new int[] { 7, 8, 0, 1, 2, 3, 4 }, 8, 1)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
        [TestCase(new int[] { 1 }, 0, -1)]
        [TestCase(new int[] { 1 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5, 4)]
        [TestCase(new int[] { 3, 1}, 1, 1)]
        [TestCase(new int[] { 3, 1, 2 }, 1, 1)]
        [TestCase(new int[] { 8, 1, 2, 3, 4, 5, 6, 7 }, 6, 6)]
        public void Test1(int[] nums, int target, int result)
        {
            Assert.That(
                new SearchInRotatedSortedArrayCase().Search(nums, target),
                Is.EqualTo(result)
                );
        }
    }
}
