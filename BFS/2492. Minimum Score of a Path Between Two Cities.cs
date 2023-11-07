//Leetcode 2492. Minimum Score of a Path Between Two Cities med
//题意：题目描述了一个城市网络，其中有两座城市分别标记为城市 1 和城市 2。城市之间存在多条双向道路，每条道路都有一个分数值。目标是找到从城市 1 到城市 2 的路径，使得路径上的最低分数值最大。
//思路：我们可以使用BFS（广度优先搜索）,构建一个邻接矩阵来表示城市之间的道路和对应的分数值。使用 BFS 遍历图，从城市 1 开始。在 BFS 遍历过程中，记录当前路径上的最低分数值。
//时间复杂度: 构建邻接矩阵的时间复杂度为 O(E)，其中 E 为道路的数量。使用 BFS 遍历图的时间复杂度为 O(V + E)，其中 V 为城市的数量。总体来说，算法的时间复杂度为 O(E + V)。
//空间复杂度：由于我们使用了邻接矩阵来表示城市之间的关系，空间复杂度为 O(V^2)，其中 V 为城市的数量。另外，我们需要一个队列来进行 BFS，空间复杂度为 O(V)。综合起来，整个算法的空间复杂度为 O(V^2)。
        public int MinScore(int n, int[][] roads)
        {
            var adj = new Dictionary<int, List<int[]>>();
            
            foreach (var road in roads)
            {

                adj.TryAdd(road[0], new List<int[]>());
                adj[road[0]].Add(new int[] { road[1], road[2] });

                adj.TryAdd(road[1], new List<int[]>());
                adj[road[1]].Add(new int[] { road[0], road[2] });
            }
            int minScore = int.MaxValue;
                      
            bool[] visited = new bool[n + 1];
            visited[1] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                visited[currentNode] = true;

                foreach (var path in adj[currentNode])
                {
                    minScore = Math.Min(minScore, path[1]);

                    if (!visited[path[0]])
                    {
                        queue.Enqueue(path[0]);
                    }
                }
            }

            return minScore;
        }