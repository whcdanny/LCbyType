//Leetcode 3127. Make a Square with the Same Color ez
//题目：你有一个大小为 3×3 的二维矩阵 grid，矩阵中的元素只有字符 'B'（黑色）和 'W'（白色）。
//你的任务是判断是否可以通过 改变最多一个格子的颜色，让矩阵中存在一个 
//2×2 的子矩形，且该子矩形中的所有格子都具有相同的颜色。
//如果可以达到目标，返回 true；否则返回 false。
//思路: 就四种可能只要2x2里面能有三个颜色相同就行
//时间复杂度：O(m*n)
//空间复杂度：O(1)
        public bool CanMakeSquare(char[][] grid)
        {
            //1.xx  2.xx 3. x  4. x
            //  x      x    xx   xx
            for (var i = 0; i < grid.Length - 1; i++)
                for (var j = 0; j < grid[0].Length - 1; j++)
                    if ((grid[i][j] == grid[i + 1][j] && grid[i][j] == grid[i][j + 1]) ||
                        (grid[i][j] == grid[i + 1][j + 1] && grid[i][j] == grid[i][j + 1]) ||
                        (grid[i][j] == grid[i + 1][j] && grid[i][j] == grid[i + 1][j + 1]) ||
                        (grid[i][j + 1] == grid[i + 1][j + 1] && grid[i][j + 1] == grid[i + 1][j]))
                        return true;
            return false;
        }