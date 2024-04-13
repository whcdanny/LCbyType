//Leetcode 2309. Greatest English Letter in Upper and Lower Case ez
//题意：给定一个由英文字母组成的字符串 s，返回在字符串 s 中既出现为小写字母又出现为大写字母的最大英文字母。
//返回的字母应为大写形式。如果不存在这样的字母，则返回空字符串。
//思路：hashtable 使用一个哈希表来统计字符串 s 中每个字符（包括大小写）的出现次数。
//从字母 'Z' 开始向字母 'A' 遍历，找到第一个同时出现为大写和小写形式的字母。
//时间复杂度：O(n)，其中 n 为消息字符串的长度。
//空间复杂度：O(26)
        public string GreatestLetter(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
            }
           
            for (char c = 'Z'; c >= 'A'; c--)
            {
                if (charCount.ContainsKey(c) && charCount.ContainsKey(char.ToLower(c)))
                {
                    return c.ToString();
                }
            }

            return "";
        }