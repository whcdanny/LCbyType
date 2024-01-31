//Leetcode 151. Reverse Words in a String med
//题意：给定一个字符串，要求反转字符串中的单词顺序。
//思路：双指针，去除多余空格： 将字符串去除首尾空格，并将单词之间的多余空格去除，确保每个单词之间只有一个空格。
//反转整个字符串： 对整个字符串进行反转，使得单词的顺序被颠倒。
//反转每个单词： 遍历每个单词，对每个单词进行反转，将单词内部的字符顺序颠倒。
//时间复杂度：遍历字符串是 O(n)，其中 n 是字符串的长度。整体时间复杂度取决于遍历字符串和翻转单词，因此为 O(n)
//空间复杂度：O(n)
        public string ReverseWords_151(string s)
        {
            // Step 1: Trim leading and trailing spaces, and remove extra spaces between words
            s = s.Trim();
            StringBuilder sb = new StringBuilder();
            bool spaceFound = false;

            foreach (char c in s)
            {
                if (c == ' ')
                {
                    if (!spaceFound)
                    {
                        sb.Append(c);
                        spaceFound = true;
                    }
                }
                else
                {
                    sb.Append(c);
                    spaceFound = false;
                }
            }

            // Step 2: Reverse the entire string
            char[] chars = sb.ToString().ToCharArray();
            ReverseString_ReverseWords_151(chars, 0, chars.Length - 1);

            // Step 3: Reverse each word
            ReverseWords_ReverseWords_151(chars);

            return new string(chars);
        }

        private void ReverseString_ReverseWords_151(char[] chars, int start, int end)
        {
            while (start < end)
            {
                char temp = chars[start];
                chars[start] = chars[end];
                chars[end] = temp;
                start++;
                end--;
            }
        }

        private void ReverseWords_ReverseWords_151(char[] chars)
        {
            int start = 0;
            int end = 0;

            while (end < chars.Length)
            {
                while (end < chars.Length && chars[end] != ' ')
                {
                    end++;
                }

                ReverseString_ReverseWords_151(chars, start, end - 1);
                start = end + 1;
                end++;
            }
        }