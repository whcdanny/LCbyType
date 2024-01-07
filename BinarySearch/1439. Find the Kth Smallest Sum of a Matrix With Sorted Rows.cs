//Leetcode 1439. Find the Kth Smallest Sum of a Matrix With Sorted Rows hard
//题意：给定 m x n 的矩阵，其中每一行元素已经排序。定义 sum 为矩阵中所有非空子集元素之和。请找到第 k 小的 sum。
//思路：使用二分搜索+DFS，去猜这这个Kth Smallest Sum，
//这里思路是必须每一行选一个元素，而且每一行是从小到大排序，所以最小的sum就是每一行的第一个相加；所以如果sum大于期望值，那么就不用找了 没有；如果有就进行DFS；
//DFS开始每一行，如果我们在某一行的某一个的sum满足小于猜的值并且此时已经有了k个了，那么后面的都不需要算了，那么每一行怎么算；
//因为我们的sum是每一行第一个元素，那么当我们在一行里算的时候 只需要sum + mat[row][j] - mat[row][0] <= target 然后count++，直到已经到达k个，此时就可以结束dfs；
//接下来，我们将新数组中从索引 left 到索引 right 的数字相加，最终结果对 10^9 + 7 取模。
//时间复杂度: O(log(MaxValue - MinValue) * m * log(n))，其中 MaxValue 和 MinValue 是矩阵中元素的最大值和最小值，m 是矩阵的行数，n 是矩阵的列数， O(m * n * m)，其中 m 是矩阵的行数，n 是矩阵的列数。O(log(MaxValue - MinValue) * m * n * log(n))。
//空间复杂度： O(m)
        public int KthSmallest(int[][] mat, int k)
        {
            int left = 0, right = int.MaxValue;
            while (left < right)
            {
                int target = left + (right - left) / 2;
                if (isOK_KthSmallest(mat, target, k))
                {
                    right = target;
                }
                else
                {
                    left = target + 1;
                }
            }
            return left;
        }

        private bool isOK_KthSmallest(int[][] mat, int target, int k)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            //这里思路是必须每一行选一个元素，而且每一行是从小到大排序，所以最小的sum就是每一行的第一个相加；
            //所以如果sum大于期望值，那么就不用找了 没有；
            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                sum += mat[i][0];
            }
            int count = 1;

            if (sum > target) return false;
            //如果有
            dfs_KthSmallest(mat, 0, sum, ref count, target, k);

            return count >= k;
        }
        //移动一次就有一个组合；
        private void dfs_KthSmallest(int[][] mat, int row, int sum, ref int count, int target, int k)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            if (count >= k || row == m) return;

            for (int j = 0; j < n; j++)
            {
                if (sum + mat[row][j] - mat[row][0] <= target)
                {
                    if (j > 0) count++;
                    dfs_KthSmallest(mat, row + 1, sum + mat[row][j] - mat[row][0], ref count, target, k);
                }
                else
                {
                    break;
                }
            }
        }