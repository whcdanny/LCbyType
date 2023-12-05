//Leetcode 1466. Reorder Routes to Make All Paths Lead to the City Zero med
//题意：有一个城市，编号为 0 到 n-1。城市之间的道路以及方向用数组 connections 表示，其中 connections[i] = [a, b] 表示一条从城市 a 到城市 b 的有向道路。现在，我们想使所有城市都有一个新的通路，使得路径总和最小。可以通过在某些道路上改变方向来实现。给定道路图 connections（形式为有向边列表），你需要重新插入所有的道路。每个城市都有一个唯一的编号，城市图中所有边都是 有向的。两个城市之间只有一条道路。返回能使所有城市都有一条新的通路的最小可能总路径。
//思路： 构建图的邻接表，将道路的原始方向和反向分别表示为正数和负数。使用深度优先搜索（DFS）遍历图。对于每个节点，检查它的邻居，如果邻居是原始方向（正数），则需要改变方向，并递归遍历邻居节点。
//注：这里用负数代表反转，然后逻辑就是为了让所有点直到0，那么就必须把从0以及父节点历遍到的子节点的全部反转，那么只要遇到有正值，那么肯定要反转；
//时间复杂度: O(N), 其中 N 是城市的数量
//空间复杂度：O(N), 其中 N 是城市的数量
        private int changes_MinReorder = 0;
        public int MinReorder(int n, int[][] connections)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            // Build the graph
            foreach (var connection in connections)
            {
                int from = connection[0];
                int to = connection[1];
                graph[from].Add(to);
                graph[to].Add(-from); // 用负数代表反转路线；
            }


            DFS_MinReorder(graph, 0, -1);

            return changes_MinReorder;
        }

        private void DFS_MinReorder(List<int>[] graph, int current, int parent)
        {
            foreach (var neighbor in graph[current])
            {
                if (neighbor > 0 && neighbor != parent)
                {
                    changes_MinReorder++; // 说明当前边需要反向
                    DFS_MinReorder(graph, neighbor, current);
                }
                else if (neighbor < 0  && -neighbor != parent)
                {
                    DFS_MinReorder(graph, -neighbor, current);
                }
            }
        }