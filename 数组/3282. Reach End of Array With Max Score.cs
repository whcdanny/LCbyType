//Leetcode 3282. Reach End of Array With Max Score med
//题目：给定一个长度为 n 的整数数组 nums。目标是从索引 0 开始，跳跃到索引 n-1，只能跳跃到比当前索引大的位置。
//从索引 i 跳到索引 j 的得分计算为(j - i) * nums[i]。
//返回到达最后一个索引时的最大可能总得分。
//思路: 转换逻辑，我们想得到最大总得分，
//从i跳到j 一定是nums[j]>nums[i]
//所以设定totalScore 被初始化为 nums[0]，表示从数组第一个元素开始的得分。currentMax 被初始化为 nums[0]，表示当前的最大值为第一个元素。
//循环从索引 1 开始，一直到索引 n - 1（即 nums.Count - 2）。
//如果 nums[i] 大于 currentMax，则更新 currentMax 为 nums[i]，表示当前最大值已经改变。
//将 currentMax 累加到 totalScore 中。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public long FindMaximumScore(IList<int> nums)
        {
            int n = nums.Count - 1;

            if (n == 0) return 0;

            long totalScore = nums[0];
            int currentMax = nums[0];

            for (int i = 1; i < n; i++)
            {
                if (nums[i] > currentMax)
                {
                    currentMax = nums[i];
                }

                totalScore += currentMax;
            }

            return totalScore;
        }