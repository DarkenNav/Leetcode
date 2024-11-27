
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class RotateArrayCase 
    {
        public void Case()
        {
            //Rotate(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);
            //Rotate(new int[] { -1, -100, 3, 99 }, 2);
            
            // [1,2,3]  3,1,2 - 2,3,1 - 1,2,3 - 3,1,2 - 2,3,1 - 1,2,3 - 3,1,2
            Rotate(new int[] { 1, 2, 3 }, 7); 
            Rotate(new int[] { -1 }, 2);
        }

        public void Rotate(int[] nums, int k)
        {
            var length = nums.Length;
            // to left - k, to right - (length - k)
            var r = length - k;
            if(r < 0)
            {
                r = length - k % length;
            }
            SwapElements(nums, 0, r - 1);
            SwapElements(nums, r, length - 1);
            SwapElements(nums, 0, length - 1);
        }

        public void SwapElements(int[] nums, int startIdex, int endIndex)
        {
            var tmp = 0;
            while(startIdex < endIndex)
            {
                tmp = nums[startIdex];
                nums[startIdex] = nums[endIndex];
                nums[endIndex] = tmp;
                startIdex++;
                endIndex--;
            }
        }

        // Submission Result: Time Limit Exceeded
        public void Rotate1(int[] nums, int k)
        {
            var lenght = nums.Length;
            for (var i = 0; i < k; i++)
            {
                var right = lenght - 1;
                var tmp = nums[right];
                while (right > 0)
                {
                    nums[right] = nums[right-1];
                    right--;
                }
                nums[0] = tmp;
            }
        }
    }
}
