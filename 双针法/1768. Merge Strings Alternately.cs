//Leetcode 1768. Merge Strings Alternately ez
//题意：给定两个字符串 word1 和 word2，通过交替顺序添加字母来合并字符串，从 word1 开始。如果一个字符串比另一个字符串长，将额外的字母追加到合并的字符串的末尾。
//要求返回合并后的字符串。
//思路：双指针法两个指针 i 和 j 分别指向 word1 和 word2 的开头。
//使用循环，交替取字符拼接到结果字符串中，直到其中一个字符串遍历完。
//如果有剩余字符，将剩余字符追加到结果字符串的末尾。
//时间复杂度：O(max(N, M))，其中 N 和 M 分别是 word1 和 word2 的长度
//空间复杂度：O(N+M)
        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder result = new StringBuilder();
            int i = 0, j = 0;

            while (i < word1.Length && j < word2.Length)
            {
                result.Append(word1[i++]);
                result.Append(word2[j++]);
            }

            while (i < word1.Length)
            {
                result.Append(word1[i++]);
            }

            while (j < word2.Length)
            {
                result.Append(word2[j++]);
            }

            return result.ToString();
        }