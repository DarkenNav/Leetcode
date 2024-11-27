using Leetcode.BinarySearch.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class FindKClosestElementsTest
    {
        // 1 <= k <= arr.length
        // 1 <= arr.length <= 10^4
        // arr is sorted in ascending order.
        // -10^4 <= arr[i], x <= 10^4

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -1, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, 1, 0, new int[] { 1 })]
        [TestCase(new int[] { 1, 1, 1, 10, 10, 10 }, 1, 9, new int[] { 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3, new int[] { 1, 2, 4, 5 })]
        public void Test1(int[] nums, int k, int x, IList<int> result)
        {
            Assert.That(
                new FindKClosestElementsCase().FindClosestElements(nums, k, x),
                Is.EqualTo(result)
                );
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -1, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, 1, 0, new int[] { 1 })]
        [TestCase(new int[] { 1, 1, 1, 10, 10, 10 }, 1, 9, new int[] { 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3, new int[] { 1, 2, 4, 5 })]
        public void Test2(int[] nums, int k, int x, IList<int> result)
        {
            var n = nums.Length;    
            Assert.That(
                new FindKClosestElementsCase().printKclosest(nums, x, k, n),
                Is.EqualTo(result)
                );
        }
    }
}
