
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue.Intro
{
    public class OpenTheLockCase 
    {
        public void Case()
        {
            // 6
            var result_1 = OpenLock(
                new string[] { "0201", "0101", "0102", "1212", "2002" },
                "0202"
                );

            // 1
            var result_2 = OpenLock(
                new string[] { "8888" },
                "0009"
                );

            // -1
            var result_3 = OpenLock(
                new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" },
                "8888"
                );

            // 8
            var result_4 = OpenLock(
                new string[] { "0000" },
                "8888"
                );

            // 0
            var result_5 = OpenLock(
                new string[] { "0201", "0101", "0102", "1212", "2002" },
                "0000"
                );

        }

        private string GetNextCombination(char[] current, int position, int order)
        {
            var next = '0';
            if (order > 0)
                next = current[position] + 1 > '9' ? '0' : (char)(current[position] + 1);
            else
                next = current[position] - 1 < '0' ? '9' : (char)(current[position] - 1);

            var newCombination = new char[4];
            Array.Copy(current, newCombination, 4);
            newCombination[position] = next;
            
            return new string(newCombination);
        }

        private bool NextCombinations(HashSet<string> deadends, string target, 
            Queue<string> queue, HashSet<string> checks)
        {
            var targetArr = target.ToArray();
            var result = new HashSet<string>();
            while(queue.Count > 0)
            { 
                var combination = queue.Dequeue().ToArray();
                for (var i = 0; i < 4; i++)
                {
                    var newCombination = GetNextCombination(combination, i, 1);
                    if (newCombination == target)
                    {
                        return true;
                    }
                    else if (!deadends.Contains(newCombination)
                        && !checks.Contains(newCombination))
                    {
                        result.Add(newCombination);
                        checks.Add(newCombination);
                    }

                    newCombination = GetNextCombination(combination, i, -1);
                    if (newCombination == target)
                    {
                        return true;
                    }
                    else if (!deadends.Contains(newCombination)
                        && !checks.Contains(newCombination))
                    {
                        result.Add(newCombination);
                        checks.Add(newCombination);
                    }
                    
                }
            }
            foreach (var item in result)
            {
                queue.Enqueue(item);
            }
            return false;
        }

        public int OpenLock(string[] deadends, string target)
        {
            var startPosition = "0000";
            if (target == startPosition)
                return 0;

            var setDeadends = new HashSet<string>(deadends);
            if (setDeadends.Contains(startPosition))
                return -1;

            var count = 1;
            var queue = new Queue<string>();
            var checks = new HashSet<string>();

            queue.Enqueue(startPosition);
            checks.Add(startPosition);
            while (queue.Count > 0)
            {
                if(NextCombinations(setDeadends, target, queue, checks))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
    }
}
