//990. Satisfiability of Equality Equations med
//给一个equations里面包含两种公式"xi==yi" or "xi!=yi" x和y可以时任意26个字母，来判法所给的一系列equations是否满足条件；
//思路：用到Union和find，先找==相当于先连接上，然后根据！=来判断是否满足条件；
		public bool EquationsPossible(string[] equations)
        {
            // 26 个英文字母
            UF uf = new UF(26);
            // 先让相等的字母形成连通分量
            foreach (string eq in equations)
            {
                char[] eqchars = eq.ToCharArray();
                if (eqchars[1] == '=')
                {
                    char x = eqchars[0];
                    char y = eqchars[3];
                    uf.union(x - 'a', y - 'a');
                }
            }
            // 检查不等关系是否打破相等关系的连通性
            foreach (string eq in equations)
            {
                char[] eqchars = eq.ToCharArray();
                if (eqchars[1] == '!')
                {
                    char x = eqchars[0];
                    char y = eqchars[3];
                    // 如果相等关系成立，就是逻辑冲突
                    if (uf.connected(x - 'a', y - 'a'))
                        return false;
                }
            }
            return true;
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