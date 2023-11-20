//Leetcode 839. Similar String Groups hard
//题意：给定字符串数组 strs，其中每个字符串都是该数组中任何其他字符串的字谜。如果两个字符串可以通过交换它们的字符而变得相似，那么它们被认为是相似的。求字符串数组中有多少个相似字符串的分组。
//思路：可以使用 BFS 进行解决。从第一个开始，跟它如果后面有类似的就存到visited，每一次走到最后就算一组；
//时间复杂度: O(N * L^2)，其中 N 为字符串数组的长度，L 为字符串的平均长度。
//空间复杂度：O(N)
        public int NumSimilarGroups(string[] strs)
        {
            int n = strs.Length;
            int groupCount = 0;
            HashSet<string> visited = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                if (!visited.Contains(strs[i]))
                {
                    BFS_NumSimilarGroups(strs, i, visited);
                    groupCount++;
                }
            }

            return groupCount;
        }
        private void BFS_NumSimilarGroups(string[] strs, int start, HashSet<string> visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited.Add(strs[start]);

            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();

                for (int i = start+1; i < strs.Length; i++)
                {
                    if (!visited.Contains(strs[i]) && AreSimilar_NumSimilarGroups(strs[curr], strs[i]))
                    {
                        queue.Enqueue(i);
                        visited.Add(strs[i]);
                    }
                }
            }
        }
        private bool AreSimilar_NumSimilarGroups(string a, string b)
        {
            int diffCount = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
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