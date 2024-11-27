using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    internal class ContainsDuplicateCase
    {
        internal void Cases()
        {
            var result_0 = ContainsDuplicate([1, 2, 3, 1]);
            var result_1 = ContainsDuplicate([1, 2, 3, 4]);
            var result_2 = ContainsDuplicate([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]);
        }

        public bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>(nums);
            return set.Count != nums.Length;

            //var n = nums.Length;
            //var set = new HashSet<int>();
            //for(var i = 0; i < n; i++)
            //{
            //    if(!set.Add(nums[i]))
            //        return true;
            //}
            //return false;
        }

        public bool ContainsDuplicate_1(int[] nums)
        {
            var n = nums.Length;
            if(n < 2) return false;

            Array.Sort(nums);
            for(var i = 1; i < n; i++)
            {
                if (nums[i] == nums[i-1])
                    return true;
            }
            return false;
        }
    }
}
