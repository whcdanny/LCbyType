//Leetcode 1971. Find if Path Exists in Graph ez
//题意：给定一个无向图，图中有n个节点，编号从0到n-1。你被给定一个二维整数数组edges，其中edges[i] = [ai, bi]表示图中有一条连接节点ai和节点bi的边。你还被给定两个节点start和target，请判断从节点start是否存在一条路径到达节点target。如果存在，返回true；否则，返回false。
//思路：使用BFS（广度优先搜索），创建一个空的集合visited，用于存储已访问过的节点。初始化一个队列，将起始节点start加入队列，并将start标记为已访问。在循环中，从队列中取出一个节点，遍历与该节点相邻的所有未访问过的节点，将其加入队列并标记为已访问。如果在这个过程中找到了目标节点target，返回true，否则继续循环。
//时间复杂度: O(N + E)
//空间复杂度：O(N)
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge[0]))
                {
                    graph[edge[0]] = new List<int>();
                }
                if (!graph.ContainsKey(edge[1]))
                {
                    graph[edge[1]] = new List<int>();
                }

                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                if (graph.ContainsKey(node))
                {
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }
            }

            return false;
        }