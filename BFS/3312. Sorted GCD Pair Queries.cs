//Leetcode 3312. Sorted GCD Pair Queries hard
//题目：给定一个二维整数数组 edges 表示一个无向图，其中 edges[i] = [ui, vi] 表示节点 ui 和 vi 之间存在一条边。要求构建一个满足以下条件的二维网格：
//网格包含从 0 到 n - 1 的所有节点，每个节点在网格中恰好出现一次。
//如果节点 ui 和 vi 之间存在边，那么这两个节点应该在网格中是相邻的（水平或垂直相邻）。
//题目保证这些边可以形成一个满足上述条件的二维网格。
//思路：图的构建：通过邻接列表保存图的结构。
//路径计算：使用 BFS 找到任意两个节点之间的最短路径。
//网格构建：通过路径构建网格，并保证相邻节点的连通性。
//时间复杂度：O(n + m)，其中 n 是节点数，m 是边的数量
//空间复杂度：O(maxValue) 大小的数组来存储 divisorCount、gcdPairCount 和 prefixSum。
        public int[][] ConstructGridLayout(int n, int[][] edges)
        {
            //建图
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                int u = edge[0], v = edge[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }
            //如果有两个单独节点，说明只能有一条直线，然后找出最短路径；
            var oneConnected = Enumerable.Range(0, n).Where(x => graph[x].Count == 1).ToArray();
            if (oneConnected.Length == 2)
            {
                int[] oneRes = shortPath(graph, oneConnected[0], oneConnected[1]);
                int[][] r = new int[1][];
                r[0] = oneRes;
                return r;
            }
            // Find the corners and size of the matrix
            // A...B
            // .....
            // D...C
            //找出四个顶点，然后分别算出ab，ac，ad
            var twoConnected = Enumerable.Range(0, n).Where(x => graph[x].Count == 2).ToArray();
            var ab = shortPath(graph, twoConnected[0], twoConnected[1]);
            var ac = shortPath(graph, twoConnected[0], twoConnected[2]);
            var ad = shortPath(graph, twoConnected[0], twoConnected[3]);

            //从三条路径中找到较短的路径来更新 ab 或 ad，以确保这两条路径都不会是最长的路径。            
            if (ab.Length > ac.Length && ab.Length > ad.Length)
                ab = ac;
            else if (ad.Length > ab.Length && ad.Length > ac.Length)
                ad = ac;

            var width = ab.Length;
            var hight = ad.Length;
            var res = new int[hight][];
            for(var i = 0; i < hight; i++)
            {
                res[i] = new int[width];
            }
            for(var i = 0; i < width; i++)
            {
                res[0][i] = ab[i];
            }
            for(var i = 0; i < hight; i++)
            {
                res[i][0] = ad[i];
            }

            for(var i = 1; i < hight; i++)
            {
                for(var j = 1; j < width; j++)
                {
                    //对于每个位置 (i, j)，选择与其上方和左方相邻节点的交集，并排除左上角的节点。
                    res[i][j] = graph[res[i - 1][j]].Intersect(graph[res[i][j - 1]]).Except(new[] { res[i - 1][j - 1] }).First();
                }
            }

            return res;
        }
        
        private int[] shortPath(Dictionary<int, List<int>> graph, int from, int to)
        {
            var visited = new HashSet<int>();
            var pre = new Dictionary<int, int> { [from] = -1 };
            var queue = new Queue<int>();
            queue.Enqueue(from);
            visited.Add(from);
            while (queue.Count > 0)
            {
                var val = queue.Dequeue();
                foreach(var next in graph[val])
                {
                    if (!visited.Add(next))
                        continue;
                    pre[next] = val;
                    if(next == to)
                    {
                        var path = new Stack<int>();
                        while (pre[to] != -1)
                        {
                            path.Push(to);
                            to = pre[to];
                        }
                        path.Push(from);
                        return path.ToArray();
                    }
                    queue.Enqueue(next);
                }
            }
            return new int[0];
        }