using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Matrix
{
    // 1072. Flip Columns For Maximum Number of Equal Rows
    public class FlipColumnsForMaximumNumberEqualRowsCase
    {
        internal void Cases()
        {
            // Output: 1
            var result_0 = MaxEqualRowsAfterFlips([[0,1],[1,1]]);
            // Output: 2
            var result_1 = MaxEqualRowsAfterFlips([[0,1],[1,0]]);
            // Output: 2
            var result_2 = MaxEqualRowsAfterFlips([
                [0,0,0], // [0,0,1]
                [0,0,1], // [0,0,0]
                [1,1,0]  // [1,1,1]
                ]);
        }

        public int MaxEqualRowsAfterFlips(int[][] matrix) 
        {
            var n = matrix[0].Length;
            var maxIdenticalRows = 0;
            foreach(var currentRow in matrix)
            {
                var flippedRow = new int[n];
                var identicalRowsCount = 0;
                for(var j = 0; j < n; j++)
                    flippedRow[j] = 1 - currentRow[j];

                foreach(var compareRow in matrix)
                {
                    if(compareRow.SequenceEqual(currentRow)
                        || compareRow.SequenceEqual(flippedRow))
                    {
                       identicalRowsCount++; 
                    }
                }
                maxIdenticalRows = Math.Max(identicalRowsCount, maxIdenticalRows);
            }

            return maxIdenticalRows;     
        }
    }
}