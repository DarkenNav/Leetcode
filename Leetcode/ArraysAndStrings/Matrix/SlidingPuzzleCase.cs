using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Matrix
{
    // 773. Sliding Puzzle
    public class SlidingPuzzleCase : IArrayLC, IMatrixLC
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = SlidingPuzzle([
                [1,2,3],
                [4,0,5]]
            );
            // Output: -1
            var result_1 = SlidingPuzzle([[1,2,3],[5,4,0]]);
            // Output: 5
            var result_2 = SlidingPuzzle([[4,1,2],[5,0,3]]);
        }

        public int SlidingPuzzle(int[][] board)
        {
            var direction = new int[][] {
                [1, 3],
                [0, 2, 4],
                [1, 5],
                [0, 4],
                [1, 3, 5],
                [2, 4]
            };
            var targetState = "123450";
            var startState = new StringBuilder();
            for(var i = 0; i < board.Length; i++)
                for(var j = 0; j < board[0].Length; j++)
                    startState.Append(board[i][j]);

            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(startState.ToString());
            visited.Add(startState.ToString());

            var moves = 0;
            while(queue.Count > 0)
            {
                var size = queue.Count;
                while(size > 0)
                {
                    var currentState = queue.Dequeue();
                    if(currentState.Equals(targetState))
                        return moves;
                    var zoroPosition = currentState.IndexOf('0');
                    foreach(var position in direction[zoroPosition])
                    {
                        var nextState = Swap(currentState, zoroPosition, position);
                        if(!visited.Add(nextState))
                            continue;
                        queue.Enqueue(nextState);
                    }
                    size--;
                }
                moves++;
            }
            return -1;
        }

        private string Swap(string str, int i, int j)
        {
            var sb = new StringBuilder(str);
            (sb[i], sb[j]) = (sb[j], sb[i]);
            return sb.ToString();
        }
    }
}