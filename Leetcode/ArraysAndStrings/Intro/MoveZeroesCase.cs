
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class MoveZeroesCase 
    {
        public void Case()
        {
            MoveZeroes(new int[] { 0, 1, 0, 3, 12 });
            MoveZeroes(new int[] { 0 });
            MoveZeroes(new int[] { 1, 1, 0 });
            MoveZeroes(new int[] { 1, 1, 0, 1 });
            MoveZeroes(new int[] { 0, 0, 1, 2 });
        }
        public void MoveZeroes(int[] nums)
        {
            var length = nums.Length;
            var position = 0;
            for (int i = 0; i < length; i++)
            {
                if (nums[i] != 0)
                {
                    if (position != i)
                    {
                        nums[position] = nums[i];
                        nums[i] = 0;
                    }
                    position++;
                }
            }
        }
    }
}
