//Leetcode 3176. Find the Maximum Length of a Good Subsequence I med
//题目：给定一个整数数组 nums 和一个非负整数 k。一个序列 seq 被称为 "good" 序列，若在 seq 中最多有 k 个相邻元素不同，
//即在 [0, seq.length - 2] 范围内满足 seq[i] != seq[i + 1] 的索引 i 的数量不超过 k。
//题目要求返回 nums 的子序列中 "good" 序列的最大可能长度。
//思路: 动态规划
//dp第 i 个元素结尾的子序列，且在相邻不等次数不超过 j 的情况下的最大长度,
//然后在 j=0 的情况下，每个元素本身可以作为长度为 1 的子序列。
//使用 numMap 存储每个元素的最近出现位置，方便在 O(1) 时间内找到当前元素上次出现的索引位置，以更新 dp[i][j] 的值
//当前元素与前一个元素不相同且允许增加不等次数（j > 0），我们可以基于 dp[i - 1][j - 1] 的长度来扩展当前子序列。
//可以利用 numMap 保存的上一次出现该元素的索引位置，通过 dp[numMap[nums[i]]][j] + 1 来更新子序列长度，避免相邻不同次数增加。
//时间复杂度：O(n^2*k)k 秒内每一秒都计算 n 个元素
//空间复杂度：O(n*k)
        public int MaximumLength_3176(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 0) return 0;
            //第 i 个元素结尾的子序列，且在相邻不等次数不超过 j 的情况下的最大长度
            int[][] dp = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                dp[i] = new int[k + 1];
            }
            //在 j=0 的情况下，每个元素本身可以作为长度为 1 的子序列。
            for (int i = 0; i < n; ++i) 
                dp[i][0] = 1;

            int res = 1;
            for (int j = 0; j <= k; ++j)
            {
                int max1 = 1;
                //使用 numMap 存储每个元素的最近出现位置，方便在 O(1) 时间内找到当前元素上次出现的索引位置，以更新 dp[i][j] 的值。
                Dictionary<int, int> numMap = new Dictionary<int, int>();
                numMap[nums[0]] = 0;

                for (int i = 1; i < n; ++i)
                {
                    dp[i][j] = 1;
                    //当前元素与前一个元素不相同且允许增加不等次数（j > 0），我们可以基于 dp[i - 1][j - 1] 的长度来扩展当前子序列。
                    if (i > 0 && j > 0) 
                        max1 = Math.Max(max1, dp[i - 1][j - 1] + 1);
                    dp[i][j] = Math.Max(dp[i][j], max1);
                    //可以利用 numMap 保存的上一次出现该元素的索引位置，通过 dp[numMap[nums[i]]][j] + 1 来更新子序列长度，避免相邻不同次数增加。
                    if (numMap.ContainsKey(nums[i]))
                    {
                        dp[i][j] = Math.Max(dp[i][j], dp[numMap[nums[i]]][j] + 1);
                    }

                    numMap[nums[i]] = i;
                    res = Math.Max(res, dp[i][j]);
                }
            }

            return res;
        }