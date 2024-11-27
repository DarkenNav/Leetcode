using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    public class PowerOfThreeCase
    {
        // -2^31 <= n <= 2^31 - 1
        public void Cases()
        {
            // Output: true. Explanation: 27 = 33
            var result_0 = IsPowerOfThree(27);
            // Output: false. Explanation: There is no x where 3^x = 0.
            var result_1 = IsPowerOfThree(0);
            // Output: false, Explanation: There is no x where 3^x = (-1).
            var result_2 = IsPowerOfThree(-1);

            var result_3 = IsPowerOfThree(3*3*3*3*3*3);
        }


        private int MaxPowerOfInt(int number)
        {
            long max = number;
            while (max < int.MaxValue)
            {
                max *= number;
            }
            return (int)(max / number);
        }

        public bool IsPowerOfThree(int n)
        {
            if(n <= 0) return false;
            return 1162261467 % n == 0; 
        }
    }
}
