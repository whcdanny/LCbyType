//309. Best Time to Buy and Sell Stock with Cooldown med
//股票问题，给一个股票在一段时间的数值，然后问收入最大；可多次交易 并且卖之后有一天的冷却；
//动态规划：dp_i_0表示手里没有股票的时候是多少钱，dp_i_1表示手里有股票我有多少钱此时为负数
// dp_i_0 每天有两个选择（今天选择 rest,今天选择 sell） 
// dp_i_1 每天有两个选择（今天选择 rest,今天选择 buy）   
//注意：因为可以多次交易 所以dp_i_0在被用到算在dp_i_1 并且注意 在计算dp_i_1时用到的时两天前的dp_i_0
//最优化空间   
		public int MaxProfit3(int[] prices)
        {
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
            int dp_pre_0 = 0; // 代表 dp[i-2][0]
            for (int i = 0; i < n; i++)
            {
                int temp = dp_i_0;//记录上一次没有股票的钱数
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);// 今天选择 rest,今天选择 sell => 我把股票卖了手里没有股票             
                dp_i_1 = Math.Max(dp_i_1, dp_pre_0 - prices[i]);//今天选择 rest,今天选择 buy => 我现在手里有股票
                dp_pre_0 = temp;
            }
            return dp_i_0;            
        }
//动态规划：没有上面空间优秀但是逻辑一样				
		public int MaxProfit3(int[] prices)
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
                if (i - 2 == -1)
                {
                    // base case 2
                    dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                    // i - 2 小于 0 时根据状态转移方程推出对应 base case
                    dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
                    continue;
                }
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 2, 0] - prices[i]);
            }
            return dp[n - 1, 0];
        }