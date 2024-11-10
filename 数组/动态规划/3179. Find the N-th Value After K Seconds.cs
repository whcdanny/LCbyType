//Leetcode 3179. Find the N-th Value After K Seconds med
//题目：给定两个整数 n 和 k，初始时，有一个长度为 n 的数组 a，其中所有元素都初始化为 1，即 a[i] = 1（对于所有 0 <= i <= n - 1）。
//每秒都会对数组中的元素进行更新，每个元素会变为它自身与所有前缀和的和。更新规则如下：
//a[0] 保持不变。
//a[1] 更新为 a[0] + a[1]。
//a[2] 更新为 a[0] + a[1] + a[2]。
//经过 k 秒之后，返回 a[n - 1] 的值。
//由于最终答案可能非常大，结果需要对 10^9 + 7 取模。
//思路: 动态规划
//每秒建立两个dp，一个表示最后k秒，一个就是每秒的，
//a[i] 的新值是 a[i] = a[i - 1] + a[i]。
//使用额外数组 dp 来记录 a[n - 1] 的每秒计算结果，避免直接更新整个数组。
//时间复杂度：O(n∗k)k 秒内每一秒都计算 n 个元素
//空间复杂度：O(n)
        public int ValueAfterKSeconds(int n, int k)
        {
            int MOD = 1000000007;
            int[] dp = new int[n];
            Array.Fill(dp, 1);

            for (int t = 0; t < k; t++)
            {
                int[] newDp = new int[n];
                newDp[0] = dp[0];

                for (int i = 1; i < n; i++)
                {
                    newDp[i] = (newDp[i - 1] + dp[i]) % MOD;
                }

                dp = newDp;
            }

            return dp[n - 1];
        }