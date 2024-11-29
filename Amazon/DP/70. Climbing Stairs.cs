//Leetcode 70. Climbing Stairs ez
//题目：你正在爬楼梯。需要走n几步才能到达顶部。
//每次你可以选择爬山1或2走楼梯。有多少种不同的方式可以爬到顶部？
//思路：动态规划dp
//每次您可以爬 1 或 2 步。当您迈出一步时，n 的值将减少到 n-1，同样，如果您迈出 2 步，它将减少到 n-2。
//通过将爬 n-1 个楼梯的方法数与爬 n-2 个楼梯的方法数相加来计算原始问题的解
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);
            int k = ClimbStairsHelper(n, dp);
            return k;
        }

        public int ClimbStairsHelper(int n, int[] dp)
        {
            if (n <= 1) return 1;
            if (dp[n] != -1) return dp[n];
            dp[n] = ClimbStairsHelper(n - 1, dp) + ClimbStairsHelper(n - 2, dp);
            return dp[n];
        }