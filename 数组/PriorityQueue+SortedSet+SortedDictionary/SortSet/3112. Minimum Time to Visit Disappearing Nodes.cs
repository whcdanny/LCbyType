//Leetcode 3112. Minimum Time to Visit Disappearing Nodes med
//题目：我们有一个无向图，图中有 n 个节点。给定一个二维数组 edges，其中 edges[i] = [ui, vi, lengthi] 描述了一个节点 ui 和节点 vi 之间有一条边，边的长度是 lengthi 单位。
//另外，给定一个数组 disappear，其中 disappear[i] 表示节点 i 消失的时间。如果节点 i 在某个时刻消失，则无法在该时间之后访问这个节点。
//图可能是非连通的，并且可能包含多条边。
//请返回一个数组 answer，其中 answer[i] 表示从节点 0 到达节点 i 所需的最短时间。如果节点 i 无法从节点 0 到达，则 answer[i] 为 -1。
//思路: SortedSet 代替 PriorityQueue 
//先建立图，然后用sortedSet按照从小到大排序
//然后从0node开始，是[0,0]表示node和time
//然后根据图来找到相连接的node，然后查看当前time+连接的length是否小于disappear[当前的node]
//从中删除时间最小的节点set。如果该节点尚未被访问过，ans则用当前时间更新，set如果到达邻居的时间小于邻居消失的时间，则将其所有邻居添加到。
//时间复杂度：O(ElogE)
//空间复杂度：O(N+E)
        public int[] MinimumTime(int n, int[][] edges, int[] disappear)
        {
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
            foreach (var edge in edges)
            {
                int u = edge[0], v = edge[1], time = edge[2];
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int[]>();
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int[]>();
                graph[u].Add(new int[] { v, time });
                graph[v].Add(new int[] { u, time });
            }

            var set = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) => a[1] != b[1] ? a[1] - b[1] : a[0] - b[0]));
            set.Add(new int[] { 0, 0 });

            int[] ans = new int[n];
            Array.Fill(ans, -1);

            while (set.Count > 0)
            {
                int[] cur = set.Min;
                set.Remove(set.Min);
                int node = cur[0], time = cur[1];
                if (ans[node] != -1)
                    continue;

                ans[node] = time;
                if (graph.ContainsKey(node))
                {
                    foreach (var connectedNode in graph[node])
                    {
                        if (ans[connectedNode[0]] == -1 && time + connectedNode[1] < disappear[connectedNode[0]])
                            set.Add(new int[] { connectedNode[0], time + connectedNode[1] });
                    }
                }
            }

            return ans;
        }