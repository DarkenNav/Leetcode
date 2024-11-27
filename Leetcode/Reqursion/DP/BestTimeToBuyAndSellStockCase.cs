using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.DP
{
    internal class BestTimeToBuyAndSellStockCase
    {
        internal void Cases()
        {
            // Output: 5
            var result_0 = MaxProfit([7, 1, 5, 3, 6, 4]);
            // Output: 0
            var result_1 = MaxProfit([7, 6, 4, 3, 1]);
        }

        public int MaxProfit(int[] prices)
        {
            var min = prices[0];
            var result = 0;

            for(var i = 1; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                result = Math.Max(result, prices[i] - min);
            }
            return result;
        }

        public int MaxProfit_1(int[] prices)
        {
            var n = prices.Length;
            var result = 0;
            for(var i = 0; i < n; i++)
            {
                for(var j = i + 1; j < n; j++)
                {
                    result = Math.Max(result, prices[j] - prices[i]);
                }
            }
            return result;
        }
    }
}
