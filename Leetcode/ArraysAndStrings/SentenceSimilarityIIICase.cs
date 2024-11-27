using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 1813. Sentence Similarity III
    public class SentenceSimilarityIIICase
    {
        public void Cases()
        {
            // Output: true
            var result_0 = AreSentencesSimilar("My name is Haley", "My Haley");
            // Output: false
            //var result_1 = AreSentencesSimilar("of", "A lot of words");
            // Output: true
            //var result_2 = AreSentencesSimilar("Eating right now", "Eating");
        }

        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            var arr1 = sentence1.Split(' ');
            var arr2 = sentence2.Split(' ');

            var result = false;
            if (arr1.Length > arr2.Length)
                result = AreSentencesSimilar(arr2, arr1);
            else
                result = AreSentencesSimilar(arr1, arr2);

            return result;
        }

        public bool AreSentencesSimilar(string[] sentence1, string[] sentence2)
        {
            var n1 = sentence1.Length;
            var n2 = sentence2.Length;

            var start = 0;
            var end1 = n1 - 1;
            var end2 = n2 - 1;

            while (start < n1 && sentence1[start] == sentence2[start]) 
            { 
                start++; 
            }

            while (end1 >= 0 && sentence1[end1] == sentence2[end2])
            {
                end1--;
                end2--;
            }

            return end1 < start;
        }

        // Queue ------------------------------------------------------------
        public bool AreSentencesSimilar_1(string sentence1, string sentence2)
        {
            var list1 = new List<string>(sentence1.Split(' '));
            var list2 = new List<string>(sentence2.Split(' '));

            while(list1.Count > 0 && list2.Count > 0
                && list1.First().Equals(list2.First()))
            {
                list1.RemoveAt(0);
                list2.RemoveAt(0);
            }

            while (list1.Count > 0 && list2.Count > 0
                && list1.Last().Equals(list2.Last()))
            {
                list1.RemoveAt(list1.Count - 1);
                list2.RemoveAt(list2.Count - 1);
            }

            return list1.Count == 0 || list2.Count == 0;
        }
    }
}
