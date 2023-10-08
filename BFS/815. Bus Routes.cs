//Leetcode 815. Bus Routes hard
//题意：题目要求在一个城市中，有许多公共汽车线路，每条线路上都有若干站点。现在你可以使用一张通行证，可以搭乘任意一辆公交车无限次。开始时，你在某个站点，需要到达目的地站点。目的是求出从起点到终点所需的最小乘坐次数。公交车可以按照任意顺序行驶，但是你必须遵守以下规则：可以搭乘任意一辆行驶在你所在站点的公交车;一旦你在某个站点搭乘了一辆公交车，你可以在途中的任意一个站点下车（包括目的地站点）;如果你想换乘其他公交车，你必须返回到起始站点，并等候另一辆公交车'
//思路：广度优先搜索（BFS）序列化： 每个站点能够搭乘的公交车记录下来, 访问过的站点和线路，遍历当前站点能够搭乘的公交车，对于每一辆公交车，遍历该公交车经过的所有站点，如果该站点未被访问过，则将该站点加入队列，如果到达目的地站点，返回乘坐的次数
//时间复杂度: 公交车总数为 n，总站点数为 m，目的地所在站点有 k 条公交线路通过，构建 stopsToBuses 哈希表的时间复杂度为 O(m * n)。BFS 的时间复杂度最坏情况下为 O(m * n^2)；总的时间复杂度为 O(m * n^2)
//空间复杂度：stopsToBuses 哈希表的空间复杂度为 O(m)，队列的空间复杂度为 O(n)， O(m + n)
        public int NumBusesToDestination_超时(int[][] routes, int source, int target)
        {
            if (source == target)
                return 0;
            Dictionary<int, HashSet<int>> stopsToBuses = new Dictionary<int, HashSet<int>>();
            Queue<(int stop, int buses)> queue = new Queue<(int stop, int buses)>();
            HashSet<int> visited = new HashSet<int>();

            for(int i=0; i<routes.Length; i++)
            {
                foreach(int stop in routes[i])
                {
                    if (!stopsToBuses.ContainsKey(stop))
                    {
                        stopsToBuses[stop] = new HashSet<int>();
                    }
                    stopsToBuses[stop].Add(i);
                }
            }

            queue.Enqueue((source, 0));
            visited.Add(source);

            while (queue.Count > 0)
            {
                (int stop, int busues) cur = queue.Dequeue();
                if (stopsToBuses.ContainsKey(cur.stop))
                {
                    foreach(int bus in stopsToBuses[cur.stop])
                    {
                        foreach(int nextstop in routes[bus])
                        {
                            if (!visited.Contains(nextstop))
                            {
                                if (nextstop.Equals(target))
                                    return cur.busues + 1;
                                queue.Enqueue((nextstop, cur.busues + 1));
                                visited.Add(nextstop);
                            }
                        }
                    }
                }
            }

            return - 1;
        }

        public int NumBusesToDestination_Succ(int[][] routes, int source, int target)
        {
            if (source == target) return 0;
            //先将每一个站出现在哪个routes里出现过，记录下第几条路线；
            Dictionary<int, HashSet<int>> stopToRoutes = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < routes.Length; i++)
            {
                foreach (int stop in routes[i])
                {
                    if (!stopToRoutes.ContainsKey(stop))
                    {
                        stopToRoutes[stop] = new HashSet<int>();
                    }
                    stopToRoutes[stop].Add(i);
                }
            }
           
            HashSet<int> visitedStops = new HashSet<int>();
            HashSet<int> visitedRoutes = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            foreach (var bus in stopToRoutes[source])
            {
                visitedRoutes.Add(bus);
                foreach (var stop in routes[bus])
                {
                    visitedStops.Add(stop);
                    queue.Enqueue(stop);
                }
            }

            int level = 1;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int currentStop = queue.Dequeue();
                    if (currentStop == target) return level;
                    //哪条路线含有现在这个站，
                    foreach (var bus in stopToRoutes[currentStop])
                    {
                        //如果当前这条线路没经过，再继续看这一站有没有经过，这样节省时间；
                        if (!visitedRoutes.Contains(bus))
                        {
                            visitedRoutes.Add(bus);
                            //如果当前站没有经过过，那么存入queue看看能不能到达目的地；
                            foreach (var stop in routes[bus])
                            {
                                if (!visitedStops.Contains(stop))
                                {
                                    visitedStops.Add(stop);
                                    queue.Enqueue(stop);
                                }
                            }
                        }
                    }
                }
                level++;
            }

            return -1;
        }