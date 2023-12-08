//Leetcode 947. Most Stones Removed with Same Row or Column med
//题意：二维平面上放置n个石头，每个石头的坐标为stones[i] = [xi, yi]，每个坐标点最多只能放一个石头。移除一个石头的条件是它与另一个尚未被移除的石头共享相同的行或列。
//思路：（建立图：遍历所有石头，如果两个石头在同一行或同一列，就在它们之间建立一条边。
//DFS搜索：对于每个连通分量，我们从其中一个石头开始，通过DFS遍历整个连通分量，并标记被访问的石头。统计每个连通分量中可以被移除的石头数量。
//计算总移除数量：遍历所有石头，对于每个石头，如果它没有被访问过，就意味着它是一个单独的连通分量，可以被完全移除。累加这些石头的数量，得到最终结果
//时间复杂度: O(n^2)的时间，其中n是石头的数量。 DFS搜索的过程需要O(n)的时间。因此，总的时间复杂度为O(n^2 + n) = O(n^2)。
//空间复杂度：用于存储图的空间复杂度为O(n^2)。用于DFS搜索的空间复杂度为O(n)。因此，总的空间复杂度为O(n^2)。
        public int RemoveStones(int[][] stones)
        {
            int n = stones.Length;
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            // Step 1: Build the graph
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
                    {
                        if (!graph.ContainsKey(i)) graph[i] = new List<int>();
                        if (!graph.ContainsKey(j)) graph[j] = new List<int>();
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            // Step 2: DFS search
            HashSet<int> visited = new HashSet<int>();
            int removeCount = 0;

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    removeCount += DFS_RemoveStones(node, graph, visited) - 1; // subtract 1 to keep one stone in each connected component
                }
            }

            return removeCount;
        }

        private int DFS_RemoveStones(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
        {
            visited.Add(node);
            int componentSize = 1;

            if (graph.ContainsKey(node))
            {
                foreach (var neighbor in graph[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        componentSize += DFS_RemoveStones(neighbor, graph, visited);
                    }
                }
            }

            return componentSize;
        }