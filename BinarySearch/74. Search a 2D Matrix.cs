//74. Search a 2D Matrix med
//是一个在二维矩阵中查找目标值
//思路：中间位置 mid = left + (right - left) / 2。中间位置映射到二维矩阵中，行索引为 mid / n，列索引为 mid % n。
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int left = 0;
            int right = m * n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int value = matrix[mid / n][mid % n];

                if (value == target)
                {
                    return true;
                }
                else if (value < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }
        public bool SearchMatrix1(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;
            int n = matrix.Length;
            int m = matrix[0].Length;
            bool res = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == target)
                    {
                        res = true;
                        break;
                    }
                }
            }

            return res;
        }