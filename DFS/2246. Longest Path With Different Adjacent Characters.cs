//Leetcode 2246. Longest Path With Different Adjacent Characters hard
//题意：给定一个树（即一个连接的、无环的图）以节点0为根，包含了从0到n-1编号的n个节点。树由一个大小为n的0索引数组parent表示，其中parent[i]是节点i的父节点。由于节点0是根，parent[0] == -1。
//还给定一个长度为n的字符串s，其中s[i] 是分配给节点i的字符。
//返回树中最长路径的长度，使得路径上的相邻节点没有相同的字符。        
//思路：深度优先搜索 (DFS),构建树的邻接, 确保相邻节点没有相同的字符;
//注：只要相邻的字母不重复就行。因为每个node最多有左右两个，所以总和也只有两个，然后找出最大的，用于迭代的计算。
//时间复杂度: O(N)，其中 N 是树中的节点数量。我们需要遍历每个节点一次。
//空间复杂度：O(N)，使用了额外的空间来存储树的邻接表和访问数组。       
        private int outputLongestPath = 0;                       
        public int LongestPath(int[] parent, string s)
        {
            List<List<int>> graphLongestPath = new List<List<int>>();
            //initialization            
            for (int i = 0; i < parent.Length; i++)
            {
                graphLongestPath.Add(new List<int>());
            }
            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] == -1) continue;
                graphLongestPath[parent[i]].Add(i);
            }

            DFS_LongestPath(0, graphLongestPath, s);
            return outputLongestPath;
        }

        private int DFS_LongestPath(int cur, List<List<int>> graphLongestPath, string s)
        {
            //一个node会有左右两个总和值，分别找出当前最大和另外一个值
            int largest = 0;
            int second = 0;            
            for (int i = 0; i < graphLongestPath[cur].Count(); i++)
            {
                int path = DFS_LongestPath(graphLongestPath[cur][i], graphLongestPath, s);
                if (s[graphLongestPath[cur][i]] == s[cur]) continue;

                if (path > largest)
                {
                    second = largest;
                    largest = path;
                }
                else if (path > second)
                {
                    second = path;
                }
            }
            //如果当前node的总和最大，更新
            if (largest + second + 1 > outputLongestPath)
            {
                outputLongestPath = largest + second + 1;
            }

            //给出当前最大的值；
            return largest + 1;
        }
        public int LongestPath1(int[] parent, string s)//会超时
        {
            Dictionary<int, List<int>> graph = BuildGraph(parent);
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                DFS_LongestPath(s, graph, i, -1, s[i], 1, ref maxLength);
            }

            return maxLength;
        }

        private Dictionary<int, List<int>> BuildGraph(int[] parent)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < parent.Length; i++)
            {
                if (!graph.ContainsKey(i)) graph[i] = new List<int>();
                if (parent[i] != -1)
                {
                    if (!graph.ContainsKey(parent[i])) graph[parent[i]] = new List<int>();
                    graph[parent[i]].Add(i);
                    graph[i].Add(parent[i]);
                }
            }
            return graph;
        }

        private void DFS_LongestPath(string s, Dictionary<int, List<int>> graph, int node, int parent, char prevChar, int currentLength, ref int maxLength)
        {
            maxLength = Math.Max(maxLength, currentLength);

            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue;
                if (prevChar != s[neighbor])
                {
                    DFS_LongestPath(s, graph, neighbor, node, s[neighbor], currentLength + 1, ref maxLength);
                }
            }
        }
