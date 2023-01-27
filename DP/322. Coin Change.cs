//322. Coin Change med
//给定一下硬币值，然后给一个总数，找出最少需要几枚硬币可以满足
//暴力算法 O(K^N)
		public int CoinChange(int[] coins, int amount)
        {
            return dp(coins, amount);
        }
        public int dp(int[] coins, int amount)
        {
            //base case
            if (amount == 0) return 0;
            if (amount == 1) return 1;
            int res = int.MaxValue;
            foreach(int coin in coins)
            {
                int subres = dp(coins, amount - coin);
                if (subres == -1) continue;
                res = Math.Min(res, subres + 1);
            }
            return res == int.MaxValue ? -1 : res;
        }
//带备忘录的递归解法 O(KN)
		public int[] memo;
		public int CoinChange(int[] coins, int amount)
        {
            memo = new int[amount + 1];
            // 备忘录初始化为一个不会被取到的特殊值，代表还未被计算   
			Array.Fill(memo, -66);
            return dp(coins, amount);
        }

        public int dp(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            if (amount < 0) return -1;
            // 查备忘录，防止重复计算
            if (memo[amount] != -66)
                return memo[amount];

            int res = int.MaxValue;
            foreach (int coin in coins)
            {
                // 计算子问题的结果
                int subProblem = dp(coins, amount - coin);
                // 子问题无解则跳过
                if (subProblem == -1) continue;
                // 在子问题中选择最优解，然后加一
                res = Math.Min(res, subProblem + 1);
            }
            // 把计算结果存入备忘录
            memo[amount] = (res == int.MaxValue) ? -1 : res;
            return memo[amount];
        }
//DP
		 public int coinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            // 数组大小为 amount + 1，初始值也为 amount + 1
            Array.Fill(dp, amount + 1);

            // base case
            dp[0] = 0;
            // 外层 for 循环在遍历所有状态的所有取值
            for (int i = 0; i < dp.Length; i++)
            {
                // 内层 for 循环在求所有选择的最小值
                foreach (int coin in coins)
                {
                    // 子问题无解，跳过
                    if (i - coin < 0)
                    {
                        continue;
                    }
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }
            return (dp[amount] == amount + 1) ? -1 : dp[amount];
        }