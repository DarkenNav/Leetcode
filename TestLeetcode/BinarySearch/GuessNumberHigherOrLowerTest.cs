using Leetcode.BinarySearch.Untro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class GuessNumberHigherOrLowerTest
    {
        [Test]
        // 1 <= n <= 2^31 - 1
        // 1 <= pick <= n
        [TestCase(10, 6)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(1000, 175)]
        [TestCase(int.MaxValue, int.MaxValue / 22)]
        public void Test1(int n, int pick)
        {
            var guess = new GuessNumberHigherOrLowerCase();
            guess.pick = pick;

            Assert.That(
                guess.GuessNumber(n), 
                Is.EqualTo(pick)
                );
        }
    }
}
