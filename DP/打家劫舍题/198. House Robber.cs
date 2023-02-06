//198. House Robber med
//给一组数表示每个房子里有多少钱，要求抢最多的钱，要求不能邻近两个都抢；
//思路：动态规划，先把第一户和第二户的最大钱数算出，后面每一户找max（前面两户的最大值+当前值，前面一户的最大值）
		public int Rob1(int[] nums)
        {            
            int n = nums.Length;
            // 记录 dp[i+1] 和 dp[i+2]
            int dp_i_1 = 0, dp_i_2 = 0;
            // 记录 dp[i]
            int dp_i = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                dp_i = Math.Max(dp_i_1, nums[i] + dp_i_2);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }
		public int Rob1(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }