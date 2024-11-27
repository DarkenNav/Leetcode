using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.Tree.Graf
{
    public class FindChampionIICase : IGrafLC
    {
        public void Cases()
        {
            // Output: 0
            var result_0 = FindChampion(3, [[0,1],[1,2]]);
            // Output: -1
            var result_1 = FindChampion(4, [[0,2],[1,3],[1,2]]);
        }

        public int FindChampion(int n, int[][] edges)
        {
            var participants = new int[n];
            for(var i = 0; i < edges.Length; i++)
                participants[edges[i][1]]++;

            var champion = -1;
            var potencialChampions = 0;
            for(var i = 0; i < n; i++)
            {
                if(participants[i] == 0)
                {
                    potencialChampions++;
                    champion = i;
                }
            }

            return potencialChampions > 1 ? -1 : champion;
        }
    }
}