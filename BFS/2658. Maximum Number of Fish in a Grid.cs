//Leetcode 2658. Maximum Number of Fish in a Grid  mid
//题意：给定一个 m x n 的二维矩阵 grid，其中每个单元格 (r, c) 表示：如果 grid[r][c] = 0，表示这是一块陆地。如果 grid[r][c] > 0，表示这是一个水域，同时包含 grid[r][c] 条鱼。一个捕鱼者可以从任意一个水域单元格(r, c) 开始，并可以执行以下操作任意次数：捕获单元格(r, c) 中的所有鱼，或者移动到任意相邻的水域单元格。要求返回捕鱼者在选择起始单元格时能够捕获到的最大鱼数，如果没有水域单元格存在则返回 0。
//思路：广度优先搜索（BFS）首先，首先，我们需要找到所有的水域单元格，然后从每个水域单元格开始进行BFS遍历。在BFS过程中，我们会记录已经捕获到的鱼的数量，并在每次移动时更新最大值。
//时间复杂度: 遍历整个矩阵需要 O(mn) 的时间复杂度，每次BFS遍历需要 O(mn) 的时间复杂度，所以总体的时间复杂度为 O(m^2 * n^2)。
//空间复杂度：O(m*n)
        public int FindMaxFish(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };            
            List<(int, int)> waters = new List<(int, int)>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        waters.Add((i, j));
                    }
                }
            }
            int maxFish = 0;
            bool[,] visite = new bool[m, n];
            foreach (var (x, y) in waters){
                if (visite[x, y] == true)
                    continue;
                Queue<(int, int)> queue = new Queue<(int, int)>();                
                queue.Enqueue((x, y));
                visite[x, y] = true;
                int curr = grid[x][y];                
                while (queue.Count > 0)
                {
                    (int qx, int qy) = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        int nx = qx + dir[0];
                        int ny = qy + dir[1];
                        if (nx >= 0 && nx < m && ny >= 0 && ny < n && waters.Contains((nx, ny))&&!visite[nx, ny])
                        {
                            queue.Enqueue((nx, ny));
                            visite[nx, ny] = true;
                            curr += grid[nx][ny];
                        }                        
                    }

                }
                maxFish = Math.Max(maxFish, curr);
            }
            return maxFish;
        }