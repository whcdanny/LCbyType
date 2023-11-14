//Leetcode 1462. Course Schedule IV med
//题意：现在你总共有 n 门课需要选，记为 0 到 n-1。在选修某些课程之前需要一些先修课程。 先修课程按数组 prerequisites 给出，其中 prerequisites[i] = [ai, bi] 表示如果要学习课程 ai 则必须先学习课程 bi 。例如，先修课程对[0, 1] 表示：想要学习课程 0 ，你需要先完成课程 1 。请你判断是否可能完成所有课程的学习？
//思路： BFS 进行遍历，来进行拓扑排序。首先，构建课程图，然后使用 BFS 遍历图。在遍历的过程中，我们记录每个课程的入度。如果最后入度数组中所有课程的入度都为 0，则表示可以完成所有课程的学习。
//时间复杂度: O(N + M), 其中 N 是课程的数量，M 是先修课程的数量
//空间复杂度：O(N + M), 使用了额外的字典和队列。
        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            // Build the course graph
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();            
            foreach (var prerequisite in prerequisites)
            {
                int from = prerequisite[0];
                int to = prerequisite[1];

                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<int>();
                }

                graph[from].Add(to);                
            }
            // Check prerequisites for each query
            IList<bool> result = new List<bool>();
            for(int i=0;i< queries.Length;i++)
            {
                int from = queries[i][0];
                int to = queries[i][1];
                // BFS for topological sort
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(from);
                HashSet<int> visited = new HashSet<int>();
                visited.Add(from);               
                while (queue.Count > 0)
                {
                    int currentCourse = queue.Dequeue();
                    if (currentCourse == to)
                    {
                        break;
                    }                       
                    if (graph.ContainsKey(currentCourse))
                    {
                        foreach (int nextCourse in graph[currentCourse])
                        {
                            if (nextCourse == to)
                            {
                                visited.Add(nextCourse);
                                break;
                            }
                            if (!visited.Contains(nextCourse))
                            {
                                queue.Enqueue(nextCourse);
                                visited.Add(nextCourse);
                            }                            
                        }
                    }
                }
                if (visited.Contains(to))
                    result.Add(true);
                else
                    result.Add(false);
            }
            
            return result;
        }