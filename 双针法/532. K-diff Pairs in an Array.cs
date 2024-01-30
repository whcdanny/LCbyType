//Leetcode 532. K-diff Pairs in an Array med
//题意：给定一个整数数组 nums 和一个整数 k，要求返回数组中唯一的 k-diff 对的数量。k-diff 对是指数组中的一对整数 (nums[i], nums[j])，满足以下条件：
//0 <= i, j<nums.length
//i != j
//|nums[i] - nums[j]| == k
//其中 |val| 表示 val 的绝对值。       
//思路：双指针，数组 nums 进行排序，以便使用双指针法。
//使用两个指针 left 和 right 分别表示数组中的两个元素。
//遍历数组，计算当前两个元素的差值 diff。
//如果 diff == k，说明找到了一个 k-diff 对，将计数器 count 增加 1，并将两个指针向前移动。
//如果 diff<k，将 right 向前移动。
//如果 diff > k，将 left 向前移动。
//避免重复计数，如果找到一个 k-diff 对，将 right 移动到下一个不重复的元素。
//继续遍历直到 right 到达数组末尾。
//返回计数器 count。
//时间复杂度：O(nlogn)
//空间复杂度：O(1)
        public int FindPairs(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
            {
                return 0;
            }

            Array.Sort(nums);

            int count = 0;
            int left = 0;
            int right = 1;

            while (left < nums.Length && right < nums.Length)
            {
                if (left != right && nums[right] - nums[left] == k)
                {
                    count++;
                    left++;
                    right++;
                    while (right < nums.Length && nums[right] == nums[right - 1])
                    {
                        right++;  // 避免重复计数
                    }
                }
                else if (nums[right] - nums[left] < k)
                {
                    right++;
                }
                else
                {
                    left++;
                    if (left == right)
                    {
                        right++;
                    }
                }
            }

            return count;
        }