//Leetcode 3. Longest Substring Without Repeating Characters med
//题意：给定一个字符串 s，找到最长的不含重复字符的子串的长度。
//思路：双指针方法来解决这个问题。
//使用两个指针 left 和 right 分别指向字符串的开头。
//使用一个字典 charIndex 来记录每个字符最近出现的位置。
//遍历字符串，当发现重复字符时，将 left 移动到该字符上一次出现的位置的下一个位置，以保证窗口内的字符都是不重复的。
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> charIndex = new Dictionary<char, int>();
            int left = 0, right = 0;
            int maxLen = 0;

            while (right < s.Length)
            {
                if (charIndex.ContainsKey(s[right]))
                {
                    left = Math.Max(charIndex[s[right]] + 1, left);
                }

                charIndex[s[right]] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
                right++;
            }

            return maxLen;
        }