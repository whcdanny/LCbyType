//Leetcode 2368. Reachable Nodes With Restrictions med
//题意：有一个无向树，其n节点标记为从0到n - 1和n - 1边。 给您一个edges长度为 2D 的整数数组n - 1，其中表示节点之间和树中存在一条边。您还将获得一个表示受限节点的整数数组。edges[i] = [ai, bi] aibirestricted返回在不访问受限节点的情况下从节点可以到达的最大节点数。0请注意，该节点0不会是受限制的节点。
//思路：DFS, 先建立graph，这里注意只要在删除的node，就不要创建了，这样最后得到只有保存下来的graph，然后从0开始访问，最后输出访问到的数量；
//注：这里用HashSet<int> restrictedSet 来代替 int[] restricted 来减少运算；
//时间复杂度: 遍历构建图：O(E)，其中 E 为边的数量。DFS 遍历：O(V + E)，其中 V 为节点的数量，E 为边的数量。每个节点和边都会被访问一次。因此，总体时间复杂度为 O(E + V + E) = O(V + E)。
//空间复杂度：图的存储：O(E)，需要存储边的信息。递归调用栈：O(V)，最坏情况下，递归调用栈的深度为节点数量。因此，总体空间复杂度为 O(E + V)。
        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            HashSet<int> restrictedSet = new HashSet<int>(restricted);
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (restrictedSet.Contains(i))
                {
                    continue;
                }

                graph.Add(i, new List<int>());
            }
            foreach (var edge in edges)
            {                
                if (restrictedSet.Contains(edge[0]) || restrictedSet.Contains(edge[1]))
                    continue;
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            visited.Add(0);
            DFS_ReachableNodes(graph, visited, 0);
            return visited.Count;
        }

        private void DFS_ReachableNodes(Dictionary<int, List<int>> graph, HashSet<int> visited, int node)
        {
            foreach(var neg in graph[node])
            {
                if (!visited.Contains(neg))
                {
                    visited.Add(neg);
                    DFS_ReachableNodes(graph, visited, neg);
                }
            }            
        }