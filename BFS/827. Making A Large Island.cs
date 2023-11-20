//Leetcode 827. Making A Large Island hard
//题意：给定一个包含值为 0 或 1 的矩阵 grid，其中 1 表示陆地，0 表示水域。我们可以通过将水域格子填平来扩大陆地，使得陆地最终的面积最大。计算在填平水域的情况下，最大的陆地面积是多少。
//思路：可以使用 BFS 进行解决。广度优先搜索（BFS）来找到每个连通块的大小。接下来，对于每个水域格子，我们将其变成陆地，并计算整个矩阵的新陆地面积。最后，找到最大的陆地面积即为答案。
//时间复杂度: O(N^2)，其中 N 为矩阵的边长
//空间复杂度：O(N^2)，其中 N 为矩阵的边长
        public int LargestIsland(int[][] grid)
        {
            int n = grid.Length;
            int maxArea = 0;
            int islandIndex = 2; // 用于标记不同的连通块

            Dictionary<int, int> areaMap = new Dictionary<int, int>(); // 保存每个连通块的面积

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int area = BFS__LargestIsland(grid, i, j, islandIndex);
                        areaMap[islandIndex] = area;
                        maxArea = Math.Max(maxArea, area);
                        islandIndex++;
                    }
                }
            }

            // 遍历水域格子，计算填平后的最大陆地面积
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        HashSet<int> neighbors = GetNeighbors(grid, i, j);
                        int totalArea = 1; // 初始面积为 1，表示当前水域格子填平后的陆地面积
                        foreach (int neighbor in neighbors)
                        {
                            totalArea += areaMap[neighbor];
                        }
                        maxArea = Math.Max(maxArea, totalArea);
                    }
                }
            }

            return maxArea;
        }

        private int BFS__LargestIsland(int[][] grid, int row, int col, int islandIndex)
        {
            int n = grid.Length;
            int area = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { row, col });

            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                int r = curr[0];
                int c = curr[1];

                if (r < 0 || r >= n || c < 0 || c >= n || grid[r][c] != 1)
                {
                    continue;
                }

                grid[r][c] = islandIndex; // 标记为当前连通块
                area++;

                // 添加相邻的陆地格子到队列
                queue.Enqueue(new int[] { r + 1, c });
                queue.Enqueue(new int[] { r - 1, c });
                queue.Enqueue(new int[] { r, c + 1 });
                queue.Enqueue(new int[] { r, c - 1 });
            }

            return area;
        }

        private HashSet<int> GetNeighbors(int[][] grid, int row, int col)
        {
            int n = grid.Length;
            HashSet<int> neighbors = new HashSet<int>();

            if (row + 1 < n && grid[row + 1][col] != 0)
            {
                neighbors.Add(grid[row + 1][col]);
            }
            if (row - 1 >= 0 && grid[row - 1][col] != 0)
            {
                neighbors.Add(grid[row - 1][col]);
            }
            if (col + 1 < n && grid[row][col + 1] != 0)
            {
                neighbors.Add(grid[row][col + 1]);
            }
            if (col - 1 >= 0 && grid[row][col - 1] != 0)
            {
                neighbors.Add(grid[row][col - 1]);
            }

            return neighbors;
        }