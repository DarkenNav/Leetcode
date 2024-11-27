
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class LongestCommonPrefixCase 
    {
        public void Case()
        {
            var result1 = LongestCommonPrefix(new string[] {
                "flower",
                "flow",
                "flight"
            });
            var result2 = LongestCommonPrefix(new string[] {
                "dog",
                "racecar",
                "car"
            });
            var result3 = LongestCommonPrefix(new string[] {
                "a"
            });
        }

        public string LongestCommonPrefix(string[] strs)
        {
            var strsLength = strs.Length;

            var prefixs = new List<string>();
            for(var i = 0; i < strsLength; i++)
            {
                var wordLength = strs[i].Length;
                for(var j = 0; j < wordLength; j++)
                {
                    var check = strs[i][0..(j+1)];
                    var count = strs.Count(x => x.StartsWith(check));
                    if(count == strsLength)
                        prefixs.Add(check);
                }
            }

            var maxPrefixs = prefixs
                .GroupBy(x => x)
                .MaxBy(y => y.Key.Length);

            return maxPrefixs == null ? string.Empty : maxPrefixs.Key;
        }
    }
}
