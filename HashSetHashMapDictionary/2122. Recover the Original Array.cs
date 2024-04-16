//Leetcode 2122. Recover the Original Array hard
//题意：Alice有一个由 n 个正整数组成的数组 arr（下标从 0 开始）。她选择了一个任意的正整数 k，并以以下方式创建了两个新的 0 索引整数数组 lower 和 higher：
//lower[i] = arr[i] - k，对于每个索引 i，其中 0 <= i<n
//higher[i] = arr[i] + k，对于每个索引 i，其中 0 <= i<n
//不幸的是，Alice 丢失了这三个数组。但她记得出现在数组 lower 和 higher 中的整数，但不记得每个整数属于哪个数组。现在需要帮助 Alice 恢复原始数组。
//给定一个由 2n 个整数组成的数组 nums，其中恰好有 n 个整数出现在 lower 中，其余出现在 higher 中，返回原始数组 arr。如果答案不唯一，则返回任何有效的数组。
//思路：hashtable 算法首先对给定数组 nums 进行排序，然后计算相邻数字之间的差值，并将所有偶数差值（且大于0）的一半添加到列表 diffList 中。
//接下来，算法创建一个字典 map1，用于记录数组 nums 中每个数字的出现次数。
//然后，对于列表 diffList 中的每个差值，算法尝试使用该差值对应的数字来恢复原始数组。
//具体地说，算法遍历数组 nums 中的每个数字，如果当前数字与当前差值和下一个偶数倍的差值对应的数字都存在于字典 map 中，
//则将当前数字添加到临时列表 tmp 中，并更新字典 map 中对应数字的出现次数。
//如果临时列表 tmp 的长度达到了数组长度的一半，则表示成功恢复了原始数组，此时返回临时列表 tmp。
//时间复杂度：O(n log n)
//空间复杂度：O(n)
        public int[] RecoverArray(int[] nums)
        {
            int N = nums.Length;
            Array.Sort(nums);
            List<int> diffList = new List<int>();
            for (int i = 1; i < N; i++)
            {
                int diff = Math.Abs(nums[i] - nums[0]);
                if (diff % 2 == 0 && diff > 0) diffList.Add(diff / 2);
            }
            Dictionary<int, int> map1 = new Dictionary<int, int>();
            foreach (int num in nums)
                map1[num] = map1.GetValueOrDefault(num, 0) + 1;
            foreach (int diff in diffList)
            {
                Dictionary<int, int> map = new Dictionary<int, int>(map1);
                List<int> tmp = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    if (tmp.Count == N / 2) break;
                    int low = nums[i];
                    int high = low + 2 * diff;
                    if (map.ContainsKey(low) && map.ContainsKey(high))
                    {
                        tmp.Add(low + diff);
                        map[low]--;
                        map[high]--;
                        if (map[low] == 0) map.Remove(low);
                        if (map[high] == 0) map.Remove(high);
                    }
                }
                if (tmp.Count == N / 2) return tmp.ToArray();
            }
            return null;
        }
