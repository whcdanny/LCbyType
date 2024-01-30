//Leetcode 581. Shortest Unsorted Continuous Subarray med
//题意：给定一个整数数组 nums，需要找到一个连续的子数组，使得如果你只对这个子数组进行升序排序，那么整个数组将变为非递减排序状态。要求返回这个最短的子数组的长度。
//思路：双指针，从左到右找到第一个开始递减的位置，得到左边界 left。
//如果整个数组已经有序（即 left 到达数组末尾前一个位置），直接返回 0。
//然后从右到左找到第一个开始递减的位置，得到右边界 right。
//在找到左右边界后，寻找中间未排序部分的最小值 minVal 和最大值 maxVal。
//从左边界开始，找到正确的左边界位置，即比 minVal 大的第一个位置。
//从右边界开始，找到正确的右边界位置，即比 maxVal 小的第一个位置。
//计算最短未排序子数组的长度为 right - left - 1。
//时间复杂度：O(n)，其中 n 是数组的长度
//空间复杂度：O(1)
        public int FindUnsortedSubarray(int[] nums)
        {
            int n = nums.Length;

            // 找到左边界
            int left = 0;
            while (left < n - 1 && nums[left] <= nums[left + 1])
            {
                left++;
            }

            // 如果数组已经有序，直接返回 0
            if (left == n - 1)
            {
                return 0;
            }

            // 找到右边界
            int right = n - 1;
            while (right > 0 && nums[right] >= nums[right - 1])
            {
                right--;
            }

            // 寻找中间未排序部分的最小值和最大值
            int minVal = int.MaxValue, maxVal = int.MinValue;
            for (int i = left; i <= right; i++)
            {
                minVal = Math.Min(minVal, nums[i]);
                maxVal = Math.Max(maxVal, nums[i]);
            }

            // 找到左边界的正确位置
            while (left >= 0 && nums[left] > minVal)
            {
                left--;
            }

            // 找到右边界的正确位置
            while (right < n && nums[right] < maxVal)
            {
                right++;
            }

            // 计算最短未排序子数组的长度
            return right - left - 1;
        }