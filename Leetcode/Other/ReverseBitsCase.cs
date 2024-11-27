using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    internal class ReverseBitsCase
    {
        internal void Cases()
        {
            // Output:    964176192 (00111001011110000010100101000000)
            var result_0 = reverseBits(0b0000_0010_1001_0100_0001_1110_1001_1100);
            // Output:   3221225471 (10111111111111111111111111111111)
            var result_1 = reverseBits(0b11111111111111111111111111111101);
        }

        public uint reverseBits(uint n)
        {
            var bitArr = new BitArray(BitConverter.GetBytes(n));
            uint result = 0;
            var j = 0;
            for (var i = 31; i >= 0; i--)
            {
                if (bitArr.Get(i))
                    result |= ((uint)1 << j);
                j++;
            }
            return result;
        }

        public uint reverseBits_1(uint n)
        {
            var bitArr = new BitArray(BitConverter.GetBytes(n));
            var left = 0; 
            var right = 31;
            while (left < right)
            {
                bool tmp = bitArr.Get(left);
                bitArr.Set(left, bitArr.Get(right));
                bitArr.Set(right, tmp);
                left++;
                right--;
            }

            uint result = 0;
            for(var i = 0; i < 32; i++)
            {
                if (bitArr.Get(i))
                    result |= ((uint)1 << i);
            }
            return result;
        }

        // Сдвиги зло)
        public uint reverseBits_x1(uint n)
        {
            uint result = n & 1;
            var count = 0;
            while (count < 31)
            {
                n = n >> 1;
                result = result << 1;
                result += n & 1;
                count++;
            }
            return result;
        }
    }
}
