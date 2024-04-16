//Leetcode 2085. Count Common Words With One Occurrence ez
//题意：给定两个字符串数组 words1 和 words2，返回在两个数组中都只出现一次的字符串的数量。
//思路：hashtable 使用两个哈希表分别记录 words1 和 words2 中每个字符串出现的次数。
//遍历两个哈希表，找到在两个数组中都只出现一次的字符串，并统计数量。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int CountWords(string[] words1, string[] words2)
        {
            Dictionary<string, int> freq1 = new Dictionary<string, int>();
            Dictionary<string, int> freq2 = new Dictionary<string, int>();

            // 统计 words1 中每个字符串出现的次数
            foreach (string word in words1)
            {
                if (!freq1.ContainsKey(word))
                {
                    freq1[word] = 0;
                }
                freq1[word]++;
            }

            // 统计 words2 中每个字符串出现的次数
            foreach (string word in words2)
            {
                if (!freq2.ContainsKey(word))
                {
                    freq2[word] = 0;
                }
                freq2[word]++;
            }

            int count = 0;
            // 找到在两个数组中都只出现一次的字符串，并统计数量
            foreach (var kvp in freq1)
            {
                if (kvp.Value == 1 && freq2.ContainsKey(kvp.Key) && freq2[kvp.Key] == 1)
                {
                    count++;
                }
            }

            return count;
        }