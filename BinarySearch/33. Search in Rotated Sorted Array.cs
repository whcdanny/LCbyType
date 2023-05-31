//33. Search in Rotated Sorted Array 
//是一个在旋转有序数组中搜索目标值
//由于数组经过旋转，可能会：目标值位于旋转点的左侧。目标值位于旋转点的右侧。我们可以使用二分查找的思想来解决这个问
        public int Search33(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] >= nums[left])
                {
                    if (target >= nums[left] && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (target <= nums[right] && target > nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }
        public int Search33_1(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;               
                if (nums[mid] == target)
                    return mid;
                else if (nums[left] == target)
                    return left;                
                else if (nums[left] < nums[mid])
                {
                    if (target > nums[left] && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else if (target < nums[left] || target > nums[mid])
                    {
                        left = mid + 1;
                    }
                }
                else if (nums[left] > nums[mid])
                {
                    if (target > nums[mid] && target < nums[left])
                    {
                        left = mid + 1;
                    }
                    else if (target < nums[mid] || target > nums[left])
                    {
                        right = mid - 1;
                    }
                }
                else if (nums[left] == nums[mid])
                {
                    left = mid + 1;
                }               
            }
            if (left - 1 < 0 || left-1 == nums.Length)
                return -1;
            return nums[left - 1] == target ? (left - 1) : -1;
        }