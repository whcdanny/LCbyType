//378. Kth Smallest Element in a Sorted Matrix med
//给定一个 n x n 的有序矩阵 matrix，其中每行和每列元素按升序排序，找到矩阵中第 k 小的元素
//思路：二分查找，左边界 left 和右边界 right，因为是升序排序，所以先比较每一个行的最右边的数，根据大小，来决定是换行，还是同一行往前找；然后再更换边界；
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int left = matrix[0][0]; // 左边界
            int right = matrix[n - 1][n - 1]; // 右边界

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int count = CountElements(matrix, mid); // 统计小于等于 mid 的元素个数

                if (count < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private int CountElements(int[][] matrix, int target)
        {
            int count = 0;
            int n = matrix.Length;
            int row = 0;
            int col = n - 1;

            while (row < n && col >= 0)
            {
                if (matrix[row][col] <= target)
                {
                    count += col + 1; // 当前列及之前的元素都小于等于 target
                    row++;
                }
                else
                {
                    col--;
                }
            }

            return count;
        }