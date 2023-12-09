//Leetcode 797. All Paths From Source to Target med
//题意：给定一个有 n 个节点的有向无环图，找到所有从 0 到 n-1 的路径并返回。路径只能沿着有向边移动。
//思路：（DFS）遍历图中的所有路径。从起始节点开始，递归地访问每个邻居节点，直到达到终点节点。在DFS递归的过程中，维护一个路径列表，记录当前路径上的节点。如果当前节点为终点节点，将路径添加到结果列表中。遍历所有路径，得到最终结果。
//时间复杂度: O(2^N * N)，其中 N 是图中的节点数。
//空间复杂度：O(N)，递归调用的栈空间
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>();
            DFS_AllPathsSourceTarget(graph, 0, graph.Length - 1, path, result);
            return result;
        }

        private void DFS_AllPathsSourceTarget(int[][] graph, int current, int target, List<int> path, List<IList<int>> result)
        {
            path.Add(current);

            if (current == target)
            {
                result.Add(new List<int>(path));
            }
            else
            {
                foreach (var neighbor in graph[current])
                {
                    DFS_AllPathsSourceTarget(graph, neighbor, target, path, result);
                }
            }

            path.RemoveAt(path.Count - 1);
        }