//Leetcode 1233. Remove Sub-Folders from the Filesystem med
//题意：给定一个文件夹列表 folder，返回删除其中所有子文件夹后的文件夹列表。可以以任何顺序返回答案。
//如果文件夹 folder[i] 位于另一个文件夹 folder[j] 中，则称它为 folder[j] 的子文件夹。
//路径的格式是由一个或多个连接在一起的字符串组成，形式为：'/' 后跟一个或多个小写英文字母。
//例如，"/leetcode" 和 "/leetcode/problems" 是有效路径，而空字符串和 "/" 不是。
//思路：DFS, 函数用于判断当前文件夹路径是否是其他文件夹的子文件夹。它通过遍历路径中的 '/' 字符，检查前缀是否在 folderSet 中，如果是，则说明当前路径是其他文件夹的子文件夹
//注：从每个folder的第二位开始，只要遇到‘/’就说明前面有一个路径，检查是否在folder里，如果有就说明当前这个是个子路径；
//时间复杂度: O(N * M)，其中 N 是文件夹数量，M 是文件夹路径的平均长度
//空间复杂度：O(N)，用于存储文件夹路径的 HashSet。
        public IList<string> RemoveSubfolders(string[] folder)
        {
            List<string> result = new List<string>();
            HashSet<string> folderSet = new HashSet<string>(folder);

            foreach (var path in folder)
            {
                if (IsSubfolder(path, folderSet))
                {
                    result.Add(path);
                }
            }

            return result;
        }

        private bool IsSubfolder(string path, HashSet<string> folderSet)
        {
            int length = path.Length;
            for (int i = 1; i < length; i++)
            {
                if (path[i] == '/' && folderSet.Contains(path.Substring(0, i)))
                {
                    return false;
                }
            }
            return true;
        }