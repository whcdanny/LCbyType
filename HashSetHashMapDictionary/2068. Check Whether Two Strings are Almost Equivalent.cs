//Leetcode 2068. Check Whether Two Strings are Almost Equivalent ez
//题意：给定两个字符串 word1 和 word2，它们被认为几乎等价，如果它们之间每个字母从 'a' 到 'z' 的频率差异最多为 3。
//要求判断两个字符串 word1 和 word2 是否几乎等价。
//思路：hashtable 使用两个哈希表分别记录字符串 word1 和 word2 中每个字母的频率。
//遍历字母表中的每个字母，计算它们在两个字符串中的频率差值的绝对值，若有任何一个字母的差值大于 3，则返回 false。
//若遍历完成后都满足条件，则返回 true。
//时间复杂度：O(n)
//空间复杂度：O(1)

        public bool CheckAlmostEquivalent(string word1, string word2)
        {
            int[] freq1 = new int[26];
            int[] freq2 = new int[26];

            // 统计 word1 中每个字母的频率
            foreach (char c in word1)
            {
                freq1[c - 'a']++;
            }

            // 统计 word2 中每个字母的频率
            foreach (char c in word2)
            {
                freq2[c - 'a']++;
            }

            // 判断每个字母的频率差值是否都不超过 3
            for (int i = 0; i < 26; i++)
            {
                if (Math.Abs(freq1[i] - freq2[i]) > 3)
                {
                    return false;
                }
            }

            return true;
        }