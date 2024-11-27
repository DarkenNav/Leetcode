using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Matrix
{
    // 1975. Maximum Matrix Sum
    public class MaximumMatrixSumCase
        : IArrayLC, IMatrixLC, IGreedyLC
    {
        public void Cases()
        { 
            // Output: 4
            var result_0 = MaxMatrixSum([[1,-1],[-1,1]]);
            // Output: 16
            var result_1 = MaxMatrixSum([[1,2,3],[-1,-2,-3],[1,2,3]]);
        }

        public long MaxMatrixSum(int[][] matrix) 
        {
            long result = 0;
            var m = matrix.Length;
            var n = matrix[0].Length;
            var negativeCount = 0;
            var minValue = int.MaxValue;
            for(var i = 0; i < m; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    var val = matrix[i][j];
                    if(matrix[i][j] < 0)
                    {
                        negativeCount++;
                        val = matrix[i][j] * -1;                      
                    }

                    result += val;
                    minValue = Math.Min(minValue, val);
                }
            }
            return negativeCount % 2 != 0 ? result - 2 * minValue : result;
        }
    }
}