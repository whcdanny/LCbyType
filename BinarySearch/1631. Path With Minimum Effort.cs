//Leetcode 1631. Path With Minimum Effort med
//题意： hiker 准备进行一次徒步旅行。给定一个大小为 rows x columns 的二维数组 heights，其中 heights[row][col] 表示单元格 (row, col) 的高度。起点位于左上角单元格 (0, 0)，目标是到达右下角单元格 (rows-1, columns-1)（即，0索引）。
//你可以向上、向下、向左或向右移动，你希望找到一条需要最小努力的路径。
//路径的努力是路径上两个相邻单元格之间高度差的最大绝对值。
//要求返回从左上角单元格到右下角单元格所需的最小努力。
//思路：使用二分搜索确定路径的最小努力，因为努力的范围在 [0, 1000000] 之间，这是一个合理的范围。
//使用深度优先搜索（DFS）进行路径搜索，每次尝试移动到相邻单元格，并检查高度差是否在当前的二分搜索值 mid 内。如果能够找到一条路径，就更新 result，并调整二分搜索的右边界。如果找不到路径，就调整二分搜索的左边界。最终返回找到的最小努力值。              
//时间复杂度: O(m * n * log(MaxDiff))，其中 m 是行数，n 是列数，MaxDiff 是高度差的最大值，log(MaxDiff) 是二分搜索的时间复杂度。
//空间复杂度：O(m * n)
        public int MinimumEffortPath(int[][] heights)
        {
            int rows = heights.Length;
            int columns = heights[0].Length;
            int left = 0;
            int right = 1000000;  // 设置二分搜索的范围，根据实际情况调整
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                bool[,] visited = new bool[rows, columns];
                if (DFS_MinimumEffortPath(heights, 0, 0, rows, columns, visited, mid))
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        private bool DFS_MinimumEffortPath(int[][] heights, int row, int col, int rows, int columns, bool[,] visited, int mid)
        {
            if (row == rows - 1 && col == columns - 1)
            {
                return true;
            }

            visited[row, col] = true;

            int[][] directions = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < columns && !visited[newRow, newCol])
                {
                    int diff = Math.Abs(heights[row][col] - heights[newRow][newCol]);
                    if (diff <= mid)
                    {
                        if (DFS_MinimumEffortPath(heights, newRow, newCol, rows, columns, visited, mid))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }