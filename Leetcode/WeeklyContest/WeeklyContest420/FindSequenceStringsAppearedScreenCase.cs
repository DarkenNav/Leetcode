using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.WeeklyContest.WeeklyContest420
{
    internal class FindSequenceStringsAppearedScreenCase
    {
        internal void Cases()
        {
            var result_0 = StringSequence("abc");
            var result_1 = StringSequence("he");
            var result_2 = StringSequence("zaz");
        }

        public IList<string> StringSequence(string target)
        {
            var results = new List<string>();
            for (var i = 0; i < target.Length; i++)
            {
                // push 1
                var currStr = new StringBuilder(results.LastOrDefault() + "a");
                results.Add(currStr.ToString());
                var last = currStr.Length - 1;
                // switch
                for (var j = 0; j < target[i] - 'a'; j++)
                {
                    currStr[last] = (char)(currStr[last] + 1);
                    results.Add(currStr.ToString());
                }
            }
            return results;
        }
    }
}
