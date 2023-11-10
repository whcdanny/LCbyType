//Leetcode2045. Second Minimum Time to Reach Destination hard
//题意：这是一个关于图的问题，其中有交通信号灯的概念。题目要求找到从顶点 1 到顶点 n 的第二小的时间。有time表示从一个点到另一个点的时间，change意思是如果时间在这之后，变灯需要等红灯的时间；
//思路：使用 BFS（广度优先搜索）首先，我们可以使用 BFS（广度优先搜索）来遍历所有可能的路径。对于每个节点，我们需要记录两个最小的时间值，一个表示到达该节点的最小时间，另一个表示第二小的时间。我们需要维护一个队列，每次从队列中取出一个节点进行扩展。对于每个节点的相邻节点，我们需要根据当前时间以及交通灯的状态计算到达相邻节点的时间，并更新最小和第二小的时间。        
//时间复杂度: 为 O(V + E)，其中 V 为节点数，E 为边数。
//空间复杂度： O(V)
        public int SecondMinimum(int n, int[][] edges, int time, int change)
        {
            List<int>[] graph = new List<int>[n + 1];
            int[] count = new int[n + 1];
            (int first, int second)[] dist = new (int, int)[n + 1];

            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
                dist[i] = (int.MaxValue, int.MaxValue);
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((1, 0));
            dist[1] = (0, int.MaxValue);

            while (q.Count > 0)
            {
                int size = q.Count;

                for (int i = 0; i < size; i++)
                {
                    (int v, int t) = q.Dequeue();

                    foreach (var u in graph[v])
                    {
                        bool isGreen = ((t / change) % 2 == 0);
                        //这里难点是算是否为红灯，然后再算需要等红灯的具体时间；
                        int newTime = t + time + (isGreen ? 0 : change - t % change);

                        if (dist[u].first == int.MaxValue)
                        {
                            dist[u].first = newTime;
                            q.Enqueue((u, newTime));
                        }
                        else if (newTime > dist[u].first && dist[u].second == int.MaxValue)
                        {
                            dist[u].second = newTime;
                            q.Enqueue((u, newTime));
                        }
                    }
                }
            }

            return dist[n].second;
        }