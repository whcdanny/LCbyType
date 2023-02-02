//基本二分法
		public int binarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1; // 注意

            while (left <= right)// 注意
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1; // 注意
                else if (nums[mid] > target)
                    right = mid - 1; // 注意
            }
            return -1;
        }
//左侧边界的二分搜索
		//右边为开区间[left， right) 因为right = nums.Length;导致
		public int left_bound(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length; // 注意

            while (left < right)// 注意
            { 
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    right = mid;//缩小「搜索区间」的上界 right，在区间 [left, mid) 中继续搜索，即不断向左收缩，达到锁定左侧边界的目的
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid; // 注意
                }
            }
            // 此时 target 比所有数都大，返回 -1
            if (left == nums.Length) return -1;
            // 判断一下 nums[left] 是不是 target
            return nums[left] == target ? left : -1;
        }
		//用两边都封闭，根据上面的基础转换得来；
		public int left_bound1(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            // 搜索区间为 [left, right]
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    // 搜索区间变为 [mid+1, right]
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    // 搜索区间变为 [left, mid-1]
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 收缩右侧边界
                    right = mid - 1;
                }
            }
            // 判断 target 是否存在于 nums 中
            // 此时 target 比所有数都大，返回 -1
            if (left == nums.Length) return -1;
            // 判断一下 nums[left] 是不是 target
            return nums[left] == target ? left : -1;
        }
//右侧边界的二分查找
		public int right_bound(int[] nums, int target)
        {
            int left = 0, right = nums.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    left = mid + 1; // 注意增大「搜索区间」的左边界 left，使得区间不断向右靠拢，达到锁定右侧边界的目的
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid;
                }
            }
            // 判断 target 是否存在于 nums 中
            // 此时 left - 1 索引越界
            if (left - 1 < 0) return -1;
            // 判断一下 nums[left] 是不是 target
            return nums[left - 1] == target ? (left - 1) : -1;
        }
		//用两边都封闭，根据上面的基础转换得来；
        public int right_bound1(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 这里改成收缩左侧边界即可
                    left = mid + 1;
                }
            }
            // 最后改成返回 left - 1
            if (left - 1 < 0) return -1;
            return nums[left - 1] == target ? (left - 1) : -1;
        }		
