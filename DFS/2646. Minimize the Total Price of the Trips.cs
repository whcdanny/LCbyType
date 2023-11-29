//Leetcode 2646. Minimize the Total Price of the Trips hard
//题意：题目描述了一个无向、无根的树，其中有 n 个节点，编号从 0 到 n - 1。给定整数 n 和长度为 n - 1 的二维整数数组 edges，其中 edges[i] = [ai, bi] 表示树中节点 ai 和 bi 之间存在一条边。
//每个节点都有一个相关联的价格。给定整数数组 price，其中 price[i] 表示第 i 个节点的价格。
//给定二维整数数组 trips，其中 trips[i] = [starti, endi] 表示从节点 starti 开始，通过任意路径移动到节点 endi。
//在执行第一次旅行之前，你可以选择一些非相邻的节点，并将其价格减半。    
//问题要求返回执行所有给定旅行所需的最小总价格和。
//思路：深度优先搜索（DFS）来解决此问题。首先算出每个节点走过的次数，然后深度到每一个点，然后考虑两种情况：选择减半或不选择减半。递归地计算最小总价格和。
//注:这里注意，如果你上一个是减半，那么相连接的不能减半，也就是加入子集的全额。
//时间复杂度: O(n * t)，其中 n 是树的节点数，t 是旅行次数
//空间复杂度：O(n * t)，其中 n 是树的节点数，t 是旅行次数
        public int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips)
        {
            List<List<int>> graph = new List<List<int>>(n);            
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int[] nodesVisitedCount = new int[n];
            HashSet<int> tempPath = new HashSet<int>();
            
            foreach (var trip in trips)
                ComputeNodesVisitedCount(trip[0], trip[1], tempPath, nodesVisitedCount, graph);            

            var minPrices = ComputeMinPrices(-1, 0, graph, price, nodesVisitedCount);
            return Math.Min(minPrices[0], minPrices[1]);
        }
        public void ComputeNodesVisitedCount(int start, int end, HashSet<int> tempPath, int[] nodesVisitedCount, List<List<int>> graph)
        {
            tempPath.Add(start);
            if (start == end)
                foreach (var node in tempPath)
                    nodesVisitedCount[node]++;
            else
                foreach (var node in graph[start])
                {
                    if (tempPath.Contains(node))
                        continue;

                    ComputeNodesVisitedCount(node, end, tempPath, nodesVisitedCount, graph);
                }
            tempPath.Remove(start);
        }
        public int[] ComputeMinPrices(int parentNode, int node, List<List<int>> graph, int[] price, int[] nodesVisitedCount)
        {
            int whole = 0, halved = 0;
            foreach (var nodeToVisit in graph[node])
            {
                if (nodeToVisit == parentNode) continue;
                var childPrices = ComputeMinPrices(node, nodeToVisit, graph, price, nodesVisitedCount);
                //这里如果减半，子集就要全额。
                halved += childPrices[1];
                //整体就不用考虑选取减半还是全额，只选最小值；
                whole += Math.Min(childPrices[0], childPrices[1]);
            }
            return new[] {
                (price[node] / 2) * nodesVisitedCount[node]  + halved,
                price[node] * nodesVisitedCount[node] + whole
                };
        }