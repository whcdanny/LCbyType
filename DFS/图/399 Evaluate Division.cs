//Leetcode 399 Evaluate Division med
//题意：给定一些字符串对和它们之间的比值，要求求解出特定的除法表达式的结果。比如说，如果已知 a/b = 2.0 和 b/c = 3.0，那么要求计算 a/c 的值。
//思路：深度优先搜索（DFS）: 建一个图，用来表示字符串之间的关系以及比值。比如对于 a/b = 2.0，可以在图中添加两条边 a -> b 和 b -> a，边的权重为 2.0。对于要求解的表达式 a/c，可以通过 DFS 在图中搜索从 a 到 c 的路径，并将路径上的权重相乘得到最终结果。
//时间复杂度:  符串的长度为 n, O(n^n)
//空间复杂度： O(n)
        public double[] CalcEquation(List<List<string>> equations, double[] values, List<List<string>> queries)
        {
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < equations.Count; i++)
            {
                string u = equations[i][0];
                string v = equations[i][1];
                double w = values[i];

                if (!graph.ContainsKey(u))
                {
                    graph[u] = new Dictionary<string, double>();
                }
                if (!graph.ContainsKey(v))
                {
                    graph[v] = new Dictionary<string, double>();
                }

                graph[u][v] = w;
                graph[v][u] = 1.0 / w;
            }

            double[] results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                string start = queries[i][0];
                string end = queries[i][1];
                HashSet<string> visited = new HashSet<string>();
                results[i] = CalcEquation_DFS(graph, start, end, 1.0, visited);
                if (results[i] == 0.0)
                {
                    results[i] = -1.0;
                }
            }

            return results;
        }

        private double CalcEquation_DFS(Dictionary<string, Dictionary<string, double>> graph, string start, string end, double result, HashSet<string> visited)
        {
            if (!graph.ContainsKey(start) || visited.Contains(start))
            {
                return 0.0;
            }

            if (start == end)
            {
                return result;
            }

            visited.Add(start);
            foreach (var neighbor in graph[start])
            {
                double subResult = CalcEquation_DFS(graph, neighbor.Key, end, result * neighbor.Value, visited);
                if (subResult != 0.0)
                {
                    return subResult;
                }
            }
            visited.Remove(start);

            return 0.0;
        }