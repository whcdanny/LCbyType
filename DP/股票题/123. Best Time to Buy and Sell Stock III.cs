//123. Best Time to Buy and Sell Stock III hard
//股票问题，给一个股票在一段时间的数值，然后问收入最大；只能交易2次；
//动态规划：dp_i_0表示手里没有股票的时候是多少钱，dp_i_1表示手里有股票我有多少钱此时为负数
// dp_i_0 每天有两个选择（今天选择 rest,今天选择 sell） 
// dp_i_1 每天有两个选择（今天选择 rest,今天选择 buy）   
//因为两天为了方便和之前版本理解 这里加上dp_i20，dp_i21
//注意：因为只能交易2次 所以dp_i_0在被用到算在dp_i_1，而dp_i21 要用到dp_i10；
//最优化空间  
		public int MaxProfit5(int[] prices)
        {
            // base case
            int dp_i10 = 0, dp_i11 = Int32.MinValue;
            int dp_i20 = 0, dp_i21 = Int32.MinValue;
            foreach (int price in prices)
            {
                dp_i20 = Math.Max(dp_i20, dp_i21 + price);
                dp_i21 = Math.Max(dp_i21, dp_i10 - price);
                dp_i10 = Math.Max(dp_i10, dp_i11 + price);
                dp_i11 = Math.Max(dp_i11, -price);
            }
            return dp_i20;            
        }
//这个方法暂时不理解		
		public int MaxProfit5(int[] prices)
        {           
            int n = prices.Length;
            int profit = 0;


            int[] left = new int[n];
            int min = prices[0];

            for (int i = 1; i < n; i++)
            {
                left[i] = Math.Max(left[i - 1], prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            int[] right = new int[n];
            int max = prices[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = Math.Max(right[i + 1], max - prices[i]);
                max = Math.Max(max, prices[i]);

                profit = Math.Max(profit, left[i] + right[i]);
            }

            return profit;
        }