using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class BestTimeBuyAndSellStockIICase
    {
        public void Cases()
        {
            // Output: 7
            var result_0 = MaxProfit([7, 1, 5, 3, 6, 4]);

            // Output: 4
            var result_1 = MaxProfit([1, 2, 3, 4, 5]);
        }

        public int MaxProfit(int[] prices)
        {
            var total = 0;
            var n = prices.Length;

            for(var i = 1; i < n; i++)
            {
                if (prices[i] > prices[i - 1])
                    total += prices[i] - prices[i - 1];
            }

            return total;
        }
    }
}
