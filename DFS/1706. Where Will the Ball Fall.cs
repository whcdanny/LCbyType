//Leetcode 1706. Where Will the Ball Fall med
//题意：这个问题描述了一个大小为 m x n 的二维网格，表示一个箱子，有 n 个小球。箱子在顶部和底部是开放的。
//箱子中的每个单元格都有一块对角板，横跨单元格的两个角，可以将小球重定向到右侧或左侧。
//将小球重定向到右侧的板横跨单元格的左上角到右下角，在网格中表示为 1。
//将小球重定向到左侧的板横跨单元格的右上角到左下角，在网格中表示为 -1。
//我们在箱子的每一列顶部放一个小球。每个小球可以被箱子接住，也可以从箱子底部掉出去。如果小球撞到两个板之间的 "V" 形图案，或者板将小球重定向到箱子的任一侧墙壁，那么小球就会被卡住。
//返回一个大小为 n 的数组 answer，其中 answer[i] 表示从顶部第 i 列放下小球后，小球在底部掉出的列，如果小球被卡住则返回 -1。
//思路：DFS, FS 递归搜索。如果小球到达底部，则返回最后的列索引。如果小球在途中被卡住或者撞到墙壁，则返回 -1。对每一列都执行上述步骤，得到最终的结果数组。
//注：V就会卡住，所以相邻两个不是一致方向就错了；        
//时间复杂度: O(m * n)，其中 m 是行数，n 是列数。在最坏的情况下，每个小球都需要遍历整个箱子。
//空间复杂度：O(m)，递归调用的深度是箱子的行数。
        public int[] FindBall(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[] answer = new int[n];

            for (int i = 0; i < n; i++)
            {
                answer[i] = DFS_FindBall(grid, 0, i);
            }

            return answer;
        }

        private int DFS_FindBall(int[][] grid, int row, int col)
        {
            if (row == grid.Length)
            {
                return col;  // Ball reached the bottom
            }
            //因为grid只有1，-1；所以就是检查边界，然后平移的右侧如果跟当前不一样就证明是V；
            if (col + grid[row][col] < 0 || col + grid[row][col] >= grid[0].Length || grid[row][col] != grid[row][col + grid[row][col]])
            {
                return -1; 
            }

            return DFS_FindBall(grid, row + 1, col + grid[row][col]);
        }