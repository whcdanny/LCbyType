//Leetcode 3295. Report Spam Message med
//题目：给定一个字符串数组 message 和一个字符串数组 bannedWords。如果 message 中至少有两个单词与 bannedWords 中的任意一个单词完全匹配，则认为 message 是垃圾消息。
//要求返回布尔值 true 或 false，表示 message 是否为垃圾消息。
//思路：使用哈希表来存储禁用词：我们可以将 bannedWords 放入一个哈希集合（HashSet），这样可以快速判断某个单词是否是禁用词。
//统计 message 中禁用词的出现次数：遍历 message 数组，统计匹配 bannedWords 中的单词出现的次数。
//判断是否为垃圾消息：如果匹配的禁用词数量大于或等于 2，就返回 true，否则返回 false。
//时间复杂度：O(m + n) m 是 bannedWords 的长度,n 是 message 的长度
//空间复杂度：O(m) m 是 bannedWords 的长度
        public bool ReportSpam(string[] message, string[] bannedWords)
        {
            // 使用哈希集合来存储禁用词
            var bannedSet = new HashSet<string>(bannedWords);
            int count = 0;

            // 遍历消息中的单词，统计出现的禁用词的次数
            foreach (var word in message)
            {
                if (bannedSet.Contains(word))
                {
                    count++;
                    // 如果禁用词数量达到2个或以上，则判定为垃圾消息
                    if (count >= 2)
                    {
                        return true;
                    }
                }
            }

            // 如果禁用词数量不足2个，则不是垃圾消息
            return false;
        }