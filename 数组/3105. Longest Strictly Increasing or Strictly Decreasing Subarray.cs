//Leetcode 3105. Longest Strictly Increasing or Strictly Decreasing Subarray ez
//题目：给定一个整数数组 nums，返回其中 最长的严格递增或严格递减子数组的长度。
//严格递增子数组：每个元素都比前一个元素大。
//严格递减子数组：每个元素都比前一个元素小。
//子数组是原数组中的一个连续部分。
//思路: 历遍，
//如果是递增那么increaseCount++，decreaseCount=0；
//如果是递减那么decreaseCount++， increaseCount=0；
//如果相等increaseCount=0，decreaseCount=0；
//然后每一次更新longestSubarray
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int LongestMonotonicSubarray(int[] nums)
        {
            var increaseCount = 0;
            var decreaseCount = 0;
            var longestSubarray = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] - nums[i + 1] > 0)
                {
                    decreaseCount++;
                    increaseCount = 0;
                }
                else if (nums[i] - nums[i + 1] < 0)
                {
                    increaseCount++;
                    decreaseCount = 0;
                }
                else
                {
                    increaseCount = decreaseCount = 0;
                }

                longestSubarray = Math.Max(longestSubarray, Math.Max(decreaseCount, increaseCount));
            }

            return longestSubarray + 1;
        }