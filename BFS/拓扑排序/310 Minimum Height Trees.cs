//Leetcode 310 Minimum Height Trees med
//题意：给定一个无向图，图中的节点标号从 0 到 n-1。找到所有可能的根节点，使得以该根节点为根的子树的最大高度最小。
//思路：拓扑排序,构建一个邻接表 adjList 用来表示图的连接关系，以及一个数组 degree 用来记录每个节点的度数。使用一个队列 leaves 将所有度为 1 的节点加入队列中，这些节点可能是潜在的根节点。从叶子节点开始，依次删除它们的连接关系，并将相邻节点的度数减 1。如果某个节点的度数变为 1，说明它也成为了新的叶子节点，将其加入队列
//时间复杂度: 节点数为 n, O(n)
//空间复杂度： O(n)
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1)
                return new List<int> {0};

            List<HashSet<int>> adjList = new List<HashSet<int>>();
            for(int i = 0; i < n; i++)
            {
                adjList.Add(new HashSet<int>());
            }

            int[] degree = new int[n];

            foreach(var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                adjList[u].Add(v);
                adjList[v].Add(u);
                degree[u]++;
                degree[v]++;
            }

            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (degree[i] == 1)
                    queue.Enqueue(i);
            }
            while (n > 2)
            {
                int size = queue.Count;
                n -= size;
                for(int i = 0; i < size; i++)
                {
                    int leaf = queue.Dequeue();
                    foreach(var neighbor in adjList[leaf])
                    {
                        degree[neighbor]--;
                        if (degree[neighbor] == 1)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            List<int> res = new List<int>();
            while (queue.Count > 0)
            {
                res.Add(queue.Dequeue()); 
            }
            return res;
        }