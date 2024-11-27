using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    public class HammingDistanceCase
    {
        // 0 <= x, y <= 231 - 1
        public void Cases()
        {
            // Output: 2
            var result_0 = HammingDistance(1, 4);
            // Output: 1
            var result_1 = HammingDistance(1, 3);
            // Output: 31
            var result_2 = HammingDistance(0, int.MaxValue);
        }

        public int HammingDistance(int x, int y)
        {
            var dist = 0;
            var bitArrX = new BitArray(BitConverter.GetBytes(x));
            var bitArrY = new BitArray(BitConverter.GetBytes(y));

            var left = 0;
            var right = bitArrX.Length - 1;
            while (left <= right)
            {
                if (bitArrX.Get(left) != bitArrY.Get(left)) dist++;
                if (left != right && bitArrX.Get(right) != bitArrY.Get(right))
                    dist++;
                left++;
                right--;
            }

            return dist;
        }
    }
}
