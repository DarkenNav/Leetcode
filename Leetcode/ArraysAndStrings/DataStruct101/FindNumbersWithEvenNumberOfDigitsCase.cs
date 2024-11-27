using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.DataStruct101
{
    public class FindNumbersWithEvenNumberOfDigitsCase
    {
        public void Cases()
        {
            var result_0 = FindNumbers([12, 345, 2, 6, 7896]);
            var result_1 = FindNumbers([555, 901, 482, 1771]);

        }

        public int FindNumbers(int[] nums)
        {
            var evensCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var count = 0;
                while(num > 0)
                {
                    num /= 10;
                    count++;
                }

                if (count % 2 == 0)
                    evensCount++;
            }
            return evensCount;
        }
    }
}
