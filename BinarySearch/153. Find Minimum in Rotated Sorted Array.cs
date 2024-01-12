//Leetcode 153. Find Minimum in Rotated Sorted Array med
//题意：假设一个按照升序排列的数组在预先未知的某个点上进行了旋转。你必须找出数组中的最小元素。   
//思路：二分搜索法: 左右两个指针，left 初始为数组开头，right 初始为数组末尾。
//判断中间元素 mid 与 right 指针所指的元素的关系。
//如果 nums[mid] > nums[right]，说明最小元素一定在 mid 右侧，将 left 指针移动到 mid + 1。
//如果 nums[mid] < nums[right]，说明最小元素一定在 mid 左侧，将 right 指针移动到 mid。
//如果 nums[mid] == nums[right]，无法判断最小元素在左侧还是右侧。将 right 指针左移一位。
//时间复杂度：O(log N) - 二分搜索法。
//空间复杂度：O(1)
        public int FindMin_153(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return nums[left];
        }