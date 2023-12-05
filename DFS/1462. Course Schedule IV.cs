//Leetcode 1462. Course Schedule IV med
//题意：现在你总共有 n 门课需要选，记为 0 到 n-1。在选修某些课程之前需要一些先修课程。 先修课程按数组 prerequisites 给出，其中 prerequisites[i] = [ai, bi] 表示如果要学习课程 ai 则必须先学习课程 bi 。例如，先修课程对[0, 1] 表示：想要学习课程 0 ，你需要先完成课程 1 。请你判断是否可能完成所有课程的学习？
//思路：构建一个图的邻接表，表示每门课程的先修课程关系。对于每个查询，使用深度优先搜索（DFS）来判断 query[1] 是否是 query[0] 的先修课程
//注：构图时，key时选的课，value是选key之前要修的课；
//时间复杂度: O(N + M), 其中 N 是课程的数量，M 是先修课程的数量
//空间复杂度：O(N + M), 使用了额外的字典和队列。
        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            List<int>[] graph = new List<int>[numCourses];
            foreach (var prerequisite in prerequisites)
            {
                if (graph[prerequisite[0]] == null)
                {
                    graph[prerequisite[0]] = new List<int>();
                }
                graph[prerequisite[0]].Add(prerequisite[1]);
            }

            List<bool> result = new List<bool>();
            foreach (var query in queries)
            {
                result.Add(DFS_IsPrerequisite(query[0], query[1], new HashSet<int>(), graph));
            }

            return result;
        }

        private bool DFS_IsPrerequisite(int source, int target, HashSet<int> visited, List<int>[] graph)
        {
            if (source == target)
            {
                return true; // source 是 target 的先修课程
            }

            visited.Add(source);
            if (graph[source] != null)
            {
                foreach (var neighbor in graph[source])
                {
                    if (!visited.Contains(neighbor) && DFS_IsPrerequisite(neighbor, target, visited, graph))
                    {
                        return true;
                    }
                }
            }

            return false;
        }