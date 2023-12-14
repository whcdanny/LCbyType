//Leetcode 210. Course Schedule II med
//题意：给定课程总量和一个先修课程的列表，按照先修关系来安排课程的学习顺序。返回一种可能的学习顺序。如果不可能完成则返回空数组。
//思路：拓扑排序问题，DFS进行拓扑排序，找到一个不在当前DFS路径上的节点，将其加入结果序列。
//注：记录节点的访问状态：0 未访问，1 正在访问，2 已访问，因为有可能有闭环，所以要有三个状态；
//时间复杂度: 构建有向图的时间复杂度为 O(E)，其中 E 是边的数量。DFS的时间复杂度为 O(V + E)，其中 V 是节点的数量，E 是边的数量。
//空间复杂度：用邻接表表示图，空间复杂度为 O(V + E)。使用数组记录节点的访问状态，空间复杂度为 O(V
        public int[] FindOrder(int numCourses, int[][] prerequisites)
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
            List<int> result = new List<int>();

            // 从每个未访问的节点开始DFS
            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0)
                {
                    if (!DFS_FindOrder(graph, i, visited, result))
                    {
                        return new int[0]; // 有环，无法完成所有课程
                    }
                }
            }

            // 将结果序列转换为数组
            return result.ToArray();
        }

        private bool DFS_FindOrder(List<List<int>> graph, int node, int[] visited, List<int> result)
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
                    if (!DFS_FindOrder(graph, neighbor, visited, result))
                    {
                        return false; // 有环，无法完成所有课程
                    }
                }
            }

            visited[node] = 2; // 已访问
            result.Insert(0, node); // 将节点加入结果序列（逆序）

            return true;
        }