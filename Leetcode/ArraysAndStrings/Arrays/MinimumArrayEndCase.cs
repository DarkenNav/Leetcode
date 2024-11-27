using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class MinimumArrayEndCase : IBitManipulationLC
    {
        public void Cases()
        {
            // Output: 6
            var result_0 = MinEnd(3, 4);
            // Output: 15
            var result_1 = MinEnd(2, 7);

            // Output: 55012476815 ??
            var result_2 = MinEnd(6715154, 7193485);
        }

        public long MinEnd(int n, int x)
        {
            long result = x;
            while (--n > 0)
            {
                result = (result + 1) | (long)x;
            }

            return result;
        }
    }


}
