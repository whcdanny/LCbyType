//Leetcode 3277. Maximum XOR Score Subarray Queries hard
//题目：给定一个整数数组 nums 和一个二维整数数组 queries，其中 queries[i] = [li, ri] 表示一个子数组查询。对于每个查询 [li, ri]，你需要找到从 nums[li..ri] 中任意子数组的最大 XOR 分数。
//XOR 分数的计算方法是：
//对于给定的数组 a，每次将 a[i] 替换为 a[i] XOR a[i + 1]（除了最后一个元素）。
//删除最后一个元素。
//重复上述步骤直到数组中只剩下一个元素，这个元素就是该数组的 XOR 分数。
//返回一个大小为 q 的数组 answer，其中 answer[i] 是查询 queries[i] 的结果。
//思路: 动态规划，计算所有子数组的 XOR：
//dp[i, j] 表示从 i 到 j 的子数组的 XOR 值。
//使用动态规划方法计算，先初始化单个元素的 XOR 值，然后根据之前的计算结果逐步扩展。
//dp[j, j + i] = dp[j, j + i - 1] ^ dp[j + 1, j + i];
//然后找出dp[j, j + i] 最大值；
//最后根据queries 去找对应的答案
//时间复杂度：O(n^2)
//空间复杂度：O(n^2)
        public int[] MaximumSubarrayXor(int[] nums, int[][] queries)
        {
            int n = nums.Length;

            // 创建二维数组 dp，用来存储子数组的 XOR 值
            int[,] dp = new int[n, n];

            // 初始化数组 dp 的对角线，表示单个元素的 XOR 值
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = nums[i];
            }

            // 计算所有可能的子数组的 XOR 值
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j + i < n; j++)
                {
                    dp[j, j + i] = dp[j, j + i - 1] ^ dp[j + 1, j + i];
                }
            }

            // 找到每个子数组的最大 XOR 值
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j + i < n; j++)
                {
                    dp[j, j + i] = Math.Max(dp[j, j + i], Math.Max(dp[j, j + i - 1], dp[j + 1, j + i]));
                }
            }

            // 根据查询结果填充 res 数组
            int[] res = new int[queries.Length];
            int idx = 0;
            foreach (var query in queries)
            {
                res[idx++] = dp[query[0], query[1]];
            }
            return res;
        }