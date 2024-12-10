//Leetcode 1786. Number of Restricted Paths From First to Last Node med
//题意：有一个无向加权连通图。给定一个正整数n，表示该图具有从到 的n标签节点，
//以及一个数组，其中每个表示节点和之间存在一条权重等于 的边。
//1nedgesedges[i] = [ui, vi, weighti]
//start从节点到节点的路径end是一系列节点，使得和，并且和之间存在一条边，
//其中。[z0, z1, z2, ..., zk] z0 = startzk = endzizi+10 <= i <= k-1
//路径的距离是路径边上权重的总和。设表示节点和节点distanceToLastNode(x)之间路径的最短距离。
//限制路径是还满足 的路径，其中。nxdistanceToLastNode(zi) > distanceToLastNode(zi+1)0 <= i <= k-1
//返回从节点到节点的受限路径数 。由于该数字可能太大，因此返回其模数。1 n 109 + 7
//思路：动态规划+priorityQueue+Dijkstra+dfs， 先构图，用List<(int, int)>[n + 1] 构图
//然后动态规划每个点到n的最小权重，用pq找出最小的距离，
//用到dfs从0开始到n，找出distance[node] > distance[next]
//时间复杂度:O((E+V)logV) E是边数, V是节点数;DFS：O(E)。总时间复杂度：O((E+V)logV)。
//空间复杂度：O(E+V)
        public int CountRestrictedPaths(int n, int[][] edges)
        {
            const int mod = 1_000_000_007;
            var graph = new List<(int, int)>[n + 1];
            for(int i = 1; i <= n; i++)
            {
                graph[i] = new List<(int, int)>();
            }
            foreach(var edge in edges)
            {
                int u = edge[0], v = edge[1], w = edge[2];
                graph[u].Add((v, w));
                graph[v].Add((u, w));
            }

            var distance = new int[n + 1];
            Array.Fill(distance, int.MaxValue);
            var pq = new SortedSet<(int dist, int node)>();
            distance[n] = 0;
            pq.Add((0, n));

            while (pq.Count > 0)
            {
                (int dist, int node) = pq.Min;
                pq.Remove((dist, node));
                foreach(var(next, weight) in graph[node])
                {
                    if (distance[next] > dist + weight)
                    {
                        pq.Remove((distance[next], next));
                        distance[next] = dist + weight;
                        pq.Add((distance[next], next));
                    }
                }
            }

            var memo = new int[n + 1];
            Array.Fill(memo, -1);
            int dfsCountRestrictedPaths(int node)
            {
                if (node == n)
                    return 1;
                if (memo[node] != -1)
                    return memo[node];
                long paths = 0;
                foreach(var(next, weight)in graph[node])
                {
                    if (distance[node] > distance[next])
                    {
                        paths += dfsCountRestrictedPaths(next);
                        paths %= mod;                        
                    }
                }
                return memo[node]=(int)paths;
            }
            return dfsCountRestrictedPaths(1);
        }