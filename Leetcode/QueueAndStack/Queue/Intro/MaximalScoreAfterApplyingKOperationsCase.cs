using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue.Intro
{
    public class MaximalScoreAfterApplyingKOperationsCase
    {
        public void Cases()
        {
            // Output: 50
            var result_0 = MaxKelements([10, 10, 10, 10, 10], 5);
            // Output: 17
            var result_1 = MaxKelements([1, 10, 3, 3, 3], 3);

            // Output: 36767245672
            var result_2 = MaxKelements([597189039, 57948756, 143524875, 379494516, 862193035, 868775043, 395597119, 275046118, 306907315, 257034002, 476132995, 69495282, 395493151, 354621370, 365510017, 520479568, 219063577, 159958079, 113409455, 170145739, 687892872, 881301934, 723211517, 276655363, 635301113, 440291651, 961908086, 821028930, 821879600, 82879805, 850787822, 547409867, 813461937, 866639644, 512259589, 130847041, 973334294, 114942610, 233744177, 941195642, 888940360, 983125701, 533826303, 726965368, 516401603, 312579605, 182667172, 447853195, 275822190, 338282009], 62126);
        }

        public long MaxKelements(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
            for (var i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(i, nums[i]);
            }

            long score = 0;
            while (queue.Count > 0 && k > 0)
            {
                _ = queue.TryDequeue(out var i, out var val);
                score += val;
                queue.Enqueue(i, (int)Math.Ceiling(val / 3.0));
                k--;
            }

            return score;
        }


    }
}
