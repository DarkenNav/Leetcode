using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 2516. Take K of Each Character From Left and Right
    public class TakeKEachCharacterFromLeftAndRightCase
    {
        public void Cases()
        {
            // Output: 8
            var result_0 = TakeCharacters("aabaaaacaabc", 2);
            // Output: -1
            var result_1 = TakeCharacters("a", 1);
            // Output: 3
            var result_2 = TakeCharacters("abc", 1);
        }

        public int TakeCharacters(string s, int k) {
            var n = s.Length;
            var freq = new int[3];
            for(var i = 0; i < n; i++)
                freq[s[i]-'a']++;

            if(freq[0] < k || freq[1] < k || freq[2] < k)
                return -1;

            var window = new int[3];
            var left = 0;
            var maxWindow = 0;
            for(var right = 0; right < n; right++)
            {
                window[s[right]-'a']++;

                while(left <= right
                    && (freq[0] - window[0] < k 
                        || freq[1] - window[1] < k 
                        || freq[2] - window[2] < k))
                {
                    window[s[left]-'a']--;
                    left++;
                }

                maxWindow = Math.Max(maxWindow, right - left + 1);
            }
            return n - maxWindow;
        }
    }
}
