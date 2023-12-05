//Leetcode 1319. Number of Operations to Make Network Connected med
//题意：有 n 台超级计算机，形成一个网络，计算机的编号是 0 到 n-1。正在修理一个有 n 台计算机的超级计算机网络。这些计算机连接在一个以太网上，为了修理这个网络，你需要连接一些补丁。每台超级计算机都有一个编号，它们之间的连接形成了无向图。
//补丁用以太网线直接连接两台计算机，并且可以传输数据。连接 computers[i] 和 computers[j] 的费用是 cost[i][j]，表示这两台计算机之间的连接花费。
//修理网络时，有一些条件和限制：如果已经连通了一对计算机，那么它们之间的连接是冗余的。连接所有计算机所需的最小费用是无向图连通的最小费用。如果可以多种不同的方式修理网络，以达到最小连接费用，则只考虑连接数量最多的情况。
//如果不可能任何方式修理网络，就返回 -1。
//思路：DFS, 首先检查连接数是否小于 n - 1，如果是则返回 -1，因为无法构成联通的网络。接着，使用深度优先搜索来计算网络的连通分量数量，最后返回最小操作次数。如果连接数小于 n - 1，返回 -1。构建图，使用邻接表表示连接关系。使用深度优先搜索遍历图，计算连通分量的数量。返回连通分量数量减一，即最小操作次数。
//注：从0开始历遍，结束后，有没历遍到的，那么就说明需要添加一个边，然后从这个没有visited的点开始，依此循环；
//时间复杂度: O(N + E)，其中 N 是电脑的数量，E 是连接的数量
//空间复杂度：O(N + E)，用于存储图的邻接表和访问状态
        public int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
            {
                return -1; // 如果连接数小于 n-1，无法构成联通的网络
            }

            List<int>[] graph = BuildGraph_MakeConnected(n, connections);
            bool[] visited = new bool[n];
            int components = 0;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    DFS_MakeConnected(i, graph, visited);
                    components++;
                }
            }

            return components - 1; // 最少需要 components - 1 次操作
        }

        private List<int>[] BuildGraph_MakeConnected(int n, int[][] connections)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var connection in connections)
            {
                graph[connection[0]].Add(connection[1]);
                graph[connection[1]].Add(connection[0]);
            }

            return graph;
        }

        private void DFS_MakeConnected(int node, List<int>[] graph, bool[] visited)
        {
            visited[node] = true;

            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    DFS_MakeConnected(neighbor, graph, visited);
                }
            }
        }