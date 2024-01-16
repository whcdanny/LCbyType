//Leetcode 2108. Find First Palindromic String in the Array ez
//题意：给定一个字符串数组 words，返回数组中第一个回文字符串。如果没有回文字符串，则返回空字符串 ""。
//回文字符串是指从前往后读和从后往前读结果相同的字符串。               
//思路：双针，遍历数组 words，对于每个字符串，判断其是否是回文字符串。
//使用双指针的方法，分别从字符串的两端向中间遍历，判断对应字符是否相等。
//如果找到回文字符串，立即返回该字符串。
//时间复杂度: O(m * n)，其中 m 是数组的长度，n 是字符串的平均长度。
//空间复杂度：O(1)
        public string FirstPalindrome(string[] words)
        {
            foreach (string word in words)
            {
                if (IsPalindrome_FirstPalindrome(word))
                {
                    return word; // 返回第一个回文字符串
                }
            }

            return ""; // 没有回文字符串，返回空字符串
        }
        private bool IsPalindrome_FirstPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }