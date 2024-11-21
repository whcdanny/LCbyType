//Leetcode 647. Palindromic Substrings med
//题意：给定一个字符串，求出它所有的回文子串的数量。不同位置或者不同长度的子串都被视为不同的回文子串。
//思路：两个指针，中心扩展法：以每个字符和每两个相邻字符之间的位置为中心，分别向两边扩展，寻找回文子串。
//时间复杂度:  n 是字符串的长度, 时间复杂度是 O(n^2)。
//空间复杂度： O(1)          
        public int CountSubstrings(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count += CountPalindromes(s, i, i); // 奇数长度的回文子串
                count += CountPalindromes(s, i, i + 1); // 偶数长度的回文子串
            }
            return count;
        }

        private int CountPalindromes(string s, int left, int right)
        {
            int count = 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                count++;
                left--;
                right++;
            }
            return count;
        }