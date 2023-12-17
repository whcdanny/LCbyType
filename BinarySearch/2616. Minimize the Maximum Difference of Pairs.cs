//Leetcode 2616. Minimize the Maximum Difference of Pairs med
//题意：给定一个整数数组 nums 和一个整数 p，找到 p 对数组的索引，使得所有这些索引对的最大差异尽可能小。同时，确保在这 p 对索引中，每个索引都不会出现两次。
//对于数组中的元素 nums[i] 和 nums[j]，它们的差异定义为 |nums[i] - nums[j]|，其中 |x| 表示 x 的绝对值。
//返回所有 p 对中最小的最大差异值。如果 p 对中有重复的索引，返回零。
//思路：二分搜索和贪婪方法, p对之间尽可能最小的最大差异。最大差异的潜在范围进行二分搜索。只要找到最小的差值能满足p，那么这个差值小的，就不会有比这个最小还满足条件的；
//注：从差值开始二分法，是因可以通过算出的对儿数与p来做比较，这样就找到最小的数目之间的的最大差值；
//时间复杂度:  O(n log m)，其中nnn是数组的长度，m是数组中最大值和最小值之间的差。对数组进行排序需要 O(n log n)，二分查找过程与贪心检查相结合需要 O(n log m)。
//空间复杂度： O(1)。我们只为变量使用恒定的空间。
        public int MinimizeMax(int[] nums, int p)
        {
            Array.Sort(nums);

            int left = 0, right = nums[nums.Length - 1] - nums[0];

            while (left < right)
            {
                int mid = (left + right) / 2;
                //如果我们能够形成所需的对，我们当前的mid值是可行的
                if (CanFormPairs(nums, mid, p))
                {
                    right = mid;
                }
                //则说明我们的 mid 值太小
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        private bool CanFormPairs(int[] nums, int mid, int p)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 1 && count < p;)
            {
                if (nums[i + 1] - nums[i] <= mid)
                {
                    count++;
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            return count >= p;
        }