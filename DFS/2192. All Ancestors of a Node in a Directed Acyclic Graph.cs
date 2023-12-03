//Leetcode 2192. All Ancestors of a Node in a Directed Acyclic Graph med
//题意：给定一个有向无环图（DAG），表示为节点数为n（从0到n-1）的图。还给定一个二维整数数组edges，表示图中的有向边。要求返回一个列表answer，其中answer[i]是第i个节点的祖先列表，按升序排列。        
//思路：深度优先搜索 (DFS),DFS（深度优先搜索）遍历图，找到每个节点的祖先。在DFS的过程中，使用一个集合（HashSet）来记录每个节点的祖先，以避免重复。
//注：这里建图的时候只需要找到每个点的父亲，也就是 graph[to].Add(from); 不要graph[from].Add(to);
//时间复杂度: O(V+E)
//空间复杂度：O(V+E)
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            List<int>[] graph = BuildGraph(n, edges);
            List<IList<int>> ancestors = new List<IList<int>>();

            for (int i = 0; i < n; i++)
            {
                HashSet<int> visited = new HashSet<int>();
                List<int> ancestorSet = DFS_GetAncestors(graph, i, visited);
                ancestorSet.Sort();
                ancestors.Add(ancestorSet);
            }

            return ancestors;
        }

        private List<int>[] BuildGraph(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                int from = edge[0];
                int to = edge[1];
                graph[to].Add(from);
            }

            return graph;
        }

        private List<int> DFS_GetAncestors(List<int>[] graph, int node, HashSet<int> visited)
        {
            List<int> res = new List<int>();
            foreach (int neighbor in graph[node])
            {
                if (visited.Contains(neighbor))
                    continue;
                visited.Add(neighbor);
                List<int> temp = DFS_GetAncestors(graph, neighbor, visited);
                temp.Add(neighbor);
                res.AddRange(temp);
            }
            return res;
        }