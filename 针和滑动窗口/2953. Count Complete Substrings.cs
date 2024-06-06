//Leetcode 2953. Count Complete Substrings hard
//题意：给定一个字符串 word 和一个整数 k。
//一个子串 s 是完整的（complete）的如果：
//s 中的每个字符恰好出现 k 次。
//相邻字符之间的差值最多为 2。也就是说，对于 s 中的任意两个相邻字符 c1 和 c2，
//它们在字母表中的位置的绝对差值最多为 2。
//返回字符串 word 中完整子串的数量。
//一个子串是字符串中不为空的连续字符序列。
//思路：滑窗 第一步是将原字符串切割成若干个区间，我们只考虑那些“相邻字符大小不超过2”的那些区间.
//需要计算每个通过初筛区间里，再有多少个符合条件的substring，
//即要求substring里出现的字符的频次都是k。
//注意到字符的种类只有26种，如果只出现一种字符，那长度就是k；
//如果出现两种字符，那长度就是2k，
//以此类推，我们发现可以遍历出现字符的种类数目，
//然后用一个固定长度的滑窗来判定是否存在substring符合条件。
//滑窗的运动过程中，只要维护一个hash表即可。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int CountCompleteSubstrings(string word, int k)
        {
            int n = word.Length;
            int res = 0;
            for (int i = 0; i < n;)
            {
                int j = i + 1;
                while (j < n && Math.Abs(word[j] - word[j - 1]) <= 2)
                {
                    j++;
                }
                res += isCountCompleteSubstrings(word.Substring(i, j - i), k);
                i = j;
            }
            return res;
        }

        private int isCountCompleteSubstrings(string s, int k)
        {
            int count = 0;
            HashSet<char> set = new HashSet<char>(s);
            for (int t = 1; t <= set.Count; t++)
            {
                int len = t * k;
                int[] freq = new int[26];
                Array.Fill(freq, 0);
                int j = 0;
                for (int i = 0; i + len - 1 < s.Length; i++)
                {
                    while (j <= i + len - 1)
                    {
                        freq[s[j] - 'a']++;
                        j++;
                    }
                    if (checked_CountCompleteSubstrings(freq, k))
                        count++;
                    freq[s[i] - 'a']--;
                }
            }
            return count;
        }

        private bool checked_CountCompleteSubstrings(int[] freq, int k)
        {
            foreach (int count in freq)
            {
                if (count != k && count != 0)
                    return false;
            }
            return true;
        }