using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Matrix
{
    public class CountSquareSubmatricesWithAllOnesCase
    {
        public void Cases()
        {
            // Output: 15
            var result_0 = CountSquares([
              [0,1,1,1],
              [1,1,1,1],
              [0,1,1,1]
            ]);

            // Output: 7
            var result_1 = CountSquares([
              [1,0,1],
              [1,1,0],
              [1,1,0]
            ]);
        }

        // О ( М∗Н∗М в ( М ,Н ))
        public int CountSquares(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var countSquares = 0;
            for (var i = 0; i < m; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    // matrix[i][j] start point
                    var k = 0;
                    while(i + k < m && j + k < n)
                    {
                        // grow square, if any 0 - next i,j 
                        if(!MatrixCheck(matrix, [i, j], k))
                            break;

                        k++;
                        countSquares++;
                    }
                }
            }
            return countSquares;
        }

        private bool MatrixCheck(int[][] matrix, int[] startPosition, int width) 
        {
            var m = startPosition[0] + width;
            var n = startPosition[1] + width;
            for (var i = startPosition[0]; i <= m; i++)
            {
                for (var j = startPosition[1]; j <= n; j++)
                {
                    if (matrix[i][j] == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
