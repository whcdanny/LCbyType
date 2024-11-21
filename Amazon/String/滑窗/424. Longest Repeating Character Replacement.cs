//Leetcode 424. Longest Repeating Character Replacement med
//题意：给定一个字符串 s、一个整数 k，找到一个最长的子串，其中可以通过替换其中的字符来使得任意相同字符的数量都可以变成 k。
//思路：可以使用双指针方法来解决这个问题。使用两个指针 left 和 right 分别指向字符串的开头。
//维护一个字典 charCount 来记录当前窗口中每个字符的出现次数。
//遍历字符串，同时维护当前窗口内的字符出现次数的最大值 maxCount。
//如果当前窗口的大小减去 maxCount 大于 k，说明无法通过替换字符来使得任意相同字符的数量变成 k，此时需要将 left 右移一位，同时更新 charCount。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： O(26) = O(1)
        public int CharacterReplacement(string s, int k)
        {
            int[] charCount = new int[26];
            int maxCount = 0;
            int left = 0, right = 0;
            int maxLen = 0;

            while (right < s.Length)
            {
                int index = s[right] - 'A';
                charCount[index]++;
                maxCount = Math.Max(maxCount, charCount[index]);

                if (right - left + 1 - maxCount > k)
                {
                    charCount[s[left] - 'A']--;
                    left++;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
                right++;
            }

            return maxLen;
        }