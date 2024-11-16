//Leetcode 1514. Path with Maximum Probability med
//题意： 解决的问题是：给定一个无向加权图，由 n 个节点（从 0 开始编号）组成，用边列表表示，其中 edges[i] = [a, b] 表示连接节点 a 和节点 b 的无向边，并且具有通过该边的成功概率 succProb[i]。
//给定两个节点 start 和 end，找到从 start 到 end 的成功概率最大的路径，并返回其成功概率。
//如果从 start 到 end 没有路径，则返回 0。如果你的答案与正确答案的差异最多为 1e-5，则你的答案将被接受。
//思路：PriorityQueue + Dijkstra , 使用邻接表来表示图，每个节点都保存与之相邻的节点及其对应的成功概率。
//使用优先队列（堆）来进行 Dijkstra 算法，每次从队列中取出概率最大的节点进行扩展。
//维护一个数组来记录从起点到每个节点的成功概率。
//根据 Dijkstra 算法的思想，更新每个节点的成功概率，直到到达终点为止。
//返回终点的成功概率。
//时间复杂度: O(ElogV)，其中 E 为边的数量，V 为节点的数量。空间复杂度为 O(V)
//空间复杂度：O(k)
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
        {
            IDictionary<int, IList<(int to, double probability)>> graphMap = new Dictionary<int, IList<(int, double)>>();
            int i = 0;
            for (i = 0; i < edges.Length; i++)
            {
                graphMap.TryAdd(edges[i][0], new List<(int, double)>());
                graphMap[edges[i][0]].Add((edges[i][1], succProb[i]));
                graphMap.TryAdd(edges[i][1], new List<(int, double)>());
                graphMap[edges[i][1]].Add((edges[i][0], succProb[i]));
            }
            HashSet<int> visitedSet = new HashSet<int>();
            PriorityQueue<int, double> queue = new PriorityQueue<int, double>();
            queue.Enqueue(start_node, -1);
            int queueLength = 0, node;
            double prob = 0;
            while (queue.Count > 0)
            {
                queueLength = queue.Count;
                for (i = 0; i < queueLength; i++)
                {
                    queue.TryDequeue(out node, out prob);
                    visitedSet.Add(node);
                    if (node == end_node)
                    {
                        return Math.Abs(prob);
                    }
                    if (graphMap.ContainsKey(node))
                    {
                        for (int j = 0; j < graphMap[node].Count; j++)
                        {
                            double newProb = graphMap[node][j].probability * prob;
                            if (!visitedSet.Contains(graphMap[node][j].to))
                            {
                                queue.Enqueue(graphMap[node][j].to, newProb);
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public double MaxProbability1(int n, int[][] edges, double[] succProb, int start, int end)
        {
            HashSet<Edge>[] graph = new HashSet<Edge>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<Edge>();
            }
            for (int j = 0; j < edges.Length; j++)
            {
                int[] edge = edges[j];
                double probability = succProb[j];
                graph[edge[0]].Add(new Edge(edge[1], probability));
                graph[edge[1]].Add(new Edge(edge[0], probability));
            }
            Queue<Edge> edgesToVisit = new Queue<Edge>();
            double[] maxProbabilities = new double[n];
            edgesToVisit.Enqueue(new Edge(start, 1D));
            while (edgesToVisit.Count() != 0)
            {
                Edge edge = edgesToVisit.Dequeue();
                int sourceNode = edge.node;
                double probability = edge.probability;
                HashSet<Edge> nextEdges = graph[sourceNode];
                foreach (Edge nextEdge in nextEdges)
                {
                    int nextNode = nextEdge.node;
                    double newProbability = probability * nextEdge.probability;
                    if (maxProbabilities[nextNode] < newProbability)
                    {
                        edgesToVisit.Enqueue(new Edge(nextNode, newProbability));
                        maxProbabilities[nextNode] = newProbability;
                    }
                }
            }
            return maxProbabilities[end];
        }
        class Edge
        {
            public int node;
            public double probability;

            public Edge(int node, double probability)
            {
                this.node = node;
                this.probability = probability;
            }
        }