//Leetcode 2477. Minimum Fuel Cost to Report to the Capital med
//题意：每个城市都有一辆车，车上有固定数量的座位，代表可以在他们所在的城市使用车辆前往首都开会，也可以在途中更换车辆。你需要返回使得总燃料消耗最小的策略。
//思路：我们可以使用BFS（广度优先搜索）,首先，我们可以构建一个图，表示城市之间的连接关系。找到最边缘的城市为出发城市，然后往0城市前进，遍历它的相邻城市，根据当前的消耗值除以seats便得出现有的消耗，然后更新最边缘的城市，然后添加到queue中；
//时间复杂度: BFS 的时间复杂度为 O(V+E)，其中 V 是城市数，E 是道路数。
//空间复杂度：O(n)
        public long MinimumFuelCost(int[][] roads, int seats)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int n = roads.Length + 1;
            int[] degree = new int[n];
            foreach (var road in roads)
            {
                int u = road[0], v = road[1];
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int>();
                graph[u].Add(v);
                graph[v].Add(u);
                ++degree[u];
                ++degree[v];
            }
           
            Queue<int> queue = new Queue<int>();
            for (int i = 1; i < n; i++)
            {
                if (degree[i] == 1)
                {
                    queue.Enqueue(i);
                }
            }
            int[] representatives = new int[n];
            Array.Fill(representatives, 1);
            long fuel = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                fuel += (long)Math.Ceiling((double)representatives[node] / seats);

                foreach (int neighbor in graph[node])
                {
                    --degree[neighbor];
                    representatives[neighbor] += representatives[node];
                    if (degree[neighbor] == 1 && neighbor != 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return fuel; // 返回到首都的消耗
        }