using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 567. Permutation in String
    public class PermutationInStringCase
    {
        public void Cases()
        {
            // Output: true
            var result_0 = CheckInclusion("ab", "eidbaooo");
            // Output: false
            var result_1 = CheckInclusion("ab", "eidboaoo");
            // Output: true
            var result_2 = CheckInclusion("ab", "ab");
        }

        public bool CheckInclusion(string s1, string s2)
        {
            var n1 = s1.Length;
            var n2 = s2.Length;
            if (n1 > n2)
                return false;

            var s1Map = GetMap(s1, 0, n1);
            for(var i = 0; i <= n2 - n1; i++)
            {
                var s2Map = GetMap(s2, i, i + n1);
                if(Matches(s1Map, s2Map))
                    return true;
            }

            return false;
        }

        //private Dictionary<char, int> GetMap(string s, int start, int end)
        private int[] GetMap(string s, int start, int end)
        {
            // var map = new Dictionary<char, int>();
            var map = new int[26];
            for(var i = start; i < end && i < s.Length; i++) 
            {
                map[s[i] - 'a']++;
                //if (map.ContainsKey(s[i]))
                //    map[s[i]]++;
                //else
                //    map[s[i]] = 1;
            }
            return map;
        }

        //private bool Matches(Dictionary<char, int> s1Map, Dictionary<char, int> s2Map)
        private bool Matches(int[] s1Map, int[] s2Map)
        {
            for (var i = 0; i < s1Map.Length; i++) 
            {
                if (s1Map[i] != s2Map[i])
                    return false;
            }
            //foreach (var item in s1Map)
            //{
                //if(!s2Map.ContainsKey(item.Key))
                //    return false;
                //if (s2Map[item.Key] - s1Map[item.Key] != 0)
                //    return false;
            //}
            return true;
        }


        // только для реверса , а по задаче оказывается ВСЕ перестановки
        public bool CheckInclusion_1(string s1, string s2)
        {
            var n1 = s1.Length;
            var n2 = s2.Length;
            if (n1 > n2)
                return false;
            if(n1 == 1)
                return s2.IndexOf(s1[0]) > -1;

            for (var i = 0; i < n2; i++)
            {
                var j = n1 - 1;
                if (s2[i] == s1[j])
                {
                    var next = 1;
                    while (j > 0)
                    {
                        if(i + next >= n2)
                            return false;

                        if (s2[i + next] != s1[j - 1])
                            break;

                        j--;
                        next++;
                    }
                    if (j == 0)
                        return true;
                }
            }

            return false;
        }
    }
}
