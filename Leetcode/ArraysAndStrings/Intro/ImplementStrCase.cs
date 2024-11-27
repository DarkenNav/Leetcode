
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class ImplementStrCase 
    {
        public void Case()
        {
            var result1 = StrStr("sadbutsad", "sad");
            var result2 = StrStr("leetcode", "leeto");
        }

        public int StrStr(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }
    }
}
