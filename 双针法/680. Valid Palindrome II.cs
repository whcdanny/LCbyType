//Leetcode 680. Valid Palindrome II ez
//题意：给定一个字符串 s，要求判断在最多删除一个字符的情况下，是否可以使得字符串成为回文字符串。
//思路：双指针，left 和 right 分别指向字符串的开头和结尾。
//在遍历过程中，如果当前字符 s[left] 不等于 s[right]，说明当前字符需要被删除，此时有两种选择：
//尝试删除左边的字符，即判断剩余的子字符串[left + 1, right] 是否为回文。
//尝试删除右边的字符，即判断剩余的子字符串[left, right - 1] 是否为回文。
//如果其中一种情况成立，即剩余字符串是回文，就返回 true。
//如果当前字符相等，继续移动指针，判断下一对字符。
//如果遍历完成后都没有返回 true，说明最多删除一个字符后无法构成回文，返回 false。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public bool ValidPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    // 如果当前字符不相等，尝试删除左边或右边的一个字符，判断剩余字符串是否为回文
                    return IsPalindrome_ValidPalindrome(s, left + 1, right) || IsPalindrome_ValidPalindrome(s, left, right - 1);
                }

                left++;
                right--;
            }

            return true;
        }
        private bool IsPalindrome_ValidPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }