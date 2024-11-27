using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    // 1233. Remove Sub-Folders from the Filesystem
    public class RemoveSubFoldersfromFilesystemCase
    {
        public void Cases()
        {
            // Output: ["/a","/c/d","/c/f"]
            var result_0 = RemoveSubfolders(["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"]);
            // Output: ["/a"]
            var result_1 = RemoveSubfolders(["/a", "/a/b/c", "/a/b/d"]);
            // Output: ["/a/b/c","/a/b/ca","/a/b/d"]
            var result_2 = RemoveSubfolders(["/a/b/c", "/a/b/ca", "/a/b/d"]);
        }

        // Quicksort O(n log n), for O(n)
        public IList<string> RemoveSubfolders(string[] folder)
        {
            var result = new List<string>();

            Array.Sort(folder);
            var root = "/..";
            for (var i = 0; i < folder.Length; i++)
            {
                if (!folder[i].StartsWith($"{root}/"))
                {
                    result.Add(folder[i]);
                    root = folder[i];
                }
            }

            return result;
        }
    }
}
