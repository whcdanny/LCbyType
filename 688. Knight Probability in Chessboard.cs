688. Knight Probability in Chessboard
//C#
public double knightProbabilityV0(int N, int K, int r, int c)
        {
            double[,] dp = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dp[i, j] = 1.0;
                }
            }
            for (int i = 1; i <= K; i++)
            {
                dp = bulidDp(dp, N);
            }
            return dp[r,c] / Math.Pow(8.0, K);
        }

        private double[,] bulidDp(double[,] dp, int N)
        {
            double[,] tmpDp = new double[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    tmpDp[i,j] = init(dp, N, i, j);
                }
            }
            return tmpDp;
        }

        private double init(double[,] dp, int N, int i, int j)
        {
            double res = 0;
            if (i + 1 < N && j + 2 < N)
            {
                res += dp[i + 1,j + 2];
            }
            if (i + 1 < N && j - 2 >= 0)
            {
                res += dp[i + 1,j - 2];
            }
            if (i - 1 >= 0 && j + 2 < N)
            {
                res += dp[i - 1,j + 2];
            }
            if (i - 1 >= 0 && j - 2 >= 0)
            {
                res += dp[i - 1,j - 2];
            }
            if (i + 2 < N && j + 1 < N)
            {
                res += dp[i + 2,j + 1];
            }
            if (i + 2 < N && j - 1 >= 0)
            {
                res += dp[i + 2,j - 1];
            }
            if (i - 2 >= 0 && j + 1 < N)
            {
                res += dp[i - 2,j + 1];
            }
            if (i - 2 >= 0 && j - 1 >= 0)
            {
                res += dp[i - 2,j - 1];
            }
            return res;
        }