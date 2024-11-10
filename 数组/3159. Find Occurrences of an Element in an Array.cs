//Leetcode 3159. Find Occurrences of an Element in an Array med
//题目：给定一个整数数组 nums、一个整数数组 queries 和一个整数 x。
//对于 queries[i]，需要找到 x 在数组 nums 中第 queries[i] 次出现的位置的索引。如果 x 在 nums 中出现的次数小于 queries[i]，则返回 -1。
//返回一个包含所有查询结果的整数数组 answer。
//思路: 记录元素索引：首先，遍历 nums 数组并记录 x 的每次出现的索引。
//可以使用一个列表 indices 来存储 x 在 nums 中的每个出现位置的索引。
//查询处理：遍历 queries，对于每个查询 queries[i]，检查它是否小于或等于 indices 的长度。
//如果满足条件，则返回 indices[queries[i] - 1]（因为 queries[i] 是第几次出现，所以要减一获取对应的索引）。
//否则，返回 -1，表示 x 在 nums 中出现的次数不足。
//时间复杂度：O(n + m)
//空间复杂度：O(n)
        public int[] OccurrencesOfElement(int[] nums, int[] queries, int x)
        {
            List<int> indices = new List<int>();
            List<int> result = new List<int>();

            // 收集 x 出现的所有索引
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == x)
                {
                    indices.Add(i);
                }
            }

            // 处理每个查询
            foreach (int q in queries)
            {
                // 检查是否存在第 q 次出现
                if (q <= indices.Count)
                {
                    result.Add(indices[q - 1]); // 第 q 次出现的位置
                }
                else
                {
                    result.Add(-1); // 不足 q 次出现，返回 -1
                }
            }

            return result.ToArray();
			//算x出现的个数和其位置
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //int counter = 1;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == x)
            //    {
            //        map.Add(counter, i);
            //        counter++;
            //    }
            //}
            //for (int i = 0; i < queries.Length; i++)
            //{
            //    if (!map.ContainsKey(queries[i])) queries[i] = -1;
            //    else queries[i] = map[queries[i]];
            //}
            //return queries;

        }