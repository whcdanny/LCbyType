//Leetcode 3092. Most Frequent IDs med
//题目：你需要维护一个集合，其中包含不同 ID 及其频率。题目给出了两个等长的数组 nums 和 freq，长度为 n，表示每一步集合中 ID 的变化规则：
//添加 ID：如果 freq[i] > 0，表示第 i 步将 freq[i] 个值为 nums[i] 的 ID 加入集合。
//移除 ID：如果 freq[i] < 0，表示第 i 步将 -freq[i] 个值为 nums[i] 的 ID 从集合中移除。
//你的任务是返回一个数组 ans，长度为 n，其中：
//ans[i] 表示第 i 步操作后，集合中出现频率最高的 ID 的出现次数。
//如果集合为空，则 ans[i] = 0。
//思路: 使用字典记录频率：
//用一个字典 idCount 来维护当前集合中每个 ID 的频率。
//如果 freq[i] > 0，在字典中增加对应 ID 的计数；如果 freq[i] < 0，减少对应 ID 的计数。
//优先队列维护最大频率：
//使用一个最大堆（优先队列）实时维护集合中出现频率最高的值。
//每次更新集合后，从堆顶获得最大频率。
//处理无效数据：
//当频率减为 0 时，将 ID 从字典中移除。
//如果堆顶的频率与字典中不一致，堆顶需要重新调整。
//时间复杂度：O(n × log k)
//空间复杂度：O(n + k)
        public long[] MostFrequentIDs(int[] nums, int[] freq)
        {
            int n = nums.Length;
            long[] result = new long[n];

            // 字典记录当前每个 ID 的频率
            var idCount = new Dictionary<int, long>();

            // 优先队列维护最大频率
            var maxHeap = new SortedDictionary<long, HashSet<int>>(Comparer<long>.Create((x, y) => y.CompareTo(x)));

            for (int i = 0; i < n; i++)
            {
                int id = nums[i];
                long change = freq[i];

                // 更新字典
                if (!idCount.ContainsKey(id))
                    idCount[id] = 0;

                long oldCount = idCount[id];
                long newCount = oldCount + change;

                if (oldCount > 0) // 如果该 ID 之前存在，移除旧频率
                {
                    maxHeap[oldCount].Remove(id);
                    if (maxHeap[oldCount].Count == 0)
                        maxHeap.Remove(oldCount);
                }

                if (newCount > 0) // 如果新频率有效，加入堆中
                {
                    idCount[id] = newCount;
                    if (!maxHeap.ContainsKey(newCount))
                        maxHeap[newCount] = new HashSet<int>();
                    maxHeap[newCount].Add(id);
                }
                else // 如果频率变为 0，从字典中移除
                {
                    idCount.Remove(id);
                }

                // 获取当前最大频率
                result[i] = maxHeap.Count > 0 ? maxHeap.Keys.First() : 0;
            }

            return result;
        }