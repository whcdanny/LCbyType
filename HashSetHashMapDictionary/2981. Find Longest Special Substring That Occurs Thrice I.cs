//Leetcode 2981. Find Longest Special Substring That Occurs Thrice I med
//题意：要求找出给定字符串中至少出现三次的最长特殊子串的长度。特殊子串是由相同字符组成的子串。
//思路：hashtable, 一个二维数组 counts，用于记录每个字符在字符串中连续出现的次数
//对于每个字符，从后往前遍历 counts 数组，累积后缀和。这样可以快速得到当前字符在字符串中连续出现次数不小于 3 的最大索引位置。
//遍历完整个 counts 数组，找到所有字符中连续出现次数不小于 3 的最小索引位置，即为最长特殊子串的长度。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaximumLength(string s)
        {
            int[,] counts = new int[26, s.Length + 1];

            // For each character, count the number of times it appears consecutively
            char last = '0';
            int repeatCount = 0;
            foreach (char c in s)
            {
                int index = c - 'a';
                if (c == last)
                {
                    repeatCount++;
                }
                else
                {
                    last = c;
                    repeatCount = 1;
                }
                counts[index, repeatCount]++;
            }

            // Acuumulate suffix sum
            for (int i = 0; i < 26; i++)
            {
                for (int j = s.Length - 1; j >= 0; j--)
                {
                    counts[i, j] += counts[i, j + 1];
                }
            }

            // Find the maximum length of special substring
            int result = -1;
            for (int i = 0; i < 26; i++)
            {
                int j = 0;
                while (counts[i, j] >= 3) j++;
                result = Math.Max(result, j - 1);
            }
            return result;
        }