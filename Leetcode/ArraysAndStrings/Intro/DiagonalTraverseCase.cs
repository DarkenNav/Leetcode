
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class DiagonalTraverseCase
    {
        public void Case()
        {
            var result1 = FindDiagonalOrder(new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            });
            var result2 = FindDiagonalOrder(new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
            });
            var result3 = FindDiagonalOrder(new int[][] {
                new int[] { 2, 5, 8 },
                new int[] { 4, 0, -1 }
            });
        }

        public int[] FindDiagonalOrder(int[][] mat)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var length = m * n;

            var result = new int[length];
            var i = 0;
            var j = 0;
            for ( var k = 0; k < length; k++ )
            {
                result[k] = mat[i][j];
                // Если четное идем вверх i-- вправо j++
                if ((i + j) % 2 == 0)
                {
                    if (j + 1 >= n)
                    {
                        // Если вправо нельзя - меняем направление
                        i = i + 1 >= m ? m - 1 : i + 1;
                    }
                    else
                    {
                        i = i - 1 <= 0 ? 0 : i - 1;
                        j++;
                    }
                }
                // Если не четное идем вниз i++ ввлево j-- 
                else
                {
                    if (i + 1 >= m)
                    {
                        // Если вниз нельзя - меняем направление
                        j = j + 1 >= n ? n - 1 : j + 1;
                    }
                    else
                    {
                        i++;
                        j = j - 1 <= 0 ? 0 : j - 1; 
                    }
                }
            }

            return result;
        }
    }
}
