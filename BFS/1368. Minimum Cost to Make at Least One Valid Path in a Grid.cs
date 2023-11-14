//Leetcode 1368. Minimum Cost to Make at Least One Valid Path in a Grid  hard
//题意：给定一个m x n网格。网格的每个单元格都有一个标志，指向您应该访问的下一个单元格（如果您当前位于该单元格中）。的符号grid[i][j]可以是：1这意味着转到右侧的单元格。（即从grid[i][j] 到grid[i][j + 1]）2这意味着转到左侧的单元格。（即从grid[i][j] 到grid[i][j - 1]）3这意味着转到下面的单元格。（即从grid[i][j] 到grid[i + 1][j]）4这意味着转到上面的单元格。（即从grid[i][j] 到grid[i - 1][j]）请注意，网格单元格上可能有一些指向网格外部的标志。您最初将从左上角的单元格开始(0, 0)。网格中的有效路径是沿着网格上的标志从左上角单元格开始(0, 0)并在右下角单元格结束的路径。(m - 1, n - 1)有效路径不一定是最短路径。您可以使用 修改单元格上的符号cost = 1。您只能修改单元格上的符号一次。返回使网格具有至少一条有效路径的最小成本。 
//思路：BFS（广度优先搜索）遍历图，计算到达每个位置的最小成本。在遍历的过程中，对于每个相邻的位置，如果当前位置与相邻位置之间的路径是相对应的，成本为 0，否则成本为 1。最终返回到达右下角位置的最小成本。
//时间复杂度: O(m * n)
//空间复杂度：O(m * n)
        public int MinCost(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            List<int[]> dirs = new List<int[]> { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            int[][] cost = new int[m][];
            for (int i = 0; i < m; i++)
            {
                cost[i] = new int[n];
                Array.Fill(cost[i], int.MaxValue);
            }

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            cost[0][0] = 0;
            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                int r = curr[0];
                int c = curr[1];                

                for (int i = 0; i < 4; i++)
                {
                    int newRow = r + dirs[i][0];
                    int newCol = c + dirs[i][1];

                    if (newRow < 0 || newRow >= m || newCol < 0 || newCol >= n) continue;

                    if ((i + 1) == grid[r][c] && cost[r][c] < cost[newRow][newCol])
                    {
                        cost[newRow][newCol] = cost[r][c];
                        queue.Enqueue(new int[] { newRow, newCol });
                    }
                    else if (cost[r][c] + 1 < cost[newRow][newCol])
                    {
                        cost[newRow][newCol] = cost[r][c] + 1;
                        queue.Enqueue(new int[] { newRow, newCol });
                    }                    
                }
            }

            return cost[m - 1][n - 1];
        }