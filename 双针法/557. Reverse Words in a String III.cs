//Leetcode 557. Reverse Words in a String III ez
//题意：给定一个字符串 s，要求对每个单词中的字符进行反转，同时保留空格和初始单词顺序。
//思路：双指针，串转换为字符数组，方便操作。
//使用两个指针 start 和 end 分别表示当前单词的起始和结束位置。
//从左到右遍历字符串：
//找到单词的起始位置，即跳过空格。
//找到单词的结束位置，即找到下一个空格或到达字符串末尾。
//对当前单词中的字符进行反转。
//更新下一个单词的起始位置。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public string ReverseWords(string s)
        {
            char[] charArray = s.ToCharArray();
            int n = charArray.Length;
            int start = 0, end = 0;

            while (start < n)
            {
                // 找到单词的起始位置
                while (start < n && charArray[start] == ' ')
                {
                    start++;
                }

                end = start;

                // 找到单词的结束位置
                while (end < n && charArray[end] != ' ')
                {
                    end++;
                }

                // 反转单词中的字符
                Reverse_ReverseWords(charArray, start, end - 1);

                // 更新下一个单词的起始位置
                start = end + 1;
            }

            return new string(charArray);
        }

        // 反转字符数组中的一段区间
        private void Reverse_ReverseWords(char[] charArray, int start, int end)
        {
            while (start < end)
            {
                char temp = charArray[start];
                charArray[start] = charArray[end];
                charArray[end] = temp;
                start++;
                end--;
            }
        }