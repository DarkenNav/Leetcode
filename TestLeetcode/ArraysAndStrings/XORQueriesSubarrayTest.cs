using Leetcode.ArraysAndStrings;
using Leetcode.SortingAndSearching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetcode.ArraysAndStrings
{
    public class XORQueriesSubarrayTest
    {
        //  1 <= arr.length, queries.length <= 3 * 10^4
        //  1 <= arr[i] <= 10^9
        //  queries[i].length == 2
        //  0 <= lefti <= righti<arr.length

        [Test]
        public void Test1()
        {
            var arr = new int[] { 1, 3, 4, 8 };
            var queries = new int[][] {
                    new int[]{ 0, 1 },
                    new int[]{ 1, 2 },
                    new int[]{ 0, 3 },
                    new int[]{ 3, 3 }
                };
            var actual = new int[] { 2, 7, 14, 8 };

            var task = new XORQueriesSubarrayCase();
            var expected = task.XorQueries(arr, queries);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 4, 8, 2, 10 };
            var queries = new int[][] {
                    new int[]{ 2, 3 },
                    new int[]{ 1, 3 },
                    new int[]{ 0, 0 },
                    new int[]{ 0, 3 }
                };
            var actual = new int[] { 8, 0, 4, 4 };

            var task = new XORQueriesSubarrayCase();
            var expected = task.XorQueries(arr, queries);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] { 4 };
            var queries = new int[][] {
                    new int[]{ 0, 0 }
                };
            var actual = new int[] { 4 };

            var task = new XORQueriesSubarrayCase();
            var expected = task.XorQueries(arr, queries);

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
