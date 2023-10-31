//Leetcode 304 Range Sum Query 2D - Immutable med
//题意：给定一个二维矩阵 matrix，以及一个整数 row1, col1, row2, col2 分别表示矩阵的左上角和右下角的坐标。你需要返回矩阵中所有元素总和的子矩阵中的元素之和。
//思路：前缀和（Prefix Sum）来解决。我们可以预先计算出一个前缀和数组 prefixSum，其中 prefixSum[i][j] 表示矩阵从 (0,0) 到 (i,j) 的所有元素之和。
//prefixSum[i][j] = matrix[i-1][j-1] + prefixSum[i-1][j] + prefixSum[i][j-1] - prefixSum[i-1][j-1] 看成区域
//例子 5x5， 我们假如算i=3 j=3;
        //x x x x x     + + + x x       - - x x x       +- +- +  x x
        //x x x x x     + + + x x       - - x x x       +- +- +  x x
        //x x x x x  => x x x x x   +   - - x x x   +   -  -  ij x x    => +-为重复 所以要减去一部分；
        //x x x x x     x x x x x       x x x x x       x  x  x  x x
        //x x x x x     x x x x x       x x x x x       x  x  x  x x
//同理：算 [x1, y1, x2, y2] 的时候 需要先把多余部分减去，然后由于左上角的部分被减了两次要加一次；
//时间复杂度：预处理前缀和数组的时间复杂度是 O(m*n)，其中 m 和 n 分别表示矩阵的行数和列数。查询子矩阵的元素之和的时间复杂度是 O(1)。
//空间复杂度：O(m*n)
        public class NumMatrix
        {
            // 定义：preSum[i][j] 记录 matrix 中子矩阵 [0, 0, i-1, j-1] 的元素和
            private int[,] preSum;

            public NumMatrix(int[][] matrix)
            {
                int m = matrix.Length, n = matrix[0].Length;
                if (m == 0 || n == 0) return;
                // 构造前缀和矩阵
                preSum = new int[m + 1, n + 1];
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        // 计算每个矩阵 [0, 0, i, j] 的元素和
                        preSum[i, j] = preSum[i - 1, j] + preSum[i, j - 1] + matrix[i - 1][j - 1] - preSum[i - 1, j - 1];
                    }
                }
            }

            // 计算子矩阵 [x1, y1, x2, y2] 的元素和
            public int SumRegion(int x1, int y1, int x2, int y2)
            {
                // 目标矩阵之和由四个相邻矩阵运算获得
                return preSum[x2 + 1, y2 + 1] - preSum[x1, y2 + 1] - preSum[x2 + 1, y1] + preSum[x1, y1];
            }
        }