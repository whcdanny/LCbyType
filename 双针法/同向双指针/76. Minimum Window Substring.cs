//Leetcode 76. Minimum Window Substring hard
//题意：给定一个字符串 s 和一个字符串 t，在 s 中找到包含 t 中所有字符的最短子串。
//思路：双指针方法来解决这个问题。使用两个指针 left 和 right 分别指向字符串的开头。维护一个字典 charCountT 来记录字符串 t 中每个字符的出现次数。使用一个计数器 count 来记录当前窗口中包含 t 中字符的数量。遍历字符串 s，将 right 右移，更新窗口状态，同时更新 count。当 count 等于 t 中字符的种类数时，说明当前窗口包含了 t 中所有字符，此时将 left 右移，缩小窗口，同时更新 count。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： O(26) = O(1)
        public string MinWindow(string s, string t)
        {
            Dictionary<char, int> charCountT = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (charCountT.ContainsKey(c))
                {
                    charCountT[c]++;
                }
                else
                {
                    charCountT[c] = 1;
                }
            }

            int left = 0, right = 0;
            int minLen = int.MaxValue;
            string result = "";
            int count = 0;

            while (right < s.Length)
            {
                if (charCountT.ContainsKey(s[right]))
                {
                    charCountT[s[right]]--;
                    if (charCountT[s[right]] >= 0)
                    {
                        count++;
                    }
                }

                while (count == t.Length)
                {
                    if (right - left + 1 < minLen)
                    {
                        minLen = right - left + 1;
                        result = s.Substring(left, minLen);
                    }

                    if (charCountT.ContainsKey(s[left]))
                    {
                        charCountT[s[left]]++;
                        if (charCountT[s[left]] > 0)
                        {
                            count--;
                        }
                    }

                    left++;
                }

                right++;
            }

            return result;
        }