//Leetcode 300. Longest Increasing Subsequence med
//题意：给定一个无序的整数数组 nums，找到其中最长上升子序列的长度
//思路：二分搜索：使用一个list存储当前长度为 i 的上升子序列，在list中找第一个大于nums[i]的位置，然后替换；这样最后list就有从0-某个位置都是递增，
//时间复杂度：O(N log N) - 遍历数组并进行二分查找。
//空间复杂度：O(N) - 需要额外的数组来保存状态。
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int n = nums.Length;
            int[] list = new int[n];
            Array.Fill(list, int.MaxValue);
            for (int i = 0; i < n; i++)
            {
                int iter = upperBound_LengthOfLIS(list, nums[i]);
                list[iter] = nums[i];
            }
            for (int i = n - 1; i >= 0; i--)
            {
                if (list[i] != int.MaxValue)
                    return i + 1;
            }
            return 0;
        }

        private int upperBound_LengthOfLIS(int[] list, int val)
        {
            int l = 0, r = list.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (list[m] < val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }
        //思路：使用一个数组 tails 来存储当前长度为 i 的上升子序列的末尾元素的最小值。遍历数组 nums，对于每个元素 num，如果 num 大于 tails 数组的最后一个元素，直接将 num 添加到 tails 数组末尾；
        //否则，使用二分查找找到 tails 中第一个大于等于 num 的元素，将其替换为 num。最终，tails 数组的长度即为所求。
        //时间复杂度：O(N log N) - 遍历数组并进行二分查找。
        //空间复杂度：O(N) - 需要额外的数组来保存状态。
        public int LengthOfLIS1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int n = nums.Length;
            int[] tails = new int[n];
            int len = 0;

            foreach (int num in nums)
            {
                int left = 0, right = len - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] < num)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                if (left == len)
                {
                    tails[len++] = num;
                }
                else
                {
                    tails[left] = num;
                }
            }

            return len;
        }