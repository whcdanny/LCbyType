//Leetcode 847. Shortest Path Visiting All Nodes hard
//题意：题目要求找到访问所有节点的最短路径。给定一个无向连通图，节点用 0 到 N-1 的整数表示，其中 N 是节点的数量。每个节点都包含一个表示颜色的整数。玩家从起始节点 0 出发，可以选择沿着边向相邻节点移动。在移动的同时，玩家可以改变经过的节点的颜色。目标是找到访问所有节点并返回起始节点的最短路径。
//思路：这是一个典型的求解最短路径问题。我们可以使用 BFS（广度优先搜索） 来解决这个问题。我们需要一个状态表示当前的位置和经过的节点的颜色集合。这可以用一个二进制掩码来表示，其中每一位代表一个节点的颜色。我们使用一个队列来进行 BFS，每个队列元素包含当前位置和经过的颜色集合。使用一个数组 dp 来记录每个状态是否已经访问过。状态由当前位置和颜色集合构成。在 BFS 过程中，我们每次从队列中取出一个状态，尝试移动到相邻节点，并更新状态。如果状态未被访问过，则加入队列继续遍历。当状态包含所有颜色时，表示已经访问过所有节点，此时返回路径长度。
//时间复杂度: 每个节点可能需要访问 2^N 种状态，其中 N 是节点的数量。因此，时间复杂度为 O(N * 2^N)
//空间复杂度：O(N * 2^N)
        public int ShortestPathLength(int[][] graph)
        {
            int n = graph.Length;
            //(1 << N) - 1 表示对上一步得到的结果减去 1。这将在二进制中所有的 N 位都设置为 1，得到一个二进制数，其所有位都是 1。例如，如果 N = 3，则 (1 << N) - 1 将得到二进制 111，即十进制的 7。
            int targetMask = (1 << n) - 1;

            Queue<int[]> queue = new Queue<int[]>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            // Add all nodes to the queue as starting points
            for (int i = 0; i < n; i++)
            {
				//表示将二进制数 1 左移 N 位。这相当于得到一个数，其二进制表示在最右边有 N 个零，其他位都为 1。例如，如果 N = 3，则 1 << N 将得到二进制 1000，即十进制的 8。
                int initialState = 1 << i;
                queue.Enqueue(new int[] { i, initialState, 0 });
                visited.Add((i, initialState));
            }

            while (queue.Count > 0)
            {
                int[] state = queue.Dequeue();
                int node = state[0];
                int mask = state[1];
                int steps = state[2];

                if (mask == targetMask)
                {
                    return steps;
                }

                foreach (int neighbor in graph[node])
                {
                    //1 << neighbor 将二进制数中的第 neighbor 位设为 1，然后通过 mask | (1 << neighbor) 将这个位的值添加到 mask 中，表示节点 neighbor 已经被访问。
                    int newMask = mask | (1 << neighbor);
                    if (!visited.Contains((neighbor, newMask)))
                    {
                        queue.Enqueue(new int[] { neighbor, newMask, steps + 1 });
                        visited.Add((neighbor, newMask));
                    }
                }
            }

            return -1;
        }