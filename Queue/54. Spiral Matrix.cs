//54. Spiral Matrix med
//题意：给定一个 m x n 的矩阵，按照顺时针螺旋顺序，返回矩阵中的所有元素。
//思路：使用四个变量 top, bottom, left, right 分别表示当前矩阵的上、下、左、右边界。创建一个队列用于按照顺序存储需要遍历的元素，初始时将矩阵的第一行放入队列中。进入循环，从队列中取出一行元素，依次将其添加到结果数组中，并根据当前的边界更新 top, bottom, left, right。将下一行的元素按照相应的方向（从左到右、从上到下、从右到左、从下到上）依次放入队列中。
//时间复杂度：m 和 n 分别是矩阵的行数和列数， O(m * n)
//空间复杂度： O(m * n)
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