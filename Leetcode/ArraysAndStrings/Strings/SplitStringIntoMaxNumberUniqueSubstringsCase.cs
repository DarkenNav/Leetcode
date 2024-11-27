using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    public class SplitStringIntoMaxNumberUniqueSubstringsCase
    {
        //"dbbpaaaab"
        //"aacaccckaaaaaa"
        //"jnafaeffbehaif"
        //"aaaaaaaaaaaaaaaa"
        //"igppsagzepaaaaba"
        //"lwaacaajuefdegb"
        //"wwwzfvedwfvhsww"
        //"eeajlaanlbeohbb"
        public void Cases()
        {
            // ??
            var result = MaxUniqueSplit("igppsagzepaaaaba");

            // Output: 5
            var result_0 = MaxUniqueSplit("ababccc");
            // Output: 2
            var result_1 = MaxUniqueSplit("aba");
            // Output: 1
            var result_2 = MaxUniqueSplit("aa");
        }

        public int MaxUniqueSplit(string s)
        {
            var seen = new HashSet<string>();
            var maxCount = new int[1];
            Backtrack(s, 0, seen, 0, maxCount);
            return maxCount[0];
        }

        private void Backtrack(string s, int start, HashSet<string> seen,
            int count, int[] maxCount)
        {
            if(count + (s.Length - start) <= maxCount[0])
                return;
            if(start == s.Length)
            {
                maxCount[0] = Math.Max(maxCount[0], count);
                return;
            }

            for(var end = start + 1; end <= s.Length; end++)
            {
                var sub = s.Substring(start, end - start);
                if (!seen.Contains(sub))
                {
                    seen.Add(sub);
                    Backtrack(s, end, seen, count + 1, maxCount);
                    seen.Remove(sub);
                }
            }
        }


        //public int MaxUniqueSplit(string s)
        //{
        //    var counts = new int[26];
        //    foreach (var c in s)
        //    {
        //        counts[c - 'a']++;
        //    }
        //    var pq = new PriorityQueue<char, int>(Comparer<int>.Create((x, y) => y - x));
        //    for (var i = 0; i < 26; i++)
        //    {
        //        if(counts[i] != 0)
        //            pq.Enqueue((char)('a' + i), counts[i]);
        //    }

        //    var map = new Dictionary<string, int>();
        //    GetStr(string.Empty, pq, map);

        //    return map.Count;
        //}

        //private void GetStr(string start, PriorityQueue<char, int> pq, Dictionary<string, int> map)
        //{
        //    while (pq.Count > 0)
        //    {
        //        _ = pq.TryDequeue(out char c, out int count);
        //        var str = new StringBuilder(start).Append(c).ToString();
        //        if (map.TryAdd(str.ToString(), 0))
        //        {
        //            if (count - 1 > 0)
        //                pq.Enqueue(c, count - 1);
        //            str = string.Empty;
        //        }
        //        GetStr(str, pq, map);
        //    }
        //}
    }
}
