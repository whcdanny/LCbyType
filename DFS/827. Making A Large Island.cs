//Leetcode 827. Making A Large Island hard
//题意：给定一个二维矩阵 grid，其中 0 表示水域，1 表示陆地。我们可以通过将任意一块水域变为陆地来使岛屿的面积最大化。在此过程中，我们需要确保网格中的每个 1 都是联通的，即从任意一个 1 到达任意一个 1 都必须经过一系列的水域。
//请计算在执行此操作之后，岛屿的最大面积是多少。如果没有岛屿，返回 0。
//思路：DFS, DFS 连通区域并计算面积： 遍历矩阵，当遇到岛屿（grid[i][j] == 1）时，使用深度优先搜索（DFS）来找到与该岛屿相连的所有岛屿，并标记这些岛屿。同时，统计连通区域的面积。
//遍历 0 的位置： 遍历矩阵，对于每个水域（grid[i][j] == 0），尝试将其变为陆地（grid[i][j] = 1），并重新进行深度优先搜索，找到与新变成的陆地相连的所有岛屿。然后计算新的面积，并将水域还原。
//最大面积的计算： 在遍历过程中，不断更新最大面积。
//注：islandIndex = 2; 用于标记不同的岛屿，避免与水域 0 冲突, 比如有两个不相连的岛屿，那么就是areaMap[2], areaMap[3]。这样当我们反转一个0的时候，如果相连2，那么就直接面积+1；
//时间复杂度: O(m * n)，其中 m 和 n 分别是矩阵的行数和列数
//空间复杂度：O(m * n)
        public int LargestIsland(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int maxArea = 0;
            int islandIndex = 2; // 用于标记不同的岛屿，避免与水域 0 冲突
            int[][] directions = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            Dictionary<int, int> areaMap = new Dictionary<int, int>(); // 记录每个岛屿的面积

            // DFS 遍历并计算岛屿面积
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int area = DFS_LargestIsland(grid, i, j, islandIndex);
                        areaMap[islandIndex] = area;
                        maxArea = Math.Max(maxArea, area);
                        islandIndex++;
                    }
                }
            }

            // 遍历 0 的位置，尝试将水域变为陆地并计算新的面积
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        HashSet<int> neighbors = new HashSet<int>();
                        int area = 1; // 初始面积为 1（当前水域变成陆地）

                        foreach (var dir in directions)
                        {
                            int ni = i + dir[0];
                            int nj = j + dir[1];

                            if (IsValid(ni, nj, m, n) && grid[ni][nj] > 1)
                            {
                                neighbors.Add(grid[ni][nj]);
                            }
                        }

                        foreach (var neighbor in neighbors)
                        {
                            area += areaMap[neighbor];
                        }

                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }

            return maxArea;
        }

        // DFS 计算岛屿面积
        private int DFS_LargestIsland(int[][] grid, int i, int j, int islandIndex)
        {
            int[][] directions = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            int m = grid.Length;
            int n = grid[0].Length;

            if (!IsValid(i, j, m, n) || grid[i][j] != 1)
            {
                return 0;
            }

            grid[i][j] = islandIndex; // 标记为当前岛屿的索引
            int area = 1;

            foreach (var dir in directions)
            {
                int ni = i + dir[0];
                int nj = j + dir[1];

                area += DFS_LargestIsland(grid, ni, nj, islandIndex);
            }

            return area;
        }

        private bool IsValid(int i, int j, int m, int n)
        {
            return i >= 0 && i < m && j >= 0 && j < n;
        }
