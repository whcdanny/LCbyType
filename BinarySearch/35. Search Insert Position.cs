//Leetcode 35. Search Insert Position ez
//题意：给定一个排序数组和一个目标值，在数组中找到目标值并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
//思路：二分搜索法:右两个指针，left 初始为数组开头，right 初始为数组末尾。
//在循环中，计算中间元素的索引 mid，比较 nums[mid] 与目标值 target 的大小。
//如果 nums[mid] == target，说明找到了目标值，返回 mid。
//如果 nums[mid] < target，说明目标值在 mid 右侧，将 left 指针移动到 mid + 1。
//如果 nums[mid] > target，说明目标值在 mid 左侧，将 right 指针移动到 mid - 1。
//时间复杂度：O(log N) - 二分搜索法。
//空间复杂度：O(1)
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }