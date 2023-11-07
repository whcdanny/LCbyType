//Leetcode 2493. Divide Nodes Into the Maximum Number of Groups hard
//题意：给定一个无向图，图中有 n 个节点，编号为 0 到 n-1。你可以从任意节点开始，每次选择一个节点，将与之相邻的所有节点分到一个分组中。同时，你可以选择保留当前节点，继续将相邻节点分组，也可以结束分组。你的目标是将所有节点划分成尽可能多的分组。返回你可以获得的最大分组数。
//思路：我们可以使用BFS（广度优先搜索）,先将给的edges找到不同的成分因为有可能是不连续的；然后根据划分的成分找到最大可能的分组；
//时间复杂度: BuildComponents 方法使用了广度优先搜索 (BFS) 来找到连通分量，其时间复杂度为 O(n + m)，其中 n 为节点数量，m 为边的数量。VisitNeighbors 方法中也使用了广度优先搜索(BFS)，其时间复杂度也为 O(n + m)。O(n + m)，其中 n 为节点数量，m 为边的数量
//空间复杂度：map 变量占用了 O(m) 的空间，其中 m 为边的数量。visited 集合占用了 O(n) 的空间，用于记录节点的访问情况。在 BuildComponents 方法中使用了一个队列 q，最坏情况下会包含所有节点，所以空间复杂度为 O(n)。groups 字典占用了 O(n) 的空间，用于记录节点所属的分组。综合起来，整个算法的空间复杂度为 O(n + m)。
        public int MagnificentSets(int n, int[][] edges)
        {
            var map = new Dictionary<int, List<int>>();

            foreach (var e in edges)
            {
                map.TryAdd(e[0], new List<int>());
                map.TryAdd(e[1], new List<int>());

                map[e[0]].Add(e[1]);
                map[e[1]].Add(e[0]);
            }

            var components = BuildComponents(n, map);
            var res = 0;

            foreach (var comp in components)
            {
                var maxVal = int.MinValue;
                foreach (var root in comp.Value)
                {
                    var temp = VisitNeighbors(root, map);
                    if (temp == -1)
                    {
                        return -1;
                    }
                    maxVal = Math.Max(maxVal, temp);
                }

                res += maxVal;
            }
            return res;
        }

        private Dictionary<int, List<int>> BuildComponents(int n, Dictionary<int, List<int>> map)
        {
            var comp = 1;
            var visited = new HashSet<int>();
            var q = new Queue<int>();
            var res = new Dictionary<int, List<int>>();

            for (int i = 1; i <= n; i++)
            {
                if (!visited.Contains(i))
                {
                    q.Enqueue(i);
                    var compNodes = new List<int>();
                    res.Add(comp, compNodes);

                    while (q.Count > 0)
                    {
                        var node = q.Dequeue();
                        compNodes.Add(node);

                        if (!map.TryGetValue(node, out var neighbors))
                            continue;

                        foreach (var neig in neighbors)
                        {
                            if (!visited.Contains(neig))
                            {
                                q.Enqueue(neig);
                                visited.Add(neig);
                            }
                        }
                    }

                    comp++;
                }
            }

            return res;
        }

        private int VisitNeighbors(int root, Dictionary<int, List<int>> map)
        {
            var groups = new Dictionary<int, int>();

            int currentGroup = 0;
            var q = new Queue<int>();
            q.Enqueue(root);
            groups.Add(root, currentGroup);

            while (q.Count > 0)
            {

                var s = q.Count;

                while (s > 0)
                {
                    var node = q.Dequeue();

                    if (map.TryGetValue(node, out var neighbors))
                    {
                        foreach (var n in neighbors)
                        {
                            if (!groups.TryGetValue(n, out var g))
                            {
                                q.Enqueue(n);
                                groups.Add(n, currentGroup + 1);
                            }
                            else
                            {
                                if (Math.Abs(g - currentGroup) != 1)
                                {
                                    return -1;
                                }
                            }
                        }
                    }

                    s--;
                }

                currentGroup++;
            }

            return currentGroup;
        }