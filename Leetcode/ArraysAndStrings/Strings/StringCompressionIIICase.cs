using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 3163. String Compression III
    public class StringCompressionIIICase
    {
        public void Cases()
        {
            // Output: "1a"
            var result_01 = CompressedString("a");
            // Output: "1a1b1c1d1e"
            var result_0 = CompressedString("abcde");
            // Output: "9a5a2b"
            var result_1 = CompressedString("aaaaaaaaaaaaaabb");
            // Output: "9a9a9a.."
            var result_11 = CompressedString("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        public string CompressedString(string word)
        {
            var count = 1;
            var result = new StringBuilder();
            var i = 0;
            while(i < word.Length - 1)
            {
                if (word[i] != word[i + 1] || count == 9)
                {
                    result.Append(count).Append(word[i]);
                    count = 1;
                }
                else
                    count++;
                i++;
            }

            result.Append(count).Append(word[i]);

            return result.ToString();
        }
    }
}
