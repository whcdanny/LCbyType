//213. House Robber II med
//给一组数表示每个房子里有多少钱，要求抢最多的钱，要求不能邻近两个都抢；现在房子是一个圈
//思路：动态规划， 由于是一个圈，所以思路就改为，第一个选或者最后一个或者两个都不选；
//由于两个都不选肯定不是最多的，所以就考虑第一个选或者最后一个，
//第一个选就相当于[0,length-2] 选最后一个相当于[1， length-1]；
		public int Rob2(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];
            return Math.Max(robRange(nums, 0, n - 2),
                            robRange(nums, 1, n - 1));
        }

        // 仅计算闭区间 [start,end] 的最优结果
        public int robRange(int[] nums, int start, int end)
        {
            int n = nums.Length;
            int dp_i_1 = 0, dp_i_2 = 0;
            int dp_i = 0;
            for (int i = end; i >= start; i--)
            {
                dp_i = Math.Max(dp_i_1, nums[i] + dp_i_2);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }
//动态规划，不太好理解这个思路		
		public int Rob2(int[] nums)
        {            
            if(nums == null || nums.Length == 0)
                    return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);
            int[] dp = new int[nums.Length - 1];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length - 1; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            int prevMax = dp[nums.Length - 2];

            dp = new int[nums.Length - 1];
            dp[0] = nums[1];
            dp[1] = Math.Max(nums[1], nums[2]);
            for (int i = 3; i < nums.Length; i++)
            {
                dp[i - 1] = Math.Max(dp[i - 3] + nums[i], dp[i - 2]);
            }
            return Math.Max(prevMax, dp[nums.Length - 2]);
        }
    