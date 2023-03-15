//1584. Min Cost to Connect All Points med
//给一组points，[xi, yi], 费用算法是manhattan distance|xi - xj| + |yi - yj|, where |val|，然后给出连接所有点的最小费用
//思路： 先生成所有的边以及权重，然后对这些边执行 Kruskal 算法，
		public int MinCostConnectPoints(int[][] points)
        {
            int n = points.Length;
            // 生成所有边及权重
            List<int[]> edges = new List<int[]>(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int xi = points[i][0], yi = points[i][1];
                    int xj = points[j][0], yj = points[j][1];
                    // 用坐标点在 points 中的索引表示坐标点
                    edges.Add(new int[] {
                i, j, Math.Abs(xi - xj) + Math.Abs(yi - yj)
            });
                }
            }
            // 将边按照权重从小到大排序
            edges.Sort((a, b) => a[2] - b[2]);
            // 执行 Kruskal 算法
            int mst = 0;
            UF uf = new UF(n);
            foreach (int[] edge in edges)
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
            return mst;
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
		public int minCostConnectPoints(int[][] points)
        {
            int n = points.Length;
            List<int[]>[] graph = buildGraph_minCostConnectPoints(n, points);
            return new Prim(graph).weightSum();
        }

        // 构造无向图
        public List<int[]>[] buildGraph_minCostConnectPoints(int n, int[][] points)
        {
            List<int[]>[] graph = new List<int[]>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
            }
            // 生成所有边及权重
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int xi = points[i][0], yi = points[i][1];
                    int xj = points[j][0], yj = points[j][1];
                    int weight = Math.Abs(xi - xj) + Math.Abs(yi - yj);
                    // 用 points 中的索引表示坐标点
                    graph[i].Add(new int[] { i, j, weight });
                    graph[j].Add(new int[] { j, i, weight });
                }
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