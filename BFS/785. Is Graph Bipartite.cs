//Leetcode 785. Is Graph Bipartite? med
//题意：给定一个无向图，图中的节点个数 n 在范围 [1, 100] 内。图中边的个数在范围 [0, 300] 内。整个图是通过一个邻接表 graph 表示的，其中 graph[i] 是节点 i 的所有邻接节点。判断这个图是否为二分图，如果是，返回 true；否则，返回 false。
//思路：广度优先搜索（BFS）来进行图的遍历，同时检查每个节点是否属于某个集合。用一个数组 colors 来表示每个节点的颜色，初始化为 0。遍历每个节点，如果节点未被染色，则从该节点开始进行 BFS。在 BFS 过程中，对于当前节点，如果它未被染色，就将其染成与相邻节点不同的颜色。如果发现某个节点已经被染色，并且颜色与当前节点相同，则说明存在相邻节点颜色相同，不是二分图。最后，遍历完所有节点，都没有发现相邻节点颜色相同的情况，说明是二分图。
//时间复杂度:  O(N + E)，其中 N 是节点数，E 是边数。
//空间复杂度： O(N)

        public bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            int[] colors = new int[n]; // 0: 未染色, 1: 集合 A, -1: 集合 B

            for (int i = 0; i < n; i++)
            {
                if (colors[i] == 0)
                {
                    if (!BFS_IsBipartite(graph, i, colors))
                    {
                        return false; // 如果发现不是二分图，则返回 false
                    }
                }
            }

            return true; // 如果遍历完所有节点都没有发现相邻节点颜色相同的情况，说明是二分图
        }

        private bool BFS_IsBipartite(int[][] graph, int start, int[] colors)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            colors[start] = 1;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                int color = colors[node];

                foreach (int neighbor in graph[node])
                {
                    if (colors[neighbor] == color)
                    {
                        return false; // 如果相邻节点颜色相同，不是二分图
                    }

                    if (colors[neighbor] == 0)
                    {
                        colors[neighbor] = -color; // 染成与相邻节点不同的颜色
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return true;
        }

        // 记录图是否符合二分图性质
        private bool ok = true;
        // 记录图中节点的颜色，false 和 true 代表两种不同颜色
        private bool[] color;
        // 记录图中节点是否被访问过
        private bool[] visited_IsBipartite;

        public bool IsBipartite1(int[][] graph)
        {
            int n = graph.Length;
            color = new bool[n];
            visited_IsBipartite = new bool[n];

            for (int v = 0; v < n; v++)
            {
                if (!visited_IsBipartite[v])
                {
                    // 改为使用 BFS 函数
                    bfs_IsBipartite1(graph, v);
                }
            }

            return ok;
        }

        // 从 start 节点开始进行 BFS 遍历
        private void bfs_IsBipartite1(int[][] graph, int start)
        {
            Queue<int> q = new Queue<int>();
            visited_IsBipartite[start] = true;
            q.Enqueue(start);

            while (q.Count != 0 && ok)
            {
                int v = q.Dequeue();
                // 从节点 v 向所有相邻节点扩散
                foreach (int w in graph[v])
                {
                    if (!visited_IsBipartite[w])
                    {
                        // 相邻节点 w 没有被访问过
                        // 那么应该给节点 w 涂上和节点 v 不同的颜色
                        color[w] = !color[v];
                        // 标记 w 节点，并放入队列
                        visited_IsBipartite[w] = true;
                        q.Enqueue(w);
                    }
                    else
                    {
                        // 相邻节点 w 已经被访问过
                        // 根据 v 和 w 的颜色判断是否是二分图
                        if (color[w] == color[v])
                        {
                            // 若相同，则此图不是二分图
                            ok = false;
                            return;
                        }
                    }
                }
            }
        }