//Leetcode 343. Integer Break med
//题意：给定一个整数n，将其拆分为k 个正整数的和，其中k≥2，并使这些整数的乘积最大化。
//返回可以获得的最大乘积。
//思路：动态规划逐步计算 n 的最大乘积：
//定义dp[i] 表示整数i 的最大乘积。
//初始状态：dp[1]=1，即 1 的最大乘积为自身。
//转移方程：dp[i]=max(dp[i], j×max(i−j, dp[i−j]))
//时间复杂度：O(n^2)
//空间复杂度：O(n) 
        public int IntegerBreak(int n)
        {
            if (n <= 3) return n - 1;

            int[] dp = new int[n + 1];
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    dp[i] = Math.Max(dp[i], j * Math.Max(i - j, dp[i - j]));
                }
            }
            return dp[n];
        }