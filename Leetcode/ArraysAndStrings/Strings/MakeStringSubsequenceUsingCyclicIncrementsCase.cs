using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Strings
{
    /// <summary>
    /// 2825. Make String a Subsequence Using Cyclic Increments
    /// </summary>
    public class MakeStringSubsequenceUsingCyclicIncrementsCase
        : IStringLC, ITwoPointersLC
    {
        public void Cases()
        {
            // Output: true
            // a = a, b/c != d/e, b/c = a/b, c/d = d/e
            var result_0 = CanMakeSubsequence("abc", "ad");
            // Output: true
            var result_1 = CanMakeSubsequence("zc", "ad");
            // Output: false
            var result_2 = CanMakeSubsequence("ab", "d");
        }

        public bool CanMakeSubsequence(string str1, string str2)
        {
            var n1 = str1.Length;
            var n2 = str2.Length;
            var i = 0;
            var j = 0;
            while(i < n1)
            {
                if(str1[i] == str2[j] 
                    || (str1[i] + 1 > 'z' ? 'a' : str1[i] + 1) == str2[j])
                {
                    j++;
                    if(j >= n2)
                        return true;
                }
                i++;
            }
            return false;
        }
    }
}