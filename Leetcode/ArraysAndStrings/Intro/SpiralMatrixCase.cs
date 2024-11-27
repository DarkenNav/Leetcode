
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class SpiralMatrixCase 
    {
        public void Case()
        {
            var result1 = SpiralOrder(new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            });
            var result2 = SpiralOrder(new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 }
            });
            var result3 = SpiralOrder(new int[][] {
                new int[] { 2, 3 }
            });
            var result4 = SpiralOrder(new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 }
            });
            var result5 = SpiralOrder(new int[][] {
                new int[] { 3 },
                new int[] { 2 }
            });
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var length = m * n;

            var result = new int[length];
            var i = 0;
            var j = 0;
            var circle = 0;
            var step = 0;
            if(n == 1)
                step = 1;
            for ( var k = 0; k < length; k++ )
            {
                result[k] = matrix[i][j];
                switch (step)
                {
                    case 0:
                        if(j + 1 == n - 1 - circle)
                            step = 1;
                        j++;                         
                        break;
                    case 1:
                        if (i + 1 == m - 1 - circle)
                            step = 2;
                        i++; 
                        break;
                    case 2:
                        if (j - 1 == 0 + circle)
                            step = 3;
                        j--; 
                        break;
                    case 3:
                        if (i - 1 == 1 + circle)
                        {
                            circle++;
                            step = 0;
                        }
                        i--; 
                        break;
                }
            }
            return result;
        }
    }
}
