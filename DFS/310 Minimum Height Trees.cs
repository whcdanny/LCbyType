//Leetcode 310 Minimum Height Trees med
//题意：给定一个无向图，图中的节点标号从 0 到 n-1。找到所有可能的根节点，使得以该根节点为根的子树的最大高度最小。
//思路：构建图：根据输入的边列表构建图，使用邻接表表示。
//从任意节点开始进行深度优先搜索，找到离该节点最远的节点，标记为节点 A。
//从节点 A 开始进行深度优先搜索，找到离节点 A 最远的节点，标记为节点 B。
//节点 A 和节点 B 之间的路径即为树的直径，中间的节点即为最小高度树的根节点。
//时间复杂度: 节点数为 n, O(n)
//空间复杂度： O(n)
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            // 特殊情况：如果只有一个节点，它已经是根节点
            if (n == 1)
            {
                return new List<int> { 0 };
            }

            // 构建图，使用邻接表表示
            List<HashSet<int>> graph = new List<HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new HashSet<int>());
            }

            // 将边添加到图中
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            // 初始化用于存储叶节点的列表
            List<int> leaves = new List<int>();

            // 查找初始叶节点（只有一个邻居的节点）
            for (int i = 0; i < n; i++)
            {
                if (graph[i].Count == 1)
                {
                    leaves.Add(i);
                }
            }

            // 持续该过程，直到最多只剩下 2 个节点
            while (n > 2)
            {
                n -= leaves.Count;
                List<int> newLeaves = new List<int>();

                // 移除当前的叶节点并更新邻居节点
                foreach (var leaf in leaves)
                {
                    int neighbor = graph[leaf].First();
                    graph[neighbor].Remove(leaf);

                    // 如果邻居变成了叶节点，将其添加到 newLeaves 列表中
                    if (graph[neighbor].Count == 1)
                    {
                        newLeaves.Add(neighbor);
                    }
                }

                // 为下一次迭代更新叶节点列表
                leaves = newLeaves;
            }

            // leaves 列表中剩下的节点即为最小高度树的根节点
            return leaves;
        }