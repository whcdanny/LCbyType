//Leetcode 1391. Check if There is a Valid Path in a Grid  med
//题意：您将获得一个m x n grid. 的每个单元格grid代表一条街道。的街道grid[i][j]可以是：1这意味着连接左侧单元格和右侧单元格的街道。2这意味着连接上层单元和下层单元的街道。3这意味着连接左侧单元格和下方单元格的街道。4这意味着连接右侧单元格和下方单元格的街道。5这意味着连接左侧单元格和上部单元格的街道。6这意味着连接右侧单元格和上部单元格的街道。true如果网格中存在有效路径则返回，false否则返回。
//思路： BFS 判断是否存在一条有效路径。利用 directions 数组表示每个格子可能的方向。在遍历的过程中，检查相邻格子的连接情况，如果有合法连接，将相邻格子加入队列继续遍历。
//时间复杂度: O(m * n)，其中 m 和 n 分别是行数和列数。
//空间复杂度：O(m * n)
        public bool HasValidPath(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            // Define the possible directions from each cell
            int[][][] directions = new int[][][]
            {
            new int[][] {new int[] {0, 1}, new int[] {0, -1}}, // Horizontal
            new int[][] {new int[] {1, 0}, new int[] {-1, 0}}, // Vertical
            new int[][] {new int[] {0, -1}, new int[] {1, 0}}, // Bottom to Left
            new int[][] {new int[] {0, 1}, new int[] {1, 0}}, // Bottom to Right
            new int[][] {new int[] {-1, 0}, new int[] {0, -1}}, // Top to Left
            new int[][] {new int[] {-1, 0}, new int[] {0, 1}} // Top to Right
            };

            Queue<int[]> queue = new Queue<int[]>();
            bool[,] visited = new bool[m, n];

            queue.Enqueue(new int[] { 0, 0 });
            visited[0, 0] = true;

            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                int x = curr[0];
                int y = curr[1];

                foreach (var direction in directions[grid[x][y] - 1])
                {
                    int nx = x + direction[0];
                    int ny = y + direction[1];

                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny])
                    {
                        foreach (var revDir in directions[grid[nx][ny] - 1])
                        {
                            if (nx + revDir[0] == x && ny + revDir[1] == y)
                            {
                                queue.Enqueue(new int[] { nx, ny });
                                visited[nx, ny] = true;
                                break;
                            }
                        }
                    }
                }
            }

            return visited[m - 1, n - 1];
        }