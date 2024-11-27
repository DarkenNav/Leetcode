using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    public class RansomNoteCase
    {
        public void Cases()
        {
            // false
            var result_0 = CanConstruct("a", "b");
            // false
            var result_1 = CanConstruct("aa", "ab");
            // true
            var result_2 = CanConstruct("aa", "aab");
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            var r = ransomNote.Length;
            var m = magazine.Length;
            if (r > m)
                return false;

            var mapM = new int[26];
            var left = 0;
            var right = m - 1;
            while(left <= right)
            {
                mapM[magazine[left] - 'a']++;
                if (left != right)
                    mapM[magazine[right] - 'a']++;

                left++;
                right--;
            }

            left = 0;
            right = r - 1;
            while (left <= right)
            {
                if(--mapM[ransomNote[left] - 'a'] < 0
                    || (left != right && --mapM[ransomNote[right] - 'a'] < 0))
                    return false;

                left++;
                right--;
            }

            return true;
        }

        public bool CanConstruct_1(string ransomNote, string magazine)
        {
            if(ransomNote.Length > magazine.Length)
                return false;

            var mapM = new int[26];
            foreach (var c in magazine)
            {
                mapM[c - 'a']++;
            }
            foreach (var c in ransomNote)
            {
                if(--mapM[c - 'a'] < 0)
                    return false;
            }

            return true;
        }
    }
}
