//Leetcode 2608. Shortest Cycle in a Graph hard
//题意：给定一个包含 n 个节点的双向图，节点编号从 0 到 n - 1。图中的边由给定的二维整数数组 edges 表示，其中 edges[i] = [ui, vi] 表示节点 ui 和节点 vi 之间存在一条边。每对节点之间最多存在一条边，且不存在自环。返回图中最短的环的长度。如果不存在环，则返回 -1。一个环是一个起点和终点相同的路径，并且路径上的每条边只会被使用一次。
//思路：广度优先搜索（BFS）遍历树，我们需要将图的边信息整理成一个邻接表adjacencyList，然后根据edges的每一条边，选取start和end，然后把含有这两个点的边从adjacencyList临时删除，这样再根据start去找是否有其他方法到达end的路径，如果有就说明有一个闭环，然后再跟minCycle去做比较；
//时间复杂度: O(n^2)
//空间复杂度：O(1)
        public int FindShortestCycle(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();            
            int minCycle = int.MaxValue;

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

            foreach(var edge in edges)
            {
                int start = edge[0];
                int end = edge[1];
                adjacencyList[start].Remove(end);
                adjacencyList[end].Remove(start);

                Queue<int> queue = new Queue<int>();
                HashSet<int> visited = new HashSet<int>();
                queue.Enqueue(start);
                visited.Add(start);
                int level = 0;
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    level++;
                    for(int i = 0; i < count; i++)
                    {
                        int current = queue.Dequeue();
                        foreach (var neighbor in adjacencyList[current])
                        {
                            if (neighbor == end)
                            {
                                minCycle = Math.Min(minCycle, level+1);
                                break;
                            }
                            if (!visited.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                                visited.Add(neighbor);
                            }
                        }
                    }
                }
                adjacencyList[start].Add(end);
                adjacencyList[end].Add(start);
            }

            return minCycle == int.MaxValue?-1:minCycle;
        }