//Leetcode 3041. Maximize Consecutive Elements in an Array After Modification hard
//题意：给出了一个由正整数组成的数组 nums。
//初始时，你可以将数组中的任何一个元素的值增加至多1。
//然后，你需要从最终数组中选择一个或多个元素，使得这些元素在按升序排序时是连续的。
//例如，元素[3, 4, 5] 是连续的，而[3, 4, 6] 和[1, 1, 2, 3] 不是。
//要求返回你可以选择的最大元素数量。
//思路：动态规划：因为数值上相邻的两个数更容易被“连接”起来，所以我们显然会将nums进行排序。
//对于相邻的两个数nums[i-1]和nums[i]，假设其数值是a和b。
//如果a与b之间相差2，那么我们可以通过a+1然后与b相连。
//有dp[i][0] = dp[i - 1][1]+1，其中dp[i][] 的第二个下标表示对于nums[i]是否采取增1的操作。
//如果a与b之间相差1，dp[i][0] = dp[i - 1][0]+1. 但是也可以双方都进行自增操作，即dp[i][1] = dp[i - 1][1]+1
//如果a与b相同，那么必须将b+1之后连接在a后面，所以有dp[i][1] = dp[i - 1][0]+1. 
//但是其实不需要同时选取nums[i - 1] 和nums[i]，因为两者的数值相同，可以舍弃其中一个，
//但是保留所有以i-1为结尾的序列。即dp[i][0] = dp[i - 1][0] 和 dp[i][1] = dp[i - 1][1]。
//时间复杂度: O(n);
//空间复杂度：O(n)
        public int MaxSelectedElements(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int[,] dp = new int[1000005, 2];
            dp[0, 0] = 1;
            dp[0, 1] = 1;
            int res = 1;
            for(int i = 1; i < n; i++)
            {
                dp[i, 0] = 1;
                dp[i, 1] = 1;
                if (nums[i] == nums[i - 1])
                {
                    dp[i, 0] = Math.Max(dp[i, 0], dp[i - 1, 0] + 0);
                    dp[i, 1] = Math.Max(dp[i, 1], dp[i - 1, 1] + 0);
                    dp[i, 1] = Math.Max(dp[i, 1], dp[i - 1, 0] + 1);
                }
                else if (nums[i] - nums[i - 1] == 1)
                {
                    dp[i, 0] = Math.Max(dp[i, 0], dp[i - 1, 0] + 1);
                    dp[i, 1] = Math.Max(dp[i, 1], dp[i - 1, 1] + 1);
                }
                else if (nums[i] - nums[i - 1] == 2)
                {
                    dp[i, 0] = Math.Max(dp[i, 0], dp[i - 1, 1] + 1);                    
                }
                res = Math.Max(res, Math.Max(dp[i, 0], dp[i, 1]));
            }
            return res;            
        }