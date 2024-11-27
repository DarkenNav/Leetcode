using Leetcode.BinarySearch.Intro;
using Leetcode.SortingAndSearching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class FirstBadVersionTest
    {
        [Test]
        // 1 <= bad <= n <= 2^31 - 1
        [TestCase(5, 4)]
        [TestCase(1, 1)]
        [TestCase(1000, 232)]
        [TestCase(int.MaxValue, 1000021)]
        public void Test1(int n, int bad)
        {
            var task = new FirstBadVersionCase();
            task.bad = bad;
            var expected = task.FirstBadVersion(n);

            Assert.That(expected, Is.EqualTo(bad));
        }
    }
}
