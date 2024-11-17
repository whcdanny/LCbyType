//Leetcode 3108. Minimum Cost Walk in Weighted Graph hard
//题目：我们需要在一个无向加权图上解决一个路径问题。在这里：
//路径的代价是路径上所有边权重的按位与（bitwise AND）。
//任务：对于每个查询，找出从起点 si 到终点 ti 的路径的最小代价。如果不存在这样的路径，返回 -1。
//注意：由于“按位与”操作，路径代价会随着边权的增加而减少。
//思路: Union-Find 
//arr对每个节点找出其父节点
//brr储存连通分量的按位与值
//如果两个节点属于同一个连通分量，则返回对应的按位与值
//时间复杂度：O(E+Q)
//空间复杂度：O(N)
        public int[] MinimumCost(int n, int[][] edges, int[][] query)
        {
            int[] arr = new int[n];// 并查集的父节点数组
            int[] brr = new int[n];// 存储每个连通分量的按位与值
            Array.Fill(brr, -1);
            //初始时，每个节点都是自己的父节点（代表各自的独立集合）
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                UnionMinimumCost(edges[i][0], edges[i][1], arr);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int p = FindMinimumCost(edges[i][0], arr);// 找到连通分量的根
                if (brr[p] == -1)
                {
                    brr[p] = edges[i][2]; // 初始化按位与值
                }
                else
                {
                    brr[p] &= edges[i][2];// 按位与更新
                }
            }

            int[] result = new int[query.Length];
            for (int i = 0; i < query.Length; i++)
            {
                int x = FindMinimumCost(query[i][0], arr);
                int y = FindMinimumCost(query[i][1], arr);
                //如果两个节点属于同一个连通分量，则返回对应的按位与值
                result[i] = (query[i][0] == query[i][1] || x != y) ? (query[i][0] == query[i][1] ? 0 : -1) : brr[x];
            }

            return result;
        }
        //合并两个集合，将一个集合的根节点指向另一个集合的根节点
        private void UnionMinimumCost(int a, int b, int[] arr)
        {
            int rootA = FindMinimumCost(a, arr);
            int rootB = FindMinimumCost(b, arr);
            if (rootA != rootB)
            {
                arr[rootA] = rootB;
            }
        }
        //路径压缩优化，快速找到集合的根节点
        private int FindMinimumCost(int ch, int[] arr)
        {
            return (arr[ch] == ch) ? ch : (arr[ch] = FindMinimumCost(arr[ch], arr));
        }