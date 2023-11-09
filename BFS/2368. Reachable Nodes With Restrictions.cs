//Leetcode 2368. Reachable Nodes With Restrictions med
//题意：有一个无向树，其n节点标记为从0到n - 1和n - 1边。 给您一个edges长度为 2D 的整数数组n - 1，其中表示节点之间和树中存在一条边。您还将获得一个表示受限节点的整数数组。edges[i] = [ai, bi] aibirestricted返回在不访问受限节点的情况下从节点可以到达的最大节点数。0请注意，该节点0不会是受限制的节点。
//思路：我们可以使用BFS（广度优先搜索）,根据edges先把他们做成一个无向形graph，然后再根据这个graph，用BFS，将0放入queue，开始历遍，并保证当前node不在restricted；
//时间复杂度: 构建邻接矩阵需要 O(n^2) 的时间，BFS 遍历图需要 O(n^2) 的时间，因此总的时间复杂度为 O(n^2)。
//空间复杂度：邻接矩阵的空间复杂度为 O(n^2)，队列的空间复杂度为 O(n)，因此总的空间复杂度为 O(n^2)。
        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
            
            foreach (var edge in edges)
            {
                if (!adjacencyList.ContainsKey(edge[0]))
                {
                    adjacencyList[edge[0]] = new List<int>();
                }
                if (!adjacencyList.ContainsKey(edge[1]))
                {
                    adjacencyList[edge[1]] = new List<int>();
                }
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            HashSet<int> visited = new HashSet<int>();
            visited.Add(0);
            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();
                foreach(var adj in adjacencyList[cur])
                {
                    if (!restricted.Contains(adj) && !visited.Contains(adj))
                    {
                        queue.Enqueue(adj);
                        visited.Add(adj);
                    }
                }
            }
            return visited.Count;
        }