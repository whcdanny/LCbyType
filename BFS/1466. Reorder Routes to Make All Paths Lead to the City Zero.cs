//Leetcode 1466. Reorder Routes to Make All Paths Lead to the City Zero med
//题意：有一个城市，编号为 0 到 n-1。城市之间的道路以及方向用数组 connections 表示，其中 connections[i] = [a, b] 表示一条从城市 a 到城市 b 的有向道路。现在，我们想使所有城市都有一个新的通路，使得路径总和最小。可以通过在某些道路上改变方向来实现。给定道路图 connections（形式为有向边列表），你需要重新插入所有的道路。每个城市都有一个唯一的编号，城市图中所有边都是 有向的。两个城市之间只有一条道路。返回能使所有城市都有一条新的通路的最小可能总路径。
//思路： BFS 进行遍历，题目是反转几条路能让所有城市到达0，那逆向思维就算从0城市需要反转几次能到达其他城市，实际上是那些没有反转的路需要反转才能满足题目要求。所以从城市 0 开始。对于每条道路，我们判断当前的方向是否与 BFS 遍历的方向一致，如果不一致，就意味着我们需要改变这条道路的方向。改变方向后，我们继续 BFS 遍历，直到所有城市都被访问过。
//时间复杂度: O(N), 其中 N 是城市的数量
//空间复杂度：O(N), 其中 N 是城市的数量
        public int MinReorder(int n, int[][] connections)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            // Build the graph
            foreach (var connection in connections)
            {
                int from = connection[0];
                int to = connection[1];
                graph[from].Add(to);
                graph[to].Add(-from); // 用负数代表反转路线；
            }

            int count = 0; // Count of roads that need to be reordered
            bool[] visited = new bool[n];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            visited[0] = true;

            while (queue.Count > 0)
            {
                int currentCity = queue.Dequeue();

                foreach (int nextCity in graph[currentCity])
                {
                    if (!visited[Math.Abs(nextCity)])
                    {
                        if (nextCity > 0)
                        {
                            count++; // Road needs to be reordered
                        }

                        queue.Enqueue(Math.Abs(nextCity));
                        visited[Math.Abs(nextCity)] = true;
                    }
                }
            }

            return count;
        }