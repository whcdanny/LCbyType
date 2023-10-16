//Leetcode 34. Find First and Last Position of Element in Sorted Array med
//题意：在一个升序排列的数组中，找到目标元素第一次和最后一次出现的位置。
//思路：二分法: 通过二分法找到目标元素的一个位置，然后再向左和向右扩展以找到第一次和最后一次出现的位置
//时间复杂度:  二分法的时间复杂度是 O(logn)，然后向左右扩展的过程的时间复杂度最坏情况下是 O(n)，O(logn + n) = O(n)
//空间复杂度： O(1)
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = { -1, -1 };

            int left = 0, right = nums.Length - 1;

            // Binary search to find any occurrence of the target
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    result[0] = mid;
                    result[1] = mid;
                    break;
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

            // If target is not found, return [-1, -1]
            if (result[0] == -1) return result;

            // Search left for the first occurrence
            left = 0;
            right = result[0] - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result[0] = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            // Search right for the last occurrence
            left = result[1] + 1;
            right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result[1] = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }