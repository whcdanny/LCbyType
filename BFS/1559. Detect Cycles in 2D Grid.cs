//Leetcode 1559. Detect Cycles in 2D Grid med
//题意：grid给定一个大小为 的字符的二维数组，您需要查找中m x n是否存在由相同值grid组成的循环。从给定单元格，您可以沿四个方向（上、下、左或右）之一移动到与其相邻的单元格之一（如果该单元格与当前单元格具有相同的值）。此外，您无法移动到上次移动时访问过的单元格。例如，循环(1, 1) -> (1, 2) -> (1, 1)无效，因为(1, 2)我们访问了(1, 1)最后访问的单元格。true如果 中存在相同值的环则返回grid，否则返回false。
//思路： BFS 进行遍历，根据当前的grid[i][j]的value来BFS 找出是否为循环；
//时间复杂度: O(M*N)，其中 M 和 N 分别是网格的行数和列数。
//空间复杂度：O(MN)
        public bool ContainsCycle(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            List<int[]> directions = new List<int[]> { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (visited[i, j]) continue;
                    char curr = grid[i][j];
                    Queue<int[]> q = new Queue<int[]>();
                    q.Enqueue(new int[] { i, j, -1, -1 });
                    while (q.Count > 0)
                    {
                        int[] rem = q.Dequeue();
                        int row = rem[0];
                        int col = rem[1];
                        int prow = rem[2];
                        int pcol = rem[3];


                        if (visited[row, col]) return true;
                        visited[row, col] = true;
                        foreach (var dir in directions)
                        {
                            int nrow = row + dir[0];
                            int ncol = col + dir[1];
                            if (nrow >= 0 && nrow < m && ncol >= 0 && ncol < n && grid[nrow][ncol] == curr)
                            {
                                bool isNotValid = (nrow == prow && ncol == pcol);
                                if (!isNotValid)
                                    q.Enqueue(new int[] { nrow, ncol, row, col });
                            }
                        }
                    }

                }
            }

            return false;
        }