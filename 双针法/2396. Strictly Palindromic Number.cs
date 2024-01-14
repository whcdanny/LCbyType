//Leetcode 2396. Strictly Palindromic Number med
//题意：为了判断一个数在不同进制下是否是回文数，可以将该数转换为指定进制下的字符串，然后判断字符串是否是回文串
//思路：左右针，遍历进制： 从进制2到n-2，遍历每一个进制。
//转换为指定进制字符串： 对于每一个进制，将给定的数转换为该进制的字符串表示。这里使用 ConvertToBase 方法。
//判断回文串： 对于得到的每一个字符串，使用 IsPalindrome 方法判断是否是回文串。
//时间复杂度: 对于每一个进制，需要将给定的数转换为字符串，时间复杂度为 O(logn)。判断字符串是否是回文串的时间复杂度为 O(logn)。遍历进制的总时间复杂度为 O((n-2) * logn)。
//空间复杂度：O(logn)
        public bool IsStrictlyPalindromic(int n)
        {
            for (int baseValue = 2; baseValue <= n - 2; baseValue++)
            {
                string representation = ConvertToBase_IsStrictlyPalindromic(n, baseValue);
                if (!IsPalindrome_IsStrictlyPalindromic(representation))
                {
                    return false;
                }
            }
            return true;
        }
        private string ConvertToBase_IsStrictlyPalindromic(int number, int baseValue)
        {
            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                int digit = number % baseValue;
                result.Insert(0, digit);
                number /= baseValue;
            }
            return result.ToString();
        }

        private bool IsPalindrome_IsStrictlyPalindromic(string s)
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