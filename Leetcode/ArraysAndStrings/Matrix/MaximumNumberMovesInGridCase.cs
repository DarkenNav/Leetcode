using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Matrix
{
    public class MaximumNumberMovesInGridCase
    {
        public void Cases()
        {
            // Output: 3
            var mat_0 = new int[][]{
                [2,  4,  3,  5], 
                [5,  4,  9,  3], 
                [3,  4,  2,  11], 
                [10, 9,  13, 15]
            };
            var result_0 = MaxMoves(mat_0);

            // Output: 0
            var mat_1 = new int[][]{
                [3,2,4],
                [2,1,9],
                [1,1,7]
            };
            var result_1 = MaxMoves(mat_1);

            // Output: 49
            var mat_2 = new int[][]{
                [1000000,92910,1021,1022,1023,1024,1025,1026,1027,1028,1029,1030,1031,1032,1033,1034,1035,1036,1037,1038,1039,1040,1041,1042,1043,1044,1045,1046,1047,1048,1049,1050,1051,1052,1053,1054,1055,1056,1057,1058,1059,1060,1061,1062,1063,1064,1065,1066,1067,1068],
                [1069,1070,1071,1072,1073,1074,1075,1076,1077,1078,1079,1080,1081,1082,1083,1084,1085,1086,1087,1088,1089,1090,1091,1092,1093,1094,1095,1096,1097,1098,1099,1100,1101,1102,1103,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,1115,1116,1117,1118]
            };
            var result_2 = MaxMoves(mat_2);
        }

        // O(3^N)
        public int MaxMoves(int[][] grid)
        {
            var maxStep = 0;
            var map = new Dictionary<(int i, int j), int>();
            for (var col = 0; col < grid.Length; col++)
            {
                maxStep = Math.Max(maxStep, MoveReqursion(col, 0, 0, grid, map));
            }
            return maxStep;
        }

        private int MoveReqursion(int i, int j, int step, int[][] grid,
            Dictionary<(int i, int j), int> map)
        {
            if(map.TryGetValue((i, j), out int max))
                return max;

            var maxStep = step;
            if (Check(i, j, -1, 1, grid))
                maxStep = Math.Max(maxStep, MoveReqursion(i - 1, j + 1, step + 1, grid, map));
            if (Check(i, j, 0, 1, grid))
                maxStep = Math.Max(maxStep, MoveReqursion(i, j + 1, step + 1, grid, map));
            if (Check(i, j, 1, 1, grid))
                maxStep = Math.Max(maxStep, MoveReqursion(i + 1, j + 1, step + 1, grid, map));

            map[(i, j)] = maxStep;
            return maxStep;
        }

        private bool Check(int i, int j, int move_i, int move_j, int[][] grid) 
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var i1 = i + move_i;
            var j1 = j + move_j;
            if (i1 < m && i1 >= 0
                && j1 < n && j1 >= 0
                && grid[i][j] < grid[i1][j1])
                return true;

            return false;
        }

    }

}
