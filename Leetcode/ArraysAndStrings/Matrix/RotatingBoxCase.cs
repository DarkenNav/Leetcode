using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Matrix
{
    public class RotatingBoxCase
        : IArrayLC, ITwoPointersLC, IMatrixLC
    {
        public void Cases()
        {
            // Output: [
            //  [".","#","#"],
            //  [".","#","#"],
            //  ["#","#","*"],
            //  ["#","*","."],
            //  ["#",".","*"],
            //  ["#",".","."]]
            var result_0 = RotateTheBox([
                ['#','#','*','.','*','.'],
                ['#','#','#','*','.','.'],
                ['#','#','#','.','#','.']
            ]);
        }

        public char[][] RotateTheBox(char[][] box)
        {
            var m = box.Length;
            var n = box[0].Length;

            var rotateBox = new char[n][];
            for(var i = 0; i < n; i++)
                rotateBox[i] = new char[m];

            for(var i = 0; i < n; i++)
            {
                for(var j = 0; j < m; j++)
                {
                    rotateBox[i][j] = box[m - 1 - j][i];
                }
            }

            // for each column rotate box, last row
            for(var j = 0; j < m; j++ )
            {
                var bottom = n - 1;
                for(var i = n - 1; i >= 0; i--)
                {
                    if(bottom == i && rotateBox[i][j] != '.')
                    {
                        bottom--;
                        continue;
                    }

                    if(rotateBox[i][j] == '*')
                    {
                        bottom = i - 1;
                    }
                    else if(rotateBox[i][j] == '#'
                        && rotateBox[bottom][j] == '.')
                    {
                        rotateBox[i][j] = '.';
                        rotateBox[bottom][j] = '#';
                        bottom--;
                    }
                }
            }

            return rotateBox;
        }
    }
}