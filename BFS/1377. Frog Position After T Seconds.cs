//Leetcode 1377. Frog Position After T Seconds hard
//题意：给定一棵由编号为到 的n顶点组成的无向树。青蛙从顶点 1开始跳跃。一秒钟内，青蛙从当前顶点跳到另一个未访问过的顶点（如果它们直接相连）。青蛙无法跳回访问过的顶点。如果青蛙可以跳到多个顶点，它会以相同的概率随机跳到其中一个顶点。否则，当青蛙无法跳到任何未访问过的顶点时，它就会永远在同一个顶点上跳跃。1n 无向树的边在数组 中给出edges，其中表示存在连接顶点和 的边。edges[i] = [ai, bi]aibit返回几秒后青蛙位于顶点的概率target。实际答案内的答案将被接受。10-5
//思路：BFS（广度优先搜索）遍历图，同时记录概率。在每个节点，将概率均分给未访问的邻居节点。
//时间复杂度: O(n)
//空间复杂度：O(n)
        public double FrogPosition(int n, int[][] edges, int t, int target)
        {
            List<int>[] graph = new List<int>[n + 1];
            bool[] visit = new bool[n + 1];
            visit[1] = true;
            for (int i = 0; i < graph.Length; i++) 
                graph[i] = new List<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                int v1 = edges[i][0], v2 = edges[i][1];
                graph[v1].Add(v2);
                graph[v2].Add(v1);
            }
            Queue<(int, double)> queue = new Queue<(int, double)>();
            queue.Enqueue((1,1.0));
            while (queue.Count > 0 && t-- > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    (int node, double val) = queue.Dequeue();
                    int childCount = 0;
                    foreach (var v in graph[node])
                        if (!visit[v]) 
                            childCount++;
                    if (node == target && childCount == 0) 
                        return val;
                    else if (node == target) 
                        return 0.0;
                    foreach (var v in graph[node])
                    {
                        if (visit[v]) continue;
                        visit[v] = true;
                        queue.Enqueue((v, val / childCount));
                    }
                }
            }
            while (queue.Count > 0)
            {
                (int node, double val) = queue.Dequeue();
                if (node == target) return val;
            }
            return 0.0;
        }