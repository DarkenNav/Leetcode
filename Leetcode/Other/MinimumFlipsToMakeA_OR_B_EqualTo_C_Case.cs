using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    internal class MinimumFlipsToMakeA_OR_B_EqualTo_C_Case
    {
        internal void Cases()
        {
            // Output: 3
            var result_0 = MinFlips(a: 2, b: 6, c: 5);
            // Output: 1
            var result_1 = MinFlips(a: 4, b: 2, c: 7);
            // Output: 0
            var result_2 = MinFlips(a: 1, b: 2, c: 3);
            // Output: 
            var result_3 = MinFlips(a: 1, b: 2, c: 1_000_000_000);
        }

        public int MinFlips(int a, int b, int c)
        {
            var count = 0;
            var bitArrA = new BitArray(BitConverter.GetBytes(a));
            var bitArrB = new BitArray(BitConverter.GetBytes(b));
            var bitArrC = new BitArray(BitConverter.GetBytes(c));

            for (var i = 0; i < 32; i++)
            {
                if ((bitArrA.Get(i) | bitArrB.Get(i)) != bitArrC.Get(i))
                {
                    if(bitArrA.Get(i) && bitArrB.Get(i) && !bitArrC.Get(i))
                        count++;
                    count++;
                }
            }

            return count;
        }
    }
}
