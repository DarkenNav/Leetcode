using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 2022. Convert 1D Array Into 2D Array
    public class Convert1DArrayInto2DArrayCase
    {
        public void Cases()
        {
            //[[1, 2],[3, 4]]
            var result_0 = Construct2DArray([1, 2, 3, 4], 2, 2);
            //[[1, 2, 3]]
            var result_1 = Construct2DArray([1, 2, 3], 1, 3);
            //[]
            var result_2 = Construct2DArray([1, 2], 1, 1);
        }

        public int[][] Construct2DArray(int[] original, int m, int n)
        {
            if (m * n != original.Length)
                return [];

            var result = new int[m][];
            var j = 0;
            for(var i = 0; i < m; i++)
            {
                result[i] = original[j..(j + n)];
                j = j + n;
            }

            return result;
        }
    }
}
