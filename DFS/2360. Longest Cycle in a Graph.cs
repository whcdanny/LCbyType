//Leetcode 2360. Longest Cycle in a Graph hard
//题意：给定一个包含 n 个节点的有向图，节点编号从 0 到 n - 1。每个节点最多有一条出边。图用一个长度为 n 的数组 edges 表示，其中 edges[i] 的值表示从节点 i 出发的边的目标节点。如果节点 i 没有出边，则 edges[i] 为 -1。
//要求返回图中最长的环的长度。如果图中不存在环，则返回 -1。
//思路：深度优先搜索 (DFS) 的方式，从0开始 一个一个找，找loop就跟最大数比，直到都访问结束
//注：因为每个node只有一个朝一个node的路。可以被理解，一个点只能由一个环如果有的话。
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int maxLength_LongestCycle = -1;
        public int LongestCycle(int[] edges)
        {
            Dictionary<int, int> nodeIndexMap = new Dictionary<int, int>();
            bool[] visited = new bool[edges.Length];

            for (int i = 0; i < edges.Length; i++)
            {
                if (!nodeIndexMap.ContainsKey(i))
                {
                    DFS_LongestCycle(edges, i, 0, nodeIndexMap, visited);
                }
            }

            return maxLength_LongestCycle;
        }

        private void DFS_LongestCycle(int[] edges, int currentNode, int index, Dictionary<int, int> nodeIndexMap, bool[] visited)
        {
            if (currentNode == -1 || edges[currentNode] == -1)
            {
                return;
            }

            visited[currentNode] = true;
            nodeIndexMap.Add(currentNode, index++);

            if (nodeIndexMap.ContainsKey(edges[currentNode]))
            {
                if (visited[edges[currentNode]])
                {
                    maxLength_LongestCycle = Math.Max(maxLength_LongestCycle, index - nodeIndexMap[edges[currentNode]]);
                }
            }
            else
            {
                DFS_LongestCycle(edges, edges[currentNode], index, nodeIndexMap, visited);
            }

            visited[currentNode] = false;
        }