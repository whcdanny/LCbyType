//Leetcode 1319. Number of Operations to Make Network Connected med
//题意：有 n 台超级计算机，形成一个网络，计算机的编号是 0 到 n-1。正在修理一个有 n 台计算机的超级计算机网络。这些计算机连接在一个以太网上，为了修理这个网络，你需要连接一些补丁。每台超级计算机都有一个编号，它们之间的连接形成了无向图。补丁用以太网线直接连接两台计算机，并且可以传输数据。连接 computers[i] 和 computers[j] 的费用是 cost[i][j]，表示这两台计算机之间的连接花费。修理网络时，有一些条件和限制：如果已经连通了一对计算机，那么它们之间的连接是冗余的。连接所有计算机所需的最小费用是无向图连通的最小费用。如果可以多种不同的方式修理网络，以达到最小连接费用，则只考虑连接数量最多的情况。如果不可能任何方式修理网络，就返回 -1。
//思路：BFS 首先判断是否有足够的补丁，即 edges.Length >= n - 1；根据connection制作个graph，然后根据这个graph从第一个服务器开始搜索，找到连接不到的服务，然后再以找不到的服务为头再进行BFS，直到所有服务器都被访问，然后每一次寻找新的头儿，就代表要连接新的线路；
//时间复杂度: O(N * N)
//空间复杂度：O(N)
        public int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
            {
                return -1; // Not enough edges to connect all computers
            }

            List<int>[] graph = BuildGraph(n, connections);
            bool[] visited = new bool[n];
            int patches = 0; // Count of patches needed

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    patches++; // Need a patch for each new connected component
                    BFS_MakeConnected(i, graph, visited);
                }
            }

            return patches - 1; // The number of components minus 1 is the number of cables needed
        }
        private List<int>[] BuildGraph(int n, int[][] connections)
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

        private void BFS_MakeConnected(int start, List<int>[] graph, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (int neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visited[neighbor] = true;
                    }
                }
            }
        }
        //思路：首先判断是否有足够的补丁，即 edges.Length >= n - 1。然后使用并查集（Union-Find）来构建网络，将连通的计算机合并到同一个集合。最后统计集合的个数，并且计算需要的补丁数量。
        //时间复杂度：O(E* α(N))，其中 E 为边的数量，α(N) 为 Ackermann 函数的反函数。
        //空间复杂度：O(N)。
        public int MakeConnected1(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
            {
                return -1; // Not enough edges to connect all computers
            }

            int[] parent = new int[n];
            int[] rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }

            int components = n; // Initially, each computer is a separate component

            foreach (var connection in connections)
            {
                int root1 = Find(connection[0], parent);
                int root2 = Find(connection[1], parent);

                if (root1 != root2)
                {
                    Union(root1, root2, parent, rank);
                    components--;
                }
            }

            return components - 1; // The number of components minus 1 is the number of cables needed
        }
        private int Find(int x, int[] parent)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x], parent);
            }

            return parent[x];
        }

        private void Union(int x, int y, int[] parent, int[] rank)
        {
            int rootX = Find(x, parent);
            int rootY = Find(y, parent);

            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }

