//Leetcode 2858. Minimum Edge Reversals So Every Node Is Reachable  hard
//题意：给定一个有向图，我们希望确定从每个节点开始，通过反转若干边，使得每个其他节点都可以从该节点到达所需的最小反转次数。        
//思路：使用深度优先搜索（DFS）来从每个节点开始探索图。创建一个图，把原路和反转路用truefalse来表示；对于每个 DFS 遍历，计算需要反转的边的数量，以便使得每个其他节点都可以到达。对图中的所有节点重复此过程。 
//时间复杂度:  时间复杂度为 O(N + E)，其中 N 为节点数，E 为图中的边数。DFS 遍历每个节点和每条边一次。
//空间复杂度： 时间复杂度为 O(N + E)，其中 N 为节点数，E 为图中的边数。DFS 遍历每个节点和每条边一次。
        public int[] MinEdgeReversals(int n, int[][] edges)//超时
        {
            Dictionary<int, List<(int, bool)>> graph = new Dictionary<int, List<(int, bool)>>();
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<(int, bool)>();
            }
            // Build the directed graph
            foreach (var edge in edges)
            {
                int from = edge[0];
                int to = edge[1];

                // 添加从 'from' 到 'to' 的有向边，并将 needToReverse 标志设置为 true
                graph[from].Add((to, true));
                // 添加从 'to' 到 'from' 的有向边，并将 needToReverse 标志设置为 false
                graph[to].Add((from, false));
            }

            int[] result = new int[n];

            // Perform DFS for each node
            for (int i = 0; i < n; i++)
            {
                HashSet<int> visited = new HashSet<int>();
                result[i] = DFS_MinEdgeReversals(graph, i, visited);
            }

            return result;
        }

        private int DFS_MinEdgeReversals(Dictionary<int, List<(int, bool)>> graph, int node, HashSet<int> visited)
        {
            int reversals = 0;

            visited.Add(node);

            foreach (var neighbor in graph[node])
            {
                int nextNode = neighbor.Item1;
                bool needToReverse = neighbor.Item2;

                if (!visited.Contains(nextNode))
                {
                    // 如果需要反转边，则增加反转次数
                    reversals += needToReverse ? 0 : 1;
                    // Continue DFS on the next node
                    reversals += DFS_MinEdgeReversals(graph, nextNode, visited);
                }
            }

            return reversals;
        }
        //使用深度优先搜索（DFS）来从每个节点开始探索图。创建一个图，把原路和反转路存入，并且创建一个只保留原路。先算一个0开始的，然后后面的可以根据相连的点，减去原路的，递归。
        public int[] MinEdgeReversals1(int n, int[][] edges)
        {
            int[] answer = new int[n];
            HashSet<(int, int)> original = new HashSet<(int, int)>();
            Dictionary<int, List<int>> g_MinEdgeReversals1 = new Dictionary<int, List<int>>();

            foreach (var edge in edges)
            {
                original.Add((edge[0], edge[1]));
                if (!g_MinEdgeReversals1.ContainsKey(edge[0])) g_MinEdgeReversals1.Add(edge[0], new List<int>());
                if (!g_MinEdgeReversals1.ContainsKey(edge[1])) g_MinEdgeReversals1.Add(edge[1], new List<int>());
                g_MinEdgeReversals1[edge[0]].Add(edge[1]);
                g_MinEdgeReversals1[edge[1]].Add(edge[0]);
            }

            answer[0] = DFS_MinEdgeReversals1(0, -1, g_MinEdgeReversals1, original);
            foreach (var next in g_MinEdgeReversals1[0])
            {
                Reroot_MinEdgeReversals1(next, 0, original, answer, g_MinEdgeReversals1);
            }
            return answer;
        }
        private int DFS_MinEdgeReversals1(int curr, int p, Dictionary<int, List<int>> g_MinEdgeReversals1, HashSet<(int, int)> original)
        {
            int ans = 0;
            foreach (var next in g_MinEdgeReversals1[curr])
            {
                if (next == p) continue;
                // Add 1 if we going against the original direction
                ans += DFS_MinEdgeReversals1(next, curr, g_MinEdgeReversals1, original) + (original.Contains((curr, next)) ? 0 : 1);
            }
            return ans;
        }

        private void Reroot_MinEdgeReversals1(int curr, int parent, HashSet<(int, int)> original, int[] answer, Dictionary<int, List<int>> g_MinEdgeReversals1)
        {
            // Adjust for the direction of edge between curr and parent.
            answer[curr] = answer[parent] + (original.Contains((curr, parent)) ? -1 : 1);
            foreach (var next in g_MinEdgeReversals1[curr])
            {
                if (next == parent) continue;
                Reroot_MinEdgeReversals1(next, curr, original, answer, g_MinEdgeReversals1);
            }
        }