//Leetcode 77 Combinations  med
//题意：给定两个整数 n 和 k，要求返回从 1 到 n 中选出 k 个数字的所有组合。
//思路：深度优先搜索（DFS）: 从 1 开始递增，依次将数字添加到当前组合中，然后递归调用寻找下一个数字。当组合的长度达到 k 时，将当前组合加入结果集中。
//时间复杂度: 整数为 n，要求的组合长度为 k, O(C(n,k) * k)
//空间复杂度： 深度可能达到 k, O(k)
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            Combine_DFS(n, k, 1, new List<int>(), result);
            return result;
        }

        private void Combine_DFS(int n, int k, int start, List<int> combination, List<IList<int>> result)
        {
            if (combination.Count == k)
            {
                result.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                combination.Add(i);
                Combine_DFS(n, k, i + 1, combination, result);
                combination.RemoveAt(combination.Count - 1);
            }
        }