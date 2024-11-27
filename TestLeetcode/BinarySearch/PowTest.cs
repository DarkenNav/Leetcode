using Leetcode.BinarySearch.Conclusion;
using Leetcode.BinarySearch.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class PowTest
    {
        //-100.0 < x< 100.0
        //-2^31 <= n <= 2^31-1
        //n is an integer.
        //Either x is not zero or n > 0.
        //-10^4 <= xn <= 10^4

        [Test]
        [TestCase(2, 10, 1024)]
        [TestCase(2.1, 3, 9.261)]
        [TestCase(2, -2, 0.25)]
        [TestCase(2, 0, 1)]
        [TestCase(0, 11, 0)]
        [TestCase(2, -2147483648, 0)]
        public void Test1(double x, int n, double result)
        {
            Assert.That(
                new PowCase().MyPow(x, n),
                Is.EqualTo(Math.Pow(x, n))
                );
        }
    }
}
