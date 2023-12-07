//Leetcode 1192. Critical Connections in a Network hard
//题意：在一个网络中找到所有的“关键连接”。这里有 n 个服务器，编号从 0 到 n - 1，通过无向的服务器到服务器的连接形成一个网络，其中 connections[i] = [ai, bi] 表示服务器 ai 和 bi 之间的连接。任何服务器都可以直接或间接地通过网络到达其他服务器。
//“关键连接”是指如果删除了这个连接，就会使得某些服务器无法到达其他服务器。
//要求返回网络中的所有关键连接，顺序不限。
//思路：首先构建图 graph 表示服务器之间的连接。然后使用深度优先搜索（DFS）来找出关键连接。在DFS中，对每个节点进行标记，记录其发现时间和最早祖先的发现时间，并在搜索过程中找到关键连接。
//注：如果某个节点的邻居的最早祖先的发现时间大于当前节点的发现时间，那么这个连接就是关键连接。
//时间复杂度: O(V + E)，其中 V 是服务器的数量，E 是连接的数量
//空间复杂度：O(V)
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            foreach (var connection in connections)
            {
                int a = connection[0];
                int b = connection[1];
                graph[a].Add(b);
                graph[b].Add(a);
            }

            int[] discoveryTime = new int[n];
            int[] earliestAncestor = new int[n];
            bool[] visited = new bool[n];
            List<IList<int>> result = new List<IList<int>>();

            DFS_CriticalConnections(0, -1, 0, graph, discoveryTime, earliestAncestor, visited, result);

            return result;
        }

        private void DFS_CriticalConnections(int current, int parent, int time, List<List<int>> graph, int[] discoveryTime, int[] earliestAncestor, bool[] visited, List<IList<int>> result)
        {
            visited[current] = true;
            discoveryTime[current] = time;
            earliestAncestor[current] = time;

            foreach (var neighbor in graph[current])
            {
                if (neighbor == parent)
                {
                    continue;
                }

                if (!visited[neighbor])
                {
                    DFS_CriticalConnections(neighbor, current, time + 1, graph, discoveryTime, earliestAncestor, visited, result);
                    earliestAncestor[current] = Math.Min(earliestAncestor[current], earliestAncestor[neighbor]);

                    if (earliestAncestor[neighbor] > discoveryTime[current])
                    {
                        result.Add(new List<int> { current, neighbor });
                    }
                }
                else
                {
                    earliestAncestor[current] = Math.Min(earliestAncestor[current], discoveryTime[neighbor]);
                }
            }
        }