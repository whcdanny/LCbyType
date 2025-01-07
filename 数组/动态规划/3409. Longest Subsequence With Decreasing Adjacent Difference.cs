//Leetcode 3409. Longest Subsequence With Decreasing Adjacent Difference med
//题意：给定一个整数数组 nums。
//要求找到一个最长的子序列 seq，使得该子序列中相邻元素之间的绝对差值形成一个非递增序列。
//也就是说，对于子序列必须满足以下条件：
//seq0, seq1, seq2, ..., seqm of nums, |seq1 - seq0| >= |seq2 - seq1| >= ... >= |seqm - seqm - 1|. 
//返回满足条件的最长子序列的长度。
//注意：子序列的元素顺序必须与原数组一致，但可以删除一些或不删除任何元素。子序列必须非空。
//思路：动态规划 然后因为1 <= nums[i] <= 300
//所以我们找出0-300对应每个num的所有diff的个数，并且从300-0找出diff只要
//只要diff越大的个数下降赋予diff-1
//这里注意dp[num, 3] = 5，那么 dp[num, 2] 至少也应该是 5
//所以dp[num, diff] 来记录以 num 结尾、绝对差值为 diff 以及以上的最长子序列长度。
//先用300-0 依此找出跟diff = Math.Abs(num - i); 然后Math.Max(dp[num, diff], dp[i, diff] + 1);
//然后再跟新dp[num, i] = Math.Max(dp[num, i], dp[num, i + 1]); i也是从299-0
//ans = Math.Max(ans, dp[num, 0]);
//时间复杂度:  O(n×300×300)=O(90,000n)
//空间复杂度： O(90,601)≈O(10^5)

        public int LongestSubsequence(int[] nums)
        {
            int[,] dp = new int[301, 301];
            bool[] arr = new bool[301];
            int ans = 0;

            foreach (int num in nums)
            {
                for (int i = 300; i >= 0; --i)
                {
                    if (arr[i])
                    {
                        int diff = Math.Abs(num - i);
                        dp[num, diff] = Math.Max(dp[num, diff], dp[i, diff] + 1);
                    }
                }
                for (int i = 299; i >= 0; --i)
                {
                    dp[num, i] = Math.Max(dp[num, i], dp[num, i + 1]);
                }
                ans = Math.Max(ans, dp[num, 0]);
                arr[num] = true;
            }

            return ans + 1;
        }