//Leetcode 3318. Find X-Sum of All K-Long Subarrays I ez
//题意：给定一个长度为 n 的整数数组 nums 和两个整数 k 和 x。
//x-和的计算方法如下：
//统计数组中所有元素的出现次数。
//仅保留出现次数最多的前 x 个元素的频次。如果有多个元素的出现次数相同，则优先选择值较大的元素。
//计算保留下来的这些元素的总和。
//如果数组中不同的元素少于 x 个，那么 x-和 就是所有元素的和。
//返回一个长度为 n - k + 1 的整数数组 answer，其中 answer[i] 表示子数组 nums[i..i + k - 1] 的 x-和。
//思路：滑动窗口法：
//滑动窗口来逐步处理所有长度为 k 的子数组。一个哈希表（字典）来记录当前窗口中每个元素的频率。
//x-和的计算：统计当前窗口中每个元素的频率，并按频率从高到低进行排序。如果频率相同，则按元素值从高到低排序。
//选出前 x 个元素进行求和，如果窗口中的不同元素少于 x 个，则对所有元素求和。
//滑动窗口更新：窗口滑动时，需要更新频率表，移除滑出窗口的元素，并添加进入窗口的元素。
//时间复杂度：排序频率表中的元素，时间复杂度为 O(klogk).共有n−k+1 个窗口，因此总时间复杂度为 O((n−k+1)⋅klogk)。
//空间复杂度：O(k)
        public int[] FindXSum(int[] nums, int k, int x)
        {
            int n = nums.Length;
            int[] answer = new int[n - k + 1];
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            // 初始化第一个窗口的频率映射
            for (int i = 0; i < k; i++)
            {
                if (!frequencyMap.ContainsKey(nums[i]))
                {
                    frequencyMap[nums[i]] = 0;
                }
                frequencyMap[nums[i]]++;
            }

            // 计算当前频率映射的 x-和
            int CalculateXSum(Dictionary<int, int> map)
            {
                // 按照频率降序排序，然后按元素值降序排序
                var sortedItems = map.OrderByDescending(entry => entry.Value)
                                     .ThenByDescending(entry => entry.Key)
                                     .Take(x)
                                     .ToList();

                // 计算前 x 个元素的和
                return sortedItems.Sum(entry => entry.Key * entry.Value);
            }

            // 计算第一个窗口的 x-和
            answer[0] = CalculateXSum(frequencyMap);

            // 滑动窗口遍历整个数组
            for (int i = 1; i <= n - k; i++)
            {
                // 移除滑出窗口的元素
                int outElement = nums[i - 1];
                frequencyMap[outElement]--;
                if (frequencyMap[outElement] == 0)
                {
                    frequencyMap.Remove(outElement);
                }

                // 添加新进入窗口的元素
                int inElement = nums[i + k - 1];
                if (!frequencyMap.ContainsKey(inElement))
                {
                    frequencyMap[inElement] = 0;
                }
                frequencyMap[inElement]++;

                // 计算当前窗口的 x-和
                answer[i] = CalculateXSum(frequencyMap);
            }

            return answer;
        }