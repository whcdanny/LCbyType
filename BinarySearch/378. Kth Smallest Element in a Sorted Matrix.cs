//Leetcode 378. Kth Smallest Element in a Sorted Matrix med
//题意：给定一个 n x n 矩阵，其中每行和每列元素均按升序排序，找到矩阵中第 k 小的元素。请注意，它是排序后的第 k 小元素，而不是第 k 个不同的元素。
//思路：二分查找，由于每一行和每一列都是升序排列的，我们可以观察到矩阵中的左上角元素是最小的，右下角元素是最大的。因此，我们可以使用二分查找
//上下界，左上角元素是最小的，即 matrix[0][0]，右下角元素是最大的，即 matrix[n-1][n-1]。然后，我们计算出中间值 mid，将矩阵中小于等于 mid 的元素个数（记为 count）。
//如果 count 小于 k，说明第 k 小的元素在右半部分，我们将 left 调整为 mid + 1；否则，第 k 小的元素在左半部分，我们将 right 调整为 mid。
//时间复杂度：二分查找的时间复杂度为 O(log(range))，其中 range 是查找范围的大小。在这个问题中，range 的上界是 matrix[n - 1][n - 1] - matrix[0][0]，因此总体时间复杂度为 O(log(matrix[n - 1][n - 1] - matrix[0][0]))。
//空间复杂度：O(1)，只使用了常数额外空间。
        public int KthSmallest1(int[][] matrix, int k)
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
            //找每一行最大的数就是每一行最后一个数；
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