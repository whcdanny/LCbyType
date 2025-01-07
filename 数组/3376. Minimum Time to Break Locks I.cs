//Leetcode 3376. Minimum Time to Break Locks I med
//题意：Bob 被困在一个地牢中，他必须打破 
//n 把锁才能逃脱。每把锁需要一定的能量才能打破，这些能量存储在一个数组 strength 中，其中 strength[i] 表示打破第 i 把锁所需的能量。
//Bob 使用一把剑来打破锁，这把剑有以下特点：
//剑的初始能量为 0。剑的能量增长因子 x 初始为 1。
//每分钟剑的能量会增加当前增长因子 x。
//要打破第 i 把锁，剑的能量必须至少达到 strength[i]。
//打破一把锁后，剑的能量重置为 0，增长因子 x 增加一个固定值 k。
//任务是计算 Bob 打破所有锁并逃出地牢所需的最短时间（以分钟为单位）。 
//思路：破锁顺序
//就是找出所有可能性，然后找出最小的time
//所有可能性是基本情况：长度为 1 的组合只有一个排列。
//归生成长度为 n−1 的排列，将新元素插入到所有可能位置。
//找出最小时间对于每把锁，计算其所需时间，公式为 strength[i]/x（向上取整计算需要的分钟数）。
//破锁后，更新剑的增长因子。
//时间复杂度:  O(n⋅n!)
//空间复杂度： O(n⋅n!)
        public int FindMinimumTime(IList<int> strength, int K)
        {
            var rs = int.MaxValue; // 初始化结果为最大值
            var combinations = GetAllombinations(strength.Count); // 获取所有可能的破锁顺序

            for (int i = 0; i < combinations.Count; i++)
            {
                var rs0 = FindMinimumTime(combinations[i], strength, K); // 计算当前顺序的最小时间
                rs = Math.Min(rs, rs0); // 更新最小结果
            }

            return rs;
        }
        private List<List<int>> GetAllombinations(int len)
        {
            if (len == 1) return new List<List<int>> { new List<int> { 0 } }; // 基本情况：只有一个元素

            var val = len - 1;
            var prev = GetAllombinations(len - 1); // 递归生成前一个长度的组合
            var rs = new List<List<int>>();

            for (int i = 0; i < prev.Count; i++) // 遍历已有组合
            {
                for (int j = 0; j <= prev[i].Count; j++) // 在组合的不同位置插入新元素
                {
                    var item = new List<int>(prev[i]);
                    item.Insert(j, val);
                    rs.Add(item);
                }
            }

            return rs;
        }
        private int FindMinimumTime(List<int> combination, IList<int> strength, int K)
        {
            var rs = 0; // 累计总时间
            var X = 1; // 初始能量增长因子

            for (int i = 0; i < combination.Count; i++)
            {
                var rs0 = strength[combination[i]] / X; // 计算当前锁所需时间
                if (strength[combination[i]] % X > 0) rs0++; // 如果不能整除，补充时间
                rs += rs0; // 累加时间
                X += K; // 更新增长因子
            }

            return rs;
        }