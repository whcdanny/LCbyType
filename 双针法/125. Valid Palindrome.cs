//125. Valid Palindrome ez: 给定一个字符串，判断它是否是一个有效的回文串。只考虑字母和数字字符，忽略字母的大小写。
//思路：定义两个指针，一个指向字符串的开头，一个指向字符串的末尾。跳过空格和非字母和数字字符，还有大小写，只要出现不一样就错了；
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                // 将字符转换为小写，并忽略非字母和数字字符
                char leftChar = Char.ToLowerInvariant(s[left]);
                char rightChar = Char.ToLowerInvariant(s[right]);

                if (!Char.IsLetterOrDigit(leftChar))
                {
                    left++; // 左指针向右移动
                }
                else if (!Char.IsLetterOrDigit(rightChar))
                {
                    right--; // 右指针向左移动
                }
                else if (leftChar != rightChar)
                {
                    return false; // 如果两个字符不相等，则不是回文串
                }
                else
                {
                    left++; // 比较相等，移动两个指针
                    right--;
                }
            }

            return true; // 两个指针相遇或交叉，是回文串
        }