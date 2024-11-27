

namespace Leetcode.QueueAndStack.Queue.Intro
{
    public class NumberOfIslandsCase 
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

        private void BFS(char[][] grid, bool[][] visits, int row, int column, int maxRow, int maxColumn)
        {
            var queue = new Queue<(int, int)>();
            queue.Enqueue((row, column));
            visits[row][column] = true;

            var nearbyRow = new int[4] { -1, 0, 1, 0 };
            var nearbyColumn = new int[4] { 0, 1, 0, -1 };

            while (queue.Count > 0)
            {
                var (queueRow, queueColumn) = queue.Dequeue();
                for(var i = 0; i < 4; i++)
                {
                    var newRow = queueRow + nearbyRow[i];
                    var newColumn = queueColumn + nearbyColumn[i];
                    if(newRow >= 0 && newRow < maxRow
                        && newColumn >= 0 && newColumn < maxColumn
                        && grid[newRow][newColumn] == '1' 
                        && !visits[newRow][newColumn])
                    {
                        visits[newRow][newColumn] = true;
                        queue.Enqueue((newRow, newColumn));
                    }
                }
            }
        }

        public int NumIslands(char[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var visits = new bool[m][];
            for(var i = 0; i < m; i++)
            {
                visits[i] = new bool[n];
            }

            int islands = 0;
            for (var i = 0; i < m; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1' && !visits[i][j])
                    {
                        BFS(grid, visits, i, j, m, n);
                        islands++;
                    }
                }
            }
            return islands;
        }   
    }
}
