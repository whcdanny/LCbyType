//Leetcode 3372. Maximize the Number of Target Nodes After Connecting Trees I med
//题意：存在两棵具有和节点的无向​​树，它们分别在范围和中具有不同的标签。nm[0, n - 1][0, m - 1]
//给定两个长度分别为edges1和的二维整数数组和，其中表示第一棵树中节点和之间存在边， 表示第二棵树中节点和之间存在边。
//还给定一个整数。edges2n - 1m - 1edges1[i] = [ai, bi] aibiedges2[i] = [ui, vi]        uivik
//如果从到 的路径上的边数小于或等于，则节点u是目标到 节点。请注意，节点始终是其自身的目标。vuvk
//n返回一个整数数组answer，其中，如果必须将第一棵树中的一个节点连接到第二棵树中的另一个节点，answer[i] 则表示第一棵树的目标节点的最大可能节点数。
//请注意，查询彼此独立。也就是说，对于每个查询，您将在继续下一个查询之前删除添加的边。
//思路：构建图+深度优先搜索（DFS）
//构建图：
//分别通过 BuildGraph 方法构建两棵树的邻接表。
//计算第二棵树的最大目标节点数：
//遍历第二棵树的所有节点，调用 DFS，找到路径长度在 k−1 范围内的最大目标节点数。
//计算第一棵树的每个节点的目标节点数：
//对于第一棵树的每个节点 i，计算路径长度在 k 范围内的目标节点数。
//加上第二棵树的最大目标节点数（模拟连接操作）。
//构建邻接表形式的图结构，使用 Dictionary<int, HashSet<int>> 来存储每个节点的邻接关系
//通过深度优先搜索计算从当前节点 cur 出发，路径长度不超过 k 的目标节点数。
//如果步数耗尽或者当前节点为父节点，返回 0。
//遍历当前节点的所有邻居节点。
//对每个邻居节点进行递归，更新目标节点计数。
//时间复杂度:O((V1​+E1​+V2​+E2)
//空间复杂度：O(v1+V2)

        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
        {
            var graph1 = BuildGraph(edges1);
            var raphg2 = BuildGraph(edges2);
            int n = edges1.Length + 1, m = edges2.Length + 1;

            // Get max Count for edge path < k in graph2:
            int maxCnt2 = 0;
            for (int i = 0; i < m; i++)
            {
                maxCnt2 = Math.Max(maxCnt2, DFS(raphg2, i, -1, k - 1));
            }

            int[] res = new int[n];          
            for (int i = 0; i < n; i++)
            {
                res[i] = maxCnt2 + DFS(graph1, i, -1, k);
            }

            return res;
        }
        private Dictionary<int, HashSet<int>> BuildGraph(int[][] edges)
        {
            Dictionary<int, HashSet<int>> g = new Dictionary<int, HashSet<int>>();
            foreach (int[] e in edges)
            {
                int u = e[0], v = e[1];
                if (!g.ContainsKey(u))
                    g.Add(u, new HashSet<int>());

                if (!g.ContainsKey(v))
                    g.Add(v, new HashSet<int>());

                g[u].Add(v);
                g[v].Add(u);
            }

            return g;
        }
        private int DFS(Dictionary<int, HashSet<int>> graph, int cur, int parent, int steps, int count = 1)
        {           
            if (steps < 0 || cur == parent)
                return 0;

            foreach (int next in graph[cur])
            {
                count += ((next == parent) ? 0 : DFS(graph, next, cur, steps - 1));                
            }

            return count;
        }