//Leetcode 2325. Decode the Message ez
//题意：给定字符串 key 和 message，分别代表密码密钥和秘密消息。解码消息的步骤如下：
//使用密钥中所有 26 个小写英文字母的第一次出现作为替换表的顺序。
//将替换表与常规的英文字母表对齐。
//使用替换表对消息中的每个字母进行替换。
//空格字符 ' ' 保持不变。
//例如，给定 key = "happy boy"（实际的密钥至少包含每个字母的一个实例），我们有部分替换表('h' -> 'a', 'a' -> 'b', 'p' -> 'c', 'y' -> 'd', 'b' -> 'e', 'o' -> 'f')。
//返回解码后的消息。
//思路：hashtable 哈希表将 key 中的字符与替换后的字符进行映射。
//使用 StringBuilder 来构建解码后的消息。
//遍历消息字符串，根据映射关系对每个字符进行替换，如果是空格字符则保持不变。
//时间复杂度：O(n)，其中 n 为消息字符串的长度。
//空间复杂度：O(26)
        public string DecodeMessage(string key, string message)
        {            
            Dictionary<char, char> substitutionTable = new Dictionary<char, char>();
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                if (!substitutionTable.ContainsKey(c) && char.IsLower(c))
                {
                    substitutionTable[c] = (char)('a' + substitutionTable.Count);
                }
            }
           
            StringBuilder decodedMessage = new StringBuilder();
            foreach (char c in message)
            {
                if (c == ' ')
                {
                    decodedMessage.Append(c);
                }
                else if (substitutionTable.ContainsKey(c))
                {
                    decodedMessage.Append(substitutionTable[c]);
                }
            }

            return decodedMessage.ToString();
        }