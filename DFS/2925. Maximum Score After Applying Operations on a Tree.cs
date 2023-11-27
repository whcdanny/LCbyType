//Leetcode 2925. Maximum Score After Applying Operations on a Tree med
//题意：有一棵包含n个节点的无向树，节点从0到n-1标记，并以节点0为根。给定长度为n-1的二维整数数组edges，其中edges[i]=[ai, bi]表示树中节点ai和bi之间有一条边。同时，给定一个长度为n的整数数组values，其中values[i] 表示与第i个节点相关联的值。初始时，你的得分为0。在每次操作中，你可以执行以下操作之一：选择一个节点i。将values[i] 添加到你的得分中。将values[i] 设置为0。如果从根到任何叶节点的路径上的值之和不为零，则树被认为是“健康”的。返回在执行任意次数的操作后，使得树保持“健康”的情况下，你能够获得的最大得分。
//思路：深度优先搜索（DFS），用反向思维，求最大，那么就用总和减去每一个分支的最小，: 先建立一个graph，并算出整个的总和，从root开始，一直找到最底层，然后每一个分支的总和和父级去比谁更小，然后得出一个最小的总和，然后用总和-最小和
//时间复杂度:  n为网格中的空白单元格和非空单元格的总数量，O(n*n)
//空间复杂度： n为网格中的空白单元格和非空单元格的总数量, O(n)
        public long MaximumScoreAfterOperations(int[][] edges, int[] values)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge[0]))
                    graph[edge[0]] = new List<int>();

                if (!graph.ContainsKey(edge[1]))
                    graph[edge[1]] = new List<int>();

                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            //Sum
            long res = 0;
            for (int i = 0; i < values.Length; i++)
            {
                res += values[i];
            }
            return res - getMin(0, -1, values, graph);
        }

        private long getMin(int node, int prev, int[] values, Dictionary<int, List<int>> graph)
        {
            long res = 0;
            foreach (int n in graph[node])
            {
                if (n == prev) continue;
                res += getMin(n, node, values, graph);
            }
            if (res == 0) return (long)values[node];
            else return Math.Min(res, values[node]);
        }