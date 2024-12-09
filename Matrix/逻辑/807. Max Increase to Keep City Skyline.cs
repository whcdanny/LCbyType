//807. Max Increase to Keep City Skyline med
//题目：给定一个城市的 n×n 的建筑矩阵 grid，其中 grid[r][c]
//表示位于第 r 行第 c 列的建筑物的高度。
//城市的天际线由城市从四个方向（北、东、南、西）看到的建筑轮廓决定。
//北/南方向的天际线是每列中建筑的最大高度。
//东/西方向的天际线是每行中建筑的最大高度。
//我们可以通过增加建筑的高度来调整城市的建筑矩阵，但不能更改从任何方向看到的天际线。
//任务是返回在不改变天际线的前提下，建筑物高度的最大增量总和
//思路：逻辑，算出确定每行和每列的最大值
//对于每一个[r][c]来说找出最小的高度这样才能满足行和列的要求
//Math.Min(maxRowHeights[r], maxColHeights[c])
//totalIncrease += maxHeight - grid[r][c];
//时间复杂度:  O(n^2)
//空间复杂度： O(1)
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int n = grid.Length;

            // 确定每行和每列的最大值
            int[] maxRowHeights = new int[n];
            int[] maxColHeights = new int[n];

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    maxRowHeights[r] = Math.Max(maxRowHeights[r], grid[r][c]);
                    maxColHeights[c] = Math.Max(maxColHeights[c], grid[r][c]);
                }
            }

            // 计算最大增量总和
            int totalIncrease = 0;

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    int maxHeight = Math.Min(maxRowHeights[r], maxColHeights[c]);
                    if (grid[r][c] < maxHeight)
                    {
                        totalIncrease += maxHeight - grid[r][c];
                    }
                }
            }

            return totalIncrease;
        }