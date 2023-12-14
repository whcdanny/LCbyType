//Leetcode 332. Reconstruct Itinerary hard
//题意：给定的机票列表，重建出一条从起点到终点的行程路线。机票列表中的每一项 [from, to] 表示飞机从起点 from 飞往终点 to。每个机场的名称用三个大写字母表示。要求返回一条满足题意的行程路线，如果存在多个有效解，则返回字典序最小的那个
//并且从起点 "JFK" 开始深度优先搜索
//思路：DFS,构建图：将机票列表构建成一个有向图，用字典（或哈希表）来表示，其中键为起点，值为该起点到达的所有终点的列表。
//对每个起点的终点列表按照字母顺序进行排序，保证字典序最小。
//使用深度优先搜索（DFS）来遍历图，按照字典序选择路径。
//注：结果是反向的，需要反转得到正确的行程路线
//时间复杂度: O(E)，其中 E 是机票的数量。
//空间复杂度：O(V+E)，其中  E 是机票的数量。V 是机场的数量。
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            List<string> result = new List<string>();

            // 构建图
            foreach (var ticket in tickets)
            {
                string from = ticket[0];
                string to = ticket[1];
                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }
                graph[from].Add(to);
            }

            // 对每个起点的终点列表按照字母顺序进行排序
            foreach (var key in graph.Keys)
            {
                graph[key].Sort();
            }

            // 从起点 "JFK" 开始深度优先搜索
            DFS_FindItinerary(graph, "JFK", result);

            // 结果是反向的，需要反转得到正确的行程路线
            result.Reverse();
            return result;
        }

        private void DFS_FindItinerary(Dictionary<string, List<string>> graph, string from, List<string> result)
        {
            if (graph.ContainsKey(from))
            {
                List<string> destinations = graph[from];
                while (destinations.Count > 0)
                {
                    string to = destinations[0];
                    destinations.RemoveAt(0);
                    DFS_FindItinerary(graph, to, result);
                }
            }
            result.Add(from);
        }