
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class PascalsTriangleCase 
    {
        public void Cases()
        {
            var result1 = Generate(5);
            var result2 = Generate(1);
            var result3 = Generate(20);
        }

        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>() { new int[] { 1 } };
            for(var i = 1; i < numRows; i++)
            {
                var items = new int[i+1];
                items[0] = 1;
                items[i] = 1;

                for (var j = 1; j < i; j++)
                {
                    items[j] = result[i - 1][j - 1] + result[i - 1][j];
                }
                result.Add(items);
            }

            return result;
        }

    }
}
