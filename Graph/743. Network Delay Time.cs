//743. Network Delay Time med
//给一个列表times[i] = (ui, vi, wi)，给一个节点K，找出多久才能使所有节点收到信号，如果无法走到所有节点return-1；
//思路：Dijkstra 算法
		public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // 节点编号是从 1 开始的，所以要一个大小为 n + 1 的邻接表
            List<int[]>[] graph = new List<int[]>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int[]>();
            }
            // 构造图
            foreach (int[] edge in times)
            {
                int from = edge[0];
                int to = edge[1];
                int weight = edge[2];
                // from -> List<(to, weight)>
                // 邻接表存储图结构，同时存储权重信息
                graph[from].Add(new int[] { to, weight });
            }
            // 启动 dijkstra 算法计算以节点 k 为起点到其他节点的最短路径
            int[] distTo = dijkstra(k, graph);

            // 找到最长的那一条最短路径
            int res = 0;
            for (int i = 1; i < distTo.Length; i++)
            {
                if (distTo[i] == Int32.MaxValue)
                {
                    // 有节点不可达，返回 -1
                    return -1;
                }
                res = Math.Max(res, distTo[i]);
            }
            return res;
        }
        class State
        {
            // 图节点的 id
            public int id;
            // 从 start 节点到当前节点的距离
            public int distFromStart;

            public State(int id, int distFromStart)
            {
                this.id = id;
                this.distFromStart = distFromStart;
            }
        }

        // 输入一个起点 start，计算从 start 到其他节点的最短距离
        public int[] dijkstra(int start, List<int[]>[] graph)
        {
            // 定义：distTo[i] 的值就是起点 start 到达节点 i 的最短路径权重
            int[] distTo = new int[graph.Length];
            Array.Fill(distTo, Int32.MaxValue);
            // base case，start 到 start 的最短距离就是 0
            distTo[start] = 0;

            // 优先级队列，distFromStart 较小的排在前面
            List<State> pq = new List<State>();
            pq.Sort((a, b) => a.distFromStart - b.distFromStart);            
           
            // 从起点 start 开始进行 BFS
            pq.Add(new State(start, 0));

            while (pq.Count!=0)
            {
                int index = pq.Count - 1;                
                State curState = pq[index];
                pq.RemoveAt(index);
                int curNodeID = curState.id;
                int curDistFromStart = curState.distFromStart;

                if (curDistFromStart > distTo[curNodeID])
                {
                    continue;
                }

                // 将 curNode 的相邻节点装入队列
                foreach (int[] neighbor in graph[curNodeID])
                {
                    int nextNodeID = neighbor[0];
                    int distToNextNode = distTo[curNodeID] + neighbor[1];
                    // 更新 dp table
                    if (distTo[nextNodeID] > distToNextNode)
                    {
                        distTo[nextNodeID] = distToNextNode;
                        pq.Add(new State(nextNodeID, distToNextNode));
                    }
                }
            }
            return distTo;
		}