using Leetcode.BinarySearch.Untro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class SqrtTest
    {
        [Test]
        // 0 <= x <= 2^31 - 1
        [TestCase(4)]
        [TestCase(0)]
        //[TestCase(-1)]
        [TestCase(16)]
        [TestCase(1000)]
        [TestCase(int.MaxValue)]
        public void Test1(int x)
        {
            var result = new SqrtCase().MySqrt(x);

            Assert.That(result, Is.EqualTo((int)Math.Sqrt(x)));
        }


    }
}
