
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class PascalsTriangleIICase 
    {
        public void Cases()
        {
            var result1 = GetRow(4);
            var result2 = GetRow(0);
            var result3 = GetRow(1);
        }

        // Одино доп пространство ----------------------------------------------
        public IList<int> GetRow(int rowIndex)
        {
            var result = new int[rowIndex + 1];
            result[0] = 1;
            if (rowIndex == 0) // level = 0
                return result;
            
            result[0] = 0;
            var midl = rowIndex / 2;
            var left = midl - 1;
            var right = midl;

            result[right] = 1; // level = 1
            result[left] = 1; // len = 2 ; left = 2 % 2 != 0
            var level = 2; // max = rowIndex
            while (left >= 0 && right < rowIndex)
            {
                var toLeft = level % 2 != 0;
                for(var i = left; i <= right; i++)
                {

                }
                

                level++;
            }


            for (var i = 2; i < rowIndex; i++)
            {
                var nextLength = i + 1;
                var toLeft = nextLength % 2 == 0;
                for (var j = 0; j < nextLength; j++)
                {
                    if (toLeft)
                    {

                    }
                    else
                    { 
                    
                    }
                }
            }
            return result;
        }

        // Рекурсия ------------------------------------------------------------
        public IList<int> GetRow_2(int rowIndex)
        {
            var result = new int[rowIndex+1];
            result[0] = 1;
            if (rowIndex == 0)
                return result;
            result[rowIndex] = 1;
            if(rowIndex == 1)
                return result;

            var prev = GetRow(rowIndex - 1);
            for (var i = 1; i < prev.Count; i++)
            {
                result[i] = prev[i] + prev[i-1];
            }

            return result;
        }

        // ----------------------------------------------------------------------
        public IList<int> GetRow_1(int rowIndex)
        {
            var result = new List<int>() { 1 };
            for (var i = 0; i < rowIndex; i++)
            {
                result = GetNextRow(result, i + 1);
            }
            return result;
        }

        public List<int> GetNextRow(List<int> row, int length)
        {
            var newRow = new List<int>() { 1 };
            for (var i = 0; i < length - 1; i++)
            {
                var item = row[i] + row[i+1];
                newRow.Add(item);
            }
            newRow.Add(1);
            return newRow;
        }
    }
}
