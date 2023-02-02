//33. Search in Rotated Sorted Array med
//给一个被旋转过的升序数列，查找target [0,1,2,4,5,6,7]=》[4,5,6,7,0,1,2]
//二分法： 由于被旋转过，所以只需要考虑left和mid和target直接的关系就可以，因为剩余的自然就在right那部分；
//例如 1 在 [4,5,6,7,0,1,2] [4]&[7]1即小于4，也小于7，那么肯定在右边所以left=mid+1；以此类推
		public int Search(int[] nums, int target)
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