using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    internal class ValidAnagramCase
    {
        internal void Cases()
        {
            var result_0 = IsAnagram("anagram", "nagaram");

            var result_1 = IsAnagram("rat", "car");
        }

        public bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length)
                return false;

            var map = new int[26];
            for(var i = 0; i < s.Length; i++)
            {
                map[s[i] - 'a']++;
                map[t[i] - 'a']--;
            }
            foreach(var letter in map)
            {
                if(letter != 0) return false;
            }
            return true;
        }
    }
}
