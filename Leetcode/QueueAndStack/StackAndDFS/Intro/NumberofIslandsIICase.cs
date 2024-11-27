
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.StackAndDFS.Intro
{
    public class NumberofIslandsIICase 
    {
        public void Case()
        {
            var grid1 = new char[][]{
              new char[]{'1','1','1','1','0'},
              new char[]{'1','1','0','1','0'},
              new char[]{'1','1','0','0','0'},
              new char[]{'0','0','0','0','0'}
            };
            var res1 = NumIslands(grid1); // Result 1

            var grid2 = new char[][]{
              new char[]{'1','1','0','0','0'},
              new char[]{'1','1','0','0','0'},
              new char[]{'0','0','1','0','0'},
              new char[]{'0','0','0','1','1'}
            };
            var res2 = NumIslands(grid2); // Result 3
        }

        private const int NEARBY_CASES = 4;
        private void DFS(char[][] grid, bool[][] visits, int row, int column, int maxRow, int maxColumn)
        {
            var stack = new Stack<(int, int)>();
            stack.Push((row, column));
            visits[row][column] = true;

            var nearbyRow = new int[NEARBY_CASES] { -1, 0, 1, 0 };
            var nearbyColumn = new int[NEARBY_CASES] { 0, 1, 0, -1 };

            while (stack.Count > 0)
            { 
                var (stackRow, stackColumn) = stack.Pop();
                for (var i = 0; i < NEARBY_CASES; i++)
                {
                    var newRow = stackRow + nearbyRow[i];
                    var newColumn = stackColumn + nearbyColumn[i];
                    if (newRow >= 0 && newRow < maxRow
                        && newColumn >= 0 && newColumn < maxColumn
                        && grid[newRow][newColumn] == '1'
                        && !visits[newRow][newColumn])
                    {
                        visits[newRow][newColumn] = true;
                        stack.Push((newRow, newColumn));
                    }
                }
            }
        }

        public int NumIslands(char[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var visits = new bool[m][];
            for (var i = 0; i < m; i++)
            {
                visits[i] = new bool[n];
            }

            int islands = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1' && !visits[i][j])
                    {
                        DFS(grid, visits, i, j, m, n);
                        islands++;
                    }
                }
            }
            return islands;
        }
    }
}
