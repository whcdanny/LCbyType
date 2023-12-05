//Leetcode 1443. Minimum Time to Collect All Apples in a Tree med
//题意：一个无向树，树中的每个节点都有一个编号从0到 n-1，并且有一些节点上有苹果。每走过一条树边需要花费1秒时间。要求返回从顶点0开始并回到该顶点的最小花费时间，以收集树中的所有苹果。
//树的边由数组 edges 给出，其中 edges[i] = [ai, bi] 表示节点 ai 和 bi 之间存在一条边。此外，还有一个布尔数组 hasApple，其中 hasApple[i] = true 表示节点 i 上有一个苹果；否则，表示该节点上没有苹果。
//思路：（构建无向图的邻接表表示。使用深度优先搜索（DFS）遍历树，同时计算从根节点到子节点的最小花费时间。每次遍历到一个节点时，判断该节点上是否有苹果，当前节点没有苹果，但是子集有；当前节点子集没有苹果，但是自己有苹果;花费时间加2秒（来回走一条边需要2秒）。
//注：当前节点没有苹果，但是子集有；当前节点子集没有苹果，但是自己有苹果；都+2；
//时间复杂度: O(N)，其中 N 是树的节点数量，每个节点只遍历一次。
//空间复杂度：O(N)，用于存储邻接表和访问节点的集合。
        public int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0];
                int v = edges[i][1];
                if (!graph.ContainsKey(u))
                {
                    graph[u] = new List<int>();
                }
                if (!graph.ContainsKey(v))
                {
                    graph[v] = new List<int>();
                }
                graph[u].Add(v);
                graph[v].Add(u);
            }

            return DFS_MinTime(0, hasApple, graph, new HashSet<int>());
        }

        private int DFS_MinTime(int node, IList<bool> hasApple, Dictionary<int, List<int>> graph, HashSet<int> visited)
        {
            visited.Add(node);
            int cost = 0;

            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    cost += DFS_MinTime(neighbor, hasApple, graph, visited);
                }
            }
            //大前提root不用考虑；
            //当前节点没有苹果，但是子集有；
            if (cost > 0 && node!=0)
            {
                cost += 2; // 来回走一条边需要2秒
            }
            //当前节点子集没有苹果，但是自己有苹果；
            if(cost==0 && hasApple[node]&&node!=0)
            {
                cost += 2; // 来回走一条边需要2秒
            }            
            return cost;
        }