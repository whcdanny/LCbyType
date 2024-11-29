//Leetcode 377. Combination Sum IV med
//题意：给定一个由不同正整数组成的数组 nums 和一个目标整数 target，返回能够凑成目标整数的所有可能组合的数量。
//每个数字在组合中可以被无限次使用。
//数组中的顺序不同被视为不同的组合。
//思路：动态规划，1.
//设 dp[i] 表示目标值为 i 时，能凑成的组合数量。
//2. 状态转移方程
//对于每一个数 num 和目标值 i：  
//如果 i >= num，则 dp[i] += dp[i - num]。
//意思是：当前目标值 i 的组合方式，可以由目标值 i - num 的组合方式加上当前数 num 组成。
//3. 初始化 dp[0] = 1：目标为 0 时，只有一种方式，就是空组合。
//时间复杂度：O(target * n)
//空间复杂度：O(target)      
        public int CombinationSum4(int[] nums, int target)
        {
            // dp[i] 表示凑成目标值 i 的组合数量
            int[] dp = new int[target + 1];
            dp[0] = 1; // 初始化：凑成目标值 0 只有一种方式，即空组合

            // 遍历每个可能的目标值
            for (int i = 1; i <= target; i++)
            {
                foreach (int num in nums)
                {
                    if (i >= num)
                    {
                        dp[i] += dp[i - num];
                    }
                }
            }

            return dp[target];
        }