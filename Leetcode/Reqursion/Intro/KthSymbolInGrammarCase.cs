using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.Intro
{
    public class KthSymbolInGrammarCase
    {
        public void Cases()
        {
            // 0 -- row 1: 0
            var result_0 = KthGrammar(1, 1);
            // 0 -- row 1: 0, row 2: 01
            var result_1 = KthGrammar(2, 1);
            // 1 -- row 1: 0, row 2: 01
            var result_2 = KthGrammar(2, 2);
            // 0 -- 0 1 10 11 100
            var result_3 = KthGrammar(4, 6);
        }

        public int KthGrammar(int n, int k, int rootVal = 0)
        {
            if (n == 1)
                return rootVal;

            var totalNodes = (int)Math.Pow(2, n - 1);
            var nextRootVal = rootVal == 0 ? 1 : 0;
            if (k > totalNodes / 2)
                return KthGrammar(n - 1, k - totalNodes / 2, nextRootVal);

            nextRootVal = rootVal == 0 ? 0 : 1;
            return KthGrammar(n - 1, k, nextRootVal);
        }

        //public int KthGrammar(int n, int k)
        //{
        //    return depthFirstSearch(n, k, 0);
        //}

        //private int depthFirstSearch(int n, int k, int rootVal)
        //{
        //    if(n == 1)
        //        return rootVal;

        //    var totalNodes = (int)Math.Pow(2, n - 1);
        //    var nextRootVal = rootVal == 0 ? 1 : 0;
        //    if (k > totalNodes / 2)
        //        return depthFirstSearch(n - 1, k - totalNodes / 2, nextRootVal);

        //    nextRootVal = rootVal == 0 ? 0 : 1;
        //    return depthFirstSearch(n - 1, k, nextRootVal);
        //}
    }
}
