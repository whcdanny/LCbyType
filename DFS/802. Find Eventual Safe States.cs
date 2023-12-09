//Leetcode 802. Find Eventual Safe States med
//题意：给定一个有向图，节点编号从 0 到 n - 1，图中可能存在自环和平行边。判断是否存在一种安全路径，使得无论起始节点是哪里，最终都能到达安全状态。安全状态是指经过有向图的一系列节点后，最终到达一个终点节点，不会再有出边。
//思路：DFS 遍历有向图： 使用深度优先搜索（DFS）遍历有向图的每个节点。
//标记访问状态： 对每个节点维护三种访问状态，分别为未访问（0）、正在访问（1）、已访问（2）。
//判断环的存在： 在DFS的过程中，如果遇到当前节点已经处于正在访问状态，说明存在环，返回 false；如果遇到当前节点已经处于已访问状态，说明当前路径上的节点都是安全的，返回 true。
//路径回溯： 遍历完一个节点的所有邻居后，将当前节点状态置为已访问。
//时间复杂度: O(N + E)，其中 N 为节点数，E 为边数。
//空间复杂度：O(N)。使用了一个队列和一个数组来存储节点状态。
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            int[] color = new int[n];
            List<int> result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (IsSafe(graph, color, i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private bool IsSafe(int[][] graph, int[] color, int node)
        {
            if (color[node] > 0)
            {
                return color[node] == 2;
            }

            color[node] = 1;

            foreach (var neighbor in graph[node])
            {
                if (!IsSafe(graph, color, neighbor))
                {
                    return false;
                }
            }

            color[node] = 2;
            return true;
        }