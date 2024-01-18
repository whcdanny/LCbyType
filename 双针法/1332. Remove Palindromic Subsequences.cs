//Leetcode 1332. Remove Palindromic Subsequences ez
//题意：给定一个字符串 s，其中只包含字母 'a' 和 'b'。在一步操作中，可以从 s 中移除一个回文子序列。
//要求返回使得给定字符串变为空串的最小步数。       
//思路：双指针，字符串中只包含 'a' 和 'b' 两种字母，而且每次可以移除一个回文子序列，因此可以分析以下情况：
//如果字符串本身就是回文串，则只需要一步操作，将整个字符串移除。
//否则，可以先移除所有的 'a'，然后移除所有的 'b'。由于每次只能移除一个回文子序列，而 'a' 和 'b' 都是回文子序列，所以总共只需要两步操作。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public int RemovePalindromeSub(string s)
        {
            if (IsPalindrome_RemovePalindromeSub(s))
            {
                // 如果字符串本身就是回文串，只需要一步操作
                return 1;
            }
            else
            {
                // 否则，两步操作分别移除所有的 'a' 和 'b'
                return 2;
            }
        }
        private bool IsPalindrome_RemovePalindromeSub(string s)
        {
            int left = 0, right = s.Length - 1;
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