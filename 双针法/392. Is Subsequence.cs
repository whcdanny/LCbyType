//Leetcode 392. Is Subsequence ez
//题意：描述了判断字符串 s 是否是字符串 t 的子序列的问题。给定两个字符串 s 和 t，如果 s 是 t 的子序列，则返回 true，否则返回 false。
//字符串的子序列是通过删除一些（可以是零个）字符而不改变其余字符的相对位置形成的新字符串。例如，"ace" 是 "abcde" 的子序列，而 "aec" 不是。
//思路：双指针，两个指针 i 和 j 分别指向字符串 s 和 t。
//在循环中，如果 s[i] 等于 t[j]，说明匹配到一个字符，将 i 移动到下一个位置。
//无论是否匹配，都将 j 移动到下一个位置。
//循环直到遍历完整个字符串 t 或者 s 的指针移动到末尾。
//返回判断 i 是否移动到 s 的末尾。
//时间复杂度：O(n)，其中 n 是字符串 t 的长度
//空间复杂度：O(1)
        public bool IsSubsequence(string s, string t)
        {
            int i = 0; // 指向字符串 s 的指针
            int j = 0; // 指向字符串 t 的指针

            while (i < s.Length && j < t.Length)
            {
                if (s[i] == t[j])
                {
                    i++; // 匹配到一个字符，移动 s 的指针
                }
                j++; // 移动 t 的指针
            }

            return i == s.Length; // 如果 s 的指针移动到末尾，说明 s 是 t 的子序列
        }