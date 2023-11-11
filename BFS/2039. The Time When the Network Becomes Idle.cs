//Leetcod2039. The Time When the Network Becomes Idle med
//题意：题目描述了一个网络，由多个服务器组成，每个服务器之间可以直接传递消息。每个数据服务器需要将其消息发送到主服务器进行处理，并等待回复。消息在服务器之间传递的时间是最短的。每个数据服务器会在第0秒开始发送消息，然后在每一秒的开始时刻检查是否收到了主服务器的回复。如果没有收到回复，数据服务器将定期重新发送消息，重新发送的时间间隔由数组patience决定。任务是找到网络变得空闲（没有消息在服务器之间传递或到达服务器）的最早秒数。
//思路：首先，我们需要建立一个图来表示服务器之间的连接关系。然后，我们可以使用BFS遍历服务器，计算每个服务器到主服务器的距离，然后根据等待时间来找出 最远端的服务器从发射第一个信息，到接收到最后的信息时长，就算最后答案；        
//每一个服务器肯定要接收到最后发出去的信息，那么正常如果没有任何延迟的话，是time，有延迟那么就找当服务器接收到第一次发出去的信息同时最后一次发出去的信息要走的距离，
//因为最多走两个来回-1，所以是2time-等待的商
//时间复杂度: O(n + m)
//空间复杂度： O(n + m)
        public int NetworkBecomesIdle(int[][] edges, int[] patience)
        {
            int n = patience.Length;
            List<int>[] graph = new List<int>[n];
            int[] dist = new int[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            //Bfs(graph, 0, dist);           
            bool[] visited = new bool[n];
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            visited[0] = true;
            int count = 0;

            while (q.Count > 0)
            {
                int size = q.Count;

                count++;
                while (size-- > 0)
                {
                    int v = q.Dequeue();
                    foreach (var u in graph[v])
                    {
                        if (visited[u]) continue;

                        visited[u] = true;
                        q.Enqueue(u);
                        dist[u] = count;
                    }
                }
            }

            int result = 0;

            for (int i = 1; i < n; i++)
            {
                int time = dist[i] * 2;
                //每一个服务器肯定要接收到最后发出去的信息，那么正常如果没有任何延迟的话，是time，有延迟那么就找当服务器接收到第一次发出去的信息同时最后一次发出去的信息要走的距离，
                //因为最多走两个来回-1，所以是2time-等待的商
                int lastTime = time - (time - 1) % patience[i] + time;
                result = Math.Max(result, lastTime);
            }

            return result;
        }