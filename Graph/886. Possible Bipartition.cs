//886. Possible Bipartition med
//给n个人的数组，每一组表示a和b相互讨厌，然后根据这组数据把人分为两组，同组人不能互相讨厌；是否能得到；
//思路：跟相邻的颜色是否为不同一样，先建图，然后根据这个图，分配颜色；
		private bool ok_PossibleBipartition = true;
        private bool[] color_PossibleBipartition;
        private bool[] visited_PossibleBipartition;
        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            // 图节点编号从 1 开始
            color_PossibleBipartition = new bool[n + 1];
            visited_PossibleBipartition = new bool[n + 1];
            // 转化成邻接表表示图结构
            List<int>[] graph = buildGraph_PossibleBipartition(n, dislikes);

            for (int v = 1; v <= n; v++)
            {
                if (!visited_PossibleBipartition[v])
                {
                    traverse_PossibleBipartition(graph, v);
                }
            }

            return ok_PossibleBipartition;
        }
        // 建图函数
        private List<int>[] buildGraph_PossibleBipartition(int n, int[][] dislikes)
        {
            // 图节点编号为 1...n
            List<int>[] graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (int[] edge in dislikes)
            {
                int v = edge[1];
                int w = edge[0];
                // 「无向图」相当于「双向图」
                // v -> w
                graph[v].Add(w);
                // w -> v
                graph[w].Add(v);
            }
            return graph;
        }

        // 和之前的 traverse 函数完全相同
        private void traverse_PossibleBipartition(List<int>[] graph, int v)
        {
            if (!ok_PossibleBipartition) return;
            visited_PossibleBipartition[v] = true;
            foreach (int w in graph[v])
            {
                if (!visited_PossibleBipartition[w])
                {
                    color_PossibleBipartition[w] = !color_PossibleBipartition[v];
                    traverse_PossibleBipartition(graph, w);
                }
                else
                {
                    if (color_PossibleBipartition[w] == color_PossibleBipartition[v])
                    {
                        ok_PossibleBipartition = false;
                        return;
                    }
                }
            }
        }