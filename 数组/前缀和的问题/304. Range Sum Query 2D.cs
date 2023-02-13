//304. Range Sum Query 2D - Immutable med
//二维矩阵中子矩阵的元素之和
//思路： 找出每一位当时的和，然后算某一个区域的和
//算每一位和，要preSum[i - 1,j] + preSum[i,j - 1] + matrix[i - 1][j - 1] - preSum[i - 1,j - 1]因为左上的位置之前的和被算了两次；
//算和也一样preSum[x2 + 1,y2 + 1] - preSum[x1,y2 + 1]（left） - preSum[x2 + 1,y1]（Up） + preSum[x1,y1]（leftUp）;因为减了两次左上位置之前的和
		public class NumMatrix
        {
            // 定义：preSum[i][j] 记录 matrix 中子矩阵 [0, 0, i-1, j-1] 的元素和
            private int[,] preSum;

            public NumMatrix(int[][] matrix)
            {
                int m = matrix.Length, n = matrix[0].Length;
                if (m == 0 || n == 0) return;
                // 构造前缀和矩阵
                preSum = new int[m + 1,n + 1];
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        // 计算每个矩阵 [0, 0, i, j] 的元素和
                        preSum[i,j] = preSum[i - 1,j] + preSum[i,j - 1] + matrix[i - 1][j - 1] - preSum[i - 1,j - 1];
                    }
                }
            }

            // 计算子矩阵 [x1, y1, x2, y2] 的元素和
            public int sumRegion(int x1, int y1, int x2, int y2)
            {
                // 目标矩阵之和由四个相邻矩阵运算获得
                return preSum[x2 + 1,y2 + 1] - preSum[x1,y2 + 1] - preSum[x2 + 1,y1] + preSum[x1,y1];
            }
        }
		public class NumMatrix1
        {

            private int[,] _dp;
            public NumMatrix1(int[][] matrix)
            {
                if (matrix.Length < 1)
                {
                    _dp = new int[0, 0];
                    return;
                }
                _dp = new int[matrix.Length, matrix[0].Length];
                for (int i = 0; i < matrix.Length; i++)
                {
                    var sum = 0;
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        var a = i > 0 ? _dp[i - 1, j] : 0;
                        sum += matrix[i][j];
                        _dp[i, j] = a + sum;
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                var up = row1 > 0 ? _dp[row1 - 1, col2] : 0;
                var left = col1 > 0 ? _dp[row2, col1 - 1] : 0;
                var leftUp = row1 > 0 && col1 > 0 ? _dp[row1 - 1, col1 - 1] : 0;
                return _dp[row2, col2] - up - left + leftUp;
            }
        }
        