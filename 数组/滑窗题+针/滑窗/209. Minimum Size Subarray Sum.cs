//Leetcode 209. Minimum Size Subarray Sum med
//题意：给定一个正整数数组和一个正nums整数target，返回子阵列
//其和大于或等于 target。如果不存在这样的子数组，0则返回。
//思路：滑动窗口法：
//每一次right++，计算当前的subSum，如果大于k，然后left++，
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinSubArrayLen(int target, int[] nums)
        {           
            int left = 0, right = 0;
            int subSum = 0;
            int res = int.MaxValue;
            while (right < nums.Length)
            {
                subSum += nums[right];
                while (subSum >= target)
                {
                    res = Math.Min(res, right - left + 1);
                    subSum -= nums[left];
                    left++;
                }
                right++;
            }
            return res == int.MaxValue? 0:res;
        }