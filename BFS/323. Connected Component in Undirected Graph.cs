//Leetcode 323. Connected Component in Undirected Graph med
//题意：给定一个无向图，节点编号从 0 到 n-1，以及一个边的列表，每个边表示两个节点之间的连接关系。求图中连通分量的个数。
//思路：广度优先搜索（BFS）序列化： 创建一个邻接表来表示图的连接关系。创建一个布尔数组 visited 用于标记节点是否已经访问过.遍历其所有未访问的邻居节点，并将它们加入队列
//时间复杂度:  n 表示节点的数量，m 表示边的数量, O(n + m)
//空间复杂度：O(n + m)
        public int CountComponents(int n, int[][] edges)
        {
            List<List<int>> adjList = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }
            foreach (int[] edge in edges)
            {
                adjList[edge[0]].Add(edge[1]);
                adjList[edge[1]].Add(edge[0]);
            }
            bool[] visited = new bool[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    BFS_CountComponents(i, adjList, visited);
                    count++;
                }
            }
            return count;
        }

        private void BFS_CountComponents(int start, List<List<int>> adjList, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in adjList[node])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visited[neighbor] = true;
                    }
                }
            }
        }