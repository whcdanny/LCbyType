//Leetcode 198. House Robber med
//题目：你是一名职业强盗，计划抢劫街道两旁的房屋。
//每栋房屋都藏有一定数量的钱，阻止你抢劫每栋房屋的唯一限制是相邻的房屋都连接了安全系统，
//如果同一晚有两栋相邻的房屋被盗，系统会自动联系警察。
//nums给定一个表示每家每户钱数的整数数组，返回你今晚在不引起警方注意的情况下可以抢劫的最大金额。
//思路：动态规划dp
//确定dp[0] 和 dp[1]
//然后因为我们不能选择相邻的两个房子去偷窃
//Math.Max(dp[i - 2] + nums[i], dp[i - 1])        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int Rob(int[] nums)
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