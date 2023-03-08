//797. All Paths From Source to Target med
//给一个directed acyclic graph (DAG)有向无环图，让你按要求写作从0到n-1的路径
//思路：以 0 为起点遍历图，同时记录遍历过的路径，当遍历到终点时将路径记录下来即可
		// 记录所有路径
        List<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            // 维护递归过程中经过的路径
            List<int> path = new List<int>();
            traverse_AllPathsSourceTarget(graph, 0, path);
            return res;
        }
        public void traverse_AllPathsSourceTarget(int[][] graph, int s, List<int> path)
        {
            // 添加节点 s 到路径
            path.Add(s);

            int n = graph.Length;
            if (s == n - 1)
            {
                // 到达终点
                res.Add(new List<int>(path));
                // 可以在这直接 return，但要 removeLast 正确维护 path
                // path.removeLast();
                // return;
                // 不 return 也可以，因为图中不包含环，不会出现无限递归
            }

            // 递归每个相邻节点
            foreach (int v in graph[s])
            {
                traverse_AllPathsSourceTarget(graph, v, path);
            }

            // 从路径移出节点 s
            path.RemoveAt(path.Count-1);
        }