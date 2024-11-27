using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    public class NumberStepsToReduceNumberToZeroCase
    {
        public void Cases()
        {
            var result_0 = NumberOfSteps(100);
        }

        public int NumberOfSteps(int num)
        {
            var count = 0;
            while(num > 0)
            {
                if(num % 2 == 0)
                    num /= 2;
                else
                    num--;
                count++;
            }
            return count;
        }
    }
}
