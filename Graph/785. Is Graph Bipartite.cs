//785. Is Graph Bipartite? med
//判断是否为二分图
//思路：DFS相当于对节点着色使得每两个相邻节点的颜色都不相同，因为图不一定是联通的，可能存在多个子图，所以要把每个节点都作为起点进行一次遍历，如果发现任何一个子图不是二分图，整幅图都不算二分图；
		// 记录图是否符合二分图性质
        private bool ok = true;
        // 记录图中节点的颜色，false 和 true 代表两种不同颜色
        private bool[] color;
        // 记录图中节点是否被访问过
        private bool[] visited_IsBipartite;

        // 主函数，输入邻接表，判断是否是二分图
        public bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            color = new bool[n];
            visited_IsBipartite = new bool[n];
            // 因为图不一定是联通的，可能存在多个子图
            // 所以要把每个节点都作为起点进行一次遍历
            // 如果发现任何一个子图不是二分图，整幅图都不算二分图
            for (int v = 0; v < n; v++)
            {
                if (!visited_IsBipartite[v])
                {
                    traverse_IsBipartite(graph, v);
                }
            }
            return ok;
        }
        // DFS 遍历框架
        private void traverse_IsBipartite(int[][] graph, int v)
        {
            // 如果已经确定不是二分图了，就不用浪费时间再递归遍历了
            if (!ok) return;

            visited_IsBipartite[v] = true;
            foreach (int w in graph[v])
            {
                if (!visited_IsBipartite[w])
                {
                    // 相邻节点 w 没有被访问过
                    // 那么应该给节点 w 涂上和节点 v 不同的颜色
                    color[w] = !color[v];
                    // 继续遍历 w
                    traverse_IsBipartite(graph, w);
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
//BFS:用到Queue
        // 记录图是否符合二分图性质
        private bool ok = true;
        // 记录图中节点的颜色，false 和 true 代表两种不同颜色
        private bool[] color;
        // 记录图中节点是否被访问过
        private bool[] visited_IsBipartite;

        public bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            color = new bool[n];
            visited_IsBipartite = new bool[n];

            for (int v = 0; v < n; v++)
            {
                if (!visited_IsBipartite[v])
                {
                    // 改为使用 BFS 函数
                    bfs(graph, v);
                }
            }

            return ok;
        }

        // 从 start 节点开始进行 BFS 遍历
        private void bfs(int[][] graph, int start)
        {
            Queue<int> q = new Queue<int>();
            visited_IsBipartite[start] = true;
            q.Enqueue(start);

            while (q.Count!=0 && ok)
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