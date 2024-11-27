using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    // 2416. Sum of Prefix Scores of Strings
    public class SumPrefixScoresStringsCase
    {
        public void Cases()
        {
            // Output: [5,4,3,2]
            var result_0 = SumPrefixScores(["abc", "ab", "bc", "b"]);

            // Output: [4]
            var result_1 = SumPrefixScores(["abcd"]);
        }

        // Trie O(N⋅M) ------------------------------------------------------
        private class TrieNode
        {
            private TrieNode[] next = new TrieNode[26];
            //public char Prefix { get; private set; }
            private int count = 0;

            public void Insert(string word)
            {
                var node = this;
                foreach (var c in word)
                {
                    if (node.next[c - 'a'] == null)
                        node.next[c - 'a'] = new();
                    node.next[c - 'a'].count++;
                    //node.next[c - 'a'].Prefix = c;
                    node = node.next[c - 'a'];
                }
            }

            public int Count(string word) 
            { 
                var result = 0;
                var node = this;
                foreach (var c in word)
                {
                    result += node.next[c - 'a'].count;
                    node = node.next[c - 'a'];
                }
                return result; 
            }
        }

        public int[] SumPrefixScores(string[] words)
        {
            var root = new TrieNode();
            foreach (var word in words) {
                root.Insert(word);
            }

            var result = new int[words.Length];
            for(var i = 0; i < words.Length; i++)
            {
                result[i] = root.Count(words[i]);
            }

            return result;
        }

        // out of memory in big string -- 1 <= words[i].length <= 1000
        public int[] SumPrefixScores_1(string[] words)
        {
            var result = new int[words.Length];
            var dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                for (var i = 1; i <= word.Length; i++)
                {
                    var prefix = word[..i];
                    if (dictionary.ContainsKey(prefix))
                        dictionary[prefix] += 1;
                    else
                        dictionary[prefix] = 1;
                }
            }

            for(var i = 0; i < words.Length; i++)
            {
                for (var j = 1; j <= words[i].Length; j++)
                {
                    var prefix = words[i][..j];
                    result[i] += dictionary[prefix];
                }
            }

            return result;
        }
    }
}
