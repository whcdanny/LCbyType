//462. Minimum Moves to Equal Array Elements II med
//题目：给定一个整数数组 nums，返回使所有数组元素相等所需的最小移动次数。
//移动定义：一次移动可以将数组中的一个元素增加或减少 1。
//题目保证答案在 32 位整数范围内。
//思路：目标值选择：将所有元素调整为某个中位数值可以使得总移动次数最小。这是因为中位数是使绝对差最小化的最佳点。
//对数组 nums 排序。
//找到中位数：
//如果数组长度为奇数，直接取中间值。
//如果数组长度为偶数，任取中间两个数之一作为目标值即可。
//遍历数组，计算每个元素与中位数的绝对差之和。
//时间复杂度:  O(nlogn)
//空间复杂度： O(1)
        public int MinMoves2(int[] nums)
        {
            // 排序数组
            Array.Sort(nums);

            // 找到中位数
            int median = nums[nums.Length / 2];

            // 计算与中位数的绝对差之和
            int moves = 0;
            foreach (int num in nums)
            {
                moves += Math.Abs(num - median);
            }

            return moves;
        }