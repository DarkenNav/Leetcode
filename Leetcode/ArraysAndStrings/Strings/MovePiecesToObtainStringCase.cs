using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Strings
{
    /// <summary>
    /// 2337. Move Pieces to Obtain a String
    /// </summary>
    public class MovePiecesToObtainStringCase : IStringLC, ITwoPointersLC
    {
        public void Cases()
        {
            // // Output: true
            // var result_0 = CanChange("_L__R__R_", "L______RR");
            // // Output: false
            // var result_1 = CanChange("R_L_", "__LR");
            // // Output: false
            // var result_2 = CanChange("_R", "R_");

            // Output: false
            var result_3 = CanChange("_L", "LL");
        }

        // Two Pointers
        public bool CanChange(string start, string target)
        {
            var n = start.Length;
            var sIndex = 0;
            var tIndex = 0;

            while(sIndex < n || tIndex < n)
            {
                while(sIndex < n && start[sIndex] == '_')
                    sIndex++;
                while(tIndex < n && target[tIndex] == '_')
                    tIndex++;

                if(sIndex == n || tIndex == n)
                    return sIndex == n && tIndex == n;
                
                if(start[sIndex] != target[tIndex]
                    || (start[sIndex] == 'L' && sIndex < tIndex)
                    || (start[sIndex] == 'R' && sIndex > tIndex))
                {
                    return false;
                }     

                sIndex++;
                tIndex++;
            }
            return true;
        }

        // Queue
        public bool CanChange_1(string start, string target)
        {
            var n = start.Length;
            var startQueue = new Queue<(char, int)>();
            var targetQueue = new Queue<(char, int)>();
            for(var i = 0; i < n; i++)
            {
                if(start[i] != '_')
                    startQueue.Enqueue((start[i], i));

                if(target[i] != '_')
                    targetQueue.Enqueue((target[i], i));
            }

            if(startQueue.Count != targetQueue.Count)
                return false;

            while(startQueue.Count > 0)
            {
                (var sChar, var sIndex) = startQueue.Dequeue();
                (var tChar, var tIndex) = targetQueue.Dequeue();

                if(sChar != tChar
                    || (sChar == 'L' && sIndex < tIndex)
                    || (sChar == 'R' && sIndex > tIndex))
                {
                    return false;
                }
            }

            return true;
        }
    }
}