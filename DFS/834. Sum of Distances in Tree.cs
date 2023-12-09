//Leetcode 834. Sum of Distances in Tree hard
//题意：给定一个有 n 个节点（节点编号从 0 到 n-1）的无向连通树和一个边缘列表 edges，其中 edges[i] = [ai, bi] 表示树中连接节点 ai 和节点 bi 的边。
//返回一个表示所有节点（从 0 到 n-1）的距离之和的数组。数组中的第 i 个元素（下标从 0 开始）表示节点 i 到其他所有节点的距离之和。
//n = 6, edges = [[0,1],[0,2],[2,3],[2,4],[2,5]]
//Output: [8,12,6,10,10,10] We can see that dist(0,1) + dist(0,2) + dist(0,3) + dist(0,4) + dist(0,5)equals 1 + 1 + 2 + 2 + 2 = 8.Hence, answer[0] = 8, and so on.
//思路：DFS, DFS1:算到root的distancesum是正确的；DFS2: 用root的distancesum来算出其他子节点的正确答案；
//注：DFS1,DFS2里面的注释如何去算distanceSum 这个跟重要
//时间复杂度: O(N)，其中 N 为节点的数量。
//空间复杂度：O(N)
        public int[] SumOfDistancesInTree(int n, int[][] edges)
        {
            int[] nodeCount = new int[n];
            int[] distanceSum = new int[n];
            List<HashSet<int>> tree = new List<HashSet<int>>();

            for (int i = 0; i < n; i++)
            {
                tree.Add(new HashSet<int>());
            }

            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]);
                tree[edge[1]].Add(edge[0]);
            }
            //算到root的distancesum是正确的；
            DFS1_SumOfDistancesInTree(0, -1, tree, nodeCount, distanceSum);
            //用root的distancesum来算出其他子节点的正确答案；
            DFS2_SumOfDistancesInTree(0, -1, tree, nodeCount, distanceSum);

            return distanceSum;
        }

        private void DFS1_SumOfDistancesInTree(int node, int parent, List<HashSet<int>> tree, int[] nodeCount, int[] distanceSum)
        {
            nodeCount[node] = 1;

            foreach (var neighbor in tree[node])
            {
                if (neighbor != parent)
                {
                    DFS1_SumOfDistancesInTree(neighbor, node, tree, nodeCount, distanceSum);
                    //计算每个节点子树中的节点数量
                    nodeCount[node] += nodeCount[neighbor];
                    //当前距离根据子距离+子数的节点数量；
                    //加子树的节点数量是因为相当于我到每个子节点的节点的距离，经过neighbor；
                    distanceSum[node] += distanceSum[neighbor] + nodeCount[neighbor];
                }
            }
        }

        private void DFS2_SumOfDistancesInTree(int node, int parent, List<HashSet<int>> tree, int[] nodeCount, int[] distanceSum)
        {
            foreach (var neighbor in tree[node])
            {
                if (neighbor != parent)
                {
                    //这里先用distanceSum[node] - nodeCount[neighbor]：表示distanceSum[node]中去掉节点neighbor的子树节点数量，即剩余的是节点node到其他邻居节点的距离之和
                    //(nodeCount.Length - nodeCount[neighbor])就表示整个节点的数量减去节点 neighbor 的子节点数量，然后因为前一步是父节点跟其他节点的距离，这样只要+上neighbor跟其他节点的距离（1）。
                    distanceSum[neighbor] = distanceSum[node] - nodeCount[neighbor] + (nodeCount.Length - nodeCount[neighbor]);
                    DFS2_SumOfDistancesInTree(neighbor, node, tree, nodeCount, distanceSum);
                }
            }
        }