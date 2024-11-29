//Leetcode 322. Coin Change med
//题目：给你一个coins代表不同面额硬币的整数数组和一个amount代表总金额的整数。
//返回凑足该金额所需的最少硬币数量。如果任何硬币组合都无法凑足该金额，则返回-1。
//你可能假设每种硬币的数量都是无限的。
//思路：动态规划dp，dp的容量是amount+1
//能否通过向较小金额（i - coin）的硬币数量中添加一枚这种硬币来实现此金额（i）的更好（更低）硬币数量
//从最小硬币开始，满足条件，Math.Min(dp[i], 1 + dp[i - coin])
//时间复杂度：O(n*m)
//空间复杂度：O(n)
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