using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    public class NumberOf1BitsCase
    {
        // 1 <= n <= 231 - 1
        public void Cases()
        {
            // Output: 3
            var result_0 = HammingWeight(11);
            // Output: 1
            var result_1 = HammingWeight(128);
            // Output: 30
            var result_2 = HammingWeight(2147483645);
            // Output: 
            var result_3 = HammingWeight(int.MaxValue);

            var watch = new Stopwatch();
            watch.Start();
            var result_31 = HammingWeight(int.MaxValue);
            var time1 = watch.Elapsed.TotalMilliseconds;
            watch.Restart();
            var result_32 = HammingWeight_1(int.MaxValue);
            var time2 = watch.Elapsed.TotalMilliseconds;
            watch.Restart();
            var result_33 = HammingWeight_2(int.MaxValue);
            var time3 = watch.Elapsed.TotalMilliseconds;
            watch.Stop();
        }

        public int HammingWeight(int n)
        {
            var weight = 0;
            var bitArr = new BitArray(BitConverter.GetBytes(n));

            var left = 0;
            var right = bitArr.Length - 1;
            while (left <= right)
            {
                if (bitArr.Get(left)) weight++;
                if (left != right && bitArr.Get(right))
                    weight++;
                left++;
                right--;
            }

            return weight;
        }

        public int HammingWeight_1(int n)
        {
            var weight = 0;
            var str = Convert.ToString(n, 2);

            var left = 0;
            var right = str.Length - 1;
            while (left <= right)
            {
                if (str[left] == '1') weight++;
                if (left != right && str[right] == '1')
                    weight++;
                left++;
                right--;
            }

            return weight;
        }

        public int HammingWeight_2(int n)
        {
            var weight = 0;
            var str = Convert.ToString(n, 2);
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '1') weight++;
            }
            return weight;
        }
    }
}
