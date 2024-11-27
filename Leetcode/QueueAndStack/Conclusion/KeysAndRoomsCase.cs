
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Conclusion
{
    public class KeysAndRoomsCase 
    {
        public void Case()
        {
            // true
            var result_0 = CanVisitAllRooms(new List<IList<int>>
            {
                new List<int>() { 1 },
                new List<int>() { 2 },
                new List<int>() { 3 },
                new List<int>()
            });

            // false
            var result_1 = CanVisitAllRooms(new List<IList<int>>
            {
                new List<int>() { 1, 3 },
                new List<int>() { 3, 0, 1 },
                new List<int>() { 2 },
                new List<int>() { 0 }
            });
        }

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            if(rooms.Count < 2)
                return true;

            var keys = new Stack<int>();
            foreach (var key in rooms[0])
            {
                keys.Push(key);
            }
            var visits = new HashSet<int>() { 0 };
            while (keys.Count > 0)
            { 
                var key = keys.Pop();
                visits.Add(key);
                foreach (var newKey in rooms[key])
                {
                    if (!visits.Contains(newKey))
                    {
                        keys.Push(newKey);
                    }
                }
            }

            return rooms.Count == visits.Count;
        }
    }
}
