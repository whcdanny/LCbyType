//Leetcode 2867. Count Valid Paths in a Tree  hard
//题意：给定一个包含 n 个节点的无向树，节点编号从 1 到 n。同时给定一个二维整数数组 edges，表示树中的边，其中 edges[i] = [ui, vi] 表示节点 ui 和 vi 之间有一条边。任务是计算树中有多少条路径，其中路径上恰好包含一个素数。        
//思路：素数数组构建： 在 isPrimeArray 中，通过埃拉托斯特尼筛法，标记出每个节点对应的值是否为素数。
//图的构建： 使用 graph 表示树的邻接表，其中 graph[i] 存储与节点 i 相邻的节点列表。
//DFS 遍历： 通过 dfs 函数进行深度优先搜索，递归地遍历树的每个节点。在递归过程中，计算每个节点的子树中满足条件的路径数量。
//路径计算： 在 dfs 中，根据当前节点是否为素数，以及子节点的计算结果，计算当前节点的满足条件的路径数量。
//返回结果： total_CountPaths 记录所有满足条件的路径数量，最终返回总数。
//时间复杂度:  构建素数数组：O(n * log(log(n)))，埃拉托斯特尼筛法的时间复杂度。构建图：O(n)，遍历所有边。DFS 遍历：O(n)，遍历所有节点。综合起来，总体时间复杂度为 O(n* log(log(n)))。
//空间复杂度： isPrimeArray 数组：O(n)。graph 邻接表：O(n)。递归调用栈：O(n)。综合起来，总体空间复杂度为 O(n)。
        long total_CountPaths = 0l;
        public long CountPaths(int n, int[][] edges)
        {
            bool[] isPrimeArray = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrimeArray[i] = true;
            }
            for (int i = 2; i <= n; i++)
            {
                if (isPrimeArray[i])
                {
                    for (long j = (long)i * i; j <= n; j += i)
                    {
                        isPrimeArray[(int)(j % int.MaxValue)] = false;
                    }
                }
            }
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i <= n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            dfs_CountPaths(graph, isPrimeArray, 1, -1);
            return total_CountPaths;
        }
        /*
         * 如果当前节点是素数 (isPrime == true)：
            cur 初始化为 0，表示当前节点的路径数量。
            对于每个子节点，通过计算 (res[0] - subRes[0]) * subRes[0] 来得到满足条件的路径数量。这里 (res[0] - subRes[0]) 表示当前节点去掉子节点的路径数量，乘以 subRes[0] 表示连接到子节点的路径数量。
            cur 加上所有子节点计算得到的路径数量。
            total_CountPaths 加上 cur / 2，因为路径是双向的，除以 2 表示考虑双向性。
            total_CountPaths 加上当前节点的路径数量 res[0]。
            res[1] 被设置为 res[0] + 1，表示当前节点的路径数量只有 1 条，因为当前节点是素数，所以只能作为路径的终点。
            res[0] 被置为 0，因为当前节点是素数，路径数量在之前已经加到 total_CountPaths 中。
          如果当前节点不是素数 (isPrime == false)：
            对于每个子节点，通过计算 (res[0] - subRes[0]) * subRes[1] 来得到满足条件的路径数量。这里 (res[0] - subRes[0]) 表示当前节点去掉子节点的路径数量，乘以 subRes[1] 表示连接到子节点的路径数量。因为当前节点不是素数，所以不需要考虑路径的双向性。
            将所有子节点计算得到的路径数量加到 total_CountPaths 中。
            res[0] 被增加 1，表示当前节点不是素数，路径数量在之前已经加到 total_CountPaths 中。
            total_CountPaths 加上当前节点的路径数量 res[1]。
         */
        public int[] dfs_CountPaths(Dictionary<int, List<int>> nexts, bool[] isPrimeArray, int index, int pre)
        {            
            List<int> next = nexts[index];
            int size = next.Count;            
            int[] res = new int[2];
            bool isPrime = isPrimeArray[index];
            List<int[]> subResList = new List<int[]>();
            foreach (int node in next)
            {
                if (node != pre)
                {
                    int[] subRes = dfs_CountPaths(nexts, isPrimeArray, node, index);
                    subResList.Add(subRes);
                    res[0] += subRes[0];
                    res[1] += subRes[1];
                }
            }
            if (isPrime)
            {
                long cur = 0l;
                foreach (var subRes in subResList)
                {
                    cur += (long)(res[0] - subRes[0]) * subRes[0];
                }
                total_CountPaths += cur / 2;
                total_CountPaths += res[0];
                res[1] = res[0] + 1;
                res[0] = 0;
            }
            else
            {
                foreach (var subRes in subResList)
                {
                    total_CountPaths += (long)(res[0] - subRes[0]) * subRes[1];
                }
                res[0] = res[0] + 1;
                total_CountPaths += res[1];
            }            
            return res;
        }