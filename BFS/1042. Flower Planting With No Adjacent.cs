//Leetcode 1042. Flower Planting With No Adjacent med
//题意：您有n花园，标记为1到n，还有一个数组paths，其中描述了 Garden 到 Garden 之间的双向路径。在每个花园中，您想种植 4 种花卉中的一种。连接的任何两个花园，它们都有不同类型的花卉;
//思路：BFS（广度优先搜索）从起点开始，从每个未染色的花园开始，向相邻花园扩展，然后对每个相邻花园选择一种颜色进行染色。这样可以确保我们按照广度优先的顺序进行染色，保证相邻花园的颜色不相同。
//时间复杂度:  O(N + E)，其中 N 为花园的个数，E 为路径的个数。遍历花园需要 O(N) 时间，遍历路径也需要 O(E) 时间。
//空间复杂度： O(N)，用于存储结果数组。
        public int[] GardenNoAdj(int n, int[][] paths)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
            }
            // Build the graph
            foreach (var path in paths)
            {
                graph[path[0]].Add(path[1]);
                graph[path[1]].Add(path[0]);
            }

            int[] result = new int[n];

            // Color the gardens
            for (int i = 1; i <= n; i++)
            {
                if (result[i - 1] == 0)
                {
                    HashSet<int> usedColors = new HashSet<int>();

                    // Check colors used by adjacent gardens
                    foreach (var neighbor in graph[i])
                    {
                        if (result[neighbor - 1] != 0)
                        {
                            usedColors.Add(result[neighbor - 1]);
                        }
                    }

                    // Color the garden with the first available color
                    for (int color = 1; color <= 4; color++)
                    {
                        if (!usedColors.Contains(color))
                        {
                            result[i - 1] = color;
                            break;
                        }
                    }
                }
            }

            return result;
        }