//Leetcode 522. Longest Uncommon Subsequence II med
//题意：给定一个字符串数组 strs，要求返回这些字符串中最长的不同子序列的长度。如果最长的不同子序列不存在，则返回 -1。
//一个不同的子序列是指一个字符串是另一个字符串的子序列，但不是其他字符串的子序列。也就是说，最长的不同子序列不会是其他字符串的子序列
//思路：双指针，将字符串数组 strs 按照长度降序排序。
//从最长的字符串开始，依次判断是否是其他字符串的子序列。
//如果当前字符串是其他字符串的子序列，则继续遍历下一个字符串。
//如果当前字符串不是其他字符串的子序列，则说明找到了最长的不同子序列，返回其长度。
//时间复杂度：对字符串数组进行排序的时间复杂度为 O(nlogn)，双指针法遍历一次数组的时间复杂度为 O(n^2)，总体时间复杂度为 O(n^2 + nlogn)
//空间复杂度：O(1)
        public int FindLUSlength(string[] strs)
        {
            Array.Sort(strs, (a, b) => b.Length.CompareTo(a.Length));

            for (int i = 0; i < strs.Length; i++)
            {
                bool isUncommon = true;

                for (int j = 0; j < strs.Length; j++)
                {
                    if (i != j && IsSubsequence_FindLUSlength(strs[j], strs[i]))
                    {
                        isUncommon = false;
                        break;
                    }
                }

                if (isUncommon)
                {
                    return strs[i].Length;
                }
            }

            return -1;
        }

        private bool IsSubsequence_FindLUSlength(string s, string t)
        {
            int i = 0, j = 0;

            while (i < s.Length && j < t.Length)
            {
                if (s[i] == t[j])
                {
                    j++;
                }
                i++;
            }

            return j == t.Length;
        }