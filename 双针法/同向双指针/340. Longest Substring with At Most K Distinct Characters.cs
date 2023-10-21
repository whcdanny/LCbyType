//Leetcode 340. Longest Substring with At Most K Distinct Characters med
//题意：给定一个字符串 s 和一个整数 k，找到 s 中的最长子串，要求该子串中的不同字符数最多为 k。
//思路：双指针方法来解决这个问题。使用两个指针 left 和 right 分别指向字符串的开头。使用一个字典 charCount 来记录当前窗口中每个字符的出现次数。遍历字符串，当不同字符数小于等于 k 时，将 right 右移一位，同时更新 charCount。当不同字符数大于 k 时，将 left 右移一位，同时更新 charCount。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： k 个不同字符, O(k)
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0) return 0;

            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int left = 0, right = 0;
            int maxLen = 0;

            while (right < s.Length)
            {
                if (charCount.ContainsKey(s[right]))
                {
                    charCount[s[right]]++;
                }
                else
                {
                    charCount[s[right]] = 1;
                }

                while (charCount.Count > k)
                {
                    char leftChar = s[left];
                    if (charCount.ContainsKey(leftChar))
                    {
                        charCount[leftChar]--;
                        if (charCount[leftChar] == 0)
                        {
                            charCount.Remove(leftChar);
                        }
                    }
                    left++;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
                right++;
            }

            return maxLen;
        }