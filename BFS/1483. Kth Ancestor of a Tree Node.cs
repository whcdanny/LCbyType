//Leetcode 1483. Kth Ancestor of a Tree Node hard
//题意：给定一个由数组 parent 表示的树，其中 parent[i] 是第 i 个节点的父节点，任务是实现 KthAncestor 类，该类具有以下方法：
//KthAncestor(int[] parent) 用 parent 数组初始化数据结构。
//int GetKthAncestor(int node, int k) 返回给定 node 的第 k 个祖先。如果不存在这样的祖先，则返回 -1。
//思路： BFS 进行遍历，图的表示:使用邻接表表示树，其中 parent[i] 是节点 i 的父节点。使用 BFS 进行预处理:对于每个节点，使用 BFS 遍历到根节点，并记录每个节点的祖先。查询祖先:对于每个查询 GetKthAncestor(node, k)，直接查找存储的祖先数组。
//时间复杂度: 预处理时间复杂度: O(N^2)，其中 N 是树中的节点数。查询时间复杂度: O(1)。
//空间复杂度： O(N^2)，考虑到存储所有祖先的空间。
        public class TreeAncestor//超时
        {
            private Dictionary<int, int> ancestors;
            public TreeAncestor(int n, int[] parent)
            {
                ancestors = new Dictionary<int, int>();
                ancestors.Add(0, -1);
                for (int i = 1; i < n; i++)
                {
                    int p = parent[i];                    
                    ancestors.Add(i,p);
                }
            }

            public int GetKthAncestor(int node, int k)
            {                
                int result = -1;
                if (ancestors.ContainsKey(node))
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (ancestors.ContainsKey(node))
                        {
                            result = ancestors[node];
                            node = result;
                        }                            
                    }
                }
                

                return result;
            }
        }        
        //思路：图的表示:使用邻接表表示树，其中 parent[i] 是节点 i 的父节点。 这个题利用了log2这个 然后缩短了时间
        //使用二进制抬升进行预处理:预处理每个节点的祖先，最多到 log(n) 级，使用二进制抬升。对于每个节点，计算它在树的深度为 2^0、2^1、2^2、...、2^j 级的祖先，其中 j 是小于等于树深度的最大的 2 的幂。
        //查询祖先:对于每个查询 GetKthAncestor(node, k)，将 k 减小到其二进制表示。遍历 k 的二进制表示，在每个设置的位上跳转到祖先。
        //预处理时间复杂度: O(N* log(N))，其中 N 是树中的节点数。
        //查询时间复杂度: O(log(K))，其中 K 是传递给 GetKthAncestor 的值。
        //空间复杂度: O(N* log(N))，考虑到祖先数组所需的空间。
        public class TreeAncestor1
        {
            private int[][] ancestors;
            public TreeAncestor1(int n, int[] parent)
            {

                int maxLog = (int)Math.Log2(n) + 1;
                ancestors = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    ancestors[i] = new int[maxLog];
                }

                // 使用二进制抬升进行预处理
                for (int j = 0; j < maxLog; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (j == 0)
                        {
                            ancestors[i][j] = parent[i];
                        }
                        else
                        {
                            int parentAt2PowerJMinus1 = ancestors[i][j - 1];
                            ancestors[i][j] = parentAt2PowerJMinus1 == -1 ? -1 : ancestors[parentAt2PowerJMinus1][j - 1];
                        }
                    }
                }
            }

            public int GetKthAncestor(int node, int k)
            {
                while (k > 0 && node != -1)
                {
                    int maxBit = (int)Math.Log2(k);  // 找到小于或等于 k 的最大的 2 的幂
                    node = ancestors[node][maxBit];  // 跳转到 2^maxBit 级的祖先
                    k -= (1 << maxBit);  // 从 k 中减去 2^maxBit
                }

                return node;
            }
        }

        /**
         * Your TreeAncestor object will be instantiated and called as such:
         * TreeAncestor obj = new TreeAncestor(n, parent);
         * int param_1 = obj.GetKthAncestor(node,k);
         */