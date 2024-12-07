//Leetcode 376. Wiggle Subsequence med
//题目：一个摆动序列是指相邻数字的差值严格地交替为正数和负数的序列。序列中第一个差值可以是正数或负数。
//如果只有一个元素的序列，或者两个不同的元素构成的序列，显然是摆动序列。
//示例：
//[1, 7, 4, 9, 2, 5] 是一个摆动序列，因为差值依次是[6, -3, 5, -7, 3]，严格交替。
//[1, 4, 7, 2, 5] 不是摆动序列，因为前两个差值都是正数。
//[1, 7, 4, 5, 5] 也不是摆动序列，因为最后一个差值为零。
//任务：给定一个整数数组 nums，返回其最长摆动子序列的长度。子序列是通过删除原数组中的一些元素（不改变顺序）得到的。
//思路: 贪心法（优化解法）：
//表示到当前位置为止的最长摆动子序列长度。
//每次只关注当前元素与前一个元素的关系：
//nums[i]>nums[i−1]：up = down + 1。    
//nums[i]<nums[i−1]：down = up + 1。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int WiggleMaxLength(int[] nums)
        {            
            int posCount = 1;
            int negCount = 1;            
            
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    posCount = negCount + 1;
                }
                else if (nums[i] < nums[i - 1])
                {
                    negCount = posCount + 1;
                }
            }

            return Math.Max(posCount,negCount);
        }