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