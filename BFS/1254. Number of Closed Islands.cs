//Leetcode 1254. Number of Closed Islands med
//题意：给定一个由 0 和 1 组成的矩阵 grid，其中 0 表示海洋，1 表示陆地。一个“封闭岛屿”是指这块陆地完全被水包围，并且没有连接到矩阵边界上的陆地。如果一个岛屿的边界上的格子在四个方向上都被水包围，则称这个岛屿是封闭岛屿。计算矩阵中封闭岛屿的数量。
//思路：BFS历遍grid，只要注意如果边界是0表示水，这个就不是岛屿；
//时间复杂度: O(M*N)，其中 M 和 N 分别是矩阵的行数和列数。
//空间复杂度：O(M*N)
        public int ClosedIsland(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var res = 0;

            var visited = new bool[m, n];

            List<int[]> directions = new List<int[]> { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
           
            // Main loop to explore all cells of the grid
            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
                    if (grid[i][j] == 0 && !visited[i, j])
                    {
                        var queue = new Queue<int[]>();
                        queue.Enqueue(new[] { i, j });
                        visited[i, j] = true;

                        var isClosed = true;

                        while (queue.Count > 0)
                        {
                            var curr = queue.Dequeue();

                            foreach(var dir in directions)
                            {
                                var x = curr[0] + dir[0];
                                var y = curr[1] + dir[1];

                                if (x >= 0 && y >= 0 && x < m && y < n)
                                {
                                    if (grid[x][y] != 0 || visited[x, y])
                                        continue;

                                    queue.Enqueue(new[] { x, y });
                                    visited[x, y] = true;
                                }
                                else
                                    isClosed = false;
                            }
                        }

                        if (isClosed)
                            res++;
                    }
                        

            return res;
        }