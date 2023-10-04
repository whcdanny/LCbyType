//Leetcode 200. Number of Islands med 
//题意：给定一个由 '1'（陆地）和 '0'（水）组成的二维网格地图，计算岛屿的数量。岛屿被水包围，并且通过水平方向或垂直方向相邻时被认为是同一岛屿。可以假设网格的四个边均被水包围。
//思路：广度优先搜索（BFS）序列化：遍历二维网格的每一个点，当为 '1' 的陆地时，将其标记为已访问，并将与该点相邻的所有陆地也标记为已访问，直到无法再继续搜索为止。每次遇到新的 '1'，都意味着发现了一个新的岛屿。
//时间复杂度: 网格大小为 m×n,O(m*n)
//空间复杂度：递归调用的最大深度取决于岛屿的数量，因此空间复杂度为 O(min(m, n))
        public int NumIslands(char[][] grid)
        {
            int res = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        res++;
                        checkedIsland(grid, i, j);
                    }
                }
            }
            return res;
        }
        private void checkedIsland(char[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] == '0')
                return;
            grid[i][j] = '0';
            checkedIsland(grid, i, j - 1);
            checkedIsland(grid, i, j + 1);
            checkedIsland(grid, i - 1, j);
            checkedIsland(grid, i + 1, j);
        }