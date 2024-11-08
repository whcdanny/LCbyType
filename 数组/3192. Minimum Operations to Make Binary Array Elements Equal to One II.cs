//Leetcode 3192. Minimum Operations to Make Binary Array Elements Equal to One II med
//题目：给定一个二进制数组 nums，每次可以选择一个索引 i，
//将从 i 到数组末尾的所有元素进行翻转（0 变成 1，1 变成 0）。
//目标是找出最少的翻转次数，使得数组中的所有元素都变成 1
//思路: 贪心策略：
//flip： 设定一个变量 flip，用来表示当前的“翻转状态”：
//如果 flip = 0，表示数组在当前位置之前没有翻转；
//如果 flip = 1，表示数组在当前位置之前被翻转过。
//flip 是一种优化方式，帮助我们记录并控制是否需要翻转当前位置，而不是实际去翻转数组中的每个元素。
//当 nums[i] 和 flip 异或后为 0 时，说明当前位置在当前翻转状态下是 0，这意味着我们需要执行翻转操作，使 nums[i] 变成 1。
//之所以用异或，是因为 flip 可以模拟数组的翻转效果。也就是说：
//如果 flip = 0，实际值就是 nums[i]；
//如果 flip = 1，实际值就是 1 - nums[i]，模拟了翻转效果。
//说白了用flip来表示前面是否反转，如果当前nums[i]与flip为0，说明根据前面的反转，当前nums[i]需要反转，无论这个数是不是1
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinOperations1(int[] nums)
        {
            int n = nums.Length;
            int flip = 0; // 当前翻转状态
            int operations = 0;

            for (int i = 0; i < n; i++)
            {
                // 如果当前位置与当前状态 flip 异或为 0，则需要翻转
                if ((nums[i] ^ flip) == 0)
                {
                    operations++;
                    flip ^= 1; // 更新翻转状态
                }
            }

            return operations;
        }