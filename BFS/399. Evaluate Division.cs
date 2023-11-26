//Leetcode 399. Evaluate Division med
//题意：给定一组除法式的计算，例如 equations = [["a","b"],["b","c"]] 表示 a/b = b/c。同时给定一组除法的结果 values = [2.0, 3.0] 表示上述等式的结果分别是 2.0 和 3.0。求解一组查询，例如 queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]，并返回对应的计算结果，如果无法计算则返回 -1.0。
//思路：(BFS)首先，将除法式的信息构建成一个图，然后对每个查询进行广度优先搜索，计算结果
//时间复杂度: 对于每个查询，都要进行一次广度优先搜索，因此时间复杂度是 O(Q * (V + E))，其中 Q 是查询数量，V 是变量的数量，E 是边的数量。
//空间复杂度：O(V + E)
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Dictionary<string, double>> graph = BuildGraph(equations, values);
            double[] results = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                results[i] = BFS_CalcEquation(graph, queries[i][0], queries[i][1]);
            }

            return results;
        }

        private Dictionary<string, Dictionary<string, double>> BuildGraph(IList<IList<string>> equations, double[] values)
        {
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < equations.Count; i++)
            {
                string u = equations[i][0];
                string v = equations[i][1];
                double value = values[i];

                if (!graph.ContainsKey(u))
                {
                    graph[u] = new Dictionary<string, double>();
                }
                if (!graph.ContainsKey(v))
                {
                    graph[v] = new Dictionary<string, double>();
                }

                graph[u][v] = value;
                graph[v][u] = 1.0 / value;
            }

            return graph;
        }

        private double BFS_CalcEquation(Dictionary<string, Dictionary<string, double>> graph, string start, string end)
        {
            if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
            {
                return -1.0;
            }

            if (start == end)
            {
                return 1.0;
            }

            Queue<(string, double)> queue = new Queue<(string, double)>();
            HashSet<string> visited = new HashSet<string>();
            queue.Enqueue((start, 1.0));

            while (queue.Count > 0)
            {
                (string node, double value) = queue.Dequeue();
                visited.Add(node);

                foreach (var neighbor in graph[node])
                {
                    string nextNode = neighbor.Key;
                    double nextValue = neighbor.Value;

                    if (!visited.Contains(nextNode))
                    {
                        double result = value * nextValue;
                        if (nextNode == end)
                        {
                            return result;
                        }
                        queue.Enqueue((nextNode, result));
                    }
                }
            }

            return -1.0; // Unable to reach the end node.
        }