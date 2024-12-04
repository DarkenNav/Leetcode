using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Strings
{
    /// <summary>
    /// 2109. Adding Spaces to a String
    /// </summary>
    public class AddingSpacesToStringCase
        : IArrayLC, ITwoPointersLC, IStringLC, ISimulationLC
    {
        public void Cases()
        {
            // Output: "Leetcode Helps Me Learn"
            var result_0 = AddSpaces("LeetcodeHelpsMeLearn", [8,13,15]);
            // Output: "i code in py thon"
            var result_1 = AddSpaces("icodeinpython", [1,5,7,9]);
            // Output: " s p a c i n g"
            var result_2 = AddSpaces("spacing", [0,1,2,3,4,5,6]);
        }

        public string AddSpaces_3(string s, int[] spaces)
        {

            var result = new string[spaces.Length + 1];
            result[0] = s[..spaces[0]];
            int i;
            for(i = 1; i < spaces.Length; i++)
            {
                result[i] = s[spaces[i-1]..spaces[i]];
            }
            var left = s.Length - spaces.Last();
            if(left > 0)
                result[i] = s[(s.Length-left)..];
            return string.Join(' ', result);
        }

        public string AddSpaces_2(string s, int[] spaces)
        {
            var result = new StringBuilder(s);
            int i;
            for(i = 0; i < spaces.Length; i++)
            {
                result.Insert(spaces[i] + i, ' ');
            }
            return result.ToString();
        }

        // fastes
        public string AddSpaces(string s, int[] spaces)
        {
            var result = new StringBuilder();
            var j = 0;
            int i;
            for(i = 0; i < s.Length &&  j < spaces.Length; i++)
            {
                if(spaces[j] == i)
                {
                    result.Append(' ');
                    j++;
                }
                result.Append(s[i]);
            }
            if(i < s.Length)
                result.Append(s[i..s.Length]);
            return result.ToString();
        }
    }
}