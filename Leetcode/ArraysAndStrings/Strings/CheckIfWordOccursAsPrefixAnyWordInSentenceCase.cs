using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Strings
{
    /// <summary>
    /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
    /// </summary>
    public class CheckIfWordOccursAsPrefixAnyWordInSentenceCase
        : IStringLC, ITwoPointersLC, IStringMatchingLC
    {
        public void Cases()
        {
            // Output: 4
            var result_0 = IsPrefixOfWord("i love eating burger", "burg");
        }

        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            var words = sentence.Split(' ');
            for(var i = 0; i < words.Length; i++)
            {
                if(words[i].Length >= searchWord.Length
                    && words[i].StartsWith(searchWord))
                    return i + 1;
            }
            return -1;
        }
    }
}