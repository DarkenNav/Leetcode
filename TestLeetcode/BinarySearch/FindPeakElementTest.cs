using Leetcode.BinarySearch.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class FindPeakElementTest
    {
        //1 <= nums.length <= 1000
        //-2^31 <= nums[i] <= 2^31 - 1
        //nums[i] != nums[i + 1] for all valid i.

        [Test]
        [TestCase(new int[] { 1, 2, 3, 1 }, 2)]
        [TestCase(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
        [TestCase(new int[] { 1 }, 0)]
        public void Test1(int[] nums, int result)
        {
            Assert.That(
                new FindPeakElementCase().FindPeakElement(nums),
                Is.EqualTo(result)
                );
        }
    }
}
