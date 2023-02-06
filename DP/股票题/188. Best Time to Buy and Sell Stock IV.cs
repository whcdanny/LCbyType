//188. Best Time to Buy and Sell Stock IV hard
//股票问题，给一个股票在一段时间的数值，然后问收入最大；限定k次交易；
//动态规划：因为限定交易次数k，就需要把每一次
//最优化空间  
		public int MaxProfit6(int k, int[] prices)
        {
            int n = prices.Length;
            if (n <= 0)
            {
                return 0;
            }
            if (k > n / 2)
            {
                // 复用之前交易次数 k 没有限制的情况
                return MaxProfit2(prices);
            }

            // base case：
            // dp[-1][...][0] = dp[...][0][0] = 0
            // dp[-1][...][1] = dp[...][0][1] = -infinity
            int[,,] dp = new int[n,k + 1,2];
            // k = 0 时的 base case
            for (int i = 0; i < n; i++)
            {
                dp[i,0,1] = Int32.MinValue;
                dp[i,0,0] = 0;
            }

            for (int i = 0; i < n; i++)
                for (int j = k; j >= 1; j--)
                {
                    if (i - 1 == -1)
                    {
                        // 处理 i = -1 时的 base case
                        dp[i,j,0] = 0;
                        dp[i,j,1] = -prices[i];
                        continue;
                    }
                    dp[i,j,0] = Math.Max(dp[i - 1,j,0], dp[i - 1,j,1] + prices[i]);
                    dp[i,j,1] = Math.Max(dp[i - 1,j,1], dp[i - 1,j - 1,0] - prices[i]);
                }
            return dp[n - 1,k,0];            
        }
		public int MaxProfit2(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                if (i - 1 == -1)
                {
                    // base case
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }
            return dp[n - 1, 0];
        }
		
//另一种算法，也是很简便，暂时不了解		
		public int MaxProfit6(int k, int[] prices)
        {            
            if (k <= 0 || prices == null || prices.Length == 0)
                return 0;

            if (k >= prices.Length / 2)
                return quickPath(prices);

            int[,] mem = new int[k + 1, prices.Length];

            for (int i = 1; i <= k; i++)
            {
                int localMax = -prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    mem[i, j] = Math.Max(mem[i, j - 1], prices[j] + localMax);
                    localMax = Math.Max(localMax, mem[i - 1, j] - prices[j]);
                }
            }

            return mem[k, prices.Length - 1];
        }
        private int quickPath(int[] prices)
        {
            int ret = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                ret += Math.Max(0, prices[i] - prices[i - 1]);
            }

            return ret;
        }