//509. Fibonacci Number ez
//暴力算法 O(N^2)
		public int Fib(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
//带备忘录的递归解法 O(N)
		public int Fib(int n)
        {
            // 备忘录全初始化为 0
            int[] memo = new int[n + 1];
            // 进行带备忘录的递归
            return helper(memo, n);
        }
        public int helper(int[] memo, int n)
        {
            // base case
            if (n == 0 || n == 1) return n;
            // 已经计算过，不用再计算了
            if (memo[n] != 0) return memo[n];
            memo[n] = helper(memo, n - 1) + helper(memo, n - 2);
            return memo[n];
        }
//动态规划DP O(N)
		public int fib(int n)
        {
            if (n == 0) return 0;
            int[] dp = new int[n + 1];
            // base case
            dp[0] = 0; dp[1] = 1;
            // 状态转移
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
//优化动态规划 O(1)
		public int fib(int n)
        {
            if (n == 0 || n == 1)
            {
                // base case
                return n;
            }
            // 分别代表 dp[i - 1] 和 dp[i - 2]
            int dp_i_1 = 1, dp_i_2 = 0;
            for (int i = 2; i <= n; i++)
            {
                // dp[i] = dp[i - 1] + dp[i - 2];
                int dp_i = dp_i_1 + dp_i_2;
                // 滚动更新
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i_1;
        }	
