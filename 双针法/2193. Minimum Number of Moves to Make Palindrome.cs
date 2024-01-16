//Leetcode 2193. Minimum Number of Moves to Make Palindrome hard
//题意：通过交换相邻字符的方式，将给定字符串 s 转换为回文串，并返回转换所需的最小移动次数。
//思路：左右针，双指针从字符串的两端开始遍历。在每一步，我们比较两个指针指向的字符，如果它们相等，则继续向中间移动。
//如果它们不相等，我们尝试在右侧找到一个匹配的字符，
//如果找不到，则交换左指针和相邻字符, 增加移动次数
//如果找到匹配的字符，从找到的这个跟left一样的字母开始一直交换到right 增加移动次数，最后再将左指针向右移动，右指针向左移动
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int MinMovesToMakePalindrome(string s)
        {
            int n = s.Length;
            char[] chars = s.ToCharArray();

            int left = 0, right = n - 1;
            int swaps = 0;

            while (left < right)
            {
                if (chars[left] == chars[right])
                {
                    left++;
                    right--;
                }
                else
                {
                    int tempRight = right;
                    while (tempRight > left && chars[tempRight] != chars[left])
                    {
                        tempRight--;
                    }

                    if (tempRight == left)
                    {
                        // No matching character found, swap with adjacent character
                        Swap_MinMovesToMakePalindrome(chars, left, left + 1);
                        swaps++;
                    }
                    else
                    {
                        // Swap characters to make it a palindrome
                        while (tempRight < right)
                        {
                            Swap_MinMovesToMakePalindrome(chars, tempRight, tempRight + 1);
                            swaps++;
                            tempRight++;
                        }
                        left++;
                        right--;
                    }
                }
            }

            return swaps;
        }
        private void Swap_MinMovesToMakePalindrome(char[] chars, int i, int j)
        {
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }