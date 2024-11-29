//Leetcode 213. House Robber II med
//题意：你是一名职业强盗，计划抢劫街道两旁的房屋。
//每栋房子里都藏有一定数量的钱。
//这个地方的所有房子都排成一个圆圈。
//这意味着第一栋房子是最后一栋房子的邻居。
//同时，相邻的房屋都连接了安全系统， 如果同一晚有两栋相邻的房子被盗，它会自动联系警察。
//nums给定一个表示每家每户钱数的整数数组，返回你今晚在不引起警方注意的情况下可以抢劫的最大金额。
//思路：动态规划，因为是循环，所以把[0, n-2] 和 [1, n-1]两个区间
//然后找出最大值，然后在比价这两个区的最大值
//时间复杂度：O(n)
//空间复杂度：O(1) 
        public int Rob213(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];
            return Math.Max(robRange2(nums, 0, n - 2), robRange2(nums, 1, n - 1));
        }

        // 仅计算闭区间 [start,end] 的最优结果
        public int robRange2(int[] nums, int start, int end)
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