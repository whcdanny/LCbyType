//Leetcode 2858. Minimum Edge Reversals So Every Node Is Reachable hard
//题意：给定一个有向图，其中节点从0到n-1标记。如果将它的边变为双向的，这个图将形成一个树。你会得到一个整数n和一个二维整数数组edges，其中edges[i] = [ui, vi] 表示一个从节点ui到节点vi的有向边。对于范围在[0, n - 1] 内的每个节点i，你的任务是独立地计算需要多少最小的边反转才能从节点i开始通过一系列有向边到达任何其他节点。返回一个整数数组answer，其中answer[i] 表示从节点i开始通过一系列有向边到达任何其他节点所需的最小反转次数。
//思路：BFS   构建有向图和反向图。对于每个节点i，分别计算从i出发的最短路径树，以及从i出发的反向最短路径树。遍历所有节点j，统计从节点j到其他节点的最短路径需要反转的边数。最终得到答案
//时间复杂度: n个节点和m条边，构建有向图和反向图的时间复杂度为O(m)，计算最短路径树的时间复杂度为O(nm)（使用BFS算法）。因此总的时间复杂度为O(nm)。
//空间复杂度：O(n+m)
        public int[] MinEdgeReversals(int n, int[][] edges)//超时
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> reversGraph = new Dictionary<int, List<int>>();
            HashSet<(int, int)> original = new HashSet<(int, int)>();
            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);

                if (!reversGraph.ContainsKey(v))
                    reversGraph[v] = new List<int>();
                reversGraph[v].Add(u);
            }
            int[] res = new int[n];
            Array.Fill(res, int.MaxValue);

            for(int i = 0; i < n; i++)
            {
                HashSet<int> visited = new HashSet<int>();
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                visited.Add(i);
                int revers = 0;
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (graph.ContainsKey(node))
                    {
                        foreach(var neighbor in graph[node])
                        {
                            if (!visited.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                                visited.Add(neighbor);
                            }
                        }
                    }
                    if (reversGraph.ContainsKey(node))
                    {
                        foreach(var neighbor in reversGraph[node])
                        {
                            if (!visited.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                                visited.Add(neighbor);
                                revers++;
                            }
                        }
                    }
                }
                res[i] = revers;
            }
            return res;
        }

        public int[] MinEdgeReversals1(int n, int[][] edges)//超时
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();            
            HashSet<(int, int)> original = new HashSet<(int, int)>();
            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                original.Add((u, v));
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int>();
                graph[v].Add(u);
            }
            int[] res = new int[n];
            Array.Fill(res, int.MaxValue);

            for (int i = 0; i < n; i++)
            {
                HashSet<int> visited = new HashSet<int>();
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                visited.Add(i);
                int revers = 0;
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (graph.ContainsKey(node))
                    {
                        foreach (var neighbor in graph[node])
                        {
                            if (!visited.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                                visited.Add(neighbor);
                                if (!original.Contains((node, neighbor)))
                                    revers++;
                            }
                        }
                    }                    
                }
                res[i] = revers;
            }
            return res;
        }