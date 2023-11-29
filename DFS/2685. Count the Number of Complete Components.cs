 //Leetcode 2685. Count the Number of Complete Components med
//题意：给定一个整数 n，表示一个具有 n 个顶点的无向图，顶点编号从 0 到 n - 1。同时给定一个二维整数数组 edges，其中 edges[i] = [ai, bi] 表示存在一条连接顶点 ai 和 bi 的无向边。返回图中完全连通分量的数量。一个连通分量是图的一个子图，其中任意两个顶点之间都存在一条路径，并且子图内的任何顶点都不与子图外的顶点共享边。一个连通分量被称为完全连通如果它的任意两个顶点之间都存在一条边。
//思路：深度优先搜索 (DFS)。构建有向图的邻接表表示。数组 visited 标记节点是否被访问，以及一个集合 componentNodes 用于记录当前连通分量中的节点。通过每一次DFS结束之后把所有componentNodes中存到的点与其边数进行比较，边数=总点数-1；表示点和线的关系，来确认是否为闭环；
//时间复杂度: O(V + E)，其中 V 为顶点数，E 为边数。
//空间复杂度：O(V + E)，使用了邻接表存储图，以及 visited 数组标记节点是否被访问。
        public int CountCompleteComponents(int n, int[][] edges)
        {
            List<int> componentNodes = new List<int>();
            List<List<int>> graph = new List<List<int>>(n);
            bool[] visited = new bool[n];
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }
            foreach (int[] edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    componentNodes = new List<int>();
                    DFS_CountCompleteComponents(i, visited, graph, componentNodes);

                    int componentCount = componentNodes.Count;
                    bool flag = false;
                    foreach (int node in componentNodes)
                    {
                        if (graph[node].Count != componentCount - 1)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        count++;
                }
            }

            return count;
        }

        private void DFS_CountCompleteComponents(int node, bool[] visited, List<List<int>> graph, List<int> componentNodes)
        {
            componentNodes.Add(node);
            visited[node] = true;

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    DFS_CountCompleteComponents(neighbor, visited, graph, componentNodes);
                }
            }
        }