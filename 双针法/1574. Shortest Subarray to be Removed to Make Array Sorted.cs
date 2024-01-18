//Leetcode 1574. Shortest Subarray to be Removed to Make Array Sorted med
//题意：给定一个整数数组 arr，从数组中移除一个子数组（可以为空），使得剩余的元素按非递减顺序排列。
//返回移除的最短子数组的长度。
//子数组是数组的一个连续子序列。
//思路：找到需要移除的子数组的左边界。左边界可以通过从左到右遍历数组，找到第一个比右侧元素大的元素的位置。假设这个位置是 left。此时可以删除右边界以外的，但不保证移除是最短；
//然后，找到需要移除的子数组的右边界。右边界可以通过从右到左遍历数组，找到第一个比左侧元素小的元素的位置。假设这个位置是 right。  此时可以删除左边界以外的，但不保证移除是最短；
//然后比较左边界内的数字是否小于等于右边界，这样可以少删除一些，
//时间复杂度：O(n)
//空间复杂度：O(1)

        public int FindLengthOfShortestSubarray(int[] arr)
        {
            int n = arr.Length;

            // Find left boundary
            int left = 0;
            while (left + 1 < n && arr[left] <= arr[left + 1])
            {
                left++;
            }

            // If the array is already sorted, return 0
            if (left == n - 1)
            {
                return 0;
            }

            // Find right boundary
            int right = n - 1;
            while (right > left && arr[right] >= arr[right - 1])
            {
                right--;
            }

            // Calculate the length of the shortest subarray to remove
            int result = Math.Min(n - left - 1, right);

            // Check for the case where removing the prefix or suffix yields a shorter subarray
            for (; left >= 0; left--)
            {
                for(int i = right; i < n; i++)
                {
                    if (arr[left] > arr[i])
                        continue;
                    result = Math.Min(result, i - left - 1);
                    break;
                }
            }

            return result;
        }