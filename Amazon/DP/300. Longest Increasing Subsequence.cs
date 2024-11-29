//Leetcode 300. Longest Increasing Subsequence med
//题意：给定一个无序的整数数组 nums，找到其中最长上升子序列的长度
//思路：动态规划，dp存每个位置的上升序列的个数
//nums[i] > nums[j] 找出i位置上升序列个数
//时间复杂度：O(N * N) - 遍历数组并进行二分查找。
//空间复杂度：O(N) - 需要额外的数组来保存状态。
        public int LengthOfLIS(int[] nums)
        {
            var answer = new int[nums.Length];
            Array.Fill(answer, 1);
            var result = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        answer[i] = Math.Max(answer[i], answer[j] + 1);
                        result = Math.Max(result, answer[i]);
                    }
                }
            }

            return result;
        }