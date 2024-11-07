//Leetcode 3195. Find the Minimum Area to Cover All Ones I  med
//题目：在这道题中，给定一个二维二进制数组 grid，其中 1 表示某个点被标记，0 表示空白区域。
//我们的目标是找到一个最小的矩形区域，该区域可以包含 grid 中所有的 1，并返回该矩形区域的面积。
//矩形区域的边必须是水平或垂直的，这意味着矩形的四条边平行于数组的边界。
//思路: 要找到包含所有 1 的最小矩形区域，可以通过遍历数组来确定 1 的最左边界（minCol）、最右边界（maxCol）、最上边界（minRow）和最下边界（maxRow）。
//遍历数组时，更新这四个边界值，找到最小的 i 和最大的 i，以及最小的 j 和最大的 j，从而包含所有的 1。
//计算面积：
//一旦找到了最左边界、最右边界、最上边界和最下边界，就可以计算出该矩形的面积。
//面积公式为：area=(maxRow−minRow+1)×(maxCol−minCol+1)
//时间复杂度：O(m * n)
//空间复杂度：O(1)
        public int MinimumArea(int[][] grid)
        {
            int minRow = grid.Length, maxRow = -1;
            int minCol = grid[0].Length, maxCol = -1;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        // 更新边界
                        minRow = Math.Min(minRow, i);
                        maxRow = Math.Max(maxRow, i);
                        minCol = Math.Min(minCol, j);
                        maxCol = Math.Max(maxCol, j);
                    }
                }
            }

            // 如果没有找到1，则返回面积0
            if (minRow == grid.Length) return 0;

            // 计算面积
            int area = (maxRow - minRow + 1) * (maxCol - minCol + 1);
            return area;
        }