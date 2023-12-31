 //Leetcode 1970. Last Day Where You Can Still Cross hard
        //题意：有一个从 1 开始的二进制矩阵，其中0代表土地，1代表水。给定整数row和col分别表示矩阵中的行数和列数。最初的一天0，整个矩阵都是陆地。然而，每天都有一个新的细胞被水淹没。给定一个从 1 开始的二维数组cells，其中表示在这一天，行和列上的单元格（从 1 开始的坐标）将被水覆盖（即变为）。cells[i] = [ri, ci]ithrithcith1你想要找到仅在陆地单元上行走就可以从顶部步行到底部的最后一天。您可以从顶行中的任何单元格开始，到底行中的任何单元格结束。您只能沿四个基本方向（左、右、上、下）行驶。返回最后一天，仅在陆地单元上行走即可从顶部步行到底部。
        //思路：使用BFS（方法isPathExists）来检查我们是否可以穿越, 使用二分搜索查找最新一天
        //时间复杂度: O ( n×log ( n ) ) 
        //空间复杂度：O ( n )
        private readonly int[] _directions = { 0, -1, 0, 1, 0 };

        public int LatestDayToCross_BFS(int row, int col, int[][] cells)
        {
            var left = 0;
            var right = row * col;
            var latestPossibleDay = 0;

            while (left < right - 1)
            {
                var mid = left + (right - left) / 2;
                if (BFS_LatestDayToCross(row, col, mid, cells))
                {
                    left = mid;
                    latestPossibleDay = mid;
                }
                else
                {
                    right = mid;
                }
            }

            return latestPossibleDay;
        }

        private bool BFS_LatestDayToCross(int row, int col, int mid, int[][] cells)
        {
            var visited = new bool[row + 1, col + 1];

            for (var i = 0; i < mid; i++)
            {
                visited[cells[i][0], cells[i][1]] = true;
            }

            var queue = new Queue<(int row, int col)>();

            for (var i = 1; i <= col; i++)
            {
                if (visited[1, i]) continue;

                // Start from the top row
                queue.Enqueue((1, i));
                visited[1, i] = true;
            }

            while (queue.Any())
            {
                var (currentRow, currentCol) = queue.Dequeue();

                for (var i = 0; i < _directions.Length - 1; i++)
                {
                    var nextRow = currentRow + _directions[i];
                    var nextCol = currentCol + _directions[i + 1];

                    if (nextRow <= 0 || nextCol <= 0 || nextRow > row || nextCol > col || visited[nextRow, nextCol]) continue;

                    visited[nextRow, nextCol] = true;

                    if (nextRow == row)
                    {
                        return true;
                    }

                    queue.Enqueue((nextRow, nextCol));
                }
            }

            return false;
        }


        //Leetcode 1970. Last Day Where You Can Still Cross hard
        //题意：有一个从 1 开始的二进制矩阵，其中0代表土地，1代表水。给定整数row和col分别表示矩阵中的行数和列数。最初的一天0，整个矩阵都是陆地。
        //然而，每天都有一个新的细胞被水淹没。给定一个从 1 开始的二维数组cells，其中表示在这一天，行和列上的单元格（从 1 开始的坐标）将被水覆盖（即变为）。
        //cells[i] = [ri, ci]ithrithcith1你想要找到仅在陆地单元上行走就可以从顶部步行到底部的最后一天。
        //您可以从顶行中的任何单元格开始，到底行中的任何单元格结束。您只能沿四个基本方向（左、右、上、下）行驶。返回最后一天，仅在陆地单元上行走即可从顶部步行到底部。
        //思路：DFS, 用二分法，找出哪一天是最后能从上走到下的天，然后每一次要更新matrix，然后只要列col能到底部 就证明有路；
        //注：二分法和DFS连用；
        //时间复杂度: O(N * log(D))，其中N是矩阵的大小，D是天数。每次DFS的时间复杂度是O(N)。
        //空间复杂度：O ( n )
        public int LatestDayToCross_DFS(int row, int col, int[][] cells)
        {
            int left = 0, right = cells.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                int[,] matrix = new int[row, col];

                for (int i = 0; i <= mid; i++)
                {
                    matrix[cells[i][0] - 1, cells[i][1] - 1] = 1;
                }

                bool[,] visited = new bool[row, col];
                bool isRoadBlocked = false;

                for (int j = 0; j < row; j++)
                {
                    if (DFS_LatestDayToCross(matrix, j, 0, row, col, visited))
                    {
                        isRoadBlocked = true;
                        break;
                    }
                }

                if (isRoadBlocked)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return right;
        }

        private bool DFS_LatestDayToCross(int[,] matrix, int row, int col, int m, int n, bool[,] visited)
        {
            if (row < 0 || row >= m || col < 0)
            {
                return false;
            }

            if (col >= n)
            {
                return true;
            }

            if (matrix[row, col] == 0 || visited[row, col])
            {
                return false;
            }

            visited[row, col] = true;

            int[] dirs = new int[3] { -1, 0, 1 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (DFS_LatestDayToCross(matrix, row + dirs[i], col + dirs[j], m, n, visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }