//Leetcode 2538. Difference Between Maximum and Minimum Price Sum hard
//题意：给定一个初始未定根的无向树，有 n 个节点，节点编号从 0 到 n - 1。给定一个整数 n 和一个长度为 n - 1 的二维整数数组 edges，其中 edges[i] = [ai, bi] 表示树中节点 ai 和 bi 之间存在一条边。
//每个节点都有一个关联的价格。给定一个整数数组 price，其中 price[i] 表示第 i 个节点的价格。给定一条路径，路径的价格和是路径上所有节点的价格之和。
//树可以在你选择的任何节点 root 处成为有根树。在选择 root 后，根据选择的根节点，所有从根节点开始的路径的价格和的最大值和最小值之差即为所产生的花费。
//返回在所有可能的根选择中，产生的最大花费。   
//思路：DBS，的过程中，记录路径价格和的最大值和最小值。利用memory存入已经算过的node。
//时间复杂度: O(n^2)，其中 n 是节点的数量
//空间复杂度：O(n)
        public long MaxOutput(int n, int[][] edges, int[] price)//用了memory也超时了
        {
            List<List<int>> graph = new List<List<int>>(n);
            int res = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var memo = new Dictionary<int, Dictionary<int, int>>();
            // 遍历所有可能的根节点
            for (int i = 0; i < n; i++)
            {
                res = Math.Max(res, (DFS_MaxOutput(i, -1, price, graph, memo)-price[i]));
            }

            return res;
        }

        // 深度优先搜索
        public int DFS_MaxOutput(int node, int parent, int[] price, List<List<int>> graph, Dictionary<int, Dictionary<int, int>> memo)
        {
            int currentCost = price[node];
            int maxSubtreeCost = 0;

            if (!memo.ContainsKey(parent))
                memo.Add(parent, new Dictionary<int, int>());
            //already traversed from
            if (memo[parent].ContainsKey(node))
                return memo[parent][node];
            else
            {
                foreach (var neighbor in graph[node])
                {
                    if (neighbor == parent)
                    {
                        continue; // 避免重复访问父节点
                    }

                    int subtreeCost = DFS_MaxOutput(neighbor, node, price, graph, memo);
                    maxSubtreeCost = Math.Max(maxSubtreeCost, subtreeCost);
                }
                currentCost += maxSubtreeCost;
                memo[parent].Add(node, currentCost);
                return currentCost;
            }                       
        }