//Leetcode 694 Number of Distinct Islands med
//题意：给定一个二维网格，其中 1 表示陆地，0 表示水域。我们需要计算岛屿的数量，其中两个岛屿被认为是相同的，当且仅当其中一个岛屿可以通过上、下、左、右的移动变换得到另一个岛屿。
//思路：深度优先搜索（DFS）: 遍历整个二维网格，当找到一个陆地时，开始进行深度优先搜索，将所有连接的陆地标记为已访问，并将它们的相对位置（相对于起始点）记录下来。将相对位置的记录排序，并将它们转化为一个唯一的字符串，作为岛屿的标识。使用一个集合（或哈希表）来记录所有不同岛屿的标识，最终集合的大小就是不同岛屿的数量。
//时间复杂度:  大小为 m x n, O(m*n)
//空间复杂度： O(m*n)
        public int NumDistinctIslands(int[][] grid)
        {
            HashSet<string> islands = new HashSet<string>();
            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        List<int> shape = new List<int>();
                        NumDistinctIslands_DFS(grid, i, j, shape, 0);
                        islands.Add(string.Join(",", shape));
                    }
                }
            }

            return islands.Count;
        }

        private void NumDistinctIslands_DFS(int[][] grid, int i, int j, List<int> shape, int dir)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0)
            {
                return;
            }

            shape.Add(dir);
            grid[i][j] = 0;

            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };

            for (int k = 0; k < 4; k++)
            {
                int x = i + dx[k];
                int y = j + dy[k];
                NumDistinctIslands_DFS(grid, x, y, shape, k + 1);
            }
        }