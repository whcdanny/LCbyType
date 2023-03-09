//210. Course Schedule II med
//给一个必修n个课程，不过有些课需要提前完成其他课程，所以给出可能上课的顺序；
//思路：拓扑排序算法，先将所给的课程关系建立一个graph，然后在寻找是否有循环时，然后根据递归存入一开始上的课，然后最后将课程的顺序反转，然后再根据位置存入res，
		// 记录后序遍历结果
        List<int> postorder = new List<int>();
        // 记录是否存在环
        bool hasCycle_findOrder = false;
        bool[] visited_findOrder, onPath_findOrder;

        // 主函数
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = buildGraph_findOrder(numCourses, prerequisites);
            visited_findOrder = new bool[numCourses];
            onPath_findOrder = new bool[numCourses];
            // 遍历图
            for (int i = 0; i < numCourses; i++)
            {
                traverse_findOrder(graph, i);
            }
            // 有环图无法进行拓扑排序
            if (hasCycle_findOrder)
            {
                return new int[] { };
            }
            // 逆后序遍历结果即为拓扑排序结果
            postorder.Reverse();
            int[] res = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                res[i] = postorder[i];
            }
            return res;
        }

        // 图遍历函数
        public void traverse_findOrder(List<int>[] graph, int s)
        {
            if (onPath_findOrder[s])
            {
                // 发现环
                hasCycle_findOrder = true;
            }
            if (visited_findOrder[s] || hasCycle_findOrder)
            {
                return;
            }
            // 前序遍历位置
            onPath_findOrder[s] = true;
            visited_findOrder[s] = true;
            foreach (int t  in graph[s])
            {
                traverse_findOrder(graph, t);
            }
            // 后序遍历位置
            postorder.Add(s);
            onPath_findOrder[s] = false;
        }

        // 建图函数
        List<int>[] buildGraph_findOrder(int numCourses, int[][] prerequisites)
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
		
		
		public int[] FindOrder1(int numCourses, int[][] prerequisites)
        {
            List<List<int>> dpList = new List<List<int>>();

            for (int i = 0; i < numCourses; ++i)
            {
                dpList.Add(new List<int>());
            }

            int[] indegree = new int[numCourses];
            for (int i = 0; i < prerequisites.Length; ++i)
            {

                int[] tempDegree = new int[2] { prerequisites[i][0], prerequisites[i][1] };
                dpList[tempDegree[1]].Add(tempDegree[0]);
                ++indegree[tempDegree[0]];
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; ++i)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }

            int[] result = new int[numCourses];
            int count = 0;
            while (queue.Count > 0)
            {
                int toTake = queue.Dequeue();
                result[count++] = toTake;

                foreach (int i in dpList[toTake])
                {
                    --indegree[i];
                    if (indegree[i] == 0)
                        queue.Enqueue(i);
                }
            }

            if (count != numCourses)
                return new int[0];

            return result;
        }