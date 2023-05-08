//54. Spiral Matrix med
//给一个矩阵，按照螺旋方式读取，也就是先从最上面一行读到头，然后往下读到头，然后往上读到刚才的起始点下一位，然后重复直到读完；
//思路：做四个边界上下左右，先上往右，然后右边境往下，下边境往左，然和左边境往上；
		public IList<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int upper_bound = 0, lower_bound = m - 1;
            int left_bound = 0, right_bound = n - 1;
            IList<int> res = new List<int>();            
            while (res.Count() < m * n)
            {
                if (upper_bound <= lower_bound)
                {
                    // 在顶部从左向右遍历
                    for (int j = left_bound; j <= right_bound; j++)
                    {
                        res.Add(matrix[upper_bound][j]);
                    }
                    // 上边界下移
                    upper_bound++;
                }

                if (left_bound <= right_bound)
                {
                    // 在右侧从上向下遍历
                    for (int i = upper_bound; i <= lower_bound; i++)
                    {
                        res.Add(matrix[i][right_bound]);
                    }
                    // 右边界左移
                    right_bound--;
                }

                if (upper_bound <= lower_bound)
                {
                    // 在底部从右向左遍历
                    for (int j = right_bound; j >= left_bound; j--)
                    {
                        res.Add(matrix[lower_bound][j]);
                    }
                    // 下边界上移
                    lower_bound--;
                }

                if (left_bound <= right_bound)
                {
                    // 在左侧从下向上遍历
                    for (int i = lower_bound; i >= upper_bound; i--)
                    {
                        res.Add(matrix[i][left_bound]);
                    }
                    // 左边界右移
                    left_bound++;
                }
            }
            return res;
        }
		
//思路：BFS的方式，从四个方向中的一个方向出发依次遍历下去，直到所有元素都被访问到为止；
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> res = new List<int>();
            if (matrix == null || matrix.Length == 0) return res;

            int rows = matrix.Length, cols = matrix[0].Length;
            int count = rows * cols;

            Queue<int[]> q = new Queue<int[]>();
            HashSet<int> visited = new HashSet<int>();

            int[][] directions = new int[][] {
                new int[] {0, 1},  // right
                new int[] {1, 0},  // down
                new int[] {0, -1}, // left
                new int[] {-1, 0}  // up
            };
            int curDir = 0; // 0:right, 1:down, 2:left, 3:up
            int curRow = 0, curCol = 0;

            for (int i = 0; i < count; i++)
            {
                res.Add(matrix[curRow][curCol]);
                visited.Add(curRow * cols + curCol);

                int nextRow = curRow + directions[curDir][0];
                int nextCol = curCol + directions[curDir][1];

                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols || visited.Contains(nextRow * cols + nextCol))
                {
                    // change direction
                    curDir = (curDir + 1) % 4;
                    nextRow = curRow + directions[curDir][0];
                    nextCol = curCol + directions[curDir][1];
                }

                curRow = nextRow;
                curCol = nextCol;
            }

            return res;
        }
		
		