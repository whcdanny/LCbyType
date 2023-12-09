//Leetcode 785. Is Graph Bipartite? med 和 886差不多
//题意：给定一个无向图，图中的节点个数 n 在范围 [1, 100] 内。图中边的个数在范围 [0, 300] 内。整个图是通过一个邻接表 graph 表示的，其中 graph[i] 是节点 i 的所有邻接节点。判断这个图是否为二分图，如果是，返回 true；否则，返回 false。
//思路：深度优先搜索（DFS）。首先，我们需要为图中的每个节点分配一个颜色，通常使用 0 和 1 表示两种颜色。然后，从任意一个节点开始，将它的所有相邻节点涂成与该节点不同的颜色。如果能够成功将所有节点涂色，并且相邻节点的颜色不同，那么图是二分图。
//使用 colors 数组来记录每个节点的颜色，初始值为 0 表示未涂色。然后，对于每个未涂色的节点，使用DFS来递归涂色，并确保相邻节点的颜色不同。如果能够成功涂色，返回 true；否则，返回 false。在外部循环中，对所有节点进行检查，最终判断整个图是否是二分图。
//时间复杂度:  O(N + E)，其中 N 是节点数，E 是边数。
//空间复杂度： O(N)
        public bool IsBipartite(int[][] graph) // == 886
        {
            int n = graph.Length;
            int[] colors = new int[n]; // 0:未涂色, 1:颜色1, -1:颜色2

            for (int i = 0; i < n; i++)
            {
                if (colors[i] == 0 && !DFS_IsBipartite(graph, i, 1, colors))
                {
                    return false;
                }
            }

            return true;
        }

        private bool DFS_IsBipartite(int[][] graph, int node, int color, int[] colors)
        {
            if (colors[node] != 0)
            {
                return colors[node] == color;
            }

            colors[node] = color;

            foreach (var neighbor in graph[node])
            {
                if (!DFS_IsBipartite(graph, neighbor, -color, colors))
                {
                    return false;
                }
            }

            return true;
        }