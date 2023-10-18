//Leetcode 186. Reverse Words in a String II med
//题意：给定一个字符数组 s，将其中的单词进行翻转。例如，输入 s = ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]，翻转后变为 ["b","l","u","e"," ","i","s"," ","s","k","y"," ","t","h","e"]。
//思路：双指针方法: 将整个字符串翻转，这样单词的顺序就会反转。然后，遍历字符串，找到每个单词的起始和结束位置，对每个单词进行翻转。
//时间复杂度:  n 是数组的长度, O(n)
//空间复杂度： O(1)
        public void ReverseWords(char[] s)
        {
            // 翻转整个字符串
            Reverse(s, 0, s.Length - 1);

            int start = 0;
            int end = 0;

            while (end < s.Length)
            {
                // 找到单词的起始位置
                while (end < s.Length && s[end] != ' ')
                {
                    end++;
                }

                // 翻转单词
                Reverse(s, start, end - 1);

                // 更新指针位置
                start = end + 1;
                end = start;
            }
        }

        private void Reverse(char[] s, int left, int right)
        {
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }