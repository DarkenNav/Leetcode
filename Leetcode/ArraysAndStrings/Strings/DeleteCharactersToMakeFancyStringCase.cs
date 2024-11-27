using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 1957. Delete Characters to Make Fancy String
    public class DeleteCharactersToMakeFancyStringCase
    {
        public void Cases()
        {
            // Output: "leetcode"
            var result_0 = MakeFancyString("leeetcode");
            // Output: "aabaa"
            var result_1 = MakeFancyString("aaabaaaa");
            // Output: "aab"
            var result_2 = MakeFancyString("aab");
        }

        public string MakeFancyString(string s)
        {
            var result = new StringBuilder();
            result.Append(s[0]);
            var count = 0;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                    count++;
                else
                    count = 0;

                if (count < 2)
                    result.Append(s[i]);
            }
            return result.ToString();
        }
    }
}
