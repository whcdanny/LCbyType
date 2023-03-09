//207. Course Schedule med
//给一个必修n个课程，不过有些课需要提前完成其他课程，所以判断所给的课程是否你能完成学业；
//思路：环形测算法，先将所给的课程关系建立一个graph，然后寻找是否有循环，有就不能完成学业；
		// 记录一次递归堆栈中的节点
        bool[] onPath;
        // 记录遍历过的节点，防止走回头路
        bool[] visited;
        // 记录图中是否有环
        bool hasCycle = false;

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = buildGraph(numCourses, prerequisites);

            visited = new bool[numCourses];
            onPath = new bool[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                // 遍历图中的所有节点
                traverse(graph, i);
            }
            // 只要没有循环依赖可以完成所有课程
            return !hasCycle;
        }

        void traverse(List<int>[] graph, int s)
        {
            if (onPath[s])
            {
                // 出现环
                hasCycle = true;
            }

            if (visited[s] || hasCycle)
            {
                // 如果已经找到了环，也不用再遍历了
                return;
            }
            // 前序代码位置
            visited[s] = true;
            onPath[s] = true;
            foreach (int t in graph[s])
            {
                traverse(graph, t);
            }
            // 后序代码位置
            onPath[s] = false;
        }

        public List<int>[] buildGraph(int numCourses, int[][] prerequisites)
        {
            // 图中共有 numCourses 个节点
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (int[] edge in prerequisites)
            {
                int from = edge[1], to = edge[0];
                // 添加一条从 from 指向 to 的有向边
                // 边的方向是「被依赖」关系，即修完课程 from 才能修课程 to
                graph[from].Add(to);
            }
            return graph;
        }
		
		public bool CanFinish1(int numCourses, int[][] prerequisites)
        {
            int[] indegree = new int[numCourses];
            foreach (int[] pre in prerequisites)
            {
                indegree[pre[0]]++;
            }
            Queue<int> quese = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    quese.Enqueue(i);
            }
            if (quese.Count == 0)
                return false;
            while (quese.Count != 0)
            {
                int course = quese.Dequeue();
                foreach (int[] pre in prerequisites)
                {
                    if (pre[1] == course)
                    {
                        indegree[pre[0]]--;
                        if (indegree[pre[0]] == 0)
                            quese.Enqueue(pre[0]);
                    }
                }
            }

            foreach (int degree in indegree)
            {
                if (degree != 0)
                    return false;
            }
            return true;
        }