//Leetcode 2186. Minimum Number of Steps to Make Two Strings Anagram II med
//题意：给定两个字符串 s 和 t。每一步操作，你可以将任意字符追加到 s 或 t 中的任意一个字符串中。
//返回使得 s 和 t 成为彼此的字谜所需的最小步数。
//字谜是指包含相同字符但顺序不同的字符串。
//思路：hashtable 统计两个字符串中每个字符的出现次数。
//遍历两个字符串的字符，找到差异部分，即需要插入到对方字符串中的字符。
//将差异部分的出现次数求和，即为所需的最小步数。
//时间复杂度：O(n) 的时间，其中 n 是字符串的长度
//空间复杂度：O(m)
        public int MinSteps(string s, string t)
        {
            Dictionary<char, int> countS = new Dictionary<char, int>();
            Dictionary<char, int> countT = new Dictionary<char, int>();

            // 统计字符串 s 和 t 中每个字符的出现次数
            foreach (char c in s)
            {
                countS[c] = countS.GetValueOrDefault(c) + 1;
            }
            foreach (char c in t)
            {
                countT[c] = countT.GetValueOrDefault(c) + 1;
            }

            int steps = 0;

            // 统计差异部分的字符出现次数之和
            foreach (char c in countS.Keys)
            {
                steps += Math.Abs(countS[c] - countT.GetValueOrDefault(c, 0));
            }
            foreach (char c in countT.Keys)
            {
                if (!countS.ContainsKey(c))
                {
                    steps += countT[c];
                }
            }

            return steps;
        }