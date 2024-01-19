//Leetcode 917. Reverse Only Letters ez
//题意：题目意思是给定一个字符串 s，按照以下规则反转字符串：
//所有不是英文字母的字符保持原位置。
//所有英文字母（大写或小写）应该被反转。
//返回反转后的字符串 s。
//思路：双指针，字符串转换为字符数组，以便进行字符的交换。
//使用两个指针 left 和 right 分别指向字符串的开头和结尾。
//在循环中，移动 left 指针直到找到第一个英文字母，移动 right 指针直到找到最后一个英文字母。
//如果 left 小于 right，则交换两个指针指向的字符，然后继续移动指针。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public string ReverseOnlyLetters(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = chars.Length - 1;

            while (left < right)
            {
                while (left < right && !Char.IsLetter(chars[left]))
                {
                    left++;
                }

                while (left < right && !Char.IsLetter(chars[right]))
                {
                    right--;
                }

                if (left < right)
                {
                    // Swap the letters
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;

                    left++;
                    right--;
                }
            }

            return new string(chars);
        }