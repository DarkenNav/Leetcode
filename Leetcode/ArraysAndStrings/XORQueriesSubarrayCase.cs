using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class XORQueriesSubarrayCase
    {
        // 1310. XOR Queries of a Subarray
        public void Cases()
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
            var expected = task.XorQueries2(arr, queries);

            //var arr = new int[] { 4 };
            //var queries = new int[][] {
            //        new int[]{ 0, 0 }
            //    };
            //var task = new XORQueriesSubarrayCase();
            //var expected = task.XorQueries(arr, queries);
        }

        public int[] XorQueries(int[] arr, int[][] queries)
        {
            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                for (var j = queries[i][0]; j <= queries[i][1]; j++)
                {
                    result[i] = result[i] ^ arr[j];
                }
            }
            return result;
        }

        // ???? Подумать - не работает
        public int[] XorQueries2(int[] arr, int[][] queries)
        {
            var prefixXor = new int[arr.Length + 1];
            for(var i = 0; i < arr.Length;  i++)
            {
                prefixXor[i + 1] = prefixXor[i] ^ arr[i];
            }

            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = prefixXor[queries[i][1] + 1] ^ arr[queries[i][0]];
            }
            return result;
        }
    }
}
