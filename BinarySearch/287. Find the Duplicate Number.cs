//Leetcode 287. Find the Duplicate Number med
//题意：给定一个包含 n + 1 个整数的数组 nums，其中每个整数在 1 到 n 之间，包括 1 和 n ，可知至少存在一个重复的整数。假设只有一个重复的整数，找出这个重复的数。
//思路：二分搜索：由于数组中的元素在 1 到 n 之间，我们可以对这个范围进行二分查找。假设中间的数为 mid，我们统计数组中小于等于 mid 的元素的个数，
//如果个数大于 mid，则说明重复数位于 [1, mid] 之间，否则重复数位于 [mid + 1, n] 之间。这样我们可以逐步缩小搜索的范围，最终找到重复的数。
//时间复杂度：O(N log N) - 遍历数组并进行二分查找。
//空间复杂度：O(1)
        public int FindDuplicate(int[] nums)
        {
            int left = 1, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int count = 0;
                foreach (int num in nums)
                {
                    if (num <= mid)
                    {
                        count++;
                    }
                }
                if (count > mid)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }