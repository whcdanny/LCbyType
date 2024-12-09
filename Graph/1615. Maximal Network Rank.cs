//Leetcode 1615. Maximal Network Rank med
//题意：有n若干个城市的基础设施，其中roads连接这些城市。
//每个表示城市之间有一条双向道路。roads[i] = [ai, bi]
//两个不同城市的网络等级定义为与任一城市直接相连的道路总数 。
//如果一条道路与两个城市都直接相连，则只计算一次。
//基础设施的最大网络等级是所有不同城市对的最大网络等级。
//给定整数n和数组roads，返回整个基础设施的最大网络等级。
//说白了就是找哪两个城市能有最多的路
//思路：构图，分别将每个城市能链接的城市存一起Dictionary<int, List<int>>()
//然后从0开始两两比对，然后只删除一次两个城市公用的一条路，然后找出最大次数
//时间复杂度：O(n*n)
//空间复杂度：O(n)
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            foreach(var road in roads)
            {
                int city1 = road[0];
                int city2 = road[1];
                if (!graph.ContainsKey(city1))
                {
                    graph[city1] = new List<int>();
                }
                if (!graph.ContainsKey(city2))
                {
                    graph[city2] = new List<int>();
                }
                graph[city1].Add(city2);
                graph[city2].Add(city1);
            }
            int res = int.MinValue;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (!graph.ContainsKey(i) || !graph.ContainsKey(j))
                        continue;

                    int count = 0;
                    
                    foreach(var r1 in graph[i])
                    {
                        if (r1 != j)
                            count++;
                    }
                    foreach(var r2 in graph[j])
                    {
                        count++;
                    }
                    res = Math.Max(res, count);
                }
            }
            return res == int.MinValue ? 0 : res;
        }