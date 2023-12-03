//Leetcode 1992. Find All Groups of Farmland med
//题意：给定一个m x n的地块矩阵land，其中land[i][j]是0表示水域，是1表示农田。农田是由相邻的1形成的一片连续区域。请找出所有的农田区域, 并给出起始点（左上角）和终点（右下角）。
//思路： DFS（深度优先搜索）的问题。我们可以遍历整个 land 矩阵，当找到一块农田土地时，从这块土地出发进行 DFS，标记所有属于同一组的土地
//注：当找到第一块land的时候只向右和下查找直到水域，因为肯定是四边形所以不用担心凹凸问题；
//时间复杂度: O(m * n)
//空间复杂度：O(1)

        public int[][] FindFarmland(int[][] land)
        {
            List<int[]> result = new List<int[]>();
            int m = land.Length;
            int n = land[0].Length;            
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (land[i][j] == 1)
                    {
                        DFS_FindFarmland(i, j, m, n, land, result);
                    }
                }
            }

            return result.ToArray();
        }

        void DFS_FindFarmland(int row, int col, int m, int n, int[][] land, List<int[]> result)
        {
            if (row < 0 || row >= m || col < 0 || col >= n || land[row][col] == 0)
            {
                return;
            }

            int r2 = row;
            int c2 = col;

            // Find the bottom right corner of the farmland group
            while (r2 < m && land[r2][col] == 1)
            {
                r2++;
            }
            r2--;

            while (c2 < n && land[row][c2] == 1)
            {
                c2++;
            }
            c2--;

            // Mark the visited land as 0
            for (int i = row; i <= r2; i++)
            {
                for (int j = col; j <= c2; j++)
                {
                    land[i][j] = 0;
                }
            }

            // Add the coordinates to the result
            result.Add(new int[] { row, col, r2, c2 });

            // Continue DFS in the remaining unvisited land
            DFS_FindFarmland(r2 + 1, col, m, n, land, result);
            DFS_FindFarmland(row, c2 + 1, m, n, land, result);
        }