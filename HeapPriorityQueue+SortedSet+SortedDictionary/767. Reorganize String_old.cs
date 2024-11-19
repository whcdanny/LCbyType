//767. Reorganize String med
//重组string，保证任何相邻的两个字母不能相同
//思路：先用dictionary存储字母相对于的次数，按照字符出现次数进行排序，最多出现次数的字符超过字符串长度的一半加一，则无法重新组织字符串，然后填充最多的开始，每隔一个位置添加，
        public string ReorganizeString(string s)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            // 统计每个字符的出现次数
            foreach (char c in s)
            {
                if (!charCounts.ContainsKey(c))
                    charCounts[c] = 0;
                charCounts[c]++;
            }

            // 按照字符出现次数进行排序
            List<char> sortedChars = charCounts.Keys.ToList();
            sortedChars.Sort((a, b) => charCounts[b].CompareTo(charCounts[a]));

            // 如果最多出现次数的字符超过字符串长度的一半加一，则无法重新组织字符串
            if (charCounts[sortedChars[0]] > (s.Length + 1) / 2)
                return "";

            char[] result = new char[s.Length];
            int index = 0;

            // 先填充出现次数最多的字符
            foreach (char c in sortedChars)
            {
                int count = charCounts[c];

                while (count > 0)
                {
                    result[index] = c;
                    index += 2; // 每隔一个位置填充字符
                    if (index >= s.Length) // 超过字符串长度时回到第二个位置
                        index = 1;

                    count--;
                }
            }

            // 填充剩余的字符
            foreach (char c in sortedChars)
            {
                while (charCounts[c] > 0 && index < s.Length)
                {
                    if (result[index] == '\0')
                    {
                        result[index] = c;
                        index += 2;
                    }
                    if (index >= s.Length) // 超过字符串长度时回到第二个位置
                        index = 1;

                    charCounts[c]--;
                }
            }

            return new string(result);
        }