//Leetcode 1877. Minimize Maximum Pair Sum in Array med
//题意：将给定数组 nums 分成 n/2 对，使得每对的最大数之和尽可能小。我们可以使用双指针法来解决这个问题。        
//思路：双指针
//对数组进行排序。
//使用两个指针，分别指向数组的开头和结尾，每次取一对数，将两个指针分别向中间移动，计算当前的最大数之和，并更新结果。
//返回最终的结果。
//时间复杂度：O(nlogn)，其中 n 是数组的长度
//空间复杂度：O(1)
        public int MinPairSum(int[] nums)
        {
            // 先对数组进行排序
            Array.Sort(nums);

            int n = nums.Length;
            int left = 0, right = n - 1;
            int result = 0;

            while (left < right)
            {
                // 计算当前的最大数之和，并更新结果
                int currentSum = nums[left] + nums[right];
                result = Math.Max(result, currentSum);

                // 移动指针
                left++;
                right--;
            }

            return result;
        }
