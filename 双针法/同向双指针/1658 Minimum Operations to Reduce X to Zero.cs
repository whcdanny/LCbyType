//Leetcode 1658 Minimum Operations to Reduce X to Zero med
//题意：给定一个整数数组 nums 和一个目标值 x，可以执行以下操作：从数组的最左侧或最右侧选择一个元素。对选定的元素进行减少 x 单位的操作。找到通过最少的操作将数组中的元素总和变为零。
//思路：双指针方法来解决这个问题。先计算数组的总和 total。将目标值 x 转换成一个减法问题，即找到一个子数组，其和为 total - x。使用双指针来找到一个子数组，使得其和为 total - x，即找到一个连续子数组，使得其和最大。记录当前子数组的长度，然后不断移动右指针，直到找到满足条件的子数组。在满足条件的子数组中，不断移动左指针，缩小子数组长度，找到最短的子数组。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： O(1)
        public int MinOperations(int[] nums, int x)
        {
            int left = 0, right = 0;
            int total = nums.Sum();
            int target = total - x;
            int sum = 0;
            int maxLen = -1;

            while (right < nums.Length)
            {
                sum += nums[right];
                while (sum > target && left <= right)
                {
                    sum -= nums[left];
                    left++;
                }

                if (sum == target)
                {
                    maxLen = Math.Max(maxLen, right - left + 1);
                }

                right++;
            }

            return maxLen == -1 ? -1 : nums.Length - maxLen;
        }