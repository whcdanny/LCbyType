//Leetcode 1377. Frog Position After T Seconds hard
//题意：给定一棵由编号为到 的n顶点组成的无向树。青蛙从顶点 1开始跳跃。一秒钟内，青蛙从当前顶点跳到另一个未访问过的顶点（如果它们直接相连）。青蛙无法跳回访问过的顶点。如果青蛙可以跳到多个顶点，它会以相同的概率随机跳到其中一个顶点。否则，当青蛙无法跳到任何未访问过的顶点时，它就会永远在同一个顶点上跳跃。1n 无向树的边在数组 中给出edges，其中表示存在连接顶点和 的边。edges[i] = [ai, bi]aibit返回几秒后青蛙位于顶点的概率target。实际答案内的答案将被接受。10-5
//思路：深度优先搜索（DFS）遍历树。在每个节点上，计算跳跃到相邻节点的概率，递归地向下遍历。注意需要处理父节点，避免重复跳跃。
//注：青蛙在该节点上不会停留，因为青蛙每秒钟会随机跳到一个相邻的未访问节点。当一个节点有子节点时，青蛙总是会选择跳到其中一个子节点而不停留在当前节点。所以要在跳过之和set0
//时间复杂度: O(n)
//空间复杂度：O(n)
        public double FrogPosition(int n, int[][] edges, int t, int target)
        {
            List<int>[] graph = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            double[] probabilities = new double[n + 1];
            probabilities[1] = 1.0;

            DFS_FrogPosition(graph, probabilities, 1, -1, t, target);

            return probabilities[target];
        }

        private void DFS_FrogPosition(List<int>[] graph, double[] probabilities, int current, int parent, int t, int target)
        {
            if (t == 0)
            {
                return;
            }

            int childCount = 0;
            foreach (var neighbor in graph[current])
            {
                if (neighbor != parent)
                {
                    childCount++;
                }
            }

            foreach (var neighbor in graph[current])
            {
                if (neighbor != parent)
                {
                    probabilities[neighbor] = probabilities[current] / childCount;
                    DFS_FrogPosition(graph, probabilities, neighbor, current, t - 1, target);
                }
            }
            //青蛙在该节点上不会停留，因为青蛙每秒钟会随机跳到一个相邻的未访问节点。当一个节点有子节点时，青蛙总是会选择跳到其中一个子节点而不停留在当前节点。所以要在跳过之和set0'
            if (childCount > 0)
            {
                probabilities[current] = 0.0; 
            }
        }