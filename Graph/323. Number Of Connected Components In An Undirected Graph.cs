//323. Number Of Connected Components In An Undirected Graph med
//给一个n个节点的图，和 edges表示ai和bi之间有一条边，求这幅图的连通分量个数
//思路：利用union find，里面使用find，union，conneted串联，		
        public int CountComponents(int n, int[][] edges)
        {
            UF uf = new UF(n);
            // 将每个节点进行连通
            foreach (int[] e in edges)
            {
                uf.union(e[0], e[1]);
            }
            // 返回连通分量的个数
            return uf.count();
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