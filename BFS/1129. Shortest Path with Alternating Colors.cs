//Leetcode 1129. Shortest Path with Alternating Colors med
//题意：给定一个有向图，图中的节点分为两种颜色：红色和蓝色。请你计算从起点开始到终点的最短路径的长度，其中路径的长度是路径上的边的总数，而且路径上的每个节点都有相应的颜色。图的边由 edges 表示，其中 edges[i] = [a, b] 表示从节点 a 到节点 b 有一条有向边。为了表示节点 a 和 b 有不同的颜色，有一个数组 colors，其中 colors[i] 是节点 i 的颜色。你将从起点 start 走到终点 end。请你返回最短路径的长度，如果不存在这样的路径则返回 -1。
//思路：BFS（广度优先搜索）从起点开始，按照题目规定的规则，不断更新节点的颜色，并将路径长度加一。最终找到终点时，返回路径长度。
//时间复杂度: O(E + V)，其中 E 是图中的边数，V 是图中的节点数。
//空间复杂度：O(E + V)，使用了邻接表表示图，队列的最大长度也与图的节点数相关。 
        public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            Dictionary<int, List<int>> redGraph = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> blueGraph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                redGraph[i] = new List<int>();
                blueGraph[i] = new List<int>();
            }

            foreach (var edge in redEdges)
            {
                redGraph[edge[0]].Add(edge[1]);
            }

            foreach (var edge in blueEdges)
            {
                blueGraph[edge[0]].Add(edge[1]);
            }

            int[] result = new int[n];
            Queue<(int, int, int, int)> queue= new  Queue<(int, int, int, int)>();
            for (var i = 1; i < n; i++)
            {
                result[i] = -1;
                var shortestPath = Int32.MaxValue;

                var visitedRed = new bool[n];
                var visitedBlue = new bool[n];

                queue.Enqueue((0, i, 1, 0));
                queue.Enqueue((0, i, -1, 0));

                while (queue.Count > 0)
                {
                    var (current, destination, color, step) = queue.Dequeue();

                    if (current == destination)
                    {
                        shortestPath = Math.Min(shortestPath, step);
                        result[destination] = shortestPath;
                        continue;
                    }

                    var visited = (color == 1) ? visitedRed : visitedBlue;
                    if (visited[current])
                    {
                        continue;
                    }
                    visited[current] = true;

                    List<int> edges;
                    if (color == 1)
                    {
                        edges = redGraph.ContainsKey(current) ? redGraph[current] : null;
                    }
                    else
                    {
                        edges = blueGraph.ContainsKey(current) ? blueGraph[current] : null;
                    }

                    color = -color;

                    if (edges != null)
                    {
                        foreach (var edge in edges)
                        {
                            queue.Enqueue((edge, destination, color, step + 1));
                        }
                    }
                }
            }

            return result;
        }