using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 884. Uncommon Words from Two Sentences
    public class UncommonWordsFromTwoSentencesCase
    {
        public void Cases()
        {
            var result_0 = UncommonFromSentences("this apple is sweet", "this apple is sour");
            var result_1 = UncommonFromSentences("apple apple", "banana");
        }

        public string[] UncommonFromSentences(string s1, string s2)
        {
            var table = new Hashtable();
            var result = new List<string>();
            foreach (string word in s1.Split(' '))
            {
                if (table.ContainsKey(word))
                    table[word] = (int)table[word] + 1;
                else
                    table.Add(word, 1);
            }
            foreach (string word in s2.Split(' '))
            {
                if (table.ContainsKey(word))
                    table[word] = (int)table[word] + 1;
                else
                    table.Add(word, 1);
            }
            foreach (DictionaryEntry entry in table)
            {
                if ((int)entry.Value == 1)
                    result.Add(entry.Key.ToString());
            }

            return [.. result];
        }
    }
}
