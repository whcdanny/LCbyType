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