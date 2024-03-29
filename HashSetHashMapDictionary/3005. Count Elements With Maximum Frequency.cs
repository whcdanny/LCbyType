//Leetcode 3005. Count Elements With Maximum Frequency ez
//题意：给定一个由正整数组成的数组nums。
//返回nums中具有最大频率的元素的总频率。
//元素的频率是数组中该元素出现的次数。
//思路：hashtable, 哈希表统计每个元素出现的频率。
//找到出现频率最高的元素的频率。
//遍历哈希表，累加频率等于最大频率的元素的频率。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaxFrequencyElements(int[] nums)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            int maxFrequency = 0;

            // 统计每个元素的频率，并找到最大频率
            foreach (int num in nums)
            {
                if (!frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num] = 0;
                }
                frequencyMap[num]++;
                maxFrequency = Math.Max(maxFrequency, frequencyMap[num]);
            }

            int totalFrequency = 0;

            // 累加频率等于最大频率的元素的频率
            foreach (var kvp in frequencyMap)
            {
                if (kvp.Value == maxFrequency)
                {
                    totalFrequency += kvp.Value;
                }
            }

            return totalFrequency;
        }
