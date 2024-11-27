using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 1371. Find the Longest Substring Containing Vowels in Even Counts
    public class FindLongestSubstringContainingVowelsEvenCounts
    {
        public void Cases()
        {
            // "leetminicowor"
            var result = FindTheLongestSubstring("eleetminicoworoep");

        }

        public int FindTheLongestSubstring(string s)
        {
            var prefixXOR = 0x00000;
            //var sw = new Stopwatch();
            //sw.Start();
            var characterMap = new int[26];
            characterMap['a' - 'a'] = 1;
            characterMap['e' - 'a'] = 2;
            characterMap['i' - 'a'] = 4;
            characterMap['o' - 'a'] = 8;
            characterMap['u' - 'a'] = 16;

            var mp = new int[32];
            for (int i = 0; i < 32; i++)
            {
                mp[i] = -1;
            }
            var longestSubstring = 0;
            for (int i = 0; i < s.Length; i++)
            {
                prefixXOR ^= characterMap[s[i] - 'a'];
                if (mp[prefixXOR] == -1 && prefixXOR != 0) 
                    mp[prefixXOR] = i;

                longestSubstring = Math.Max(longestSubstring, i - mp[prefixXOR]);
            }
            //sw.Stop();
            //var resultTime = sw.Elapsed;
            return longestSubstring;
        }
    }
}
