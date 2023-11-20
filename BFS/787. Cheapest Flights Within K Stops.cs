//Leetcode 787. Cheapest Flights Within K Stops med
//题意：题目描述了一个航班的信息，以及每个城市之间的价格。要求找到从起点城市到目标城市的最便宜的价格，但是限制了中转的次数不能超过 K 次。
//思路：FS 来解决。我们可以从起点城市开始，每一步都探索当前城市的邻接城市，然后记录到每个城市的最小花费。为了限制中转次数，我们可以记录每一步中转的次数，如果次数超过 K，则停止向下探索。在这个过程中，我们需要维护每个城市的最小花费。如果我们发现一个更便宜的价格到达某个城市，我们更新这个城市的最小花费。
//注：这个不需要查重，也就是不需要visited，因为有可能其他地方飞同一个城市更便宜，这也是这道题的宗旨；
//时间复杂度:  O(V + E)，其中 V 是节点数量，E 是边数量。
//空间复杂度： O(V)
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
            for(int i=0;i<n;i++)
            {
                graph[i] = new List<int[]>();
            }
            // 构建图
            foreach (var flight in flights)
            {               
                graph[flight[0]].Add(new int[] { flight[1], flight[2] });
            }

            // BFS 队列，每个元素包括城市、当前花费和中转次数
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { src, 0, 0 });

            int[] res = new int[n];            
            Array.Fill(res, Int32.MaxValue);
            res[src] = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int city = current[0];
                int cost = current[1];
                int stops = current[2];
                
                if (stops > k)
                {
                    // 如果中转次数超过限制，跳过该节点
                    continue;
                }
                foreach (var neighbor in graph[city])
                {
                    int newcost = cost + neighbor[1];
                    if (newcost < res[neighbor[0]])
                    {
                        res[neighbor[0]] = newcost;
                        queue.Enqueue(new int[] { neighbor[0], newcost, stops + 1 });
                    }
                }                   
            }

            // 如果未找到合适的路径，返回 -1
            return res[dst]== Int32.MaxValue ? -1 : res[dst];
        }