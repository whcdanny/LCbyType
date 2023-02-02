//704. Binary Search ez
//即搜索一个数，如果存在，返回其索引，否则返回 -1
//二分搜索：用区间来找，如果mid小于target 那么left=mid+1；反之right=mid-1；直到left<=rigth	
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