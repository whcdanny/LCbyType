//Leetcode 1971. Find if Path Exists in Graph ez
//题意：给定一个无向图，图中有n个节点，编号从0到n-1。你被给定一个二维整数数组edges，其中edges[i] = [ai, bi]表示图中有一条连接节点ai和节点bi的边。你还被给定两个节点start和target，请判断从节点start是否存在一条路径到达节点target。如果存在，返回true；否则，返回false。
//思路：DFS, 先建立双向图，然后从起始点开始查找，如果没找到终点，那么false 反之true
//时间复杂度: O(N + E)，其中N是顶点数，E是图中的边数
//空间复杂度：O(N + E)，其中N是顶点数，E是图中的边数
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            //建图
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge[0]))
                {
                    graph[edge[0]] = new List<int>();
                }
                if (!graph.ContainsKey(edge[1]))
                {
                    graph[edge[1]] = new List<int>();
                }
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
           
            HashSet<int> visited = new HashSet<int>();
            
            return DFS_ValidPath(graph, visited, source, destination);
        }

        private bool DFS_ValidPath(Dictionary<int, List<int>> graph, HashSet<int> visited, int current, int destination)
        {            
            if (current == destination)
            {
                return true;
            }
            
            visited.Add(current);
            
            if (graph.ContainsKey(current))
            {
                foreach (var neighbor in graph[current])
                {                    
                    if (!visited.Contains(neighbor))
                    {
                        if (DFS_ValidPath(graph, visited, neighbor, destination))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }