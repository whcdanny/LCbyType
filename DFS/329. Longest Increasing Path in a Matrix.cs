//Leetcode 329. Longest Increasing Path in a Matrix  hard
//题意：给定一个矩阵 matrix，矩阵中的每个元素表示一个整数。要求找到矩阵中的最长递增路径的长度。在该路径中，每个元素只能移动到其上、下、左、右四个相邻元素之
//思路：动态规划问题, DFS,由于每个元素只能移动到上、下、左、右四个相邻元素，因此可以定义一个二维数组 dp 来记录以每个元素为起点的最长递增路径的长度。
//对矩阵中的每个元素调用深度优先搜索（DFS），计算以该元素为起点的最长递增路径的长度，并更新 dp 数组。
//在递归的过程中，如果当前元素的值比相邻元素的值大，那么递归调用相邻元素，并在相邻元素的最长递增路径长度的基础上加 1。
//注：用了dp；
//时间复杂度: O(m⋅n)，其中 m 和 n 分别为矩阵的行数和列数。
//空间复杂度：使用了二维数组 dp 来存储每个元素的最长递增路径长度，因此空间复杂度为O(m⋅n)
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[,] dp = new int[rows, cols];
            int maxLength = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maxLength = Math.Max(maxLength, DFS_LongestIncreasingPath(matrix, dp, i, j));
                }
            }

            return maxLength;
        }

        private int DFS_LongestIncreasingPath(int[][] matrix, int[,] dp, int i, int j)
        {
            if (dp[i, j] != 0)
            {
                return dp[i, j];
            }

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            int maxLength = 1;

            for (int k = 0; k < 4; k++)
            {
                int ni = i + dx[k];
                int nj = j + dy[k];

                if (ni >= 0 && ni < matrix.Length && nj >= 0 && nj < matrix[0].Length && matrix[ni][nj] > matrix[i][j])
                {
                    maxLength = Math.Max(maxLength, 1 + DFS_LongestIncreasingPath(matrix, dp, ni, nj));
                }
            }

            dp[i, j] = maxLength;
            return maxLength;
        }
