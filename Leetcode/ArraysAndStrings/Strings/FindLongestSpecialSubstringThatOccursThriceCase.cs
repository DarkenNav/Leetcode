using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Strings
{
    /// <summary>
    /// 2981. Find Longest Special Substring That Occurs Thrice I
    /// </summary>
    public class FindLongestSpecialSubstringThatOccursThriceCase
        : IHashTableLC, IBinarySearchLC, IStringLC, ISlidingWindowLC, ICountingLC
    {
        public void Cases()
        {
            // Output: 2
            var result_0 = MaximumLength("aaaa");
            // Output: -1
            var result_1 = MaximumLength("abcdef");
            // Output: 1
            var result_2 = MaximumLength("abcaba");
        }

        // Hash Table + Sliding Window, 
        // Runtime (1ms)) 27.59%, Memory (45.29MB) 10.00%
        public int MaximumLength(string s)
        {
            var left = 0;
            var right = 0;
            var map = new Dictionary<string, int>();
            var max = -1;
            while(left < s.Length && right < s.Length)
            {
                if(s[left] != s[right])
                {
                    left++;
                    right = left;
                }
                else
                {
                    var str = s[left..(right + 1)];
                    _ = map.TryGetValue(str, out int count);
                    map[str] = ++count;

                    if(count >= 3 && str.Length > max)
                        max = str.Length;

                    if(++right >= s.Length)
                    {
                        left++;
                        right = left;    
                    }
                }
            }
            return max;
        }

        // Hash Table, Runtime (12ms) 17.24%, Memory (46.71MB) 10.00%
        public int MaximumLength_1(string s)
        {
            var map = new Dictionary<string, int>();
            for(var i = 0; i < s.Length; i++)
            {
                var str = s[i].ToString();
                _ = map.TryGetValue(str, out int count);
                map[str] = count + 1;

                for(var j = i + 1; j < s.Length && s[i] == s[j]; j++)
                {
                    str = str + s[j];
                    _ = map.TryGetValue(str, out count);
                    map[str] = count + 1;
                }
            }
            
            var max = -1;
            foreach(var item in map)
            {
                if(item.Value < 3)
                    continue;
                max = Math.Max(max, item.Key.Length);
            }
            return max;
        }
    }
}