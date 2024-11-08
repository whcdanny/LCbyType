//Leetcode 3190. Find Minimum Operations to Make All Elements Divisible by Three ez
//题目：给定一个整数数组 nums，每次操作可以对数组中的任意元素加 1 或减 1。
//目标是将数组中的所有元素都变成 3 的倍数，且需要操作次数最少。
//思路: 对每个元素 num 计算其除以 3 的余数 num % 3。根据余数的不同情况，分别计算所需的最小操作次数：
//余数为 0：已经是 3 的倍数，不需要操作。
//余数为 1：需要执行一次操作，减少 1 或增加 2 来使该元素成为 3 的倍数。
//余数为 2：需要执行一次操作，减少 2 或增加 1 来使该元素成为 3 的倍数
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinimumOperations(int[] nums)
        {
            int operations = 0;

            foreach (var num in nums)
            {
                int remainder = num % 3;
                if (remainder == 1)
                {
                    operations += 1; // 减 1 或加 2
                }
                else if (remainder == 2)
                {
                    operations += 1; // 加 1 或减 2
                }
            }

            return operations;
        }