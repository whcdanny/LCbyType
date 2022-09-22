1559. Detect Cycles in 2D Grid		
//c#
		public bool containsCycle(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (char.IsUpper(grid[i][j]))
                    {        
                        continue;
                    }

                    grid[i][j] = char.ToUpper(grid[i][j]);
                    if (dfs(grid, j, i, j + 1, i) ||          
                        dfs(grid, j, i, j - 1, i) ||
                        dfs(grid, j, i, j, i + 1) ||
                        dfs(grid, j, i, j, i - 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
		
		private bool dfs(char[][] grid, int fromX, int fromY, int toX, int toY)
        {       
            if (toX < 0 || toX >= grid[0].Length || toY < 0 || toY >= grid.Length)
            {       
                return false;
            }

            if (grid[fromY][fromX] == grid[toY][toX])           
            {     
                return true;
            }

            if (char.ToLower(grid[fromY][fromX]) != char.ToLower(grid[toY][toX]))
            {      
                return false;
            }

            grid[toY][toX] = char.ToUpper(grid[toY][toX]);         
            return (toX + 1 != fromX && dfs(grid, toX, toY, toX + 1, toY)) ||   
                (toX - 1 != fromX && dfs(grid, toX, toY, toX - 1, toY)) ||
                (toY + 1 != fromY && dfs(grid, toX, toY, toX, toY + 1)) ||
                (toY - 1 != fromY && dfs(grid, toX, toY, toX, toY - 1));
        }