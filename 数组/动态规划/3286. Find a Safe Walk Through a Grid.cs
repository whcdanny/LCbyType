//Leetcode 3286. Find a Safe Walk Through a Grid med
//题目：给定一个 m x n 的二进制矩阵 grid 和一个整数 health，表示健康值。你从左上角的 (0, 0) 开始，目标是到达右下角的 (m - 1, n - 1)。你可以在矩阵中上下左右移动，只要你的健康值是正数。
//如果 grid[i][j] = 1，表示该格子是不安全的，会减少你的健康值 1。如果 grid[i][j] = 0，表示该格子是安全的，不会减少你的健康值。
//要求判断是否能在健康值大于或等于 1 的情况下到达右下角。如果可以，则返回 true，否则返回 false。
//思路：动态规划+DFS 
//初始化dp，然后分别是行，列，健康值，初始值都为-1
//用dfs搜索，从0，0开始查找 每个dp[x, y, health] = (up || down || left || right) ? 1 : 0;取决于上下左右是否有一个可以在不死亡的情况下通过
//时间复杂度：O(m * n * health)，其中 m 和 n 分别是网格的行数和列数，health 是初始健康值。
//空间复杂度：O(m * n * health)
        public bool FindSafeWalk(IList<IList<int>> grid, int health)
        {           
            // 获取网格的行数和列数
            int rows = grid.Count;
            int cols = grid[0].Count;
            bool[,] visited = new bool[rows, cols];

            // 初始化动态规划数组 dp
            int[,,] dp = new int[rows, cols, health + 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int h = 0; h <= health; h++)
                    {
                        dp[i, j, h] = -1;
                    }
                }
            }

            // 从 (0,0) 开始调用递归方法
            return FindSafeWalk_DFS(0, 0, grid, health, dp, visited);
        }

        private bool FindSafeWalk_DFS(int x, int y, IList<IList<int>> grid, int health, int[,,] dp, bool[,] visited)
        {
            int rows = grid.Count;
            int cols = grid[0].Count;
            // 检查当前坐标是否合法、是否已访问过或健康值是否小于等于 0
            if (!IsValid(x, y, rows, cols) || visited[x, y] || health <= 0)
            {
                return false;
            }

            // 如果到达右下角，判断健康值是否大于该位置的值
            if (x == rows - 1 && y == cols - 1)
            {
                return health > grid[x][y];
            }

            // 如果已经计算过该位置的结果，直接返回
            if (dp[x, y, health] != -1)
            {
                return dp[x, y, health] == 1;
            }

            // 标记当前单元格为已访问
            visited[x, y] = true;

            // 减少健康值
            health -= grid[x][y];

            // 递归探索四个方向
            bool up = FindSafeWalk_DFS(x - 1, y, grid, health, dp, visited);
            bool down = FindSafeWalk_DFS(x + 1, y, grid, health, dp, visited);
            bool left = FindSafeWalk_DFS(x, y - 1, grid, health, dp, visited);
            bool right = FindSafeWalk_DFS(x, y + 1, grid, health, dp, visited);

            // 恢复健康值，并标记为未访问
            health += grid[x][y];
            visited[x, y] = false;

            // 将结果存入动态规划数组
            dp[x, y, health] = (up || down || left || right) ? 1 : 0;

            return up || down || left || right;
        }

        private bool IsValid(int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols;
        }