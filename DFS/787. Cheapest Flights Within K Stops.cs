//Leetcode 787. Cheapest Flights Within K Stops med 超时
//题意：题目描述了一个航班的信息，以及每个城市之间的价格。要求找到从起点城市到目标城市的最便宜的价格，但是限制了中转的次数不能超过 K 次。
//思路：（DFS）遍历航班信息，搜索所有可能的路径。在搜索的过程中，记录当前路径的总价格，并更新最小价格。限制搜索的次数不超过 K+1，以满足题目的经停次数限制。
//在搜索的过程中，剪枝处理，避免不必要的搜索。最终返回最小价格。
//注：这个不需要查重，也就是不需要visited，因为有可能其他地方飞同一个城市更便宜，这也是这道题的宗旨；
//时间复杂度:  O(N^K)，其中 N 是城市数量，K 是经停的最大次数
//空间复杂度： O(N)，递归调用的栈空间   
        private int minPrice_FindCheapestPrice;//超时
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            minPrice_FindCheapestPrice = int.MaxValue;
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();

            foreach (var flight in flights)
            {
                if (!graph.ContainsKey(flight[0]))
                {
                    graph[flight[0]] = new List<int[]>();
                }
                graph[flight[0]].Add(new int[] { flight[1], flight[2] });
            }

            DFS_FindCheapestPrice(graph, src, dst, k + 1, 0);

            return minPrice_FindCheapestPrice == int.MaxValue ? -1 : minPrice_FindCheapestPrice;
        }

        private void DFS_FindCheapestPrice(Dictionary<int, List<int[]>> graph, int current, int target, int stops, int currentPrice)
        {
            if (current == target)
            {
                minPrice_FindCheapestPrice = Math.Min(minPrice_FindCheapestPrice, currentPrice);
                return;
            }

            if (stops == 0)
            {
                return;
            }

            if (!graph.ContainsKey(current))
            {
                return;
            }

            foreach (var neighbor in graph[current])
            {
                int nextCity = neighbor[0];
                int nextPrice = neighbor[1];
                DFS_FindCheapestPrice(graph, nextCity, target, stops - 1, currentPrice + nextPrice);
            }
        }