using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class RichestCustomerWealthCase
    {
        public void Cases()
        {
            // Output: 6
            var result_0 = MaximumWealth([[1, 2, 3], [3, 2, 1]]);
            // Output: 10
            var result_1 = MaximumWealth([[1, 5], [7, 3], [3, 5]]);
            // Output: 17
            var result_2 = MaximumWealth([[2, 8, 7], [7, 1, 3], [1, 9, 5]]);
        }

        public int MaximumWealth(int[][] accounts)
        {
            var max = 0;
            for(var i = 0; i < accounts.Length; i++)
            {
                var summ = 0;   
                for(var j = 0; j < accounts[i].Length; j++)
                {
                    summ += accounts[i][j];
                }
                max = Math.Max(max, summ);  
            }
            return max;
        }
    }
}
