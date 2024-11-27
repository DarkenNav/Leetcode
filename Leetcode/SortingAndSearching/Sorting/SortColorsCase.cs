using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class SortColorsCase : ISortingLC
    {
        public void Cases()
        {
            int[] arr_0 = [2, 0, 2, 1, 1, 0];
            SortColors(arr_0);

            int[] arr_1 = [2, 0, 1];
            SortColors(arr_1);
        }

        // Counting Sort
        public void SortColors(int[] nums)
        {
            var n = nums.Length;
            var max = int.MinValue;
            for (var i = 0; i < n; i++)
            {
                if (nums[i] > max) max = nums[i];
            }

            var counts = new int[max + 1];
            for (var i = 0; i < n; i++)
            {
                counts[nums[i]]++;
            }

            var startIndex = 0;
            for (var i = 0; i < max + 1; i++)
            {
                var count = counts[i];
                counts[i] = startIndex;
                startIndex += count;
            }

            var sorted = new int[n];
            for (var i = 0; i < n; i++)
            {
                var elem = nums[i];
                sorted[counts[elem]] = elem;
                counts[elem]++;
            }

            for (var i = 0; i < n; i++)
            {
                nums[i] = sorted[i];
            }
        }

        // Sort Colors opt with only 3 color
        public void SortColors_1(int[] nums)
        {
            var n = nums.Length;
            var colorsCount = new int[3];
            // calc colors
            for(var i = 0; i < n; i++)
            {
                colorsCount[nums[i]]++;
            }

            // set colors
            for (var i = 0; i < n; i++)
            {
                if(colorsCount[0] > 0)
                {
                    nums[i] = 0;
                    colorsCount[0]--;
                }
                else if (colorsCount[1] > 0)
                {
                    nums[i] = 1;
                    colorsCount[1]--;
                }
                else
                {
                    nums[i] = 2;
                }
            }
        }

    }


}
