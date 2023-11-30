//Leetcode 2492. Minimum Score of a Path Between Two Cities med
//题意：题目描述了一个城市网络，其中有两座城市分别标记为城市 1 和城市 2。城市之间存在多条双向道路，每条道路都有一个分数值。目标是找到从城市 1 到城市 2 的路径，使得路径上的最低分数值最大。        
//思路： DFS 深入到图表中，检查从当前节点到其连接节点的路径是否小于先前的最小值。继续直到所有节点都被访问过
//时间复杂度: O(n) 因为我们需要访问所有节点
//空间复杂度：构建图邻接列表的最坏情况为 O(n^2)。
        public int MinScore(int n, int[][] roads)
        {
            Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();
            for(int i = 1; i <=n; i++)
            {
                graph[i] = new List<(int, int)>();
            }
            foreach (var road in roads)
            {
                int city1 = road[0], city2 = road[1], distance = road[2];                
                graph[city1].Add((city2, distance));
                graph[city2].Add((city1, distance));
            }
            int minDistance = int.MaxValue;
            HashSet<int> visited = new HashSet<int>();
            DFS_MinScore(graph, 1, ref minDistance, visited);

            return minDistance;
        }

        private void DFS_MinScore(Dictionary<int, List<(int, int)>> graph, int currentCity, ref int minDistance, HashSet<int> visited)
        {
            if (visited.Contains(currentCity))
                return;

            visited.Add(currentCity);
            if (graph.ContainsKey(currentCity))
            {
                foreach (var road in graph[currentCity])
                {
                    int nextCity = road.Item1;
                    int distance = road.Item2;
                    minDistance = Math.Min(minDistance, distance);
                    DFS_MinScore(graph, nextCity, ref minDistance, visited);
                }
            }
        }        