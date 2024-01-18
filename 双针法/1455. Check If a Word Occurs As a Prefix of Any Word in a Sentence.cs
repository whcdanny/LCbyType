//Leetcode 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence ez
//题意：给定一个由单个空格分隔的一些单词组成的句子，以及一个搜索词 searchWord，检查 searchWord 是否是句子中任何单词的前缀。
//如果 searchWord 是句子中某个单词的前缀，则返回该单词在句子中的索引（从 1 开始）。如果 searchWord 是多个单词的前缀，则返回第一个单词的索引（最小索引）。如果没有找到匹配的单词，则返回 -1。
//思路：双指针，将句子按照空格分隔成单词数组。
//遍历单词数组，判断每个单词是否以 searchWord 为前缀。
//如果找到匹配的单词，则返回其索引。
//时间复杂度：O(n)，其中 n 是句子中的单词数量
//空间复杂度：O(1)
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            string[] words = sentence.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(searchWord))
                {
                    return i + 1;
                }
            }

            return -1;
        }