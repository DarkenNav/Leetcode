

namespace Leetcode.QueueAndStack.Conclusion
{
    public class ZeroOneMatrixCase 
    {
        public void Case()
        {
            //  [[0,0,0],[0,1,0],[0,0,0]]
            var result_0 = UpdateMatrix(new int[][] {
                new int[]{ 0, 0, 0 },
                new int[]{ 0, 1, 0 },
                new int[]{ 0, 0, 0 }
            });

            //  [[0,0,0],[0,1,0],[1,2,1]]
            var result_1 = UpdateMatrix(new int[][] {
                new int[]{ 0, 0, 0 },
                new int[]{ 0, 1, 0 },
                new int[]{ 1, 1, 1 }
            });

            //  [[1,2,1],[0,1,0],[0,1,0],[1,2,1]]
            var result_2 = UpdateMatrix(new int[][] {
                new int[]{ 1, 1, 1 },
                new int[]{ 0, 1, 0 },
                new int[]{ 0, 1, 0 },
                new int[]{ 1, 1, 1 },
            });


            var result_3 = UpdateMatrix(new int[][]{
                //        0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23                                         
                new int[]{0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1},
                new int[]{1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1},
                new int[]{0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1},
                new int[]{1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1},
                new int[]{1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1},
                new int[]{1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0},
                new int[]{1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0},
                new int[]{1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1},
                new int[]{1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0},
                new int[]{1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                new int[]{0, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0},
                new int[]{1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1},
                new int[]{0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1},
                new int[]{0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                new int[]{0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1},
                new int[]{0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1},
                new int[]{1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1},
                new int[]{1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1},
                new int[]{1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0},
                new int[]{0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1},
                new int[]{0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0},
                new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                new int[]{1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
                new int[]{1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1},
                new int[]{0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0},
                new int[]{1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
                new int[]{1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1},
                new int[]{1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1},
                new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1},
                new int[]{1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1}
                });
            

            //  [[1,2,1],[0,1,0],[0,1,0],[1,2,1]]
            var result_4 = UpdateMatrix(new int[][] {
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 0, 0, 0 },
            });
        }

        private const int NEARBY_CASES = 4;
        private static int[] NearbyR = new int[NEARBY_CASES] { -1, 0, 1, 0 };
        private static int[] NearbyC = new int[NEARBY_CASES] { 0, 1, 0, -1 };

        public int[][] UpdateMatrix(int[][] mat)
        {
            var m = mat.Length;
            var n = mat[0].Length;

            var distances = new int[m][];
            var visits = new bool[m][];
            for (var i = 0; i < m; i++)
            {
                distances[i] = new int[n];
                Array.Fill(distances[i], int.MaxValue);
                visits[i] = new bool[n];
            }

            var queue = new Queue<(int qRow, int qColumn)>();
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        distances[i][j] = 0;
                        visits[i][j] = true;
                    }
                }
            }

            while (queue.Count > 0)
            {
                (int qRow, int qColumn) = queue.Dequeue();
                for (var i = 0; i < NEARBY_CASES; i++)
                {
                    var newRow = qRow + NearbyR[i];
                    var newColumn = qColumn + NearbyC[i];

                    if (newRow >= 0 && newRow < m
                        && newColumn >= 0 && newColumn < n
                        && !visits[newRow][newColumn]
                        && distances[newRow][newColumn] == int.MaxValue)
                    {
                        distances[newRow][newColumn] = distances[qRow][qColumn] + 1;
                        visits[newRow][newColumn] = true;
                        queue.Enqueue((newRow, newColumn));
                    }
                }
            }

            return distances;
        }

    }
}
