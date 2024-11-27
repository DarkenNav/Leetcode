using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    internal class FirstUniqueCharacterInStringCase
    {
        internal void Cases()
        {
            // Output: 0
            var result_0 = FirstUniqChar("leetcode");
        }

        public int FirstUniqChar(string s)
        {
            var map = new int[26];
            foreach (char c in s)
            {
                map[c - 'a']++;
            }
            for (var i = 0; i < s.Length; i++)
            {
                if (map[s[i] - 'a'] == 1)
                    return i;
            }
            return -1;
        }
    }
}
