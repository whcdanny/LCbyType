//Leetcode 2685. Count the Number of Complete Components  mid
//题意：给定一个整数 n，表示一个具有 n 个顶点的无向图，顶点编号从 0 到 n - 1。同时给定一个二维整数数组 edges，其中 edges[i] = [ai, bi] 表示存在一条连接顶点 ai 和 bi 的无向边。返回图中完全连通分量的数量。一个连通分量是图的一个子图，其中任意两个顶点之间都存在一条路径，并且子图内的任何顶点都不与子图外的顶点共享边。一个连通分量被称为完全连通如果它的任意两个顶点之间都存在一条边。
//思路：广度优先搜索（BFS）首先，我们需要将图的边信息整理成一个邻接表，便于后续的遍历。然后，我们可以从每个顶点开始进行BFS遍历，将与当前顶点连接的所有顶点标记为已访问，并将它们加入到BFS队列中。在BFS的过程中，如果我们访问到的点数*点数-1 等于 访问的点数连接线个数，说明这是一个完整闭环
//时间复杂度: O(V + E)，其中 V 为顶点数，E 为边数。
//空间复杂度：O(E)，其中 E 为边数
        public int CountCompleteComponents(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();
            int completeComponents = 0;

            foreach (var edge in edges)
            {
                if (!adjacencyList.ContainsKey(edge[0]))
                {
                    adjacencyList[edge[0]] = new List<int>();
                }
                if (!adjacencyList.ContainsKey(edge[1]))
                {
                    adjacencyList[edge[1]] = new List<int>();
                }
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited.Contains(i))
                {
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(i);
                    visited.Add(i);
                    int componentSize = 0;
                    int adjancyListcount = 0;
                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        componentSize++;                        
                        if (adjacencyList.ContainsKey(current))
                        {
                            adjancyListcount += adjacencyList[current].Count;
                            foreach (var neighbor in adjacencyList[current])
                            {
                                if (!visited.Contains(neighbor))
                                {
                                    queue.Enqueue(neighbor);
                                    visited.Add(neighbor);
                                }
                            }
                        }                        
                    }
                    //访问到的点数* 点数-1 等于 访问的点数连接线个数
                    if (componentSize * (componentSize - 1) == adjancyListcount)
                    {
                        completeComponents++;
                    }
                }
            }

            return completeComponents;

        }