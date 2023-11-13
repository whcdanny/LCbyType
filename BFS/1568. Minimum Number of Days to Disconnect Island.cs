//Leetcode 1568. Minimum Number of Days to Disconnect Island hard
//题意：给你一个m x n二进制网格grid，其中1代表土地，0代表水。岛是最大4 个方向（水平或垂直）连接的组。如果我们只有一个岛屿，则称电网已连接，否则称电网已断开。有一天，我们可以将任何一个陆地单元(1)变成水单元(0)。返回断开电网的最小天数。
//思路： BFS 进行遍历，对于每一个岛屿，使用 BFS 遍历方式，将岛屿的 '1' 串连接的陆地的 '1' 串变成 '0'，然后计算分离后的岛屿数量。
//时间复杂度: O(M*N)，其中 M 和 N 分别是网格的行数和列数。
//空间复杂度：O(MN)
        public int MinDays(int[][] grid)
        {
            if (!isConnected(grid))
                return 0;
            int m = grid.Length;
            int n = grid[0].Length;

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        grid[i][j] = 0;
                        if (!isConnected(grid))
                            return 1;
                        grid[i][j] = 1;
                    }
                }
            }
            return 2;                        
        }

        public bool isConnected(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            bool[,] visited = new bool[m, n];
            List<int[]> directions = new List<int[]> { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(grid[i][j]==1 && !visited[i, j])
                    {
                        Queue<(int, int)> queue = new Queue<(int, int)>();
                        queue.Enqueue((i, j));
                        visited[i, j] = true;
                        count += 1;
                        while (queue.Count > 0)
                        {
                            (int x, int y) = queue.Dequeue();
                            foreach(var dir in directions)
                            {
                                int nx = x + dir[0];
                                int ny = y + dir[1];
                                if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny] && grid[nx][ny] == 1)
                                {
                                    queue.Enqueue((nx, ny));
                                    visited[nx, ny] = true;
                                }
                            }
                        }
                    }
                }
            }

            return count == 1;
        }