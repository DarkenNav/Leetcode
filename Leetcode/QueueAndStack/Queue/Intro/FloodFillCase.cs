
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Leetcode.QueueAndStack.Queue.Intro
{
    public class FloodFillCase 
    {
        public void Case()
        {
            //  [[2,2,2],[2,2,0],[2,0,1]]
            var result_0 = FloodFill(new int[][] {
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 0 },
                new int[]{ 1, 0, 1 }
            }, 1, 1, 2);

            //  [[0,0,0],[0,0,0]]
            var result_1 = FloodFill(new int[][] {
                new int[]{ 0,0,0 },
                new int[]{ 0,0,0 }
            }, 0, 0, 0);
        }

        private const int NEARBY_CASES = 4;
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color)
                return image;

            var m = image.Length;
            var n = image[0].Length;

            var nearbyR = new int[NEARBY_CASES] { -1, 0, 1, 0 };
            var nearbyC = new int[NEARBY_CASES] { 0, 1, 0, -1 };

            var newImage = new int[m][];
            var visits = new bool[m][];
            for( var i = 0; i < m; i++)
            {
                visits[i] = new bool[n];
                newImage[i] = new int[n];
                Array.Copy(image[i], newImage[i], n);
            }

            var stack = new Stack<(int row, int column)>();
            stack.Push((sr, sc));
            visits[sr][sc] = true;
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                for(var i = 0; i < NEARBY_CASES; i++)
                {
                    var nextR = current.row + nearbyR[i];
                    var nextC = current.column + nearbyC[i];
                    if(nextR >= 0 && nextR < m
                        && nextC >= 0 && nextC < n
                        && !visits[nextR][nextC]
                        && image[current.row][current.column] == image[nextR][nextC])
                    {
                        stack.Push((nextR, nextC));
                        visits[nextR][nextC] = true;
                    }
                    newImage[current.row][current.column] = color;
                }                
            }
            return newImage;
        }
    }
}
