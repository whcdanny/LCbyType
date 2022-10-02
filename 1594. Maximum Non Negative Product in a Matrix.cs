1594. Maximum Non Negative Product in a Matrix		
//C#		
		public int MaxProductPath(int[][] grid)
        {            
            int n = grid.Length;
            int m = grid[0].Length;
            long[,] minNeg = new long[n,m];
            long[,] maxPos = new long[n,m];
            bool hasZero = false;
            if (grid[0][0] == 0)
            {
                return 0;
            }
            else
            {
                minNeg[0,0] = grid[0][0];
                maxPos[0,0] = grid[0][0];
            }

            for (int i = 1; i < n; i++)
            {
                if (grid[i][0] == 0)
                {
                    hasZero = true;
                }
                else if (grid[i][0] < 0)
                {
                    maxPos[i,0] = minNeg[i - 1,0] * grid[i][0];
                    minNeg[i,0] = maxPos[i - 1,0] * grid[i][0];
                }
                else
                {
                    minNeg[i,0] = minNeg[i - 1,0] * grid[i][0];
                    maxPos[i,0] = maxPos[i - 1,0] * grid[i][0];
                }
            }
            for (int i = 1; i < m; i++)
            {
                if (grid[0][i] == 0)
                {
                    hasZero = true;
                }
                else if (grid[0][i] < 0)
                {
                    maxPos[0,i] = minNeg[0,i - 1] * grid[0][i];
                    minNeg[0,i] = maxPos[0,i - 1] * grid[0][i];
                }
                else
                {
                    minNeg[0,i] = minNeg[0,i - 1] * grid[0][i];
                    maxPos[0,i] = maxPos[0,i - 1] * grid[0][i];
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        hasZero = true;
                    }
                    else
                    {
                        long min = Math.Min(minNeg[i - 1,j], minNeg[i,j - 1]);
                        long max = Math.Max(maxPos[i - 1,j], maxPos[i,j - 1]);
                        if (grid[i][j] < 0)
                        {
                            minNeg[i,j] = max * grid[i][j];
                            maxPos[i,j] = min * grid[i][j];
                        }
                        else
                        {
                            minNeg[i,j] = min * grid[i][j];
                            maxPos[i,j] = max * grid[i][j];
                        }
                    }
                }
            }            
            if (maxPos[n - 1,m - 1] < 0)
            {
                return hasZero ? 0 : -1;
            }
            else
            {
                return (int)(maxPos[n - 1,m - 1] % 1000000007);
            }
        }
		
		
		public static int maxProductPath(int[][] grid)
        {
            long[] max = new long[] { -1 };
            dfs(grid, 0, 0, max, grid[0][0]);
            return (int)(max[0] % 1_000_000_007);
        }

        private static void dfs(int[][] grid, int row, int column, long[] max, long current)
        {
            if (row == grid.Length - 1 && column == grid[row].Length - 1)
            {
                max[0] = Math.Max(max[0], current);
                return;
            }

            if (grid[row][column] == 0)
            {
                max[0] = Math.Max(max[0], 0);
                return;
            }

            if (row + 1 < grid.Length)
            {
                dfs(grid, row + 1, column, max, current * grid[row + 1][column]);
            }

            if (column + 1 < grid[row].Length)
            {
                dfs(grid, row, column + 1, max, current * grid[row][column + 1]);
            }
        }