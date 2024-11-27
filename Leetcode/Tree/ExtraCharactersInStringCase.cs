using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    // 2707. Extra Characters in a String
    public class ExtraCharactersInStringCase
    {
        public void Cases()
        {
            // 1
            var result_0 = MinExtraChar("leetscode", ["leet", "code", "leetcode"]);
            // 3
            var result_1 = MinExtraChar("sayhelloworld", ["hello", "world"]);
        }

        private int[] memo;
        private HashSet<string> dictionarySet;
        public int MinExtraChar(string s, string[] dictionary)
        {
            memo = new int[s.Length]; 
            for(var i = 0; i < s.Length; i++)
            {
                memo[i] = -1;
            }
            dictionarySet = new HashSet<string>(dictionary);

            return DP(0, s.Length, s);
        }

        private int DP(int start, int n, string s)
        {
            if(start == n)
                return 0;
            if (memo[start] != -1)
                return memo[start];

            var result = DP(start + 1, n, s) + 1;
            for(var i = start; i < n; i++)
            {
                var curr = s.Substring(start, i + 1 - start);
                if(dictionarySet.Contains(curr))
                {
                    result = Math.Min(result, DP(i + 1, n, s));
                }
            }
            memo[start] = result;
            return result;
        }
    }
}
