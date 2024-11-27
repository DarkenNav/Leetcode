using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    public class QueryKthSmallestTrimmedNumberCase : ISortingLC
    {
        public void Cases()
        {
            // Вывод: [2,2,1,0]
            var result_0 = SmallestTrimmedNumbers(
                ["102", "473", "251", "814"],
                [[1, 1], [2, 3], [4, 2], [1, 2]]);

            // Вывод: [3,0]
            var result_1 = SmallestTrimmedNumbers(
                ["24", "37", "96", "04"],
                [[2, 1], [2, 2]]);

            // Вывод: [1,5,11,10,7,0,0,1,13,13,5,12]
            var result_2 = SmallestTrimmedNumbers(
                ["64333639502", "65953866768", "17845691654", "87148775908", "58954177897", "70439926174", "48059986638", "47548857440", "18418180516", "06364956881", "01866627626", "36824890579", "14672385151", "71207752868"],
                [[9, 4], [6, 1], [3, 8], [12, 9], [11, 4], [4, 9], [2, 7], [10, 3], [13, 1], [13, 1], [6, 1], [5, 10]]
                );
        }

        public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        {
            var countNums = nums.Length;
            var countQueries = queries.Length;

            var results = new int[countQueries];
            var store = new object[countNums][];

            for(var i = 0; i < countQueries; i++)
            {
                var k = queries[i][0];
                var trim = queries[i][1];

                for (var j = 0; j < countNums; j++)
                {
                    // Substring(nums[j].Length - trim)
                    store[j] = [nums[j][^trim..], j];
                }

                Array.Sort(store, (a, b) => {
                    var comparison = string.Compare((string)a[0], (string)b[0]);
                    return comparison == 0 ? ((int)a[1]).CompareTo((int)b[1]) : comparison;
                });

                results[i] = (int)store[k - 1][1];
            }

            return results;
        }



        //public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        //{
        //    var nq = queries.Length;
        //    var result = new int[nq];
        //    var mapResult = new Dictionary<(int k, int trim), int>();
        //    var mapTrim = new Dictionary<int, (int[], int[])>();

        //    for(var i = 0; i < nq; i++)
        //    {
        //        if (mapResult.TryGetValue((queries[i][0], queries[i][1]), out int val))
        //        {
        //            result[i] = val;
        //        }
        //        else
        //        {
        //            result[i] = GetkthMinIndex(nums, queries[i][0], queries[i][1], mapTrim);
        //            mapResult.Add((queries[i][0], queries[i][1]), result[i]);
        //        }
        //    }
        //    return result;
        //}

        //public int GetkthMinIndex(string[] nums, int k, int trim,
        //    Dictionary<int, (int[], int[])> mapTrim)
        //{
        //    var n = nums.Length;
        //    int[] arr;
        //    int[] counts;
        //    if (mapTrim.ContainsKey(trim))
        //    {
        //        arr = mapTrim[trim].Item1;
        //        counts = mapTrim[trim].Item2;
        //    }
        //    else
        //    {
        //        arr = new int[n];
        //        for (var i = 0; i < n; i++)
        //        {
        //            arr[i] = int.Parse(nums[i].Substring(nums[i].Length - trim));
        //        }

        //        var max = int.MinValue;
        //        for (var i = 0; i < n; i++)
        //        {
        //            if (arr[i] > max) max = arr[i];
        //        }

        //        counts = new int[max + 1];
        //        for (var i = 0; i < n; i++)
        //        {
        //            counts[arr[i]]++;
        //        }

        //        var startIndex = 0;
        //        for (var i = 0; i < max + 1; i++)
        //        {
        //            var count = counts[i];
        //            counts[i] = startIndex;
        //            startIndex += count;
        //        }
        //    }
        //    var sorted = new int[n];
        //    for (var i = 0; i < n; i++)
        //    {
        //        var elem = arr[i];
        //        sorted[counts[elem]] = elem;

        //        if (counts[elem] == k - 1)
        //            return i;

        //        counts[elem]++;
        //    }
        //    return 0;
        //}
    }
}
