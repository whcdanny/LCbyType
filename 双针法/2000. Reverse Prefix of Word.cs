//Leetcode 2000. Reverse Prefix of Word ez
//题意：给定一个字符串 word 和一个字符 ch，反转从字符串开头到第一次出现 ch 的位置的子串（包括 ch 在内）。如果字符 ch 在字符串中不存在，则不进行任何操作。
//思路：两个指针 left 和 right，初始时均指向字符串开头。
//遍历字符串，当遇到第一次出现的字符 ch 时，将从 left 到 right 的子串进行反转。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public string ReversePrefix(string word, char ch)
        {
            char[] chars = word.ToCharArray();
            int left = 0, right = 0;

            // 寻找字符 ch 的位置
            while (right < word.Length && chars[right] != ch)
            {
                right++;
            }

            // 如果找到了字符 ch，则反转子串
            if (right < word.Length)
            {
                while (left < right)
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;
                    left++;
                    right--;
                }
            }

            return new string(chars);
        }