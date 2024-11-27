using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Matrix
{
    public class CountUnguardedCellsInGridCase
        : IArrayLC, IMatrixLC
    {
        public void Cases()
        {
            // Output: 7
            var result_0 = CountUnguarded(4, 6, 
                [[0,0],[1,1],[2,3]],
                [[0,1],[2,2],[1,4]]);

            // Output: 4
            var result_1 = CountUnguarded(3, 3, 
                [[1,1]],
                [[0,1],[1,0],[2,1],[1,2]]);

            // Output: 1
            var result_2 = CountUnguarded(2, 7, 
                [[1,5],[1,1],[1,6],[0,2]],
                [[0,6],[0,3],[0,5]]);
        }

        private enum RoomState
        {
            None = 0,
            Wall = 1,
            Guard = 2,
            AgroZone = 3        
        }

        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls) {
            // create space
            var space = new int[m][];
            for(var i = 0; i < m; i++)
                space[i] = new int[n];

            // create walls
            for(var i = 0; i < walls.Length; i++)
                space[walls[i][0]][walls[i][1]] = (int)RoomState.Wall;

            // create guards
            for(var i = 0; i < guards.Length; i++)
                space[guards[i][0]][guards[i][1]] = (int)RoomState.Guard;

            for(var i = 0; i < guards.Length; i++)
                BuilderView(space, guards[i][0], guards[i][1]);                

            var count = 0;
            for(var i = 0; i < m; i++)
                for(var j = 0; j < n; j++)
                    if(space[i][j] == (int)RoomState.None) count++;

            return count;
        }

        private void BuilderView(int[][] space, int fromX, int fromY)
        {
            // to left
            for(var i = fromX - 1; i >= 0; i--)
                if(!BuilderViewRay(space, i, fromY)) 
                    break;

            // to right
            for(var i = fromX + 1; i < space.Length; i++)
                if(!BuilderViewRay(space, i, fromY)) 
                    break;

            // to top
            for(var i = fromY - 1; i >= 0; i--)
                if(!BuilderViewRay(space, fromX, i)) 
                    break;

            // to bottom
            for(var i = fromY + 1; i < space[0].Length; i++)
                if(!BuilderViewRay(space, fromX, i)) 
                    break;  
        }

        private bool BuilderViewRay(int[][] space, int x, int y)
        {
            if(space[x][y] == (int)RoomState.Wall 
                || space[x][y] ==(int)RoomState.Guard) 
                return false;

            space[x][y] = (int)RoomState.AgroZone;
            return true;     
        }
    }
}