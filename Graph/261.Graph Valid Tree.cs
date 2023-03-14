//261.Graph Valid Tree med
//从0到n - 1的n个结点，和一个无向边列表edges（每条边用节点二元组表示），请你判断输入的这些边组成的结构是否是一棵树
//思路： Kruskal 算法： 每当添加一个边的时候，先看看这个边的两个点的parent是否一样，不一样就可以建立graph，如果一样那就说明有循环；
//从0到n - 1的n个结点，和一个无向边列表edges（每条边用节点二元组表示），请你判断输入的这些边组成的结构是否是一棵树
		public bool ValidTree(int n, int[][] edges)
        {
            // 初始化 0...n-1 共 n 个节点
            UF uf = new UF(n);
            // 遍历所有边，将组成边的两个节点进行连接
            foreach (int[] edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                // 若两个节点已经在同一连通分量中，会产生环
                if (uf.connected(u, v))
                {
                    return false;
                }
                // 这条边不会产生环，可以是树的一部分
                uf.union(u, v);
            }
            // 要保证最后只形成了一棵树，即只有一个连通分量
            return uf.count() == 1;
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