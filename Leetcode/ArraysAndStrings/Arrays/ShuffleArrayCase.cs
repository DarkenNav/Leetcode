using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class ShuffleArrayCase
    {
        public void Cases()
        {
            
            //Your Solution object will be instantiated and called as such:
            Solution obj = new Solution([1, 2, 3]);
            int[] param_1 = obj.Reset();
            int[] param_2 = obj.Shuffle();
             
        }

        public class Solution
        {
            private int[] original;
            private int[] array;

            Random rand = new Random();

            public Solution(int[] nums)
            {
                array = nums;                
                original = (int[])nums.Clone(); 
            }

            public int[] Reset()
            {
                return original;
            }


            public int[] Shuffle()
            {
                var n = original.Length;
                for(var i = 0; i < n; i++)
                {
                    var j = rand.Next(n - i) + i;

                    var tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
                return array;
            }
        }
    }
}
