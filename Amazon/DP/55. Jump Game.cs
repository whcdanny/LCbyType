//Leetcode 55. Jump Game med
//题意：给你一个整数数组nums。你的初始位置是数组的第一个索引，数组中的每个元素代表你在该位置的最大跳跃长度。
//true若可以到达最后一个索引则返回，false否则。
//思路：动态规划，dp表示每个位置是否能到达；
//根据每个nums[i]，找出能到的最大位置int max = Math.Min(i + nums[i], n - 1);
//然后从max到i位置，更新dp[j] = true;
//时间复杂度：O(n)
//空间复杂度：O(n) 
        public bool CanJump(int[] nums)
        {
            int n = nums.Length;
            bool[] dp = new bool[n];

            dp[0] = true;

            for (int i = 0; i < n - 1; i++)
            {
                if (!dp[i])
                {
                    return false;
                }
                if (nums[i] > 0)
                {
                    int max = Math.Min(i + nums[i], n - 1);

                    for (int j = max; j > i && !dp[j]; j--)
                    {
                        if (j == n - 1)
                        {
                            return true;
                        }
                        dp[j] = true;
                    }
                }
            }

            return dp[n - 1];
        }