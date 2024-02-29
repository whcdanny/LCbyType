//Leetcode 787. Cheapest Flights Within K Stops med
//题意：题目描述了一个航班的信息，以及每个城市之间的价格。要求找到从起点城市到目标城市的最便宜的价格，但是限制了中转的次数不能超过 K 次。
//思路：BFS + PriorityQueue; 遍历航班信息，建立graph，然后用pq存目的地，停止次数，价格，然后按照价格最低到高构建这个pq；        
//时间复杂度: O((V+E) * log(E))
//空间复杂度：O(V+E)
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            Dictionary<int, IList<(int dst, int price)>> adjList = new Dictionary<int, IList<(int dst, int price)>>();
            int i = 0;
            for (i = 0; i < flights.Length; i++)
            {
                adjList.TryAdd(flights[i][0], new List<(int, int)>());
                adjList[flights[i][0]].Add((flights[i][1], flights[i][2]));
            }
            //dst    //stop   //price 
            PriorityQueue<(int node, int stop), int> pq = new PriorityQueue<(int node, int stop), int>();
            pq.Enqueue((src, 0), 0);

            int[] prices = new int[n];
            int[] stops = new int[n];

            Array.Fill(prices, int.MaxValue);
            Array.Fill(stops, int.MaxValue);
            prices[src] = 0;
            stops[src] = 0;
            int price = 0, newPrice, newStop = 0;

            while (pq.Count > 0 && pq.TryDequeue(out var vertex, out price))
            {
                if (vertex.node == dst)
                {
                    return price;
                }
                if (vertex.stop < k + 1)
                {
                    if (adjList.ContainsKey(vertex.node))
                    {
                        for (int j = 0; j < adjList[vertex.node].Count; j++)
                        {
                            var nextNode = adjList[vertex.node][j];
                            newPrice = price + nextNode.price;
                            newStop = vertex.stop + 1;
                           
                            if (newPrice < prices[nextNode.dst])
                            {
                                prices[nextNode.dst] = newPrice;
                                stops[nextNode.dst] = newStop;
                                pq.Enqueue((nextNode.dst, newStop), newPrice);
                            }
                            else if (newStop < stops[nextNode.dst])
                            {
                                stops[nextNode.dst] = newStop;
                                pq.Enqueue((nextNode.dst, newStop), newPrice);
                            }
                        }
                    }
                }
            }
            return -1;
        }