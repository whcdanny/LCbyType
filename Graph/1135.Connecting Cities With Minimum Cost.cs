//1135.Connecting Cities With Minimum Cost med
//最低成本链接，给一个connection的[ciry1,city2,cost], 如果满足所有城市连接，并且最小成本；
//思路：Kruskal 算法：先根据cost从小到大排序，然后如果不连接建立边，然后此时的成本时最小，然后+，因为节点 0 没有被使用，所以 0 会额外占用一个连通分量；
		public int MinimumCost(int n, int[][] connections)
        {
            // 城市编号为 1...n，所以初始化大小为 n + 1
            UF uf = new UF(n + 1);
            // 对所有边按照权重从小到大排序
            Array.Sort(connections, (a, b)=> (a[2] - b[2]));
            // 记录最小生成树的权重之和
            int mst = 0;
            foreach (int[] edge in connections)
            {
                int u = edge[0];
                int v = edge[1];
                int weight = edge[2];
                // 若这条边会产生环，则不能加入 mst
                if (uf.connected(u, v))
                {
                    continue;
                }
                // 若这条边不会产生环，则属于最小生成树
                mst += weight;
                uf.union(u, v);
            }
            // 保证所有节点都被连通
            // 按理说 uf.count() == 1 说明所有节点被连通
            // 但因为节点 0 没有被使用，所以 0 会额外占用一个连通分量
            return uf.count() == 2 ? mst : -1;
        }
		
		class UF
        {
            // 连通分量个数
            public int count_uf;
            // 存储每个节点的父节点
            private int[] parent;

            // n 为图中节点的个数
            public UF(int n)
            {
                count_uf = n;
                parent = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                }
            }

            // 将节点 p 和节点 q 连通
            public void union(int p, int q)
            {
                int rootP = find(p);
                int rootQ = find(q);

                if (rootP == rootQ)
                    return;

                parent[rootQ] = rootP;
                // 两个连通分量合并成一个连通分量
                count_uf--;
            }

            // 判断节点 p 和节点 q 是否连通
            public bool connected(int p, int q)
            {
                int rootP = find(p);
                int rootQ = find(q);
                return rootP == rootQ;
            }

            public int find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = find(parent[x]);
                }
                return parent[x];
            }

            // 返回图中的连通分量个数
            public int count()
            {
                return count_uf;
            }
        }
		
//思路：Prim 算法
		public int minimumCost(int n, int[][] connections)
        {
            // 转化成无向图邻接表的形式
            List<int[]>[] graph = buildGraph_minimumCost(n, connections);
            // 执行 Prim 算法
            Prim prim = new Prim(graph);

            if (!prim.allConnected())
            {
                // 最小生成树无法覆盖所有节点
                return -1;
            }

            return prim.weightSum();
        }
        public List<int[]>[] buildGraph_minimumCost(int n, int[][] connections)
        {
            // 图中共有 numCourses 个节点
            List<int[]>[] graph = new List<int[]>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
            }
            foreach (int[] conn in connections)
            {
                // 题目给的节点编号是从 1 开始的，
                // 但我们实现的 Prim 算法需要从 0 开始编号
                int u = conn[0] - 1;
                int v = conn[1] - 1;
                int weight = conn[2];
                // 「无向图」其实就是「双向图」
                // 一条边表示为 int[]{from, to, weight}
                graph[u].Add(new int[] { u, v, weight });
                graph[v].Add(new int[] { v, u, weight });
            }
            return graph;
        }        
		
		class Prim
        {
            // 核心数据结构，存储「横切边」的优先级队列
            private List<int[]> pq;
            // 类似 visited 数组的作用，记录哪些节点已经成为最小生成树的一部分
            private bool[] inMST;
            // 记录最小生成树的权重和
            private int weightSum_Prim = 0;
            // graph 是用邻接表表示的一幅图，
            // graph[s] 记录节点 s 所有相邻的边，
            // 三元组 int[]{from, to, weight} 表示一条边
            private List<int[]>[] graph;

            public Prim(List<int[]>[] graph)
            {
                this.graph = graph;
                // 按照边的权重从小到大排序
                this.pq.Sort((a, b) => a[2] - b[2]);
                //this.pq = new PriorityQueue<>((a, b)-> {
                //    // 按照边的权重从小到大排序
                //     return a[2] - b[2];});
                // 图中有 n 个节点
                int n = graph.Length;
                this.inMST = new bool[n];

                // 随便从一个点开始切分都可以，我们不妨从节点 0 开始
                inMST[0] = true;
                cut(0);
                // 不断进行切分，向最小生成树中添加边
                int index = 0;
                while (pq.Count!=0) {                    
                    int[] edge = pq[index];
                    pq.RemoveAt(index);
                    index++;
                    int to = edge[1];
                    int weight = edge[2];
                    if (inMST[to]) {
                        // 节点 to 已经在最小生成树中，跳过
                        // 否则这条边会产生环
                        continue;
                    }
                    // 将边 edge 加入最小生成树
                    weightSum_Prim += weight;
                    inMST[to] = true;
                    // 节点 to 加入后，进行新一轮切分，会产生更多横切边
                    cut(to);
                }
            }

            // 将 s 的横切边加入优先队列
            private void cut(int s)
            {
                // 遍历 s 的邻边
                 foreach (int[] edge in graph[s]) {
                    int to = edge[1];
                    if (inMST[to])
                    {
                        // 相邻接点 to 已经在最小生成树中，跳过
                        // 否则这条边会产生环
                        continue;
                    }
                    // 加入横切边队列
                    pq.Add(edge);
                }
            }

            // 最小生成树的权重和
            public int weightSum()
            {
                return weightSum_Prim;
            }

            // 判断最小生成树是否包含图中的所有节点
            public bool allConnected()
            {
                for (int i = 0; i < inMST.Length; i++)
                {
                    if (!inMST[i])
                    {
                         return false;
                    }
                }
                return true;
            }
        }