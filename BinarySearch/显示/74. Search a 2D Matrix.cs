//Leetcode 74. Search a 2D Matrix med
//题意：求在一个按照以下规律排列的二维矩阵中查找目标值：每行中的整数从左到右按升序排列。每行的第一个整数大于前一行的最后一个整数。
//思路：二分法: 二维矩阵看作一个有序的一维数组，然后使用二分查找来找到目标值,int mid = left + (right - left) / 2;int value = matrix[mid / n][mid % n];
//时间复杂度:  m 是矩阵的行数，n 是矩阵的列数 , O(log(m*n)) = O(log(m) + log(n))
//空间复杂度： O(1)
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