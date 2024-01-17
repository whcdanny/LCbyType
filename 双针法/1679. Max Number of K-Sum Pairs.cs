//Leetcode 1679. Max Number of K-Sum Pairs med
//题意：给定一个整数数组 nums 和一个整数 k。每次操作，可以从数组中选择两个数，使它们的和等于 k，然后将这两个数从数组中移除。求在给定数组上能够执行的最大操作次数。
//思路：双指针对数组 nums 进行排序。
//初始化双指针 left 和 right 分别指向数组的头和尾。
//循环条件为 left<right，在每一轮循环中，判断 nums[left] + nums[right] 是否等于 k。
//如果等于 k，则表示找到一对数满足和为 k，可以执行一次操作，同时移动双指针 left 和 right。
//如果小于 k，则说明当前和小于目标值 k，需要增大和，因此移动指针 left。
//如果大于 k，则说明当前和大于目标值 k，需要减小和，因此移动指针 right。
//时间复杂度：O(nlogn)
//空间复杂度：O(1)
        public int MaxOperations(int[] nums, int k)
        {
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1;
            int count = 0;

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == k)
                {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < k)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return count;
        }