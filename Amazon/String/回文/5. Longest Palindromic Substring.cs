//Leetcode 5. Longest Palindromic Substring med
//题意：找出一个字符串中最长的回文子串
//思路：两个指针，
//为了确定是单数还是双数，所以要从(i,i) 和 (i,i+1)从中间往两边延申
//从每个字符开始，向两边扩展，分别处理奇数长度和偶数长度的回文串。
//然后更新start和end start = i - (len - 1) / 2;end = i + len / 2;
//时间复杂度:  n 是字符串的长度, 时间复杂度是 O(n^2)。
//空间复杂度： O(1)          
        public string LongestPalindrome_5(string s)
        {
            if (s == null || s.Length < 1) 
                return "";

            int start = 0;
            int end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }
        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }