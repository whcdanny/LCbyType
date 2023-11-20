//Leetcode 797. All Paths From Source to Target med
//题意：给定一个有 n 个节点的有向无环图，找到所有从 0 到 n-1 的路径并返回。路径只能沿着有向边移动。
//思路：初始时，将包含节点 0 的路径放入队列中。然后，开始迭代队列，每次出队一个路径，检查路径的最后一个节点是否为目标节点。如果是，将该路径加入结果列表。否则，对于最后一个节点的每个邻居，创建一个新路径，并将新路径加入队列中。不断迭代直到队列为空。
//时间复杂度: O(V + E) 表示，其中 V 是节点（顶点）的数量，E 是边的数量。在最坏情况下，如果是指数级别的问题，可能是 O(2^N) 这样的指数级别。
//空间复杂度： O(V) 或 O(V + E)，其中 V 是节点的数量，E 是边的数量。
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            List<IList<int>> result = new List<IList<int>>();
            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(new List<int> { 0 });

            while (queue.Count > 0)
            {
                List<int> path = queue.Dequeue();
                int lastNode = path[path.Count - 1];

                if (lastNode == graph.Length - 1)
                {
                    result.Add(new List<int>(path));
                }
                else
                {
                    foreach (var neighbor in graph[lastNode])
                    {
                        List<int> newPath = new List<int>(path);
                        newPath.Add(neighbor);
                        queue.Enqueue(newPath);
                    }
                }
            }

            return result;
        }