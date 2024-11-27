using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Matrix
{
    public class RotateImageCase
    {
        public void Cases()
        {
            // Output: [[7,4,1],[8,5,2],[9,6,3]]
            var mat_0 = new int[][] {   [1, 2, 3], 
                                        [4, 5, 6], 
                                        [7, 8, 9] };
            Rotate(mat_0);
            // Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
            var mat_1 = new int[][] { [5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16] };
            Rotate(mat_1);

        }

        public void Rotate(int[][] matrix)
        {
            // m = 4
            var m = matrix.Length;

            // [5,  1,  9,  11],
            // [2,  4,  8,  10],
            // [13, 3,  6,  7],
            // [15, 14, 12, 16]
            // move each circle in matrix
            for (var i = 0; i < m / 2; i++)
            {
                for(var j = i; j < m - i - 1; j++)
                {
                    // 5 <- 15 <- 16 <- 11 <- 5;
                    // 1 <- 13 <- 12 <- 10 <- 1   

                    // j=0 [0][0] ; j=1 [0][1] ...
                    var tmp = matrix[i][j];
                    // [0][0] <- [3][0] ; [0][1] <- [2][0] ...
                    matrix[i][j] = matrix[m - j - 1][i];
                    // [3][0] <- [3][3]; [2][0] <- [3][2] ...
                    matrix[m - j - 1][i] = matrix[m - i - 1][m - j - 1];
                    // [3][3] <- [0][3] ; [3][2] <- [1][2] ...
                    matrix[m - i - 1][m - j - 1] = matrix[j][m - i - 1];
                    // [0][3] <- [0][0] ; [1][2] <- [0][1] ...
                    matrix[j][m - i - 1] = tmp;
                }
            }
        }
    }
}
