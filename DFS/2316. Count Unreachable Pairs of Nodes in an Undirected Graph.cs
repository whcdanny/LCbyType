//Leetcode 2316. Count Unreachable Pairs of Nodes in an Undirected Graph med
//题意：给定一个整数 n，表示一个具有 n 个节点的无向图，节点编号从 0 到 n - 1。给定一个二维整数数组 edges，其中 edges[i] = [ai, bi] 表示节点 ai 和节点 bi 之间存在一条无向边。
//返回无法从彼此达到的不同节点对的数量。
//思路：深度优先搜索 (DFS),FS 遍历图，标记每个节点所在的连通组件。从0开始，历遍并存储访问，然后找到不相连的点，然后算总数。
//注：算完会有重复，所以/2
//时间复杂度: O(V + E)，其中 V 是节点数量，E 是边数量。遍历图需要 O(V + E) 的时间
//空间复杂度：O(V + E)，其中 V 是节点数量，E 是边数量。遍历图需要 O(V + E) 的时间

        public long CountPairs(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();            
            HashSet<int> visited = new HashSet<int>();
            long res = 0;
            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (visited.Contains(i))
                    continue;
                //HashSet<int> temp = new HashSet<int>(visited);
                var count = DFS_CountPairs(i, adjacencyList, visited, n);
                list.Add(count);
                //int count = 0;
                //for(int j = 0; j < n; j++)
                //{
                //    if (!visited.Contains(j))
                //        count++;
                //}
                //res += count * (visited.Count-temp.Count);
            }           
            for (int i = 0; i < list.Count; i++)
            {
                res += list[i] * (long)(n - list[i]);
            }
            res /= 2;            
            return res;
        }

        private int DFS_CountPairs(int node, Dictionary<int, List<int>> adjacencyList, HashSet<int> visited, int n)
        {
            int res = 0;
            visited.Add(node);
            res++;
            foreach(var adj in adjacencyList[node])
            {
                if (adj == node || visited.Contains(adj)) continue;
                res+=DFS_CountPairs(adj, adjacencyList, visited, n);
            }
            return res;
        }
