//Leetcode 704. Binary Search ez
//题意：给定一个升序排序的整数数组 nums，以及一个目标值 target。在数组中查找 target，如果 target 存在，则返回其索引，否则返回 -1。
//思路：二分搜索：适用于有序数组。其基本思路是通过比较目标值与中间元素的大小，缩小搜索范围，直到找到目标值或确定目标值不存在。        
//二分搜索：用区间来找，如果mid小于target 那么left=mid+1；反之right=mid-1；直到left<=rigth	
//时间复杂度: O(log n)，其中 n 是数组的长度
//空间复杂度：O(1)
	public int BinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            return -1;
        }