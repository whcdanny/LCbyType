//Leetcode 2850. Minimum Moves to Spread Stones Over Grid med
//题意：给定一个大小为3x3的矩阵grid，表示每个单元格中的石头数量。矩阵中总共有9颗石头，一个单元格中可以有多颗石头。在一个移动中，你可以将一颗石头从它当前的单元格移动到与之相邻的任意单元格。返回将每个单元格中放置一颗石头所需的最小移动次数。
//思路：深度优先搜索（DFS）: 首先，将空白单元格和非空单元格分别存储在emptyPos和notEmptyPos两个列表中。使用递归函数Func来尝试所有可能的移动组合，其中filledEmpty表示已经填充的空白单元格数量，当filledEmpty等于emptyPos.Count时，表示所有的空白单元格都已填充，返回0。
//时间复杂度:  n为网格中的空白单元格和非空单元格的总数量，O(n*n)
//空间复杂度： n为网格中的空白单元格和非空单元格的总数量, O(n)
        List<(int x, int y)> emptyPos = new List<(int x, int y)>();
        List<(int x, int y)> notEmptyPos = new List<(int x, int y)>();

        public int MinimumMoves(int[][] grid)
        {
            int size = grid.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        emptyPos.Add((i, j));
                    }
                    else if (grid[i][j] > 1)
                    {
                        notEmptyPos.Add((i, j));
                    }
                }
            }

            return DFS_MinimumMoves(grid, 0);
        }

        public int DFS_MinimumMoves(int[][] grid, int filledEmpty)
        {
            if (filledEmpty == emptyPos.Count) return 0;

            int minDistance = int.MaxValue;

            foreach (var notEmpty in notEmptyPos)
            {
                if (grid[notEmpty.x][notEmpty.y] == 1) continue;

                foreach (var empty in emptyPos)
                {
                    if (grid[empty.x][empty.y] == 1) continue;

                    grid[empty.x][empty.y] += 1;
                    grid[notEmpty.x][notEmpty.y] -= 1;
                    int d = Math.Abs(notEmpty.x - empty.x) + Math.Abs(notEmpty.y - empty.y);

                    minDistance = Math.Min(minDistance, d + DFS_MinimumMoves(grid, filledEmpty + 1));

                    grid[notEmpty.x][notEmpty.y] += 1;
                    grid[empty.x][empty.y] -= 1;
                }
            }

            return minDistance;
        }