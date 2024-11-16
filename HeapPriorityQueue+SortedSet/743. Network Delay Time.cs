//Leetcode 743. Network Delay Time med
//题意：给定一个有n个节点的网络，节点从1到n标记。同时给定一个列表times，其中times[i] = (ui, vi, wi)表示有向边，其中ui是源节点，vi是目标节点，wi是信号从源节点到目标节点所需的时间。
//我们将从给定的某个节点k发送信号。返回所有n个节点接收信号所需的最小时间。如果不可能让所有n个节点接收到信号，则返回-1。
//思路：PriorityQueue + Dijkstra;
//构建图，使用字典表示邻接表; 使用优先队列（最小堆）来存储节点和到达该节点的最小时间
//如果当前节点有邻居节点，将邻居节点加入队列; 如果邻居节点未访问过，加入队列;如果所有节点都被访问过，返回最大的到达时间 
//时间复杂度：O((E + V) * logV)，其中E是边的数量，V是节点的数量。
//空间复杂度：O(V)
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // 构建图，使用字典表示邻接表
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
            foreach (var time in times)
            {
                int u = time[0];
                int v = time[1];
                int w = time[2];
                if (!graph.ContainsKey(u))
                {
                    graph[u] = new List<int[]>();
                }
                graph[u].Add(new int[] { v, w });
            }

            // 使用优先队列（最小堆）来存储节点和到达该节点的最小时间
            PriorityQueue<int[]> minHeap = new PriorityQueue<int[]>((a, b) => a[1] - b[1]);

            // 记录节点到达时间的字典
            Dictionary<int, int> dist = new Dictionary<int, int>();

            // 将起始节点放入队列
            minHeap.Enqueue(new int[] { k, 0 });

            while (minHeap.Count > 0)
            {
                int[] current = minHeap.Dequeue();
                int node = current[0];
                int time = current[1];

                // 如果节点已经访问过，直接跳过
                if (dist.ContainsKey(node))
                {
                    continue;
                }

                // 更新节点的到达时间
                dist[node] = time;

                // 如果当前节点有邻居节点，将邻居节点加入队列
                if (graph.ContainsKey(node))
                {
                    foreach (var neighbor in graph[node])
                    {
                        int v = neighbor[0];
                        int w = neighbor[1];
                        // 如果邻居节点未访问过，加入队列
                        if (!dist.ContainsKey(v))
                        {
                            minHeap.Enqueue(new int[] { v, time + w });
                        }
                    }
                }
            }

            // 如果所有节点都被访问过，返回最大的到达时间
            if (dist.Count == n)
            {
                int maxTime = 0;
                foreach (var time in dist.Values)
                {
                    maxTime = Math.Max(maxTime, time);
                }
                return maxTime;
            }

            // 如果有节点未被访问过，返回 -1
            return -1;
        }