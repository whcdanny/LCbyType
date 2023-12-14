//Leetcode 207 Course Schedule med
//题意：给定课程的数量和一组先修课程的关系，判断是否可能完成所有课程。
//思路：拓扑排序,构建有向图，用邻接表表示课程之间的先后关系。使用DFS进行拓扑排序，判断是否存在环。
//注：记录节点的访问状态：0 未访问，1 正在访问，2 已访问，因为有可能有闭环，所以要有三个状态；
//时间复杂度: 构建有向图的时间复杂度为 O(E)，其中 E 是边的数量。DFS的时间复杂度为 O(V + E)，其中 V 是节点的数量，E 是边的数量。
//空间复杂度：用邻接表表示图，空间复杂度为 O(V + E)。使用数组记录节点的访问状态，空间复杂度为 O(V
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // 构建有向图
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                graph.Add(new List<int>());
            }

            foreach (var prereq in prerequisites)
            {
                graph[prereq[1]].Add(prereq[0]);
            }

            // 记录节点的访问状态：0 未访问，1 正在访问，2 已访问
            int[] visited = new int[numCourses];

            // 从每个未访问的节点开始DFS
            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0)
                {
                    if (!DFS_CanFinish(graph, i, visited))
                    {
                        return false; // 有环，无法完成所有课程
                    }
                }
            }

            return true;
        }

        private bool DFS_CanFinish(List<List<int>> graph, int node, int[] visited)
        {
            visited[node] = 1; // 正在访问

            foreach (var neighbor in graph[node])
            {
                if (visited[neighbor] == 1)
                {
                    return false; // 存在环，无法完成所有课程
                }

                if (visited[neighbor] == 0)
                {
                    if (!DFS_CanFinish(graph, neighbor, visited))
                    {
                        return false; // 有环，无法完成所有课程
                    }
                }
            }

            visited[node] = 2; // 已访问
            return true;
        }