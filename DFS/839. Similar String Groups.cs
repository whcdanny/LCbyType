//Leetcode 839. Similar String Groups hard
//题意：给定字符串数组 strs，其中每个字符串都是该数组中任何其他字符串的字谜。如果两个字符串可以通过交换它们的字符而变得相似，那么它们被认为是相似的。求字符串数组中有多少个相似字符串的分组。
//思路：遍历字符串列表 strs，对于每个字符串，尝试将其与其他字符串进行比较，检查是否相似。如果相似，则将它们标记为已访问，并递归地继续检查它们的相似关系。
//时间复杂度: 外层循环遍历每个字符串，内层循环遍历每个字符串并比较是否相似，所以总时间复杂度为 O(N^2 * L)，其中 N 为字符串列表的长度，L 为字符串的平均长度。
//空间复杂度：O(N)
        public int NumSimilarGroups(string[] strs)
        {
            int n = strs.Length;
            bool[] visited = new bool[n];
            int groups = 0;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    DFS_NumSimilarGroups(i, strs, visited);
                    groups++;
                }
            }

            return groups;
        }

        private void DFS_NumSimilarGroups(int index, string[] strs, bool[] visited)
        {
            visited[index] = true;

            for (int i = 0; i < strs.Length; i++)
            {
                if (!visited[i] && IsSimilar_NumSimilarGroups(strs[index], strs[i]))
                {
                    DFS_NumSimilarGroups(i, strs, visited);
                }
            }
        }

        private bool IsSimilar_NumSimilarGroups(string s1, string s2)
        {
            int diffCount = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    diffCount++;
                    if (diffCount > 2)
                    {
                        return false;
                    }
                }
            }
            return diffCount == 2 || diffCount == 0;
        }