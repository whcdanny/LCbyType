//Leetcode 3152. Special Array II med
//题目：一个数组被认为是“特殊数组”，当它的每一对相邻元素的奇偶性不同。
//给定一个整数数组 nums 和一个二维整数矩阵 queries，其中每个查询 queries[i] = [fromi, toi] 表示一个子数组 nums[fromi..toi]，任务是检查该子数组是否为“特殊数组”。
//返回一个布尔数组 answer，其中 answer[i] 为 true 表示 nums[fromi..toi] 是特殊数组，否则为 false。
//思路: 遍历数组 nums，找到从每个起始位置 from 开始的最长交替子数组的终止位置 to。
//如果两个相邻元素的和为偶数（即同为奇数或同为偶数），则停止增长，否则继续扩展。
//当找到 from 到 to - 1 的有效交替区间时，将 max 中这些索引值的最长交替终止位置更新为 to - 1。
//这意味着，从 from 开始的最长交替子数组可以一直延续到 to - 1。
//时间复杂度：O(n + q)
//空间复杂度：O(n + q)
        public bool[] IsArraySpecial1(int[] nums, int[][] queries)
        {
            var max = new int[nums.Length];
            int from = 0;

            // 构建 max 数组，标记每个位置可以达到的最长交替末尾
            while (from < nums.Length)
            {
                int to = from + 1;
                while (to < nums.Length)
                {
                    if ((nums[to] + nums[to - 1]) % 2 == 0)
                        break; // 检查是否为同奇偶性
                    to++;
                }
                // 更新 from 到 to 的区间的最大交替终点
                for (int i = from; i < to; ++i)
                {
                    max[i] = to - 1;
                }
                from = to;
            }
            // 查询处理
            return queries.Select(query => max[query[0]] >= query[1]).ToArray();
        }