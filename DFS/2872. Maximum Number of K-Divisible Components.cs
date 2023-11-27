//Leetcode 2872. Maximum Number of K-Divisible Components hard
//题意：给定一个包含 n 个节点的无向树，节点编号从 0 到 n - 1。还给定一个二维整数数组 edges，长度为 n - 1，表示树中的边，其中 edges[i] = [ai, bi] 表示节点 ai 和 bi 之间有一条边。
//同时，给定一个长度为 n 的整数数组 values，其中 values[i] 表示第 i 个节点的值。还有一个整数 k。
//通过从树中移除一些边，可以获得一个“有效分割”，其中移除的边可以是任意集合，也可以为空集，分割后的每个子树的节点值之和必须是 k 的倍数。每个子树的值是其包含节点的值之和。
//任务是返回任何有效分割中的最大连接子树数量。
//思路：DFS）来遍历树的每个节点。计算从根部开始计算每个节点子树的值之和，并记录访问过的node，然后跟K做%，然后reset0，为了找到下一个；
//时间复杂度:  O(N)，其中 N 是节点的数量。
//空间复杂度： 递归调用栈的最大深度为树的高度，最坏情况下为 N，因此空间复杂度是 O(N)。
        private int maxComponents = 0;
        public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            HashSet<int> visited = new HashSet<int>();

            // Start DFS from the root node (node 0).
            DFS_MaxKDivisibleComponents(0, graph, values, k, visited);

            return maxComponents;
        }

        private long DFS_MaxKDivisibleComponents(int node, Dictionary<int, List<int>> graph, int[] values, int k, HashSet<int> visited)
        {
            visited.Add(node);
            long componentValue = (long)values[node];

            foreach (int neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    componentValue += DFS_MaxKDivisibleComponents(neighbor, graph, values, k, visited);
                }
            }

            if (componentValue % k == 0)
            {
                maxComponents++;
                return 0; // Reset componentValue for this component
            }

            return componentValue;
        }