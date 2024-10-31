//Leetcode 3251. Find the Count of Monotonic Pairs II hard
//题目：给定一个正整数数组 nums，长度为 n。我们需要找到数组 (arr1, arr2) 的所有符合条件的对数，其中：
//数组 arr1 和 arr2 的长度均为 n。
//arr1 单调不减，即 arr1[0] <= arr1[1] <= ... <= arr1[n - 1]。
//arr2 单调不增，即 arr2[0] >= arr2[1] >= ... >= arr2[n - 1]。
//对于每个 0 <= i<n，arr1[i] + arr2[i] == nums[i]。
//目标是计算所有符合条件的 (arr1, arr2) 对数，结果对 
//10^9 +7 取模。
//思路:递归 + 动态规划 (Memoization)：
//使用 DFS 递归生成满足条件的 arr1 和 arr2。
//使用 dp 字典来缓存子问题的解，减少重复计算。
//每次递归调用时，选择当前 arr1 的数值 x，并在 arr2 中计算满足 arr1[i] + arr2[i] == nums[i] 的条件。
//时间复杂度：O(n * m)，其中 n 是数组长度，m 是 nums[i] 可能的最大值
//空间复杂度：O(m)，只需要一个大小为 m 的 dp 数组
        public int CountOfPairs1(int[] nums)
        {
            int n = nums.Length;
            int m = 1001;
            int mod = 1000000007;
            int[] dp = new int[m];// 定义 dp 数组来存储中间计算结果
            Array.Fill(dp, 1); // 初始化 dp 数组，假设初始状态下每个位置都有 1 个配对可能

            for (int i = 1; i < n; ++i)
            {
                int d = Math.Max(0, nums[i] - nums[i - 1]); //这决定了新元素纳入时满足条件的单调性差异范围。
                //小到大更新 dp[j]，表示从位置 j 开始到 j-1 之间可达成的配对数目
                for (int j = 1; j < nums[i] + 1; ++j)
                {
                    //包含之前计算出的递增组合数
                    dp[j] = (dp[j] + dp[j - 1]) % mod;
                }
                //确保单调性符合当前 nums[i] 及之前所有元素的递增规则
                for (int j = nums[i]; j >= d; --j)
                {
                    //将所有差异在 d 范围内的数值设置为符合条件的组合数
                    dp[j] = dp[j - d];
                }
                //dp 值设为 0，因为这些值已经不符合当前 nums[i] 所需的单调性条件
                for (int j = d - 1; j >= 0; --j)
                {
                    dp[j] = 0;
                }
            }

            int res = 0;
            for (int j = 0; j <= nums[n - 1]; ++j)
                res = (res + dp[j]) % mod;

            return res;
        }