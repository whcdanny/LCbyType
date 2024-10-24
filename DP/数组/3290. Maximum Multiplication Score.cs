//Leetcode 3290. Maximum Multiplication Score med
//题目：给定一个整数数组 a，其大小为 4，另一个整数数组 b 的大小至少为 4。
//你需要从数组 b 中选择 4 个索引 i0、i1、i2 和 i3，使得 i0 < i1 < i2 < i3。
//你的得分将等于以下公式：score=a[0]×b[i0]+a[1]×b[i1]+a[2]×b[i2]+a[3]×b[i3] 返回你可以获得的最大得分。
//思路：DP 动态规划
//通过逐步计算数组 b 的前 i 个元素和数组 a 的前 j 个元素的最佳乘积组合，来找到最大得分。
//使用倒序遍历内层循环的目的是避免重复计算，保证更新 dp[j] 的时候不会覆盖掉 dp[j-1]。
//更新dp就是比较最大值：当前dp[i]和前一个dp[i-1]+a[i]*b[i]
//然后当长度4的时候更新res
//时间复杂度：O(n)，其中 n 是数组
//空间复杂度：O(1)
        public long MaxScore(int[] a, int[] b)
        {
            long[] dp = new long[5];
            dp[0] = 0; // no chosen elements result is 0
            for (int j = 1; j <= 4; j++)
                dp[j] = long.MinValue;
            long result = long.MinValue;
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 4; j >= 1; j--)
                {
                    if (j > (i + 1)) continue;
                    dp[j] = Math.Max(dp[j - 1] + b[i] * (long)a[j - 1], dp[j]);
                    if (j == 4)
                    {
                        result = Math.Max(result, dp[j]);
                    }
                }
            }
            return result;
        }