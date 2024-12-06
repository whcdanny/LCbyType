//Leetcode 1557. Minimum Number of Vertices to Reach All Nodes med
//题意：给定一个 有向无环图，其 n 顶点编号从 0 到 n-1，以及一个数组 edges ，
//其中 表示从节点 到节点的  有向边 。edges[i] = [fromi, toi]fromitoi
//找到图中的所有节点均可到达的最小顶点集。保证存在唯一的解决方案。
//请注意，您可以按任意顺序返回顶点。
//思路：构图+BFS
//先将每个点可以到达的点建图
//然后从0号node开始查找到n-1
//然后用visited来表达能被连接到的所有点
//那么剩下的就是顶点
//时间复杂度：O(n)
//空间复杂度：O(n)
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            foreach(var edge in edges)
            {
                if (!map.ContainsKey(edge[0]))
                    map[edge[0]] = new List<int>();
                map[edge[0]].Add(edge[1]);
            }
            bool[] visited = new bool[n];
            List<int> res = new List<int>();
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (visited[i])
                    continue;               
                queue.Enqueue(i);
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (map.ContainsKey(node))
                    {
                        foreach (var nig in map[node])
                        {
                            if (visited[nig])
                                continue;
                            visited[nig] = true;
                            queue.Enqueue(nig);
                        }
                    }
                    
                }
            }
            for(int i = 0; i < n; i++)
            {
                if (!visited[i])
                    res.Add(i);
            }
            return res;
        }