//Leetcode 72 Edit Distance med
//题意：给定两个单词 word1 和 word2，要求计算将 word1 转换成 word2 所需的最少操作次数。
//思路：深度优先搜索（DFS）: 两个字符相等，我们继续向后遍历。如果两个字符不相等，我们可以选择插入、删除或者替换操作，并返回三者中的最小值. 会超时
//时间复杂度:  n 是两个单词中较长的那个的长度，O(3^n)
//空间复杂度： m 和 n 分别是两个单词的长度, O(m + n)
        public int MinDistance(string word1, string word2)
        {
            return MinDistance_DFS(word1, word2, 0, 0);
        }

        private int MinDistance_DFS(string word1, string word2, int i, int j)
        {
            if (i == word1.Length) return word2.Length - j;
            if (j == word2.Length) return word1.Length - i;

            if (word1[i] == word2[j])
            {
                return MinDistance_DFS(word1, word2, i + 1, j + 1);
            }

            int insert = MinDistance_DFS(word1, word2, i, j + 1) + 1;
            int delete = MinDistance_DFS(word1, word2, i + 1, j) + 1;
            int replace = MinDistance_DFS(word1, word2, i + 1, j + 1) + 1;

            return Math.Min(Math.Min(insert, delete), replace);
        }
