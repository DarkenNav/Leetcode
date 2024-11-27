using Leetcode.BinarySearch.Conclusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.BinarySearch
{
    public class FindSmallestLetterGreaterThanTargetTest
    {
        [Test]
        [TestCase(new char[] { 'c', 'f', 'j' }, 'a', 'c')]
        [TestCase(new char[] { 'c', 'f', 'j' }, 'c', 'f')]
        [TestCase(new char[] { 'x', 'x', 'y', 'y' }, 'z', 'x')]
        [TestCase(new char[] { 'c', 'f', 'j' }, 'd', 'f')]
        [TestCase(new char[] { 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n' }, 'n', 'e')]
        public void Test1(char[] letters, char target, char result)
        {
            Assert.That(
                new FindSmallestLetterGreaterThanTargetCase().NextGreatestLetter(letters, target),
                Is.EqualTo(result)
                );
        }
    }
}
