//Leetcode 3250. Find the Count of Monotonic Pairs I hard
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
//时间复杂度：O(n * M)，其中 M 是 nums 的最大值
//空间复杂度：O(n * M)
        public int CountOfPairs(int[] nums)
        {
            var dp = new Dictionary<(int, int), long>();
            long result = CountOfPairs_dfs(nums, dp, 0, 0);
            return (int)(result % 1000000007);
        }

        private long CountOfPairs_dfs(int[] nums, Dictionary<(int, int), long> dp, int index, int num)
        {
            long modulo = 1000000007;

            if (index == nums.Length)
            {
                return 1;
            }

            if (dp.ContainsKey((index, num)))
            {
                return dp[(index, num)];
            }

            long localResult = 0;

            for (int x = num; x <= nums[index]; x++)
            {
                int y = nums[index] - x;

                if (index > 0 && y > nums[index - 1] - num)
                {
                    continue;
                }

                localResult += CountOfPairs_dfs(nums, dp, index + 1, x);
            }

            localResult %= modulo;
            dp[(index, num)] = localResult;
            return localResult;
        }