//Leetcode 1292. Maximum Side Length of a Square with Sum Less than or Equal to Threshold med
//题意：给定一个 m x n 的矩阵 mat 和一个整数 threshold，你需要找到矩阵中边长最大的正方形，使得该正方形内元素的和不超过 threshold。
//思路：使用二分搜索+前缀和：前缀和： 先计算矩阵的前缀和，方便后续计算子矩阵的和。
//二分搜索： 使用二分搜索找到最大的边长。对于每个边长，遍历矩阵，计算每个子矩阵的和，判断是否小于等于 threshold。
//时间复杂度:  二分搜索的时间复杂度是 O(log(min(m, n)))，每次判断是否存在边长为 len 的正方形需要 O(1) 的时间。因此，总体时间复杂度为 O(log(min(m, n)) * m * n)。
//空间复杂度： 额外使用了一个二维数组 prefixSum 存储前缀和，其大小为 (m+1) x (n+1)，因此空间复杂度为 O(m * n)。
        public int MaxSideLength(int[][] mat, int threshold)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            // 计算前缀和
            int[][] prefixSum = new int[m + 1][];
            for (int i = 0; i <= m; i++)
            {
                prefixSum[i] = new int[n + 1];
            }
            //预处理了一个大一点的matrix存这个前缀和；
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    prefixSum[i][j] = mat[i - 1][j - 1] + prefixSum[i - 1][j] + prefixSum[i][j - 1] - prefixSum[i - 1][j - 1];
                }
            }

            // 二分搜索找到最大的边长
            int left = 1, right = Math.Min(m, n);
            int maxSideLength = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (HasSquareWithSumLessThanThreshold(prefixSum, mid, threshold))
                {
                    maxSideLength = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return maxSideLength;
        }

        // 判断是否存在边长为 len 的正方形，其元素和不超过 threshold
        private bool HasSquareWithSumLessThanThreshold(int[][] prefixSum, int len, int threshold)
        {
            int m = prefixSum.Length - 1;
            int n = prefixSum[0].Length - 1;

            for (int i = len; i <= m; i++)
            {
                for (int j = len; j <= n; j++)
                {
                    //因为[i - len][j - len] 到 [i][j]肯定是正方形；
                    int sum = prefixSum[i][j] - prefixSum[i - len][j] - prefixSum[i][j - len] + prefixSum[i - len][j - len];
                    if (sum <= threshold)
                    {
                        return true;
                    }
                }
            }

            return false;
        }