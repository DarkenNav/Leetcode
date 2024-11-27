using Leetcode.ArraysAndStrings;
using Leetcode.BinarySearch.Conclusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class ValidPerfectSquareTest
    {
        [Test]
        [TestCase(16)]
        [TestCase(14)]
        [TestCase(1024)]
        [TestCase(1111111)]
        public void Test1(int num)
        {
            Assert.That(
                new ValidPerfectSquareCase().IsPerfectSquare(num),
                Is.EqualTo(Math.Sqrt(num) % 1 == 0)
                );
        }
    }
}
