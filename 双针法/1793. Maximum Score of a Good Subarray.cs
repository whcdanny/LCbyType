//Leetcode 1793. Maximum Score of a Good Subarray hard
//题意：给定一个整数数组 nums（下标从 0 开始）和一个整数 k。
//定义子数组(i, j) 的得分为 min(nums[i], nums[i + 1], ..., nums[j]) * (j - i + 1)。一个好的子数组是一个子数组，其中 i <= k <= j。
//要求返回一个好的子数组的最大得分。       
//思路：双指针法，从中心 k 出发，向两侧扩展。计算包含 k 的好的子数组得分，并不断更新最大得分。
//左右指针，从中心 k 出发。
//计算当前子数组的得分，并更新最大得分。
//向两侧扩展指针，选择 min(nums[left], nums[right]) 较大的一侧进行扩展，保证得分最大化。
//注：较大的一侧进行扩展 是因为如果添加的数 大于minVal，那么我们的宽度增加 那么maxScore也就变大；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaximumScore(int[] nums, int k)
        {
            int left = k, right = k, minVal = nums[k], maxScore = nums[k];

            while (left > 0 || right < nums.Length - 1)
            {
                if ((left > 0 ? nums[left - 1] : 0) < (right < nums.Length - 1 ? nums[right + 1] : 0))
                {
                    right++;
                    minVal = Math.Min(minVal, nums[right]);
                }
                else
                {
                    left--;
                    minVal = Math.Min(minVal, nums[left]);
                }

                maxScore = Math.Max(maxScore, minVal * (right - left + 1));
            }

            return maxScore;
        }