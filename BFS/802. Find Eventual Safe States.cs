//Leetcode 802. Find Eventual Safe States med
//题意：给定一个有向图，节点编号从 0 到 n - 1，图中可能存在自环和平行边。判断是否存在一种安全路径，使得无论起始节点是哪里，最终都能到达安全状态。安全状态是指经过有向图的一系列节点后，最终到达一个终点节点，不会再有出边。
//思路：通过反向思考，从终点开始考虑，看是否能够到达起点。我们需要找到能够到达起点的节点，这些节点就是安全节点。通过拓扑排序的方式，从终点出发，标记能够到达的节点，并将它们加入队列。最终，队列中的节点就是安全节点。
//时间复杂度: O(N + E)，其中 N 为节点数，E 为边数。
//空间复杂度：O(N)。使用了一个队列和一个数组来存储节点状态。
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            List<int> result = new List<int>();
            //表示指向当前节点的边的数量，即有多少条边指向当前节点。
            int[] inDegree = new int[n];
            List<List<int>> reversedGraph = new List<List<int>>();

            // Initialize reversed graph and in degrees
            for (int i = 0; i < n; i++)
            {
                reversedGraph.Add(new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                foreach (int neighbor in graph[i])
                {
                    reversedGraph[neighbor].Add(i);
                    inDegree[i]++;
                }
            }

            // Initialize queue with nodes that have in degree 0
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            // BFS
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                result.Add(node);

                foreach (int child in reversedGraph[node])
                {
                    inDegree[child]--;
                    if (inDegree[child] == 0)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            result.Sort();
            return result;
        }