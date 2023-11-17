//Leetcode 1020. Number of Enclaves med
//题意：给定一个二维数组 A，其中 0 表示海洋， 1 表示陆地。陆地上的 1 形成一个或多个岛屿，通过水平或垂直连接。我们称一个岛屿为「离岸不远的陆地」，如果这个岛屿内部的所有格子都在其边界上的某个水平或垂直方向上相邻的另一个岛屿上。可以执行以下操作：任何小岛都可以通过填充水来连接到另一个小岛，而不远离陆地。返回可以填充水的小岛的数量。
//思路：BFS（广度优先搜索）岛屿上的每个点，并进行标记。在标记的过程中，如果发现岛屿靠近边界，将该岛屿标记为不可填充，然后不用计算数量；
//时间复杂度:  O(m * n)，其中 m 和 n 分别为数组的行数和列数
//空间复杂度： O(m * n)，其中 m 和 n 分别为数组的行数和列数
        public int NumEnclaves(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            List<int[]> directions = new List<int[]> { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            int ans = 0;
            //find the ones from the grid and put start BFS from there
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //look for land
                    int count = 0;
                    if (grid[i][j] == 1 && !visited.Contains((i,j)))
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                        bool IsBoundary = false;
                        while (queue.Count > 0)
                        {
                            (int row, int col) = queue.Dequeue();
                            grid[row][col] = 0;
                            count++;
                            //any time our land touches to boundary set IsBoundary to true
                            if (row == 0 || col == 0|| row == m - 1|| col == n - 1)
                            {
                                IsBoundary = true;                                
                            }
                            foreach (var dir in directions)
                            {
                                int newRow = row + dir[0];
                                int newCol = col + dir[1];
                                if (newRow >= 0 && newRow < m-1 && newCol >= 0 && newCol < n-1 && grid[newRow][newCol] == 1 && !visited.Contains((newRow, newCol)))
                                {
                                    queue.Enqueue((newRow, newCol));
                                    visited.Add((newRow, newCol));
                                }
                            }
                        }
                        if (IsBoundary) 
                            count = 0;
                        ans += count;
                    }
                }
            }
            return ans;
        }