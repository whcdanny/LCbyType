//Leetcode 395. Longest Substring with At Least K Repeating Characters med
//题意：给定一个字符串 s 和一个整数 k，找到 s 中的最长子串，要求该子串中的每个字符出现的次数都至少为 k。
//思路：使用递归和分治的方法来解决这个问题 首先统计字符串中每个字符的出现次数，得到一个字符频率表。遍历字符串，找到第一个出现次数小于 k 的字符，将其作为分隔符，将问题分解为两个子问题：左侧子串和右侧子串。
//时间复杂度:  n 是字符串的长, O(n * log n)
//空间复杂度： O(log n)
        public int LongestSubstring(string s, int k)
        {
            if (s.Length < k) return 0;

            Dictionary<char, int> frequency = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }

            foreach (char c in s)
            {
                if (frequency[c] < k)
                {
                    string[] parts = s.Split(new char[] { c }, 2);
                    return Math.Max(LongestSubstring(parts[0], k), LongestSubstring(parts[1], k));
                }
            }

            return s.Length;
        }
		
		//MaxUniqueLetters 方法用于计算字符串中的最大唯一字符数。它遍历字符串，使用一个数组 charCount 统计每个字符的出现次数，然后记录非零项的数量，这就是最大的唯一字符数。
        //主函数 LongestSubstring 开始处理主要逻辑。
        //int[] charCount = new int[26] 初始化了一个数组，用于记录字符的出现次数。
        //int maxUnique = MaxUniqueLetters(s) 计算了字符串中的最大唯一字符数。
        //外层循环 for (int currUnique = 1; currUnique <= maxUnique; currUnique++) 遍历可能的唯一字符数，从 1 到最大唯一字符数。
        //内层的双指针循环 while (right<s.Length) 开始维护一个滑动窗口。    
        //当 unique <= currUnique 时，表示窗口中的字符不超过当前唯一字符数的限制。此时右指针 right 向右移动，将对应字符的出现次数加一，更新窗口状态。
        //当 unique> currUnique 时，表示窗口中的字符超过了当前唯一字符数的限制。此时左指针 left 向右移动，将对应字符的出现次数减一，更新窗口状态。
        //在每一步中，都会检查当前窗口是否满足条件（即窗口中的字符不超过当前唯一字符数的限制，并且每个字符的出现次数至少为 k）。如果满足条件，更新结果。
        public int LongestSubstring_p(string s, int k)
        {
            int[] charCount = new int[26];
            int maxUnique = MaxUniqueLetters(s);
            int result = 0;

            for (int currUnique = 1; currUnique <= maxUnique; currUnique++)
            {
                Array.Fill(charCount, 0);
                int left = 0, right = 0, unique = 0, countAtLeastK = 0;

                while (right < s.Length)
                {
                    if (unique <= currUnique)
                    {
                        int index = s[right] - 'a';
                        if (charCount[index] == 0) unique++;
                        charCount[index]++;
                        if (charCount[index] == k) countAtLeastK++;
                        right++;
                    }
                    else
                    {
                        int index = s[left] - 'a';
                        if (charCount[index] == k) countAtLeastK--;
                        charCount[index]--;
                        if (charCount[index] == 0) unique--;
                        left++;
                    }

                    if (unique == currUnique && unique == countAtLeastK)
                    {
                        result = Math.Max(result, right - left);
                    }
                }
            }

            return result;
        }

        private int MaxUniqueLetters(string s)
        {
            int[] charCount = new int[26];
            int unique = 0;
            foreach (char c in s)
            {
                int index = c - 'a';
                if (charCount[index] == 0) unique++;
                charCount[index]++;
            }
            return unique;
        }